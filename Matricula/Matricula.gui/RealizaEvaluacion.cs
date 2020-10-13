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
    public partial class RealizaEvaluacion : Form
    {

        private EvaluacionBO log;
        private List<Evaluacion> lista;
        private MatriculaEstudianteBO logMatricula;
        private List<MatriculaEstudiante> listaMatricula;

        /// <summary>
        /// Carga el combo con las materias en las que está matriculado el estudiante
        /// </summary>
        private void cargarMaterias()
        {
            listaMatricula = logMatricula.getLista();
            cmbMateria.Items.Clear();
            for (int i = 0; i < listaMatricula.Count; i++)
            {
                if (listaMatricula[i].idPersona.Equals(txtIdEstudiante.Text) && listaMatricula[i].estado.Equals("Matriculado"))
                {
                    cmbMateria.Items.Add(listaMatricula[i].idMateria);
                    cmbMateria.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Cuenta la cantidad de datos en la lista y asigan la cantidad + 1 contatenado
        /// a E0 al id de la evalución
        /// </summary>
        private void asignarIdEvaluacion()
        {
            lista = log.getLista();
            string asiga = "E0";
            int ticket = lista.Count + 1;
            txtIdEvaluacion.Text = asiga + ticket.ToString();
        }

        /// <summary>
        /// Manda a la lista los datos ingresados y luego escribe los datos de la lista en 
        /// el archivo.
        /// </summary>
        private void aceptar()
        {
            errorProvider1.SetError(cmbMateria, "");
            if (txtDescripcion.Text != "")
            {
                errorProvider1.SetError(txtDescripcion, "");
                if (log.permiteEvalucion(txtIdEstudiante.Text, cmbMateria.Text) != -1)
                {
                    errorProvider1.SetError(cmbMateria, "Ya realizó la evaluación de esta materia");
                    cmbMateria.Focus();
                    return;
                }
                else
                {
                    DateTime fecha = dateTimeEvaluacion.Value.Date;
                    log.agregar(txtIdEvaluacion.Text, txtDescripcion.Text, txtIdEstudiante.Text, cmbMateria.Text, txtEstado.Text, fecha);
                    log.crearArchivo();
                    MessageBox.Show("Evaluación registrada","Evaluaciones",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }

            }
            else
            {
                errorProvider1.SetError(txtDescripcion, "Descripción es requerdia");
                txtDescripcion.Focus();
                return;
            }

        }

        /// <summary>
        /// Verifica si en la lista ya se realizó la evaluación del curso.
        /// </summary>
        private void asignarEstado()
        {
            if (log.permiteEvalucion(txtIdEstudiante.Text, cmbMateria.Text) != -1)
            {
                txtEstado.Text = "Aplicada";
            }
            else
            {
                txtEstado.Text = "Pendiente";
            }
        }


        /// <summary>
        /// Inicia los datos en el constructor
        /// </summary>
        private void inicio()
        {
            asignarIdEvaluacion();
            cargarMaterias();
            txtIdEvaluacion.Enabled = false;
            txtIdEstudiante.Enabled = false;
            txtEstado.Enabled = false;
            dateTimeEvaluacion.Enabled = false;
        }

        public RealizaEvaluacion(string idEstudiante)
        {
            InitializeComponent();
            log = new EvaluacionBO();
            lista = new List<Evaluacion>();
            logMatricula = new MatriculaEstudianteBO();
            listaMatricula = new List<MatriculaEstudiante>();
            txtIdEstudiante.Text = idEstudiante;
            inicio();
            asignarEstado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }
    }
}
