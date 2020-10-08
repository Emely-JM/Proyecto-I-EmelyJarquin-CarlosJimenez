using Matricula.bo;
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
            ManuUsuario frm = new ManuUsuario();
            frm.ShowDialog();
        }
    }
}
