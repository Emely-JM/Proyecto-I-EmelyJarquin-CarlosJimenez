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

        private List<string> expiraContrasena = new List<string> { "30 días", "60 días", "90 días" };

        public FrmContrasenaUsuario(Usuario u)
        {
            InitializeComponent();
            this.u = u;
            ubo = new UsuarioBO();
            cmbExpiraContrasena.DataSource = expiraContrasena;
            cmbExpiraContrasena.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContrasena.Text.Equals(txtConfirmarContrasena.Text))
                {
                    u.contrasena = txtContrasena.Text;
                    u.fechaExpiraContrasena = DateTime.Now.AddDays(int.Parse(cmbExpiraContrasena.SelectedItem.ToString().Substring(0, 2)));
                    ubo.cambiarContrasena(u);
                    Dispose();
                }
                else
                {
                    MessageBox.Show(this, "Las contraseñas ingresadas no coinciden");
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
