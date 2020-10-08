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
    public partial class CursosAsignados : Form
    {

        private AsignacionBO log;
        private List<Asignacion> lista;

        /// <summary>
        /// Carga el combo con las materias del id del profesor pasado por parámetro
        /// </summary>
        /// <param name="id"></param>
        private void cargar(string id)
        {
            lista = log.getLista();
            cmbCursos.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idProf.Equals(id))
                {
                    cmbCursos.Items.Add(lista[i].idMateria);
                }
            }
        }

        public CursosAsignados(string id)
        {
            InitializeComponent();
            lista = new List<Asignacion>();
            log = new AsignacionBO();
            cargar(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
