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
    public partial class ManuUsuario : Form
    {
        private Usuario u;
        private string id;

        public ManuUsuario(Usuario u)
        {
            InitializeComponent();
            this.u = u;
            id = u.idPersona;
        }

        private void toolStripMenuItemMatricula_Click(object sender, EventArgs e)
        {
            RealizaMatricula frm = new RealizaMatricula(id);
            frm.ShowDialog();
        }

        private void toolStripMenuItemEvaluacion_Click(object sender, EventArgs e)
        {
            RealizaEvaluacion frm = new RealizaEvaluacion(id);
            frm.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItemNotas_Click(object sender, EventArgs e)
        {
            NotasEstudiante frm = new NotasEstudiante(id);
            frm.ShowDialog();
        }

        private void pagosPendientes_Click(object sender, EventArgs e)
        {
            Pago frm = new Pago(id);
            frm.ShowDialog();
        }

        private void eliminarPrematriculaDeMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminaPrematricula frm = new EliminaPrematricula(id);
            frm.ShowDialog();
        }

        private void toolStripMenuItemContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                FrmContrasenaUsuario frm = new FrmContrasenaUsuario(u);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al intentar cambiar la contraseña");
            }
        }
    }
}
