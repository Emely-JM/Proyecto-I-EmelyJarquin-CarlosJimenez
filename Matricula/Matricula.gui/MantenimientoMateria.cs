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
        MateriaBO log;
        List<Materias> lista;
        string id;

        /// <summary>
        /// Resetea la tabla y recorre la lista para ingresar los datos en las celdas de la tabla
        /// </summary>
        private void verDatos()
        {
            lista = log.getLista();
            tblTabla.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                tblTabla.Rows.Add(lista[i].idMateria, lista[i].nombre, lista[i].cantidadCreditos, lista[i].idCarrera, lista[i].precio, lista[i].costo);
            }
        }


        public MantenimientoMateria()
        {
            InitializeComponent();
            log = new MateriaBO();
            lista = new List<Materias>();
            verDatos();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            verDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EditaMateria frm = new EditaMateria();
            frm.ShowDialog();
            verDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
            try
            {
                log.eliminar(id);
                log.crearArchivo();
                verDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                string nombre = this.tblTabla.CurrentRow.Cells[1].Value.ToString();
                int creditos = int.Parse(this.tblTabla.CurrentRow.Cells[2].Value.ToString());
                string idCarrea = this.tblTabla.CurrentRow.Cells[3].Value.ToString();
                double precio = double.Parse(this.tblTabla.CurrentRow.Cells[4].Value.ToString());
                double costo = double.Parse(this.tblTabla.CurrentRow.Cells[5].Value.ToString());
                EditaMateria frm = new EditaMateria(id, nombre, creditos, idCarrea, precio, costo);
                frm.ShowDialog();
                verDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
