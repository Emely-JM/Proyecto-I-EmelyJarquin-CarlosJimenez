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
        private double sumaMaterias = 0;
        private double costo = 0;
        private MateriaBO logMateria;
        private List<Materias> listaMateria;
        private MatriculaEstudianteBO logMatricula;
        private List<MatriculaEstudiante> listaMatricula;
        private ValidaDatos validar;
        private Form parent;

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
            double sumaSinIva = 0;
            double sumaConIva = 0;
            sumaSinIva = sumaMaterias + costo;
            sumaConIva = (sumaSinIva * 0.13) / 100;
            total = sumaSinIva+sumaConIva;
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

                    if (!cmbMaterias.Text.Equals(""))
                    {
                        errorProvider1.SetError(txtTarjeta, "");
                        logMatricula.pagoRealizado(txtIdEstudiante.Text, fechaActual);
                        logMatricula.crearArchivo();
                        MessageBox.Show("Transacción exitosa", "Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        errorProvider1.SetError(cmbMaterias, "No hay materias pendientes de pago");
                        cmbMaterias.Focus();
                        return;
                    }
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

        public Pago(Form parent,string u)
        {
            InitializeComponent();
            this.parent = parent;
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

        private void Pago_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
