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
    public partial class NotasEstudiante : Form
    {
        private string idEstud;
        private RegistroNotaBO log;
        private List<RegistroNota> lista;

        /// <summary>
        /// Llena el combo con los id de la meteria calificada por el profesor
        /// según la materia elegida por el estudiante
        /// </summary>
        private void cargarCombo()
        {
            lista = log.getLista();
            cmbMateria.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idEstudiante.Equals(idEstud))
                {
                    cmbMateria.Items.Add(lista[i].idMateria);
                    cmbMateria.SelectedIndex = 0;
                }
            }
        }

        public NotasEstudiante(string idEstudiante)
        {
            InitializeComponent();
            txtNota.Enabled = false;
            txtEstado.Enabled = false;
            log = new RegistroNotaBO();
            lista = new List<RegistroNota>();
            idEstud = idEstudiante;
            cargarCombo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMateria_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idEstudiante.Equals(idEstud))
                {
                    txtEstado.Text = lista[i].estado;
                    txtNota.Text = lista[i].nota.ToString();
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
