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
    public partial class RealizaMatricula : Form
    {
        private MatriculaEstudianteBO log;
        private List<MatriculaEstudiante> lista;
        private string idPeriodo;
        private string estado;
        private DateTime fechaMatricula;
        private DateTime fechaPago;

        /// <summary>
        /// Método que imprime un errorProvider en el comboBox pasado por parámetro 
        /// y con el mensaje indicado en el parámetro
        /// </summary>
        /// <param name="text"> representa el comboBox al que se le dará foco para imprimir el mensaje</param>
        /// <param name="mensaje"> representa el mensaje que se desea imprimir </param>
        private void mensaje(ComboBox text, string mensaje)
        {
            errorProvider1.SetError(text, mensaje);
            text.Focus();
            return;
        }

        /// <summary>
        /// Asigna un ticket o id a las facturas que se registran según la cantidad de datos de la lista, 
        /// a cada id se le suma un dato más de los que hay en la lista
        /// </summary>
        private void asignarIdFactura()
        {
            //lista = log.getLista();
            string asiga = "F0";
            int ticket = lista.Count;
            txtIdFactura.Text = asiga + ticket.ToString();
        }

        /// <summary>
        /// Asigna un ticket o id a los comprobantes que se registran según la cantidad de datos de la lista, 
        /// a cada id se le suma un dato más de los que hay en la lista
        /// </summary>
        private void asignarComprobante()
        {  
            //lista = log.getLista();
            string asiga = "C0";
            int ticket = lista.Count;
            txtComprobante.Text = asiga + ticket.ToString();
        }

        /// <summary>
        /// Realiza validaciones en los comboBox's
        /// si todo está bien; manda los datos al método agregar del log
        /// </summary>
        private void aceptar()
        {
            if(idPeriodo != null)
            {
                errorProvider1.SetError(cmbPeriodo,"");
                if(estado != null)
                {
                    errorProvider1.SetError(cmbEstado, "");
                    fechaMatricula = dateTimeMatricula.Value.Date;
                    fechaPago = dateTimePago.Value.Date;
                    log.agregar(txtIdFactura.Text,txtIdPersona.Text,idPeriodo,fechaMatricula,estado,txtComprobante.Text,fechaPago);
                    log.crearArchivo();
                    this.Close();
                }
                else
                {
                    mensaje(cmbEstado, "Debe seleccionar un estado");
                }
            }
            else
            {
                mensaje(cmbPeriodo, "Debe seleccionar un periodo");
            }
        }

        public RealizaMatricula()
        {
            InitializeComponent();
            log = new MatriculaEstudianteBO();
            lista = new List<MatriculaEstudiante>();
            txtIdFactura.Enabled = false;
            txtIdPersona.Enabled = false;
            txtComprobante.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            idPeriodo = cmbPeriodo.Text;
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = cmbEstado.Text;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }
    }
}
