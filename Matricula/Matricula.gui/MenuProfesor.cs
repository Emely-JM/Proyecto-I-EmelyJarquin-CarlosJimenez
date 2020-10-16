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
    public partial class MenuProfesor : Form
    {
        private Usuario u;
        private string usu;
        private Form parent;

        public MenuProfesor(Form parent,Usuario u)
        {
            InitializeComponent();
            this.parent = parent;
            this.u = u;
            usu = u.idPersona;
        }

        private void cursosAsignados_Click(object sender, EventArgs e)
        {
            CursosAsignados frm = new CursosAsignados(this,usu);
            this.Visible = false;
            frm.Show();
        }

        private void ListaEstudiantes_Click(object sender, EventArgs e)
        {
            ListaEstudiante frm = new ListaEstudiante(this,usu);
            this.Visible = false;
            frm.Show();
        }

        private void Notas_Click(object sender, EventArgs e)
        {
            RegistraNota frm = new RegistraNota(this,usu);
            this.Visible = false;
            frm.Show();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void MenuProfesor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
