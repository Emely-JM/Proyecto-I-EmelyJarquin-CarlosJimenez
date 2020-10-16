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
        
        private AsignacionBO log;
        private List<Asignacion> lista;
        private MatriculaEstudianteBO logMatricula;
        private List<MatriculaEstudiante> listMatricula;
        private PersonaBO logPersona;
        private List<Persona> listaPersona;
        private RegistroNotaBO logNota;
        private List<RegistroNota> listaNota;
        private Form parent;

        /// <summary>
        /// Carga el combo con las materias del id del profesor pasado por parámetro
        /// </summary>
        /// <param name="id"></param>
        private void cargarComboIdMaterias()
        {
            lista = log.getLista();
            cmbMateria.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idProf.Equals(txtIdProf.Text))
                {
                    cmbMateria.Items.Add(lista[i].idMateria);
                    cmbMateria.SelectedIndex = 0;
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
        private void cargarEstudiantes(string idPeriodo)
        {
            listMatricula = logMatricula.getLista();
            listaPersona = logPersona.getLista();
            listaNota = logNota.getLista();
            cmbEstudiante.Text = "";
            cmbEstudiante.Items.Clear();
            for (int i = 0; i < listMatricula.Count; i++)
            {
                for (int x = 0; x < listaPersona.Count; x++)
                {
                    for (int c = 0; c < listaNota.Count; c++)
                    {
                        if (listMatricula[i].idProfesor.Equals(txtIdProf.Text) &&
                            listMatricula[i].idMateria.Equals(cmbMateria.Text) && 
                            listMatricula[i].estado.Equals("Matriculado"))
                        {
                            if (listaPersona[x].cedula.Equals(listMatricula[i].idPersona))
                            {
                                if (listaNota[c].idEstudiante.Equals(listaPersona[x].cedula) && listaNota[c].idPeriodo.Equals(idPeriodo))
                                {
                                    cmbEstudiante.Items.Add(listaPersona[x].nombre + " " + listaPersona[x].apellido1 + " " + listaPersona[x].apellido2 + "-" + listaNota[c].estado + "(" + listaNota[c].nota + ")");
                                    cmbEstudiante.SelectedIndex = 0;

                                }
                            }
                        }
                    }
                }
            }
        }

        public ListaEstudiante(Form parent,string id)
        {
            InitializeComponent();
            this.parent = parent;
            lista = new List<Asignacion>();
            log = new AsignacionBO();
            logMatricula = new MatriculaEstudianteBO();
            logPersona = new PersonaBO();
            listMatricula = new List<MatriculaEstudiante>();
            listaPersona = new List<Persona>();
            logNota = new RegistroNotaBO();
            listaNota = new List<RegistroNota>();
            txtIdProf.Text = id;
            cargarComboIdMaterias();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCuatrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEstudiantes(cmbCuatrimestre.Text);
        }

        private void ListaEstudiante_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
