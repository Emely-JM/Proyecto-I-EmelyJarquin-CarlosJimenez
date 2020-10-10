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
        ///  Método que imprime un errorProvider en el combo pasado por parámetro 
        /// y con el mensaje indicado en el parámetro
        /// </summary>
        /// <param name="text">representa el textBox al que se le dará foco para imprimir el mensaje</param>
        /// <param name="mensaje">representa el mensaje que se desea imprimir</param>
        private void mensajeCombo(ComboBox text, string mensaje)
        {
            errorProvider1.SetError(text, mensaje);
            text.Focus();
            return;
        }

        /// <summary>
        /// Llena el combo con el id de los usuarios que sean de tipo profesor
        /// </summary>
        private void llenarComboProfesor()
        {
            listaU = logU.getLista();
            cmbProfesor.Items.Clear();
            for (int i = 0; i < listaU.Count; i++)
            {
                if (listaU[i].tipoPersona.Equals("Profesor") && listaU[i].estado.Equals("Activo"))
                {
                    cmbProfesor.Items.Add(listaU[i].cedula);
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
            }
        }

        /// <summary>
        /// Selecciona los datos de los combos según el id
        /// </summary>
        private void buscar(int id)
        {
            for(int i = 0; i < lista.Count; i++)
            {
                if(lista[i].id == id)
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
            int ticket = lista.Count;
            txtId.Text = asigna.ToString() + ticket;
        }

        /// <summary>
        /// Válida que se seleccionen datos de los combos y los manda a guardar 
        /// y crear el archivo.
        /// </summary>
        private void aceptar()
        {
            if(idProfesor != null)
            {
                errorProvider1.SetError(cmbProfesor,"");
                if(idMateria != null)
                {
                    errorProvider1.SetError(cmbMateria,"");
                    log.agregar(int.Parse(txtId.Text),idProfesor,idMateria);
                    log.crearArchivo();
                    this.Close();
                }
                else
                {
                    mensajeCombo(cmbMateria,"Debe seleccionar el id de una materia");
                }
            }
            else
            {
                mensajeCombo(cmbProfesor, "Debe seleccionar el id de un profesor");
            }
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

        private void cmbProfesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            idProfesor = cmbProfesor.Text;
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMateria = cmbMateria.Text;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }
    }
}
