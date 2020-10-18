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
        private ValidaDatos validar;

        private string idPersona;

        /// <summary>
        /// Inicializa la ventana para agregar un usuario nuevo
        /// </summary>
        public FrmEdicionUsuario()
        {
            InitializeComponent();
            txtContrasena.Enabled = true;
            txtConfirmarContrasena.Enabled = true;
            chkActivo.Enabled = false;
            u = new Usuario();
            ubo = new UsuarioBO();
            pbo = new PersonaBO();
            validar = new ValidaDatos();
            idPersona = "";
            cargarDatos();
            cmbExpiraContrasena.SelectedIndex = 0;
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
            txtContrasena.Enabled = false;
            txtConfirmarContrasena.Enabled = false;
            chkActivo.Enabled = true;
            this.u = u;
            ubo = new UsuarioBO();
            pbo = new PersonaBO();
            validar = new ValidaDatos();
            idPersona = u.idPersona;
            cargarDatos();
            cmbExpiraContrasena.SelectedIndex = 0;
        }

        /// <summary>
        /// Método que imprime un errorProvider en el textBox pasado por parámetro 
        /// y con el mensaje indicado en el parámetro
        /// </summary>
        /// <param name="text"> representa el textBox al que se le dará foco para imprimir el mensaje</param>
        /// <param name="mensaje"> representa el mensaje que se desea imprimir </param>
        private void mensaje(TextBox text, string mensaje)
        {
            errorProvider.SetError(text, mensaje);
            text.Focus();
            return;
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
                    foreach (Persona p in pbo.getLista())
                    {
                        if (p.idPersona.Equals(u.idPersona))
                        {
                            txtPersona.Text = p.cedula;
                            break;
                        }
                    }
                    txtCodigo.Text = u.codigo;
                    chkActivo.Checked = u.activo;
                }
                else
                {
                    chkActivo.Checked = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos del usuario", "Datos del usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Busca una persona existente en la aplicación según un número de cédula ingresado
        /// </summary>
        private void buscarPersona()
        {
            Persona p = new Persona();

            foreach (Persona persona in pbo.getLista())
            {
                if (persona.cedula.Equals(txtBuscarPersona.Text))
                {
                    p = persona;
                    idPersona = p.cedula;
                    txtPersona.Text = p.cedula.ToString(); // Muestra el código en la ventana
                    generarCodigo(p);
                    txtBuscarPersona.Clear();
                    break;
                }
            }
            txtBuscarPersona.Clear();
        }

        /// <summary>
        /// Genera un código para un usuario basandose en el nombre
        /// de la persona realacionada con el usuario
        /// </summary>
        /// <param name="p">
        /// Instancia de la clase Persona
        /// </param>
        private void generarCodigo(Persona p)
        {
            string codigo = "";
            int contador1 = 1;
            int contador2 = 1;
            int posicion = contador1;
            bool esIgual = true;

            int indice = p.nombre.IndexOf(" "); // Posición de un espacio en blanco si la persona tiene dos nombres
            string nombre1 = p.nombre;
            string nombre2 = "";

            // Si la persona tiene dos nombres, separa el nombre en dos variables diferentes
            if (indice != -1)
            {
                nombre1 = p.nombre.Substring(0, indice);
                nombre2 = p.nombre.Substring(indice + 1);
            }

            // Genera el código inicial
            codigo = nombre1.Substring(0, 1).ToUpper()
                + p.apellido1.Substring(0, 1).ToUpper()
                + p.apellido2.Substring(0, 1).ToUpper();
            if (nombre2 != "")
            {
                codigo = codigo.Insert(1, nombre2.Substring(0, 1).ToUpper());
            }
            esIgual = verificarCodigo(codigo);

            // Mientras exista un usuario con un código igual al generado,
            // se le van insertando letras al código según el nombre de la persona
            while (esIgual)
            {
                if (esIgual && contador2 == 1 && contador1 < nombre1.Length)
                {
                    codigo = codigo.Insert(posicion, nombre1[contador1].ToString().ToUpper());
                    contador2++;
                    posicion += contador1 + 1;
                    esIgual = verificarCodigo(codigo);
                }
                if (esIgual && contador2 == 2 && contador1 < nombre2.Length && nombre2 != "")
                {
                    codigo = codigo.Insert(posicion, nombre2[contador1].ToString().ToUpper());
                    contador2++;
                    posicion += contador1 + 1;
                    esIgual = verificarCodigo(codigo);
                }
                if (esIgual && contador2 == 3 && contador1 < p.apellido1.Length)
                {
                    codigo = codigo.Insert(posicion, p.apellido1[contador1].ToString().ToUpper());
                    contador2++;
                    posicion += contador1 + 1;
                    esIgual = verificarCodigo(codigo);
                }
                if (esIgual && contador2 == 4 && contador1 < p.apellido2.Length)
                {
                    codigo = codigo.Insert(posicion, p.apellido2[contador1].ToString().ToUpper());
                    esIgual = verificarCodigo(codigo);
                }
                contador1++;
                contador2 = 1;
                posicion = contador1;
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
            foreach (Usuario usuario in ubo.GetUsuarios(""))
            {
                if (usuario.codigo == codigo && usuario.id != u.id)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarPersona();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodigo.Text))
                {
                    errorProvider.SetError(txtCodigo, "");
                    if (txtContrasena.Text.Equals(txtConfirmarContrasena.Text))
                    {
                        u.codigo = txtCodigo.Text;
                        u.idPersona = idPersona;
                        u.contrasena = txtContrasena.Text;
                        u.fechaExpiraContrasena = DateTime.Now.AddDays(int.Parse(cmbExpiraContrasena.SelectedItem.ToString().Substring(0, 2)));
                        u.activo = chkActivo.Checked;
                        ubo.guardar(u);
                        Dispose();
                    }
                    else
                    {
                        txtContrasena.Clear();
                        txtConfirmarContrasena.Clear();
                        MessageBox.Show("Las contraseñas ingresadas no coinciden", "Error de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    mensaje(txtCodigo, "El código es requerido");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de edición de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de edición de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtBuscarPersona_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }
    }
}
