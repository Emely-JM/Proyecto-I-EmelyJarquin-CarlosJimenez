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
        bool admin1;
        string u;

        /// <summary>
        /// Imprime mensajes sobre los botones con tooltip
        /// </summary>
        private void mensajes()
        {
            this.toolTip1.SetToolTip(btnCRUDAdmin, "Mantenimiento de administradores");
            this.toolTip1.SetToolTip(btnCRUDCarreras, "Mantenimiento de carreras");
            this.toolTip1.SetToolTip(btnCRUDMateria, "Mantenimiento de materias");
            this.toolTip1.SetToolTip(btnCRUDPersonas, "Mantenimiento de personas");
        }

        public MenuAdmin(bool admin, string usu)
        {
            InitializeComponent();
            mensajes();
            admin1 = admin;
            u = usu;
        }

        private void btnCRUDAdmin_Click(object sender, EventArgs e)
        {
            MantenimientoAdmin frm = new MantenimientoAdmin(admin1);
            frm.ShowDialog();
        }

        private void btnCRUDCarreras_Click(object sender, EventArgs e)
        {
            MantenimientoCarrera frm = new MantenimientoCarrera(admin1);
            frm.ShowDialog();
        }

        private void btnCRUDMateria_Click(object sender, EventArgs e)
        {
            MantenimientoMateria frm = new MantenimientoMateria(admin1);
            frm.ShowDialog();
        }

        private void btnCRUDPersonas_Click(object sender, EventArgs e)
        {
            MantenimientoPersona frm = new MantenimientoPersona(admin1, u);
            frm.ShowDialog();
        }
    }
}
