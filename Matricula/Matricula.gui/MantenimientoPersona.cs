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
        private string usu = "";
        PersonaBO log;
        List<Persona> lista;
        private string id = "";


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
                    lista[i].nivelAcademico, lista[i].tipoPersona,lista[i].fechaIngreso,lista[i].estado);
            }
        }

        public MantenimientoPersona(bool esadmin, string u)
        {
            InitializeComponent();
            adminPermisos(esadmin);
            log = new PersonaBO();
            lista = new List<Persona>();
            usu = u;
            verDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EditaPersona frm = new EditaPersona(usu);
            frm.ShowDialog();
            verDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult oDlgRes;
            try
            {
                id = this.tblTabla.CurrentRow.Cells[0].Value.ToString();
                oDlgRes = MessageBox.Show("¿Seguro de que desea eliminar esta persona?", "Eliminación de datos", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                if(oDlgRes == DialogResult.Yes)
                {
                    log.eliminar(id);
                    log.crearArchivo();
                    verDatos();
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
                EditaPersona frm = new EditaPersona(usu,id);
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
            List<Persona> filtrados = lista.Where(x => x.idPersona.StartsWith(txtFiltro.Text)).ToList();
            tblTabla.Rows.Clear();
            for (int i = 0; i < filtrados.Count; i++)
            {
                tblTabla.Rows.Add(filtrados[i].idPersona, filtrados[i].cedula, filtrados[i].nombre, filtrados[i].apellido1, filtrados[i].apellido2,
                    filtrados[i].nivelAcademico, filtrados[i].tipoPersona, filtrados[i].fechaIngreso, filtrados[i].estado);
            }
        }
    }
}
