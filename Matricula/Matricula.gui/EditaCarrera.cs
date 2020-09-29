using Matricula.bo;
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
    public partial class EditaCarrera : Form
    {
        CarreraBO log;
        ValidaDatos validar;
        private string estado;
        private string Id;

        /// <summary>
        /// Método que imprime un errorProvider en el textBox pasado por parámetro 
        /// y con el mensaje indicado en el parámetro
        /// </summary>
        /// <param name="text"> representa el textBox al que se le dará foco para imprimir el mensaje</param>
        /// <param name="mensaje"> representa el mensaje que se desea imprimir </param>
        private void mensaje(TextBox text, string mensaje)
        {
            errorProvider1.SetError(text, mensaje);
            text.Focus();
            return;
        }

        /// <summary>
        /// Válida que los textBox cumplan con ciertas condiciones como no estar vacíos 
        /// e ingresar correos válidos, además válida que se seleccione un opción del comboBox
        /// Agrega los datos al método de agregar de CarreraBO
        /// </summary>
        private void aceptar()
        {
            if (buscar(Id) != true)
            {
                if (txtId.Text != "")
                {
                    errorProvider1.SetError(txtId, "");
                    if (txtNombre.Text != "")
                    {
                        errorProvider1.SetError(txtNombre, "");
                        if (txtCreditos.Text != "")
                        {
                            errorProvider1.SetError(txtCreditos, "");
                            if (log.buscarNombre(txtNombre.Text) != -1)
                            {
                                mensaje(txtNombre, "Ya existe una carrera con este nombre");
                            }
                            else
                            {
                                errorProvider1.SetError(txtNombre, "");
                                if (log.buscarId(txtId.Text) != -1)
                                {
                                    mensaje(txtId, "Ya existe una carrera con este id");
                                }
                                else
                                {
                                    errorProvider1.SetError(txtId, "");
                                    if (estado != null)
                                    {
                                        errorProvider1.SetError(cmbEstado, "");
                                        DateTime apertura = datetimeApertura.Value.Date;
                                        DateTime cierre = dateTimeCierre.Value.Date;
                                        int creditos = int.Parse(txtCreditos.Text);
                                        log.agregar(txtId.Text, txtNombre.Text, creditos, estado, apertura, cierre);
                                        log.crearArchivo();
                                        this.Close();
                                    }
                                    else
                                    {
                                        errorProvider1.SetError(cmbEstado, "Debe seleccionar un estado");
                                        cmbEstado.Focus();
                                        return;
                                    }

                                }


                            }
                        }
                        else
                        {
                            mensaje(txtCreditos, "Total de créditos es requerido");
                        }
                    }
                    else
                    {
                        mensaje(txtNombre, "Nombre de carrerea es requerido");
                    }
                }
                else
                {
                    mensaje(txtId, "Id es requerido");
                }
            }
            else
            {
                DateTime apertura = datetimeApertura.Value.Date;
                DateTime cierre = dateTimeCierre.Value.Date;
                int creditos = int.Parse(txtCreditos.Text);
                log.modificar(Id,txtId.Text,txtNombre.Text,creditos,estado,apertura,cierre);
                log.crearArchivo();
                this.Close();
            }
        }

        /// <summary>
        /// Método que llama al método correspondiente para buscar el id y 
        /// decidir si debe ingresar o actualizar los datos
        /// </summary>
        /// <param name="id"> id ha buscar </param>
        /// <returns> retorna true si encuentra el id </returns>
        private bool buscar(string id)
        {
            bool busca = false;
            if (log.buscarId(id) != -1)
            {
                busca = true;
            }
            return busca;
        }


        public EditaCarrera()
        {
            InitializeComponent();
            log = new CarreraBO();
            validar = new ValidaDatos();
            lblTitulo.Text = "Carrera - Agregar";
        }

        public EditaCarrera(string id, string nombre, int creditos, string estado, DateTime apertura, DateTime cierre)
        {
            InitializeComponent();
            log = new CarreraBO();
            validar = new ValidaDatos();
            lblTitulo.Text = "Carrera - Editar";
            Id = id;
            txtId.Text = id;
            txtNombre.Text = nombre;
            txtCreditos.Text = creditos.ToString();
            cmbEstado.SelectedItem = estado;
            cmbEstado.Text = estado;
            datetimeApertura.Value = apertura;
            dateTimeCierre.Value = cierre;

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloLetras(e);
        }

        private void txtCreditos_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = cmbEstado.Text;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }
    }
}
