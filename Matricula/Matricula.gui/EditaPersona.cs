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
    public partial class EditaPersona : Form
    {

        private PersonaBO log;
        private List<Persona> lista;
        private ValidaDatos validar;
        private DateTime FechaNac;
        private DateTime FechaIngreso;
        private int cedula;
        private Form parent;

        /// <summary>
        /// Método que imprime un errorProvider en el textBox pasado por parámetro 
        /// y con el mensaje indicado en el parámetro
        /// </summary>
        /// <param name="text"> representa el textBox al que se le dará foco para imprimir el mensaje</param>
        /// <param name="mensaje"> representa el mensaje que se desea imprimir </param>
        private void mensaje(TextBox text, string mensaje)
        {
            errorProvider1.SetError(text, mensaje);
            text.Focus();
            return;
        }

        /// <summary>
        /// Asigna un ticket o id a las personas que se registran según la cantidad de datos de la lista, 
        /// a cada id se le suma un dato más de los que hay en la lista
        /// </summary>
        private void asignarId()
        {
            lista = log.getLista();
            string asiga = "P0";
            int ticket = lista.Count + 1;
            txtIdPersona.Text = asiga + ticket.ToString();
        }

        /// <summary>
        /// Realiza validaciones para que los textos sean llenados de manera correcta.
        /// </summary>
        private void aceptar()
        {
            if (log.BuscarId(txtIdPersona.Text) != false)
            {
                FechaNac = dateTimeNacimiento.Value.Date;
                FechaIngreso = dateTimeIngreso.Value.Date;
                log.modificar(txtIdPersona.Text, txtCedula.Text, txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text,
                             char.Parse(cmbSexo.Text), FechaNac, cmbNivelAcademico.Text, FechaIngreso, txtUsuarioRegistro.Text, cmbTipoPersona.Text, cmbNacionalidad.Text, chkEstado.Checked);
                log.crearArchivo();
                this.Close();
            }
            else
            {
                if (txtCedula.Text != "")
                {
                    errorProvider1.SetError(txtCedula, "");

                    if (log.buscarCedula(txtCedula.Text) != -1)
                    {
                        mensaje(txtCedula, "Ya hay una persona registrada con esta cédula");
                    }

                    else
                    {
                        errorProvider1.SetError(txtCedula, "");
                        if (txtNombre.Text != "")
                        {
                            errorProvider1.SetError(txtNombre, "");
                            if (txtPrimerApellido.Text != "")
                            {
                                errorProvider1.SetError(txtPrimerApellido, "");
                                if (txtSegundoApellido.Text != "")
                                {
                                    errorProvider1.SetError(txtSegundoApellido, "");
                                    FechaNac = dateTimeNacimiento.Value.Date;
                                    FechaIngreso = dateTimeIngreso.Value.Date;
                                    log.agregar(txtIdPersona.Text, txtCedula.Text, txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text,
                                        char.Parse(cmbSexo.Text), FechaNac, cmbNivelAcademico.Text, FechaIngreso, txtUsuarioRegistro.Text, cmbTipoPersona.Text, cmbNacionalidad.Text, chkEstado.Checked);
                                    log.crearArchivo();
                                    this.Close();
                                }
                                else
                                {
                                    mensaje(txtSegundoApellido, "Segundo apellido es requerido");
                                }
                            }
                            else
                            {
                                mensaje(txtPrimerApellido, "Primer apellido es requerido");
                            }
                        }
                        else
                        {
                            mensaje(txtNombre, "Nombre es requerido");
                        }
                    }
                }
                else
                {
                    mensaje(txtCedula, "Cédula es requerida");
                }
            }
        }

        /// <summary>
        /// LLena los campos de texto según el id encontrado 
        /// para editar los datos
        /// </summary>
        /// <param name="idBuscar"> id de persona a buscar </param>
        private void llenarEdita(string idBuscar)
        {
            lista = log.getLista();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idPersona.Equals(idBuscar))
                {
                    txtIdPersona.Text = lista[i].idPersona;
                    txtCedula.Text = lista[i].cedula.ToString();
                    txtNombre.Text = lista[i].nombre;
                    txtPrimerApellido.Text = lista[i].apellido1;
                    txtSegundoApellido.Text = lista[i].apellido2;
                    cmbSexo.Text = lista[i].sexo.ToString();
                    dateTimeNacimiento.Text = lista[i].fechaNacimiento.ToString();
                    cmbNivelAcademico.Text = lista[i].nivelAcademico;
                    dateTimeIngreso.Text = lista[i].fechaIngreso.ToString();
                    txtUsuarioRegistro.Text = lista[i].usuarioRegistro;
                    cmbTipoPersona.Text = lista[i].tipoPersona;
                    cmbNacionalidad.Text = lista[i].nacionalidad;
                    chkEstado.Checked = lista[i].estado;
                }
            }
        }

        public EditaPersona(Form parent, string u)
        {
            InitializeComponent();
            this.parent = parent;
            txtUsuarioRegistro.Text = u;
            lblTitulo.Text = "Persona - Agregar";
            log = new PersonaBO();
            validar = new ValidaDatos();
            lista = new List<Persona>();
            cmbTipoPersona.SelectedIndex = 0;
            cmbSexo.SelectedIndex = 0;
            cmbNivelAcademico.SelectedIndex = 0;
            cmbNacionalidad.SelectedIndex = 0;
            txtIdPersona.Enabled = false;
            txtUsuarioRegistro.Enabled = false;
            chkEstado.Visible = false;
            chkEstado.Checked = true;
            asignarId();
        }

        public EditaPersona(Form parent,string u, string idB)
        {
            InitializeComponent();
            this.parent = parent;
            lblTitulo.Text = "Persona - Editar";
            log = new PersonaBO();
            validar = new ValidaDatos();
            lista = new List<Persona>();
            txtIdPersona.Enabled = false;
            txtUsuarioRegistro.Enabled = false;
            chkEstado.Visible = true;
            llenarEdita(idB);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloLetras(e);
        }

        private void txtPrimerApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloLetras(e);
        }

        private void txtSegundoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloLetras(e);
        }

        private void EditaPersona_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
