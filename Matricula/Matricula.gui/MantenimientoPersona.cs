﻿using EliminaDatos;
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
    public partial class MantenimientoPersona : Form
    {
        private Elimina elimina;
        private string usu = "";
        private PersonaBO log;
        private List<Persona> lista;
        private string id = "";
        private Form parent;

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
        /// Permite ingresar en la tabla algunos datos de la lista
        /// </summary>
        private void verDatos()
        {
            lista = log.getLista();
            tblTabla.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                tblTabla.Rows.Add(lista[i].idPersona, lista[i].cedula, lista[i].nombre, lista[i].apellido1, lista[i].apellido2,
                    lista[i].nivelAcademico, lista[i].tipoPersona, lista[i].fechaIngreso, lista[i].estado);
            }
        }

        public MantenimientoPersona(Form parent, bool esadmin, string u)
        {
            InitializeComponent();
            this.parent = parent;
            adminPermisos(esadmin);
            usu = u;
            log = new PersonaBO();
            lista = new List<Persona>();
            elimina = new Elimina();
        }

        private void btnVerDatos_Click(object sender, EventArgs e)
        {
            verDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EditaPersona frm = new EditaPersona(this, usu);
            frm.Show();
            this.Visible = false;
            verDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblTabla.CurrentRow != null)
                {
                    id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                    EditaPersona frm = new EditaPersona(this, usu, id);
                    frm.Show();
                    this.Visible = false;
                    verDatos();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la tabla", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult oDlgRes;
            try
            {
                if (tblTabla.CurrentRow != null)
                {
                    id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                    string cedula = this.tblTabla.CurrentRow.Cells[1].Value.ToString();
                    bool activo = bool.Parse(this.tblTabla.CurrentRow.Cells[8].Value.ToString());
                    oDlgRes = MessageBox.Show("¿Seguro de que desea eliminar esta persona?", "Eliminación de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (oDlgRes == DialogResult.Yes)
                    {
                        if (elimina.eliminarPersona(cedula) != -1)
                        {
                            MessageBox.Show("No se puede eliminar a esta persona, ya que hay datos ligados, debe eliminar dichos datos para lograr eliminar, en su lugar se desactivará", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (activo == true)
                            {
                                log.activaDesactiva(id, false);
                            }
                            else
                            {
                                log.activaDesactiva(id, true);
                            }
                        }
                        else
                        {
                            log.eliminar(id);
                        }
                        log.crearArchivo();
                        verDatos();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila de la tabla", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            lista = log.getLista();
            List<Persona> filtrados = lista.Where(x => x.cedula.StartsWith(txtFiltro.Text)).ToList();
            tblTabla.Rows.Clear();
            for (int i = 0; i < filtrados.Count; i++)
            {
                tblTabla.Rows.Add(filtrados[i].idPersona, filtrados[i].cedula, filtrados[i].nombre, filtrados[i].apellido1, filtrados[i].apellido2,
                    filtrados[i].nivelAcademico, filtrados[i].tipoPersona, filtrados[i].fechaIngreso, filtrados[i].estado);
            }
        }

        private void btnActivaDes_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                bool activo = bool.Parse(this.tblTabla.CurrentRow.Cells[8].Value.ToString());
                if (activo == true)
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de desactivar a la persona con el id: " + id + "?", "Activar y desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        log.activaDesactiva(id, false);
                        MessageBox.Show("Desactivado", "Activar y desactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de activar a la persona con el id: " + id + "?", "Activar y desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        log.activaDesactiva(id, true);
                        MessageBox.Show("Activado", "Activar y desactivar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                log.crearArchivo();
                verDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una fila " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MantenimientoPersona_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
