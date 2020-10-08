using Matricula.bo;
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
                        MenuAdmin frm = new MenuAdmin(log.enviarU(), txtUsuAdmin.Text);
                        frm.ShowDialog();
                        txtUsuAdmin.Text = "";
                        txtPassAdmin.Text = "";
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

        private void aceptarStudent()
        {
            try
            {
                Usuario u = new Usuario();
                u.codigo = txtUsuStuden.Text;
                u.contrasena = txtPassStuden.Text;

                u = ubo.iniciarSesion(u);

                if (u != null && isStudent(u))
                {
                    ManuUsuario frm = new ManuUsuario();
                    frm.ShowDialog();
                    txtUsuStuden.Text = "";
                    txtPassStuden.Text = "";
                }
                else
                {
                    MessageBox.Show(this, "Credenciales inválidos", "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(this, e.Message);
            }
        }

        private void aceptarTeacher()
        {
            try
            {
                Usuario u = new Usuario();
                u.codigo = txtUsuTeachers.Text;
                u.contrasena = txtPassTeachers.Text;

                u = ubo.iniciarSesion(u);

                if (u != null && isTeacher(u))
                {
                    ManuUsuario frm = new ManuUsuario();
                    frm.ShowDialog();
                    txtUsuTeachers.Text = "";
                    txtPassTeachers.Text = "";
                }
                else
                {
                    MessageBox.Show(this, "Credenciales inválidos", "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(this, e.Message);
            }
        }

        private bool isStudent(Usuario u)
        {
            foreach (Persona persona in pbo.getLista())
            {
                if (persona.idPersona.Equals(u.idPersona) && persona.tipoPersona.Equals("Estudiante"))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isTeacher(Usuario u)
        {
            foreach (Persona persona in pbo.getLista())
            {
                if (persona.idPersona.Equals(u.idPersona) && persona.tipoPersona.Equals("Profesor"))
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
            encripta = new Encripta();
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
    }
}
