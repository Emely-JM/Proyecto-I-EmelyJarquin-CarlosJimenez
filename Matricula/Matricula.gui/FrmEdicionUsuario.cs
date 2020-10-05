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
    public partial class FrmEdicionUsuario : Form
    {
        private Usuario u;
        private UsuarioBO ubo;

        public FrmEdicionUsuario()
        {
            InitializeComponent();
            lblActivo.Visible = false;
            chkActivo.Visible = false;
            u = new Usuario();
            ubo = new UsuarioBO();
            cargarDatos();
        }

        public FrmEdicionUsuario(Usuario u)
        {
            InitializeComponent();
            lblActivo.Visible = false;
            chkActivo.Visible = false;
            this.u = u;
            ubo = new UsuarioBO();
            cargarDatos();
        }

        private void cargarDatos()
        {
            try
            {
                if (u.id != 0)
                {
                    txtCodigo.Text = u.codigo;
                    txtPersona.Text = "";
                    cmbTipoUsuario.SelectedItem = u.tipoUsuario;
                    txtContrasena.Text = "";
                    cmbExpiraContrasena.SelectedIndex = 0;
                    chkActivo.Checked = u.activo;
                }
                else
                {
                    chkActivo.Checked = true;
                }
            }
            catch (Exception)
            {
               throw new Exception("Error al cargar los datos del cliente");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                u.codigo = txtCodigo.Text;
                u.idPersona = 0;
                u.tipoUsuario = cmbTipoUsuario.SelectedItem.ToString();
                u.contrasena = "";
                u.fechaExpiraContrasena = DateTime.Now.AddDays(int.Parse(cmbExpiraContrasena.SelectedItem.ToString()));
                u.activo = chkActivo.Checked;
                ubo.guardar(u);
                Dispose();
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar el usuario");
            }   
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmEdicionUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

    }
}
