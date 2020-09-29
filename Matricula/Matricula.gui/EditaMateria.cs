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
    public partial class EditaMateria : Form
    {

        private string idCarrea;
        private MateriaBO log;
        private ValidaDatos validar;

        private CarreraBO logCarrera;
        private List<Carrera> listaCarrera;

        /// <summary>
        /// Llena el comboBox con los datos de id de carrera de la lista perteneciente a las carreras
        /// </summary>
        private void cargarCombo()
        {
            logCarrera.limpiarLista();
            listaCarrera = logCarrera.getLista();
            cmbCarrera.Items.Clear();
            for (int i = 0; i < listaCarrera.Count; i++)
            {
                cmbCarrera.Items.Add(listaCarrera[i].idCarrera);
            }

        }

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
        /// Válida que los campos de texto no estén vacíos o cumplan con condiciones
        /// como el id que no puede existir para ingresarlo a registrar
        /// </summary>
        private void aceptar()
        {
            if (txtIdMateria.Text != "")
            {
                errorProvider1.SetError(txtIdMateria, "");
                if (txtNombre.Text != "")
                {
                    errorProvider1.SetError(txtNombre, "");
                    if (txtCantidadCreditos.Text != "")
                    {
                        errorProvider1.SetError(txtCantidadCreditos, "");
                        if (idCarrea != null)
                        {
                            errorProvider1.SetError(cmbCarrera, "");
                            if (txtPrecio.Text != "")
                            {
                                errorProvider1.SetError(txtPrecio, "");
                                if (txtCosto.Text != "")
                                {
                                    errorProvider1.SetError(txtCosto, "");
                                    if (log.buscarIdMateria(txtIdMateria.Text) != -1)
                                    {
                                        mensaje(txtIdMateria, "Este id ya se encuentra registrado");
                                    }
                                    else
                                    {
                                        if (log.buscarNombre(txtNombre.Text) != -1)
                                        {
                                            mensaje(txtNombre, "Este nombre ya está registrado en una materia");
                                        }
                                        else
                                        {
                                            int creditos = int.Parse(txtCantidadCreditos.Text);
                                            double precio = double.Parse(txtPrecio.Text);
                                            double costo = double.Parse(txtCosto.Text);
                                            log.agregar(txtIdMateria.Text, txtNombre.Text, creditos, idCarrea, precio, costo);
                                            log.crearArchivo();
                                            this.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    mensaje(txtCosto, "El costo de la materia es requerido");
                                }
                            }
                            else
                            {
                                mensaje(txtPrecio, "El precio de la materio es requerido");
                            }

                        }
                        else
                        {
                            errorProvider1.SetError(cmbCarrera, "Debe seleccionar un id de carrera");
                            cmbCarrera.Focus();
                            return;
                        }
                    }
                    else
                    {
                        mensaje(txtCantidadCreditos, "La cantidad de créditos de la materia es requerido");
                    }
                }
                else
                {
                    mensaje(txtNombre, "El nombre de la materia es requerido");
                }
            }
            else
            {
                mensaje(txtIdMateria, "El id de la materia es requerido");
            }
        }

        public EditaMateria()
        {
            InitializeComponent();
            lblTitulo.Text = "Materia - Agregar";
            log = new MateriaBO();
            validar = new ValidaDatos();
            listaCarrera = new List<Carrera>();
            logCarrera = new CarreraBO();
            cargarCombo();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCarrea = cmbCarrera.Text;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloLetras(e);
        }

        private void txtCantidadCreditos_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
