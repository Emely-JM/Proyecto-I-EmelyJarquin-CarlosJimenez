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
    public partial class MantenimientoCarrera : Form
    {

        CarreraBO log;
        List<Carrera> lista;
        string id = "";

        /// <summary>
        /// Ingresa los datos de la lista a la tabla
        /// </summary>
        private void verDatos()
        {
            lista = log.getLista();
            tblTabla.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                tblTabla.Rows.Add(lista[i].idCarrera, lista[i].nombre, lista[i].creditosTotales, lista[i].estado, lista[i].FechaApertura, lista[i].FechaCierrre);
            }
        }


        public MantenimientoCarrera()
        {
            InitializeComponent();
            log = new CarreraBO();
            lista = new List<Carrera>();
            verDatos();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            verDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EditaCarrera frm = new EditaCarrera();
            frm.ShowDialog();
            verDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
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
                string estado = this.tblTabla.CurrentRow.Cells[3].Value.ToString();
                DateTime apertura = DateTime.Parse(this.tblTabla.CurrentRow.Cells[4].Value.ToString());
                DateTime cierre = DateTime.Parse(this.tblTabla.CurrentRow.Cells[5].Value.ToString());
                EditaCarrera frm = new EditaCarrera(id, nombre, creditos, estado, apertura, cierre);
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
