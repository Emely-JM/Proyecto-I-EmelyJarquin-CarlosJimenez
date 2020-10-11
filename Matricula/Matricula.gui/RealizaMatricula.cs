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
        private AsignacionBO logA;
        private List<Asignacion> listaA;
        private string estado = "Prematricula";
        private DateTime fechaMatricula;

        /// <summary>
        /// Asigna un ticket o id a las facturas que se registran según la cantidad de datos de la lista, 
        /// a cada id se le suma un dato más de los que hay en la lista
        /// </summary>
        private void asignarIdFactura()
        {
            lista = log.getLista();
            string asiga = "F0";
            int ticket = lista.Count + 1;
            txtIdFactura.Text = asiga + ticket.ToString();
        }

        /// <summary>
        /// Asigna un ticket o id a los comprobantes que se registran según la cantidad de datos de la lista, 
        /// a cada id se le suma un dato más de los que hay en la lista
        /// </summary>
        private void asignarComprobante()
        {
            lista = log.getLista();
            string asiga = "C0";
            int ticket = lista.Count + 1;
            txtComprobante.Text = asiga + ticket.ToString();
        }

        /// <summary>
        /// Carga los combos de id de materia y profesores
        /// según el id del profesor
        /// </summary>
        /// <param name="idProf"></param>
        private void cargarComboProfYMat(string idProf)
        {
            listaA = logA.getLista();
            cmbProfe.Items.Clear();
            cmbMateria.Items.Clear();
            for (int i = 0; i < listaA.Count; i++)
            {
                if (listaA[i].idProf.Equals(idProf))
                {
                    cmbProfe.Items.Add(listaA[i].idProf);
                    cmbMateria.Items.Add(listaA[i].idMateria);
                }
            }

        }

        /// <summary>
        /// Realiza validaciones en los comboBox's
        /// si todo está bien; manda los datos al método agregar del log
        /// </summary>
        private void aceptar()
        {
            if (log.permitirMatricula(txtIdPersona.Text, cmbMateria.Text) != -1)
            {
                errorProvider1.SetError(cmbMateria, "Ya se encuentra matriculado en este curso");
                cmbMateria.Focus();
                return;
            }
            else
            {
                DateTime fechaPago = DateTime.Now;
                fechaMatricula = dateTimeMatricula.Value.Date;
                log.agregar(txtIdFactura.Text, txtIdPersona.Text, cmbPeriodo.Text, fechaMatricula, cmbMateria.Text, cmbProfe.Text, estado, txtComprobante.Text, fechaPago);
                log.crearArchivo();
                this.Close();
            }
        }

        public RealizaMatricula(string idPersona)
        {
            InitializeComponent();
            log = new MatriculaEstudianteBO();
            lista = new List<MatriculaEstudiante>();
            logA = new AsignacionBO();
            listaA = new List<Asignacion>();
            txtIdFactura.Enabled = false;
            txtIdPersona.Enabled = false;
            txtComprobante.Enabled = false;
            txtIdPersona.Text = idPersona;
            asignarIdFactura();
            asignarComprobante();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void cmbProfe_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboProfYMat(cmbProfe.Text);
        }
    }
}
