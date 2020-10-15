using Matricula.bo;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matricula.gui
{
    public partial class Pago : Form
    {
        double sumaMaterias = 0;
        double costo = 0;
        MateriaBO logMateria;
        List<Materias> listaMateria;
        MatriculaEstudianteBO logMatricula;
        List<MatriculaEstudiante> listaMatricula;
        ValidaDatos validar;

        /// <summary>
        /// Carga las materias ligadas al id del usuario pasado en el contructor
        /// siempre que se encuentren en prematricula
        /// </summary>
        private void cargarCombo(string id)
        {
            listaMatricula = logMatricula.getLista();
            listaMateria = logMateria.getLista();

            cmbMaterias.Items.Clear();
            for (int i = 0; i < listaMatricula.Count; i++)
            {
                for (int x = 0; x < listaMateria.Count; x++)
                {
                    if (listaMatricula[i].idPersona.Equals(id) && listaMatricula[i].estado.Equals("Prematricula"))
                    {

                        if (listaMateria[x].idMateria.Equals(listaMatricula[i].idMateria))
                        {
                            sumaMaterias += listaMateria[x].precio;
                            costo += listaMateria[x].costo;
                            cmbMaterias.Items.Add(listaMatricula[i].idMateria + " - " + listaMateria[x].nombre);
                            cmbMaterias.SelectedIndex = 0;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Suma el costo de las materias y costos adicionales de cada uno
        /// y le agrega el iva del 13%
        /// </summary>
        /// <returns> total ha pagar </returns>
        private double totalPagar()
        {
            double total = 0;
            double subTotal = sumaMaterias + costo;
            total = subTotal + (subTotal * 0.13);
            return total;
        }

        /// <summary>
        /// Válida el cambo de la tarjeta
        /// </summary>
        private void aceptar()
        {
            DateTime fechaActual = DateTime.Now;
            if (!txtTarjeta.Text.Equals(""))
            {
                errorProvider1.SetError(txtTarjeta, "");
                if (txtTarjeta.Text.Length == 4)
                {
                    errorProvider1.SetError(txtTarjeta, "");
                    logMatricula.pagoRealizado(txtIdEstudiante.Text, fechaActual);
                    logMatricula.crearArchivo();
                    MessageBox.Show("Transacción exitosa", "Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                errorProvider1.SetError(txtTarjeta, "Debe ingresar solamente los últimos cuatro digitos de la tarjeta");
                txtTarjeta.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtTarjeta, "Debe ingresar el número de tarjeta");
                txtTarjeta.Focus();
                return;
            }
        }

        public Pago(string u)
        {
            InitializeComponent();
            validar = new ValidaDatos();
            logMateria = new MateriaBO();
            listaMateria = new List<Materias>();
            logMatricula = new MatriculaEstudianteBO();
            listaMatricula = new List<MatriculaEstudiante>();
            cargarCombo(u);
            txtIdEstudiante.Text = u;
            txtCostoMateria.Text = sumaMaterias.ToString();
            txtCostosAsociados.Text = costo.ToString();
            txtTotal.Text = totalPagar().ToString();
            txtIVA.Text = "0.13";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }
    }
}
