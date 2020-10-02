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
        List<Persona> lista;
        
        private ValidaDatos validar;
        private char sexo;
        private string nivelAcademico;
        private string tipoPersona;
        private string nacionalidad;
        private string estado;
        private DateTime FechaNac;
        private DateTime FechaIngreso;
        private int cedula;

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
            //lista = log.getLista();
            string asiga = "C0";
            int ticket = lista.Count;
            txtIdPersona.Text = asiga + ticket.ToString();
        }

        /// <summary>
        /// Realiza validaciones para que los textos sean llenados de manera correcta.
        /// </summary>
        private void aceptar()
        {

            if (buscar(int.Parse(txtCedula.Text)) != false)
            {
                FechaNac = dateTimeNacimiento.Value.Date;
                FechaIngreso = dateTimeIngreso.Value.Date;
                cedula = int.Parse(txtCedula.Text);
                log.modificar(txtIdPersona.Text, txtIdPersona.Text, cedula, txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text,
                              sexo, FechaNac, nivelAcademico, FechaIngreso, txtUsuarioRegistro.Text, tipoPersona, nacionalidad, estado);
                log.crearArchivo();
                this.Close();
            }
            else
            {
                if (txtCedula.Text != "")
                {
                    errorProvider1.SetError(txtCedula, "");

                    if (log.buscarCedula(int.Parse(txtCedula.Text)) != -1)
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
                                    if (sexo != null)
                                    {
                                        errorProvider1.SetError(cmbSexo, "");
                                        if (nivelAcademico != null)
                                        {
                                            errorProvider1.SetError(cmbNivelAcademico, "");
                                            if (tipoPersona != null)
                                            {
                                                errorProvider1.SetError(cmbTipoPersona, "");
                                                if (estado != null)
                                                {
                                                    errorProvider1.SetError(cmbEstado, "");
                                                    FechaNac = dateTimeNacimiento.Value.Date;
                                                    FechaIngreso = dateTimeIngreso.Value.Date;
                                                    cedula = int.Parse(txtCedula.Text);

                                                    log.agregar(txtIdPersona.Text, cedula, txtNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text,
                                                        sexo, FechaNac, nivelAcademico, FechaIngreso, txtUsuarioRegistro.Text, tipoPersona, nacionalidad, estado);
                                                    log.crearArchivo();
                                                    this.Close();
                                                }
                                                else
                                                {
                                                    errorProvider1.SetError(cmbEstado, "Debe seleccionar un estado");
                                                    cmbEstado.Focus();
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                errorProvider1.SetError(cmbTipoPersona, "Debe seleccionar un tipo de persona");
                                                cmbTipoPersona.Focus();
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            errorProvider1.SetError(cmbNivelAcademico, "Debe seleccionar un nivel académico");
                                            cmbNivelAcademico.Focus();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(cmbSexo, "Debe seleccionar sexo");
                                        cmbSexo.Focus();
                                        return;
                                    }
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
                    cmbEstado.Text = lista[i].estado;
                }
            }
        }

        /// <summary>
        /// Busca el valor del id, si lo encuentra entonces edita y sino agrega
        /// </summary>
        /// <param name="cedula"> dato a buscar </param>
        /// <returns></returns>
        private bool buscar(int cedula)
        {
            bool busca = false;
            if (log.buscarCedula(cedula) != -1)
            {
                busca = true;
            }
            return busca;

        }

        public EditaPersona(string u)
        {
            InitializeComponent();
            lblTitulo.Text = "Persona - Agregar";
            txtIdPersona.Enabled = false;
            txtUsuarioRegistro.Enabled = false;
            cmbEstado.Enabled = false;
            cmbEstado.Text = "Activo";

            log = new PersonaBO();
            validar = new ValidaDatos();
            lista = new List<Persona>();
            lista = log.getLista();
            asignarId();
            txtUsuarioRegistro.Text = u;
        }

        public EditaPersona(string u, string idB)
        {
            InitializeComponent();
            lblTitulo.Text = "Persona - Editar";
            txtIdPersona.Enabled = false;
            txtUsuarioRegistro.Enabled = false;
            log = new PersonaBO();
            validar = new ValidaDatos();
            lista = new List<Persona>();
            lista = log.getLista();
            llenarEdita(idB);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            sexo = char.Parse(cmbSexo.Text);
        }

        private void cmbNivelAcademico_SelectedIndexChanged(object sender, EventArgs e)
        {
            nivelAcademico = cmbNivelAcademico.Text;
        }

        private void cmbTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoPersona = cmbTipoPersona.Text;
        }

        private void cmbNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            nacionalidad = cmbNacionalidad.Text;
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = cmbEstado.Text;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            aceptar();
        }
    }
}
