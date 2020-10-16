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
    public partial class MenuAdmin : Form
    {
        private bool admin1;
        private string usu;
        private Form parent;

        /// <summary>
        /// Imprime mensajes sobre los botones con tooltip
        /// </summary>
        private void mensajes()
        {
            this.toolTip1.SetToolTip(btnCRUDAdmin, "Mantenimiento de administradores");
            this.toolTip1.SetToolTip(btnCRUDCarreras, "Mantenimiento de carreras");
            this.toolTip1.SetToolTip(btnCRUDMateria, "Mantenimiento de materias");
            this.toolTip1.SetToolTip(btnCRUDPersonas, "Mantenimiento de personas");
            this.toolTip1.SetToolTip(btnAsignacion, "Mantenimiento de asignaciones");
            this.toolTip1.SetToolTip(btnCRUDUsuarios, "Mantenimiento de Usuarios");
            this.toolTip1.SetToolTip(btnEvaluaciones, "Historial de evaluaciones");
        }

        public MenuAdmin(Form parent, string u ,bool activo)
        {
            InitializeComponent();
            mensajes();
            this.parent = parent;
            admin1 = activo;
            usu = u;
        }

        private void btnCRUDAdmin_Click(object sender, EventArgs e)
        {
            MantenimientoAdmin frm = new MantenimientoAdmin(this,admin1);
            frm.Show();
            this.Visible = false;
        }

        private void btnCRUDCarreras_Click(object sender, EventArgs e)
        {
            MantenimientoCarrera frm = new MantenimientoCarrera(this,admin1);
            frm.Show();
            this.Visible = false;
        }

        private void btnCRUDMateria_Click(object sender, EventArgs e)
        {
            MantenimientoMateria frm = new MantenimientoMateria(this,admin1);
            frm.Show();
            this.Visible = false;
        }

        private void btnCRUDPersonas_Click(object sender, EventArgs e)
        {
            MantenimientoPersona frm = new MantenimientoPersona(this,admin1, usu);
            frm.Show();
            this.Visible = false;
        }

        private void btnAsignacion_Click(object sender, EventArgs e)
        {
            MantenimientoAsignacion frm = new MantenimientoAsignacion(this,admin1);
            frm.Show();
            this.Visible = false;
        }

        private void btnCRUDUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuario frm = new FrmUsuario(this);
            frm.Show();
            this.Visible = false;
        }

        private void btnEvaluaciones_Click(object sender, EventArgs e)
        {
            HistorialEvaluacion frm = new HistorialEvaluacion(this);
            frm.Show();
            this.Visible = false;
        }

        private void MenuAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
