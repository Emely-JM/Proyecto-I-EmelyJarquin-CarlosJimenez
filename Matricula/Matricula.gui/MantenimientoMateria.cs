using EliminaDatos;
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
    public partial class MantenimientoMateria : Form
    {
        private Elimina eliminar;
        private MateriaBO log;
        private List<Materias> lista;
        private string id;
        private Form parent;

        /// <summary>
        /// Resetea la tabla y recorre la lista para ingresar los datos en las celdas de la tabla
        /// </summary>
        private void verDatos()
        {
            lista = log.getLista();
            tblTabla.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                tblTabla.Rows.Add(lista[i].idMateria, lista[i].nombre, lista[i].cantidadCreditos, lista[i].idCarrera, lista[i].precio, lista[i].costo, lista[i].estado);
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
            }
        }

        public MantenimientoMateria(Form parent,bool admin)
        {
            InitializeComponent();
            this.parent = parent;
            log = new MateriaBO();
            lista = new List<Materias>();
            adminPermisos(admin);
            eliminar = new Elimina();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            verDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EditaMateria frm = new EditaMateria(this);
            frm.Show();
            this.Visible = false;
            verDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult oDlgRes;
            try
            {
                id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                bool activo = bool.Parse(this.tblTabla.CurrentRow.Cells[6].Value.ToString());
                oDlgRes = MessageBox.Show("¿Seguro de que desea eliminar esta materia?", "Eliminación de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (oDlgRes == DialogResult.Yes)
                {
                    if (eliminar.eliminarMateria(id) != -1)
                    {
                        MessageBox.Show("No se puede eliminar esta materia ya que tiene matriculas ligadas, debe eliminar las matriculas para eliminar la materia. En su lugar, se procederá a " +
                            "desactivar la materia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (activo == true)
                        {
                            log.modificaEstado(id, false);
                        }
                        else
                        {
                            log.modificaEstado(id, true);

                        }
                    }
                    else
                    {
                        log.eliminar(id);
                    }
                    log.crearArchivo();
                    verDatos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                EditaMateria frm = new EditaMateria(this,id);
                frm.Show();
                this.Visible = false;
                verDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lista = log.getLista();
            List<Materias> filtrados = lista.Where(x => x.idMateria.StartsWith(textBox1.Text)).ToList();
            tblTabla.Rows.Clear();
            for (int i = 0; i < filtrados.Count; i++)
            {
                tblTabla.Rows.Add(filtrados[i].idMateria, filtrados[i].nombre, filtrados[i].cantidadCreditos, filtrados[i].idCarrera, filtrados[i].precio,
                    filtrados[i].costo);
            }
        }

        private void btnActivaDes_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                bool activo = bool.Parse(this.tblTabla.CurrentRow.Cells[6].Value.ToString());

                if (activo == true)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de desactivar a la materia: " + id + "?", "Activar y desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        log.modificaEstado(id, false);
                        MessageBox.Show("Desactivado", "Activar y desactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de activar a la materia: " + id + "?", "Activar y desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        log.modificaEstado(id, true);
                        MessageBox.Show("Activado", "Activar y desactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                log.crearArchivo();
                verDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MantenimientoMateria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
