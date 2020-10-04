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

        private string idMateria;
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
                if(listaMatricula[i].idPersona.Equals(txtIdEstudiante.Text))
                cmbMateria.Items.Add(listaMatricula[i].idMateria);
            }
        }


        /// <summary>
        /// Manda a la lista los datos ingresados y luego escribe los datos de la lista en 
        /// el archivo.
        /// </summary>
        private void aceptar()
        {
            if (cmbMateria != null)
            {
                errorProvider1.SetError(cmbMateria, "");
                if (txtDescripcion.Text != "")
                {
                    errorProvider1.SetError(txtDescripcion, "");
                    if (log.permiteEvalucion(txtIdEstudiante.Text, idMateria) != -1)
                    {
                        errorProvider1.SetError(cmbMateria, "Ya realizó la evaluación de esta materia");
                        cmbMateria.Focus();
                        return;
                    }
                    else
                    {
                        DateTime fecha = dateTimeEvaluacion.Value.Date;
                        log.agregar(txtIdEvaluacion.Text,txtDescripcion.Text,txtIdEstudiante.Text,idMateria,txtEstado.Text,fecha);
                        log.crearArchivo();
                    }

                }
                else
                {
                    errorProvider1.SetError(txtDescripcion, "Descripción es requerdia");
                    txtDescripcion.Focus();
                    return;
                }
            }
            else
            {
                errorProvider1.SetError(cmbMateria, "Debe seleccionar una materia para evaluar");
                cmbMateria.Focus();
                return;
            }
        }


        public RealizaEvaluacion(string idEstudiante)
        {
            InitializeComponent();
            log = new EvaluacionBO();
            lista = new List<Evaluacion>();
            logMatricula = new MatriculaEstudianteBO();
            listaMatricula = new List<MatriculaEstudiante>();
            txtIdEstudiante.Text = idEstudiante;
            cargarMaterias();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMateria = cmbMateria.Text;
        }
    }
}
