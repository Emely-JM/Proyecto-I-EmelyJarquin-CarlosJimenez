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
    public partial class FrmUsuario : Form
    {
        private UsuarioBO ubo;

        public FrmUsuario()
        {
            InitializeComponent();
            ubo = new UsuarioBO();
            tabla.Columns[0].ValueType = typeof(object);
        }

        /// <summary>
        /// Carga la tabla DataGridView en la ventana con los usuarios activos de la aplicación
        /// </summary>
        private void cargarTabla()
        {
            try
            {
                tabla.Rows.Clear();
                if (String.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    foreach (Usuario u in ubo.GetUsuarios())
                    {
                        if (u.activo)
                        {
                            tabla.Rows.Add(u, u.codigo, u.activo);
                        }
                    }
                }
                else
                {
                    foreach (Usuario u in ubo.GetUsuarios())
                    {
                        if (u.codigo.Equals(txtBuscar.Text) && u.activo)
                        {
                            tabla.Rows.Add(u, u.codigo, u.activo);
                        }
                    }
                }
                txtBuscar.Clear();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Error al cargar la tabla");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarTabla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmEdicionUsuario frm = new FrmEdicionUsuario();
            frm.ShowDialog();
            cargarTabla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario u = (Usuario) tabla.CurrentRow.Cells[0].Value;
                FrmEdicionUsuario frm = new FrmEdicionUsuario(u);
                frm.ShowDialog();
                cargarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al intentar editar el usuario");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario u = (Usuario)tabla.CurrentRow.Cells[0].Value;
                u.activo = false;
                ubo.guardar(u);
                cargarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al intentar editar el usuario");
            }
        }

        private void btnContrasena_Click(object sender, EventArgs e)
        {

        }

        private void FrmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
