﻿using Matricula.bo;
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
    public partial class EliminaPrematricula : Form
    {
        private string id;
        private string idEliminar;
        private MatriculaEstudianteBO logMat;
        private List<MatriculaEstudiante> listaMat;
        private Form parent;

        /// <summary>
        /// Carga las materias ligadas al id del usuario pasado en el contructor
        /// siempre que se encuentren en prematricula
        /// </summary>
        private void cargarCombo()
        {
            listaMat = logMat.getLista();
            cmbMaterias.Items.Clear();
            for (int i = 0; i < listaMat.Count; i++)
            {
                if (listaMat[i].idPersona.Equals(id))
                {
                    cmbMaterias.Items.Add(listaMat[i].idMateria);
                    cmbMaterias.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Busca el id de la materia seleccionada en el combo
        /// y busca en la lista el id de factura ligado a la materia
        /// 
        /// </summary>
        /// <param name="idMat"> id de la materia a buscar </param>
        /// <returns> retorna el id de la factura </returns>
        private string BuscarFact(string idMat)
        {
            string idFactura = "";
            listaMat = logMat.getLista();
            for (int i = 0; i < listaMat.Count; i++)
            {
                if (listaMat[i].idMateria.Equals(idMat))
                {
                    idFactura = listaMat[i].idFactura;
                }
            }
            return idFactura;
        }

        /// <summary>
        /// Válida el combos y llama a los métodos para eliminar los datos
        /// </summary>
        private void aceptar()
        {
            DialogResult oDlgRes;
            try
            {
                if (cmbMaterias.Text != "")
                {

                    oDlgRes = MessageBox.Show("¿Seguro de que desea eliminar esta materia de sus datos?", "Eliminación de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (oDlgRes == DialogResult.Yes)
                    {
                        logMat.eliminar(BuscarFact(idEliminar));
                        logMat.crearArchivo();
                        MessageBox.Show("Ha eliminado/desertado esta materia", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No hay materías que eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public EliminaPrematricula(Form parent,string idP)
        {
            InitializeComponent();
            this.parent = parent;
            logMat = new MatriculaEstudianteBO();
            listaMat = new List<MatriculaEstudiante>();
            id = idP;
            txtId.Text = idP;
            cargarCombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            idEliminar = cmbMaterias.Text;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void EliminaPrematricula_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
