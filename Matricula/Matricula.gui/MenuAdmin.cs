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
    public partial class MenuAdmin : Form
    {
        /// <summary>
        /// Imprime mensajes sobre los botones con tooltip
        /// </summary>
        private void mensajes()
        {
            this.toolTip1.SetToolTip(btnCRUDAdmin,"Mantenimiento de administradores");
            this.toolTip1.SetToolTip(btnCRUDCarreras, "Mantenimiento de carreras");
        }

        public MenuAdmin()
        {
            InitializeComponent();
            mensajes();
        }

        private void btnCRUDAdmin_Click(object sender, EventArgs e)
        {
            MantenimientoAdmin frm = new MantenimientoAdmin();
            frm.ShowDialog();
        }

        private void btnCRUDCarreras_Click(object sender, EventArgs e)
        {
            MantenimientoCarrera frm = new MantenimientoCarrera();
            frm.ShowDialog();
        }
    }
}
