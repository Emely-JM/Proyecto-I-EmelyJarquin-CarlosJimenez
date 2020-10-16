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
    public partial class HistorialEvaluacion : Form
    {
        private EvaluacionBO log;
        private List<Evaluacion> lista;
        private Form parent;

        /// <summary>
        /// Ingresa los datos de la lista a la tabla
        /// </summary>
        private void verDatos()
        {
            lista = log.getLista();
            tblTabla.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                tblTabla.Rows.Add(lista[i].idEvalucion, lista[i].idEstudiante, lista[i].idMateria, lista[i].estado, lista[i].fechaEvaluacion, lista[i].descripcion);
            }

        }

        public HistorialEvaluacion(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            log = new EvaluacionBO();
            lista = new List<Evaluacion>();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            verDatos();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            lista = log.getLista();
            List<Evaluacion> filtrados = lista.Where(x => x.idEstudiante.StartsWith(txtFiltro.Text)).ToList();
            tblTabla.Rows.Clear();
            for (int i = 0; i < filtrados.Count; i++)
            {
                tblTabla.Rows.Add(filtrados[i].idEvalucion, filtrados[i].idEstudiante, filtrados[i].idMateria, filtrados[i].estado, filtrados[i].fechaEvaluacion, filtrados[i].descripcion);
            }
        }

        private void HistorialEvaluacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
