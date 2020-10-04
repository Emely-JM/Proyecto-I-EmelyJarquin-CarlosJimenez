using Matricula.bo;
using Matricula.entities;
using System;
using System.Activities.Expressions;
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
    public partial class MantenimientoAdmin : Form
    {
        AdminBO log;
        List<Admin> lista;
        string usuario;

        /// <summary>
        /// Ingresa los datos de la lista a la tabla
        /// </summary>
        private void verDatos()
        {
            log.limpiarLista();
            lista = log.getLista();
            tblTabla.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                tblTabla.Rows.Add(lista[i].usuario, lista[i].nombre, lista[i].correo, lista[i].admin, lista[i].activo);
            }
        }

        /// <summary>
        /// Otorga los permisos de administrador
        /// </summary>
        /// <param name="admin1"> representa si el empleado logueado es administrador o no </param>
        private void adminPermisos(bool admin1)
        {
            if (admin1 != true)
            {
                btnEliminar.Enabled = false;
                btnPass.Enabled = false;
            }
        }

        public MantenimientoAdmin(bool admin)
        {
            InitializeComponent();
            log = new AdminBO();
            lista = new List<Admin>();
            adminPermisos(admin);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EditaAdmin frm = new EditaAdmin();
            frm.ShowDialog();
            verDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult oDlgRes;
            try
            {
                usuario = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                oDlgRes = MessageBox.Show("¿Seguro de que desea eliminar este usuario?", "Eliminación de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (oDlgRes == DialogResult.Yes)
                {
                    log.eliminar(usuario);
                    log.crearArchivo();
                    verDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila" + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActivaDes_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                bool activo = bool.Parse(this.tblTabla.CurrentRow.Cells[4].Value.ToString());
                if (activo == true)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de desactivar al usuario: " + usuario + "?", "Activar y desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        log.activaDesactiva(usuario, false);
                        MessageBox.Show("Desactivado", "Activar y desactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de activar al usuario: " + usuario + "?", "Activar y desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        log.activaDesactiva(usuario, true);
                        MessageBox.Show("Activado", "Activar y desactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                log.crearArchivo();
                verDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                if (usuario != null)
                {
                    NuevaContrasena frm = new NuevaContrasena();
                    frm.ShowDialog();
                    if (frm.isAceptar())
                    {
                        log.modificarContrasena(usuario, frm.aceptarButton());
                        MessageBox.Show("Contraseña cambiada","Cambio de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    log.crearArchivo();
                    verDatos();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            verDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                string nombre = this.tblTabla.CurrentRow.Cells[1].Value.ToString();
                string correo = this.tblTabla.CurrentRow.Cells[2].Value.ToString();
                bool admin = bool.Parse(this.tblTabla.CurrentRow.Cells[3].Value.ToString());
                bool activo = bool.Parse(this.tblTabla.CurrentRow.Cells[4].Value.ToString());
                EditaAdmin frm = new EditaAdmin(usuario, nombre, correo, admin, activo);
                frm.ShowDialog();
                verDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            lista = log.getLista();
            List<Admin> filtrados = lista.Where(x => x.usuario.StartsWith(txtFiltro.Text)).ToList();
            tblTabla.Rows.Clear();
            for (int i = 0; i < filtrados.Count; i++)
            {
                tblTabla.Rows.Add(filtrados[i].usuario, filtrados[i].nombre, filtrados[i].correo, filtrados[i].admin, filtrados[i].activo);
            }
        }
    }
}
