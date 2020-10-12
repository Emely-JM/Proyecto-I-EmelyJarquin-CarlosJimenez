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
    public partial class MantenimientoAsignacion : Form
    {
        AsignacionBO log;
        List<Asignacion> lista;
        int id = 0;

        /// <summary>
        /// Muestra los datos de la lista en la tabla
        /// </summary>
        private void verDatos()
        {
            lista = new List<Asignacion>();
            lista = log.getLista();
            tblTabla.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                tblTabla.Rows.Add(lista[i].id, lista[i].idProf, lista[i].idMateria);
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

        public MantenimientoAsignacion(bool admin)
        {
            InitializeComponent();
            adminPermisos(admin);
            log = new AsignacionBO();
            lista = new List<Asignacion>();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            verDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AsignacionMateria frm = new AsignacionMateria();
            frm.ShowDialog();
            verDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult oDlgRes;
            try
            {
                id = int.Parse(this.tblTabla.CurrentRow.Cells[0].Value.ToString());
                oDlgRes = MessageBox.Show("¿Seguro de que desea eliminar esta asignación?", "Eliminación de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (oDlgRes == DialogResult.Yes)
                {
                    log.eliminar(id);
                    log.crearArchivo();
                    verDatos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            lista = log.getLista();
            List<Asignacion> filtrados = lista.Where(x => x.idProf.StartsWith(txtFiltro.Text)).ToList();
            tblTabla.Rows.Clear();
            for (int i = 0; i < filtrados.Count; i++)
            {
                tblTabla.Rows.Add(filtrados[i].id, filtrados[i].idProf, filtrados[i].idMateria);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
