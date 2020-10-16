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
        private Form parent;

        public ManuUsuario(Form parent,Usuario u)
        {
            InitializeComponent();
            this.parent = parent;
            this.u = u;
            id = u.idPersona;
        }

        private void toolStripMenuItemMatricula_Click(object sender, EventArgs e)
        {
            RealizaMatricula frm = new RealizaMatricula(this,id);
            this.Visible = false;
            frm.Show();
        }

        private void toolStripMenuItemEvaluacion_Click(object sender, EventArgs e)
        {
            RealizaEvaluacion frm = new RealizaEvaluacion(this,id);
            this.Visible = false;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItemNotas_Click(object sender, EventArgs e)
        {
            NotasEstudiante frm = new NotasEstudiante(this,id);
            this.Visible = false;
            frm.Show();
        }

        private void pagosPendientes_Click(object sender, EventArgs e)
        {
            Pago frm = new Pago(this,id);
            this.Visible = false;
            frm.Show();
        }

        private void eliminarPrematriculaDeMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminaPrematricula frm = new EliminaPrematricula(this,id);
            this.Visible = false;
            frm.Show();
        }

        private void toolStripMenuItemContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                FrmContrasenaUsuario frm = new FrmContrasenaUsuario(this,u);
                this.Visible = false;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error al intentar cambiar la contraseña");
            }
        }

        private void ManuUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
