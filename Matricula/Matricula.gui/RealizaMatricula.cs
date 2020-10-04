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
    public partial class RealizaMatricula : Form
    {
        private MatriculaEstudianteBO log;
        private List<MatriculaEstudiante> lista;
        private MateriaBO logMateria;
        private List<Materias> listaMateria;
        private string idPeriodo;
        private string estado;
        private string idMateria;
        private DateTime fechaMatricula;
        private DateTime fechaPago;

        /// <summary>
        /// Método que imprime un errorProvider en el comboBox pasado por parámetro 
        /// y con el mensaje indicado en el parámetro
        /// </summary>
        /// <param name="text"> representa el comboBox al que se le dará foco para imprimir el mensaje</param>
        /// <param name="mensaje"> representa el mensaje que se desea imprimir </param>
        private void mensaje(ComboBox text, string mensaje)
        {
            errorProvider1.SetError(text, mensaje);
            text.Focus();
            return;
        }

        /// <summary>
        /// Asigna un ticket o id a las facturas que se registran según la cantidad de datos de la lista, 
        /// a cada id se le suma un dato más de los que hay en la lista
        /// </summary>
        private void asignarIdFactura()
        {
            //lista = log.getLista();
            string asiga = "F0";
            int ticket = lista.Count;
            txtIdFactura.Text = asiga + ticket.ToString();
        }

        /// <summary>
        /// Asigna un ticket o id a los comprobantes que se registran según la cantidad de datos de la lista, 
        /// a cada id se le suma un dato más de los que hay en la lista
        /// </summary>
        private void asignarComprobante()
        {  
            //lista = log.getLista();
            string asiga = "C0";
            int ticket = lista.Count;
            txtComprobante.Text = asiga + ticket.ToString();
        }

        /// <summary>
        /// LLena el combo con los datos que están en 
        /// la lista perteneciente a las materias
        /// </summary>
        private void cargarComboMateria()
        {
            listaMateria = logMateria.getLista();
            cmbMateria.Items.Clear();
            for (int i = 0; i < listaMateria.Count; i++)
            {
                cmbMateria.Items.Add(listaMateria[i].idMateria);
            }

        }

        /// <summary>
        /// Carga el id del estudiante en la caja del textBox
        /// que representa el estudiante que está matriculando
        /// </summary>
        /// <param name="id"></param>
        private void cargarIdPersona(string id)
        {
            txtIdPersona.Text = id;
        }

        /// <summary>
        /// Realiza validaciones en los comboBox's
        /// si todo está bien; manda los datos al método agregar del log
        /// </summary>
        private void aceptar()
        {
            if (idMateria != null)
            {
                errorProvider1.SetError(cmbMateria, "");
                if (log.permitirMatricula(txtIdPersona.Text, idMateria) != -1)
                {
                    mensaje(cmbMateria, "Ya se encuentra matriculado en este curso");
                }
                else
                {
                    errorProvider1.SetError(cmbMateria, "");
                    if (idPeriodo != null)
                    {
                        errorProvider1.SetError(cmbPeriodo, "");
                        if (estado != null)
                        {
                            errorProvider1.SetError(cmbEstado, "");
                            fechaMatricula = dateTimeMatricula.Value.Date;
                            fechaPago = dateTimePago.Value.Date;
                            log.agregar(txtIdFactura.Text, txtIdPersona.Text, idPeriodo, fechaMatricula, idMateria, estado, txtComprobante.Text, fechaPago);
                            log.crearArchivo();
                            this.Close();
                        }
                        else
                        {
                            mensaje(cmbEstado, "Debe seleccionar un estado");
                        }
                    }
                    else
                    {
                        mensaje(cmbPeriodo, "Debe seleccionar un periodo");
                    }
                }

            }
            else
            {
                mensaje(cmbMateria, "Debe seleccionar una materia para matricular");
            }

        }

        public RealizaMatricula(string idPersona)
        {
            InitializeComponent();
            log = new MatriculaEstudianteBO();
            lista = new List<MatriculaEstudiante>();
            logMateria = new MateriaBO();
            listaMateria = new List<Materias>();
            txtIdFactura.Enabled = false;
            txtIdPersona.Enabled = false;
            txtComprobante.Enabled = false;
            cargarIdPersona(idPersona);
            cargarComboMateria();
            asignarIdFactura();
            asignarComprobante();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            idPeriodo = cmbPeriodo.Text;
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = cmbEstado.Text;
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            idMateria = cmbMateria.Text;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }
    }
}
