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
        private string id;


        public ManuUsuario(string idEstudiante)
        {
            InitializeComponent();
            id = idEstudiante;
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
    }
}
