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
using System.Text.RegularExpressions;
using Matricula.dao;

namespace Matricula.gui
{
    public partial class EditaAdmin : Form
    {
        AdminBO log;
        ValidaDatos validar;
        string usuarioBuscar;

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
        /// Válida que los textBox cumplan con ciertas condiciones como no estar vacíos 
        /// e ingresar correos válidos.
        /// Agrega los datos de los textBox al método de agregar del AdminBO
        /// </summary>
        private void aceptar()
        {
            Regex regEmail = new Regex(@"^(([^<>()[\]\\.,;:\s@""]+"
                    + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                    + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                    + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                    + @"[a-zA-Z]{2,}))$", RegexOptions.Compiled);

            if (buscar(usuarioBuscar) != true)
            {
                if (txtUsuario.Text != "")
                {
                    errorProvider1.SetError(txtUsuario, "");

                    if (txtNombre.Text != "")
                    {
                        errorProvider1.SetError(txtNombre, "");
                        if (regEmail.IsMatch(txtCorreo.Text))
                        {
                            errorProvider1.SetError(txtCorreo, "");
                            if (txtContrasena.Text != "")
                            {
                                errorProvider1.SetError(txtContrasena, "");
                                if (txtContrasena1.Text != "")
                                {
                                    errorProvider1.SetError(txtContrasena1, "");
                                    if (txtContrasena.Text.Equals(txtContrasena1.Text))
                                    {
                                        if (log.buscarUsuario(txtUsuario.Text) != -1)
                                        {
                                            mensaje(txtUsuario, "Este usuario ya existe");
                                        }
                                        else
                                        {
                                            if (log.buscarCorreo(txtCorreo.Text) != -1)
                                            {
                                                mensaje(txtCorreo, "Este correo ya existe");
                                            }
                                            else
                                            {
                                                log.agregar(txtUsuario.Text, txtNombre.Text, txtCorreo.Text, txtContrasena.Text, chkAdmin.Checked, chkActivo.Checked);
                                                log.crearArchivo();
                                                this.Close();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        mensaje(txtContrasena1, "Las contraseñas no coincides");
                                    }
                                }
                                else
                                {
                                    mensaje(txtContrasena1, "Debe confirmar la contraseña");
                                }
                            }
                            else
                            {
                                mensaje(txtContrasena, "Contraseña es requerida");
                            }
                        }
                        else
                        {
                            mensaje(txtCorreo, "Correo válido");
                        }
                    }

                    else
                    {
                        mensaje(txtNombre, "Nombre es requerido");
                    }

                }
                else
                {
                    mensaje(txtUsuario, "Usuario es requerido");
                }
            }
            else
            {
                log.modificar(txtUsuario.Text, txtNombre.Text, txtCorreo.Text, chkAdmin.Checked, chkActivo.Checked);
                log.crearArchivo();
                this.Close();
            }


        }

        /// <summary>
        /// Busca al usuario para identificar si se ingresa o se actualizan los datos
        /// </summary>
        /// <param name="usu"> usuario a buscar </param>
        /// <returns> returna true si lo encuentra o false sino</returns>
        private bool buscar(string usu)
        {
            bool busca = false;
            if (log.buscarUsuario(usu) != -1)
            {
                busca = true;
            }
            return busca;
        }


        public EditaAdmin()
        {
            InitializeComponent();
            lblTitulo.Text = "Administrador - Agregar";
            log = new AdminBO();
            validar = new ValidaDatos();
            chkActivo.Enabled = false;
            chkActivo.Checked = true;

        }

        public EditaAdmin(string usu,string nombre,string correo, bool admin, bool activo)
        {
            InitializeComponent();
            lblTitulo.Text = "Administrador - Editar";
            log = new AdminBO();
            validar = new ValidaDatos();
            label5.Enabled = false;
            txtContrasena.Enabled = false;
            label6.Enabled = false;
            txtContrasena1.Enabled = false;
            chkActivo.Enabled = true;
            usuarioBuscar = usu;
            txtUsuario.Text = usu;
            txtNombre.Text = nombre;
            txtCorreo.Text = correo;
            chkActivo.Checked = activo;
            chkAdmin.Checked = admin;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloLetras(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloLetras(e);
        }
    }
}
