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
        private string idEstudiante;
        double sumaMaterias = 0;
        double costo = 0;
        MateriaBO logM;
        List<Materias> listaM;
        MatriculaEstudianteBO logMat;
        List<MatriculaEstudiante> listaMat;
        ValidaDatos validar;

        /// <summary>
        /// Carga las materias ligadas al id del usuario pasado en el contructor
        /// siempre que se encuentren en prematricula
        /// </summary>
        private void cargarCombo()
        {
            listaMat = logMat.getLista();
            listaM = logM.getLista();
            cmbMaterias.Items.Clear();
            for (int i = 0; i < listaMat.Count; i++)
            {
                if (listaMat[i].idPersona.Equals(idEstudiante) && listaMat[i].estado.Equals("Prematricula"))
                {
                    for (int x = 0; x < listaM.Count; x++)
                    {
                        if (listaM[i].idMateria.Equals(listaMat[i].idMateria))
                        {
                            sumaMaterias += listaM[i].precio;
                            costo += listaM[i].costo;
                            cmbMaterias.Items.Add(listaMat[i].idMateria + " " + listaM[i].nombre);
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
            if (!txtTarjeta.Text.Equals(""))
            {
                errorProvider1.SetError(txtTarjeta, "");
                if (txtTarjeta.Text.Length == 4)
                {
                    errorProvider1.SetError(txtTarjeta, "");
                    logMat.pagoRealizado(idEstudiante);
                    logMat.crearArchivo();
                    this.Close();
                }
                errorProvider1.SetError(txtTarjeta, "Debe ingresar solamente los últimos cuatro digitos de la tarjeta");
                txtTarjeta.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(txtTarjeta,"Debe ingresar el número de tarjeta");
                txtTarjeta.Focus();
                return;
            }
        }

        public Pago(string u)
        {
            InitializeComponent();
            idEstudiante = u;
            validar = new ValidaDatos();
            logM = new MateriaBO();
            listaM = new List<Materias>();
            logMat = new MatriculaEstudianteBO();
            listaMat = new List<MatriculaEstudiante>();
            cargarCombo();
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
