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
        private string usu;

        public MenuProfesor(Usuario u)
        {
            InitializeComponent();
            usu = u.idPersona;
        }

        private void cursosAsignados_Click(object sender, EventArgs e)
        {
            CursosAsignados frm = new CursosAsignados(usu);
            frm.ShowDialog();
        }

        private void ListaEstudiantes_Click(object sender, EventArgs e)
        {
            ListaEstudiante frm = new ListaEstudiante(usu);
            frm.ShowDialog();
        }

        private void Notas_Click(object sender, EventArgs e)
        {
            RegistraNota frm = new RegistraNota();
            frm.ShowDialog();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
