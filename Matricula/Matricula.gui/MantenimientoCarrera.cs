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
    public partial class MantenimientoCarrera : Form
    {

        CarreraBO log;
        List<Carrera> lista;
        string id = "";
        MateriaBO logMateria;
        List<Materias> listaMateria;

        /// <summary>
        /// Ingresa los datos de la lista a la tabla
        /// </summary>
        private void verDatos()
        {
            lista = log.getLista();
            tblTabla.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                tblTabla.Rows.Add(lista[i].idCarrera, lista[i].nombre, lista[i].creditosTotales, lista[i].estado, lista[i].FechaApertura, lista[i].FechaCierrre);
            }
        }

        /// <summary>
        /// Otorga los permisos de administrador
        /// </summary>
        /// <param name="admin1"> representa si el empleado logueado es administrador o no </param>
        private void adminPermisos(bool admin1)
        {
            if (admin1 != true)
            {
                btnEliminar.Enabled = false;
            }
        }

        /// <summary>
        /// Busca el id de la carrera en la lista perteneciente a las materias
        /// si ya hay una materia ligada al id de la carrera, entonces no se permite
        /// eliminar la carrera, de lo contrario sí se elimina
        /// </summary>
        /// <param name="idCarrera"> representa el id de la carrera que se desea buscar </param>
        /// <returns> retorna el indice si encuentra el id o un -1 sino</returns>
        private int eliminarCarrera(string idCarrera)
        {
            listaMateria = logMateria.getLista();
            for (int i = 0; i < listaMateria.Count; i++)
            {
                if (listaMateria[i].idCarrera.Equals(idCarrera))
                {
                    return i;
                }
            }
            return -1;
        }

        public MantenimientoCarrera(bool admin)
        {
            InitializeComponent();
            log = new CarreraBO();
            lista = new List<Carrera>();
            logMateria = new MateriaBO();
            listaMateria = new List<Materias>();
            adminPermisos(admin);
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            verDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EditaCarrera frm = new EditaCarrera();
            frm.ShowDialog();
            verDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult oDlgRes;
            try
            {
                id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                oDlgRes = MessageBox.Show("¿Seguro de que desea eliminar esta carrera?", "Eliminación de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (oDlgRes == DialogResult.Yes)
                {
                    if(eliminarCarrera(id) != -1)
                    {
                        MessageBox.Show("No puede eliminar esta carrera, ya que está ligada a una materia, debe eliminar la materia para poder eliminar la carrera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    else
                    {
                        log.eliminar(id);
                        log.crearArchivo();
                        verDatos();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                string nombre = this.tblTabla.CurrentRow.Cells[1].Value.ToString();
                int creditos = int.Parse(this.tblTabla.CurrentRow.Cells[2].Value.ToString());
                string estado = this.tblTabla.CurrentRow.Cells[3].Value.ToString();
                DateTime apertura = DateTime.Parse(this.tblTabla.CurrentRow.Cells[4].Value.ToString());
                DateTime cierre = DateTime.Parse(this.tblTabla.CurrentRow.Cells[5].Value.ToString());
                EditaCarrera frm = new EditaCarrera(id, nombre, creditos, estado, apertura, cierre);
                frm.ShowDialog();
                verDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            lista = log.getLista();
            List<Carrera> filtrados = lista.Where(x => x.idCarrera.StartsWith(txtFiltro.Text)).ToList();
            tblTabla.Rows.Clear();
            for (int i = 0; i < filtrados.Count; i++)
            {
                tblTabla.Rows.Add(filtrados[i].idCarrera, filtrados[i].nombre, filtrados[i].creditosTotales, filtrados[i].estado, filtrados[i].FechaApertura, filtrados[i].FechaCierrre);
            }
        }
    }
}
