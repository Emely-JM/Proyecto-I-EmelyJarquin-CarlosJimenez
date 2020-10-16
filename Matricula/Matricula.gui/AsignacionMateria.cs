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
        private AsignacionBO log;
        private List<Asignacion> lista;
        private PersonaBO logU;
        private List<Persona> listaU;
        private MateriaBO logM;
        private List<Materias> listaM;
        private Form parent;

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
                if(listaM[i].estado == true)
                {
                    cmbMateria.Items.Add(listaM[i].idMateria);
                    cmbMateria.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Selecciona los datos de los combos según el id
        /// </summary>
        private int buscar(int id)
        {
            lista = log.getLista();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].id == id)
                {
                    txtId.Text = lista[i].id.ToString();
                    cmbProfesor.Text = lista[i].idProf;
                    cmbMateria.Text = lista[i].idMateria;
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Asigna un id según la cantidad de datos de la lista
        /// </summary>
        private void asignarID()
        {
            lista = log.getLista();
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
            if (log.BuscarId(int.Parse(txtId.Text)) != false)
            {
                log.modificar(int.Parse(txtId.Text), cmbProfesor.Text, cmbMateria.Text);
            }
            else
            {
                if (log.permitirAsignacion(cmbProfesor.Text, cmbMateria.Text) != -1)
                {
                    errorProvider1.SetError(cmbMateria, "Esta matería ya ha sido asignada al profesor indicado");
                    cmbMateria.Focus();
                    return;
                }
                else
                {
                    log.agregar(int.Parse(txtId.Text), cmbProfesor.Text, cmbMateria.Text);
                }
            }
            log.crearArchivo();
            this.Close();

        }

        /// <summary>
        /// Carga el nombre del profesor según el id seleccionado del combo
        /// </summary>
        /// <param name="id"> id del profesor a buscar </param>
        private void cargarNombreProf(string id)
        {
            listaU = logU.getLista();
            txtNombreProf.Clear();
            for (int x = 0; x < listaU.Count; x++)
            {
                if (listaU[x].cedula.Equals(id))
                {
                    txtNombreProf.Text = listaU[x].nombre + " " + listaU[x].apellido1 + " " + listaU[x].apellido2;
                }
            }
        }

        public AsignacionMateria(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
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

        public AsignacionMateria(Form parent, int idP)
        {
            InitializeComponent();
            this.parent = parent;
            txtId.Enabled = false;
            log = new AsignacionBO();
            logU = new PersonaBO();
            logM = new MateriaBO();
            lista = new List<Asignacion>();
            listaU = new List<Persona>();
            listaM = new List<Materias>();
            llenarComboProfesor();
            llenarComboMateria();
            buscar(idP);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void cmbProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarNombreProf(cmbProfesor.Text);
        }

        private void AsignacionMateria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
