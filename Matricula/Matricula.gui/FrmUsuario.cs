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
        private PersonaBO pbo;
        private Form parent;
        private ValidaDatos validar;

        public FrmUsuario(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            ubo = new UsuarioBO();
            pbo = new PersonaBO();
            validar = new ValidaDatos();
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
                foreach (Usuario u in ubo.GetUsuarios(txtBuscar.Text.ToUpper()))
                {
                    foreach (Persona p in pbo.getLista())
                    {
                        if (u.idPersona.Equals(p.cedula))
                        {
                            string nombre = p.nombre + " " + p.apellido1
                                + " " + p.apellido2;
                            tabla.Rows.Add(u, u.codigo, u.idPersona, nombre,
                                p.tipoPersona, u.activo);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la tabla", "Error de la tabla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
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
                if (tabla.CurrentRow != null)
                {
                    Usuario u = (Usuario)tabla.CurrentRow.Cells[0].Value;
                    FrmEdicionUsuario frm = new FrmEdicionUsuario(u);
                    frm.ShowDialog();
                    cargarTabla();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario de la tabla", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cargarTabla();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Error de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar editar el usuario", "Error de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;
            try
            {
                if (tabla.CurrentRow != null)
                {
                    Usuario u = (Usuario)tabla.CurrentRow.Cells[0].Value;
                    respuesta = MessageBox.Show("¿Seguro de que desea eliminar este usuario?", "Eliminando un usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (respuesta == DialogResult.Yes)
                    {
                        u.activo = false;
                        ubo.guardar(u);
                    }
                    cargarTabla();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario de la tabla", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cargarTabla();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar eliminar el usuario", "Error de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabla.CurrentRow != null)
                {
                    Usuario u = (Usuario)tabla.CurrentRow.Cells[0].Value;
                    FrmContrasenaUsuario frm = new FrmContrasenaUsuario(this, u);
                    frm.ShowDialog();
                    cargarTabla();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario de la tabla", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cargarTabla();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar cambiar la contraseña", "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloLetras(e);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarTabla();
        }
    }
}
