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
        private PersonaBO logP;
        private List<Persona> listaP;
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
        /// Carga el combo del profesor con los datos del id y nombre completo
        /// </summary>
        private void cargarComboProf()
        {
            listaA = logA.getLista();
            listaP = logP.getLista();
            cmbProfe.Items.Clear();
            for (int i = 0; i < listaA.Count; i++)
            {
                cmbProfe.Items.Add(listaA[i].idProf);
                cmbProfe.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Carga las meterias asignadas a un profesor seleccionado
        /// </summary>
        /// <param name="idProfesor"> id del profesor a buscar </param>
        private void cargarComboMateria(string idProfesor)
        {
            listaA = logA.getLista();
            cmbMateria.Items.Clear();
            for (int i = 0; i < listaA.Count; i++)
            {
                if (listaA[i].idProf.Equals(idProfesor))
                {
                    cmbMateria.Items.Add(listaA[i].idMateria);
                }
            }
        }

        /// <summary>
        /// Carga el nombre del profesor según el id del combo seleccionado
        /// </summary>
        /// <param name="id"> id a buscar </param>
        private void cargarNombreProf(string id)
        {
            listaA = logA.getLista();
            listaP = logP.getLista();
            txtProfesor.Clear();
            for (int x = 0; x < listaP.Count; x++)
            {
                if (listaP[x].cedula.Equals(id))
                {
                    txtProfesor.Text = listaP[x].nombre + " " + listaP[x].apellido1 + " " + listaP[x].apellido2;
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
                if (cmbMateria.Text.Equals(""))
                {
                    errorProvider1.SetError(cmbMateria, "Debe seleccionar una materia para matricular");
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
        }

        public RealizaMatricula(string idPersona)
        {
            InitializeComponent();
            log = new MatriculaEstudianteBO();
            lista = new List<MatriculaEstudiante>();
            logA = new AsignacionBO();
            listaA = new List<Asignacion>();
            logP = new PersonaBO();
            listaP = new List<Persona>();
            txtIdFactura.Enabled = false;
            txtIdPersona.Enabled = false;
            txtComprobante.Enabled = false;
            txtProfesor.Enabled = false;
            txtIdPersona.Text = idPersona;
            asignarIdFactura();
            asignarComprobante();
            cargarComboProf();
            cmbPeriodo.SelectedIndex = 0;

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
            cargarComboMateria(cmbProfe.Text);
            cargarNombreProf(cmbProfe.Text);
        }
    }
}
