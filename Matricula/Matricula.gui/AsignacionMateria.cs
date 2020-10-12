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
    public partial class AsignacionMateria : Form
    {
        private int id;
        private string idProfesor;
        private string idMateria;
        private AsignacionBO log;
        private List<Asignacion> lista;
        private PersonaBO logU;
        private List<Persona> listaU;
        private MateriaBO logM;
        private List<Materias> listaM;


        /// <summary>
        /// Llena el combo con el id de los usuarios que sean de tipo profesor
        /// </summary>
        private void llenarComboProfesor()
        {
            listaU = logU.getLista();
            cmbProfesor.Items.Clear();
            for (int i = 0; i < listaU.Count; i++)
            {
                if (listaU[i].tipoPersona.Equals("Profesor") && listaU[i].estado == true)
                {
                    cmbProfesor.Items.Add(listaU[i].cedula);
                    cmbProfesor.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Llena el combo de las materias con el id de las materias registradas
        /// </summary>
        private void llenarComboMateria()
        {
            listaM = logM.getLista();
            cmbMateria.Items.Clear();
            for (int i = 0; i < listaM.Count; i++)
            {
                cmbMateria.Items.Add(listaM[i].idMateria);
                cmbMateria.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Selecciona los datos de los combos según el id
        /// </summary>
        private void buscar(int id)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].id == id)
                {
                    cmbProfesor.Text = lista[i].idProf;
                    cmbMateria.Text = lista[i].idMateria;
                }
            }
        }

        /// <summary>
        /// Asigna un id según la cantidad de datos de la lista
        /// </summary>
        private void asignarID()
        {
            int asigna = 0;
            int ticket = lista.Count + 1;
            txtId.Text = asigna.ToString() + ticket;
        }

        /// <summary>
        /// Válida que se seleccionen datos de los combos y los manda a guardar 
        /// y crear el archivo.
        /// </summary>
        private void aceptar()
        {
            log.agregar(int.Parse(txtId.Text), cmbProfesor.Text, cmbMateria.Text);
            log.crearArchivo();
            this.Close();
        }

        public AsignacionMateria()
        {
            InitializeComponent();
            txtId.Enabled = false;
            log = new AsignacionBO();
            logU = new PersonaBO();
            logM = new MateriaBO();
            lista = new List<Asignacion>();
            listaU = new List<Persona>();
            listaM = new List<Materias>();
            llenarComboProfesor();
            llenarComboMateria();
            asignarID();
        }

        public AsignacionMateria(int idP)
        {
            InitializeComponent();
            txtId.Enabled = false;
            log = new AsignacionBO();
            logU = new PersonaBO();
            logM = new MateriaBO();
            lista = new List<Asignacion>();
            listaU = new List<Persona>();
            listaM = new List<Materias>();
            llenarComboProfesor();
            llenarComboMateria();
            id = idP;
            buscar(id);

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
