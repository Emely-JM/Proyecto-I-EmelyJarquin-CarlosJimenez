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
        public ManuUsuario()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemMatricula_Click(object sender, EventArgs e)
        {
            RealizaMatricula frm = new RealizaMatricula();
            frm.ShowDialog();
        }

        private void toolStripMenuItemEvaluacion_Click(object sender, EventArgs e)
        {
            RealizaEvaluacion frm = new RealizaEvaluacion();
            frm.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
