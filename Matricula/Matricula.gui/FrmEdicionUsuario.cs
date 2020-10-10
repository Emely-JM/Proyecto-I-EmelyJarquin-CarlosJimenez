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
    public partial class FrmEdicionUsuario : Form
    {
        private Usuario u;
        private UsuarioBO ubo;
        private PersonaBO pbo;

        string idPersona = "";

        /// <summary>
        /// Inicializa la ventana para agregar un usuario nuevo
        /// </summary>
        public FrmEdicionUsuario()
        {
            InitializeComponent();
            lblActivo.Visible = false;
            chkActivo.Visible = false;
            u = new Usuario();
            ubo = new UsuarioBO();
            pbo = new PersonaBO();
            cargarDatos();
        }

        /// <summary>
        /// Inicializa la ventana para editar un usuario existente
        /// </summary>
        /// <param name="u">
        /// Instancia de la clase Usuario
        /// </param>
        public FrmEdicionUsuario(Usuario u)
        {
            InitializeComponent();
            lblActivo.Visible = false;
            chkActivo.Visible = false;
            this.u = u;
            ubo = new UsuarioBO();
            pbo = new PersonaBO();
            cargarDatos();
        }

        /// <summary>
        /// Carga los datos de un usuario en los espacios correspondientes
        /// </summary>
        private void cargarDatos()
        {
            try
            {
                if (u.id != 0) // Verifica que sea un usuario existente
                {
                    txtCodigo.Text = u.codigo;
                    txtPersona.Text = "";
                    txtContrasena.Text = "";
                    cmbExpiraContrasena.SelectedIndex = 0;
                    chkActivo.Checked = u.activo;
                }
                else
                {
                    chkActivo.Checked = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Error al cargar los datos del cliente");
            }
        }

        /// <summary>
        /// Busca una persona existente en la aplicación según un número de cédula ingresado
        /// </summary>
        /// <returns>
        /// Instancia de la clase Persona
        /// </returns>
        private Persona buscarPersona()
        {
            Persona p = new Persona();

            foreach (Persona persona in pbo.getLista())
            {
                if (persona.cedula.Equals(txtBuscar.Text))
                {
                    p = persona;
                    idPersona = p.idPersona;
                    txtPersona.Text = p.cedula.ToString(); // Muestra el código en la ventana
                    txtBuscar.Clear();
                    break;
                }
            }
            return p;
        }


        /// <summary>
        /// Genera un código para un usuario basandose en el nombre
        /// de la persona realacionada con el usuario
        /// </summary>
        private void generarCodigo()
        {
            string codigo = "";
            int contador = 2;
            bool esIgual = true;
            Persona p = buscarPersona();

            // El código se inicializa con la primera letra del nombre,
            // primer apellido y segundo apellido de la persona
            codigo = buscarPersona().nombre.Substring(0, 1).ToUpper()
                        + buscarPersona().apellido1.Substring(0, 1).ToUpper()
                        + buscarPersona().apellido2.Substring(0, 1).ToUpper();
            esIgual = verificarCodigo(codigo);

            // Si el código inicial ya existe le sigue agregando más letras al código
            // según el nombre de la persona
            while (esIgual)
            {
                // Le agrega más letras según el nombre de la persona
                if (contador < buscarPersona().nombre.Length && esIgual)
                {
                    codigo = buscarPersona().nombre.Substring(0, contador).ToUpper();
                    esIgual = verificarCodigo(codigo);
                }
                // Le agrega más letras según el primer apellido de la persona
                if (contador < buscarPersona().apellido1.Length && esIgual)
                {
                    codigo += buscarPersona().apellido1.Substring(0, contador).ToUpper();
                    esIgual = verificarCodigo(codigo);
                }
                // Le agrega más letras según el segundo apellido de la persona
                if (contador < buscarPersona().apellido2.Length && esIgual)
                {
                    codigo += buscarPersona().apellido2.Substring(0, contador).ToUpper();
                    esIgual = verificarCodigo(codigo);
                }
                contador++;
            }
            txtCodigo.Text = codigo; // Muestra el código en la ventana
        }

        /// <summary>
        /// Verifica que el nuevo código para un usuario no sea duplicado
        /// </summary>
        /// <param name="codigo">
        /// String con el código nuevo del usuario
        /// </param>
        /// <returns>
        /// Verdadero si el código es duplicado
        /// </returns>
        private bool verificarCodigo(string codigo)
        {
            foreach (Usuario usuario in ubo.GetUsuarios())
            {
                if (usuario.codigo == codigo)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarPersona();
            generarCodigo();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                u.codigo = txtCodigo.Text;
                u.idPersona = idPersona;
                u.contrasena = txtContrasena.Text;
                u.fechaExpiraContrasena = DateTime.Now.AddDays(int.Parse(cmbExpiraContrasena.SelectedItem.ToString()));
                u.activo = chkActivo.Checked;
                ubo.guardar(u);
                Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error al agregar el usuario");
            }   
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmEdicionUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

    }
}
