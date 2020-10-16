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
        private MateriaBO log;
        private List<Materias> listaM;
        private ValidaDatos validar;
        private CarreraBO logCarrera;
        private List<Carrera> listaCarrera;
        private string id;
        private int creditos;
        private double precio;
        private double costo;
        private Form parent;

        /// <summary>
        /// Llena el comboBox con los datos de id de carrera de la lista perteneciente a las carreras
        /// </summary>
        private void cargarCombo()
        {
            listaCarrera = logCarrera.getLista();
            cmbCarrera.Items.Clear();
            DateTime FechAc = DateTime.Now.Date;
            for (int i = 0; i < listaCarrera.Count; i++)
            {
                if (listaCarrera[i].estado.Equals("En Oferta"))
                {
                    if(FechAc <= listaCarrera[i].FechaCierrre.Date)
                    {
                        cmbCarrera.Items.Add(listaCarrera[i].idCarrera);
                        cmbCarrera.SelectedIndex = 0;
                    }
                    
                }
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
            if (buscar(id) != true)
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
                                            creditos = int.Parse(txtCantidadCreditos.Text);
                                            precio = double.Parse(txtPrecio.Text);
                                            costo = double.Parse(txtCosto.Text);
                                            log.agregar(txtIdMateria.Text, txtNombre.Text, creditos, cmbCarrera.Text, precio, costo, chkActivo.Checked);
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
            else
            {
                creditos = int.Parse(txtCantidadCreditos.Text);
                precio = double.Parse(txtPrecio.Text);
                costo = double.Parse(txtCosto.Text);
                log.modificar(id, txtIdMateria.Text, txtNombre.Text, creditos, cmbCarrera.Text, precio, costo, chkActivo.Checked);
                log.crearArchivo();
                this.Close();
            }
        }

        /// <summary>
        /// Busca los datos relacionados al id retorna el indice o -1 de no encontrarlos
        /// </summary>
        /// <param name="Id"> id de materia a buscar </param>
        /// <returns> retorna el indice o -1 si no lo encuentra</returns>
        private bool buscar(string Id)
        {
            bool busca = false;
            if (log.buscarIdMateria(Id) != -1)
            {
                busca = true;
            }
            return busca;

        }

        /// <summary>
        /// Carga los datos del id a editar
        /// </summary>
        public void cargar()
        {
            listaM = log.getLista();
            for (int i = 0; i < listaM.Count; i++)
            {
                if (listaM[i].idMateria.Equals(id))
                {
                    txtIdMateria.Text = listaM[i].idMateria;
                    txtNombre.Text = listaM[i].nombre;
                    txtCantidadCreditos.Text = listaM[i].cantidadCreditos.ToString();
                    cmbCarrera.Text = listaM[i].idCarrera;
                    txtPrecio.Text = listaM[i].precio.ToString();
                    txtCosto.Text = listaM[i].costo.ToString();
                    chkActivo.Checked = listaM[i].estado;
                }
            }
        }


        public EditaMateria(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            lblTitulo.Text = "Materia - Agregar";
            log = new MateriaBO();
            validar = new ValidaDatos();
            listaCarrera = new List<Carrera>();
            logCarrera = new CarreraBO();
            cargarCombo();
            chkActivo.Visible = false;
            chkActivo.Checked = true;
        }

        public EditaMateria(Form parent, string idMateria)
        {
            InitializeComponent();
            this.parent = parent;
            lblTitulo.Text = "Materia - Editar";
            log = new MateriaBO();
            validar = new ValidaDatos();
            listaCarrera = new List<Carrera>();
            logCarrera = new CarreraBO();
            listaM = new List<Materias>();
            cargarCombo();
            chkActivo.Visible = true;
            id = idMateria;
            cargar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
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

        private void EditaMateria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (parent != null)
            {
                parent.Visible = true;
            }
        }
    }
}
