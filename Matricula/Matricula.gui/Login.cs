﻿using Matricula.bo;
using Matricula.entities;
using Matricula.utilitario;
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
    public partial class Login : Form
    {
        private AdminBO log;
        private UsuarioBO ubo;
        private PersonaBO pbo;
        private UsuarioBO logU;
        private Encripta encripta;

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
        /// Permite iniciar sesión a los administradores y usuarios admin
        /// si la contraseña y usuario son correctos
        /// </summary>
        private void aceptarAdmin()
        {
            if (txtUsuAdmin.Text != "")
            {
                errorProvider1.SetError(txtUsuAdmin, "");
                if (txtPassAdmin.Text != "")
                {
                    errorProvider1.SetError(txtPassAdmin, "");
                    string contrasena = encripta.Encriptar(txtPassAdmin.Text);
                    if (log.loguarse(txtUsuAdmin.Text, contrasena))
                    {
                        MenuAdmin frm = new MenuAdmin(this,txtUsuAdmin.Text,log.enviarU());
                        frm.Show();
                        txtUsuAdmin.Text = "";
                        txtPassAdmin.Text = "";
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Credenciales inválidos", "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    mensaje(txtPassAdmin, "Contraseña es requerida");
                }
            }
            else
            {
                mensaje(txtUsuAdmin, "Usuario es requerido");
            }
        }

        /// <summary>
        /// Permite a un usuario ingresar a la aplicación como estudiante
        /// si el usuario y contraseña son correctos
        /// </summary>
        private void aceptarStudent()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtUsuStuden.Text))
                {
                    errorProvider1.SetError(txtUsuStuden, "");
                    if (!String.IsNullOrEmpty(txtPassStuden.Text))
                    {
                        errorProvider1.SetError(txtPassStuden, "");
                        Usuario u = new Usuario();
                        u.codigo = txtUsuStuden.Text.ToUpper();
                        u.contrasena = txtPassStuden.Text;

                        u = ubo.iniciarSesion(u);

                        if (u != null && isStudent(u))
                        {
                            ManuUsuario frm = new ManuUsuario(this, u);
                            frm.Show();
                            txtUsuStuden.Text = "";
                            txtPassStuden.Text = "";
                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Credenciales inválidos", "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        mensaje(txtPassStuden, "La contraseña es requerida");
                    }
                }
                else
                {
                    mensaje(txtUsuStuden, "El usuario es requerido");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Permite a un usuario ingresar a la aplicación como profesor
        /// si el usuario y contraseña son correctos
        /// </summary>
        private void aceptarTeacher()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtUsuTeachers.Text))
                {
                    errorProvider1.SetError(txtUsuTeachers, "");
                    if (!String.IsNullOrEmpty(txtPassTeachers.Text))
                    {
                        errorProvider1.SetError(txtPassTeachers, "");
                        Usuario u = new Usuario();
                        u.codigo = txtUsuTeachers.Text.ToUpper();
                        u.contrasena = txtPassTeachers.Text;

                        u = ubo.iniciarSesion(u);

                        if (u != null && isTeacher(u))
                        {
                            MenuProfesor frm = new MenuProfesor(this, u);
                            frm.Show();
                            txtUsuTeachers.Text = "";
                            txtPassTeachers.Text = "";
                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show(this, "Credenciales inválidos", "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        mensaje(txtPassTeachers, "La contraseña es requerida");
                    }
                }
                else
                {
                    mensaje(txtUsuTeachers, "El usuario es requerido");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Verifica que un usuario sea estudiante
        /// </summary>
        /// <param name="u">
        /// Instancia de la clase Usuario
        /// </param>
        /// <returns>
        /// Verdadero si el usuario es de tipo estudiante
        /// </returns>
        private bool isStudent(Usuario u)
        {
            foreach (Persona persona in pbo.getLista())
            {
                if (persona.cedula.Equals(u.idPersona) && persona.tipoPersona.Equals("Estudiante"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica que un usuario sea profesor
        /// </summary>
        /// <param name="u">
        /// Instancia de la clase Usuario
        /// </param>
        /// <returns>
        /// Verdadero si el usuario es de tipo profesor
        /// </returns>
        private bool isTeacher(Usuario u)
        {
            foreach (Persona persona in pbo.getLista())
            {
                if (persona.cedula.Equals(u.idPersona) && persona.tipoPersona.Equals("Profesor"))
                {
                    return true;
                }
            }
            return false;
        }

        public Login()
        {
            InitializeComponent();
            log = new AdminBO();
            logU = new UsuarioBO();
            ubo = new UsuarioBO();
            pbo = new PersonaBO();
            encripta = new Encripta();
            txtUsuAdmin.Text = "Admin";
            txtPassAdmin.Text = "Admin123*";
        }

        private void btnAceptarAdmin_Click(object sender, EventArgs e)
        {
            aceptarAdmin();
        }

        private void btnCancelarAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptarStuden_Click(object sender, EventArgs e)
        {
            aceptarStudent();
        }

        private void btnCancelarStuden_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAceparTeachers_Click(object sender, EventArgs e)
        {
            aceptarTeacher();
        }

        private void btnCancelarTeachers_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FrmEdicionUsuario frm = new FrmEdicionUsuario();
            frm.ShowDialog();
        }

        private void btnRegistroProf_Click(object sender, EventArgs e)
        {
            FrmEdicionUsuario frm = new FrmEdicionUsuario();
            frm.ShowDialog();
        }
    }
}
