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
    public partial class FrmContrasenaUsuario : Form
    {
        private Usuario u;
        private UsuarioBO ubo;
        private Form parent;

        public FrmContrasenaUsuario(Form parent,Usuario u)
        {
            InitializeComponent();
            this.parent = parent;
            this.u = u;
            ubo = new UsuarioBO();
            cmbExpiraContrasena.SelectedIndex = 0;
        }

        /// <summary>
        /// Método que imprime un errorProvider en el textBox pasado por parámetro 
        /// y con el mensaje indicado en el parámetro
        /// </summary>
        /// <param name="text"> representa el textBox al que se le dará foco para imprimir el mensaje</param>
        /// <param name="mensaje"> representa el mensaje que se desea imprimir </param>
        private void mensaje(TextBox text, string mensaje)
        {
            errorProvider.SetError(text, mensaje);
            text.Focus();
            return;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtContrasena.Text))
                {
                    errorProvider.SetError(txtContrasena, "");
                    if (!String.IsNullOrEmpty(txtConfirmarContrasena.Text))
                    {
                        errorProvider.SetError(txtConfirmarContrasena, "");
                        if (txtContrasena.Text.Equals(txtConfirmarContrasena.Text))
                        {
                            u.contrasena = txtContrasena.Text;
                            u.fechaExpiraContrasena = DateTime.Now.AddDays(int.Parse(cmbExpiraContrasena.SelectedItem.ToString().Substring(0, 2)));
                            ubo.cambiarContrasena(u);
                            Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas ingresadas no coinciden", "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        mensaje(txtConfirmarContrasena, "La contraseña es requerida");
                    }
                }
                else
                {
                    mensaje(txtContrasena, "La contraseña es requerida");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmContrasenaUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
