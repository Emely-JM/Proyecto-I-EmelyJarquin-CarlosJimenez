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
        private Form parent;

        /// <summary>
        /// Llena el combo con los id de la meteria calificada por el profesor
        /// según la materia elegida por el estudiante
        /// </summary>
        private void cargarComboMaterias(string idPeriodo)
        {
            lista = log.getLista();
            cmbMateria.Items.Clear();
            cmbMateria.Text = "";
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idPeriodo.Equals(idPeriodo))
                {
                    cmbMateria.Items.Add(lista[i].idMateria);
                    cmbMateria.SelectedIndex = 0;
                }
            }
        }

        private void cargarComboEstudiantes()
        {
            lista = log.getLista();
            txtEstado.Text = "";
            txtNota.Text = "";
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idEstudiante.Equals(idEstud) && lista[i].idPeriodo.Equals(cmbCuatrimestre.Text))
                {
                    txtEstado.Text = lista[i].estado;
                    txtNota.Text = lista[i].nota.ToString();
                }
            }
        }


        public NotasEstudiante(Form parent,string idEstudiante)
        {
            InitializeComponent();
            this.parent = parent;
            txtNota.Enabled = false;
            txtEstado.Enabled = false;
            log = new RegistroNotaBO();
            lista = new List<RegistroNota>();
            idEstud = idEstudiante;
            cmbCuatrimestre.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMateria_Click(object sender, EventArgs e)
        {
            cargarComboEstudiantes();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCuatrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboMaterias(cmbCuatrimestre.Text);
        }

        private void NotasEstudiante_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
