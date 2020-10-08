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
    public partial class ListaEstudiante : Form
    {
        private string idP;
        private AsignacionBO log;
        private List<Asignacion> lista;
        private MatriculaEstudianteBO logE;
        private List<MatriculaEstudiante> listaE;
        private PersonaBO logP;
        private List<Persona> listaP;

        /// <summary>
        /// Carga el combo con las materias del id del profesor pasado por parámetro
        /// </summary>
        /// <param name="id"></param>
        private void cargarComboIdMaterias(string id)
        {
            lista = log.getLista();
            cmbMateria.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idProf.Equals(id))
                {
                    cmbMateria.Items.Add(lista[i].idMateria);
                }
            }
        }

        /// <summary>
        /// Busca el id de la materia en la lista perteneciente a 
        /// los estudiantes y buscar el id de la persona ligada a la materia
        /// en la lista perteneciente a las personas y carga sus datos de nombre y apellidos
        /// en el combo
        /// </summary>
        /// <param name="idMateria"> id de la materia a buscar</param>
        private void cargarEstudiantes(string idMateria)
        {
            listaE = logE.getLista();
            listaP = logP.getLista();
            cmbEstudiante.Items.Clear();
            for (int i = 0; i < listaE.Count; i++)
            {
                if (listaE[i].idProfesor.Equals(idP) && listaE[i].idMateria.Equals(idMateria))
                {
                    for (int x = 0; x < listaP.Count; x++)
                    {
                        if (listaP[i].idPersona.Equals(listaE[i].idPersona)){
                            cmbMateria.Items.Add(listaP[i].nombre + " " + listaP[i].apellido1 + " " + listaP[i].apellido2);
                        }
                    }
                }
            }
        }

        public ListaEstudiante(string id)
        {
            InitializeComponent();
            lista = new List<Asignacion>();
            log = new AsignacionBO();
            logE = new MatriculaEstudianteBO();
            logP = new PersonaBO();
            listaE = new List<MatriculaEstudiante>();
            listaP = new List<Persona>();
            idP = id;
            cargarComboIdMaterias(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEstudiantes(cmbMateria.Text);
        }
    }
}
