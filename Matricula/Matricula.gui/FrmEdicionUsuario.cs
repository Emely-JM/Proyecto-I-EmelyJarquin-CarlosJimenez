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

        private void cargarDatos()
        {
            try
            {
                if (u.id != 0)
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
            catch (Exception)
            {
               throw new Exception("Error al cargar los datos del cliente");
            }
        }

        private Persona buscarPersona()
        {
            Persona p = new Persona();
            foreach (Persona persona in pbo.getLista())
            {
                if (persona.cedula == int.Parse(txtBuscar.Text))
                {
                    p = persona;
                    idPersona = p.idPersona;
                    txtCodigo.Text = p.cedula.ToString();
                    txtBuscar.Clear();
                    break;
                }
            }
            return p;
        }

        private string generarCodigo()
        {
            string codigo = "";
            int contador = 1;
            bool esIgual = true;
            Persona p = buscarPersona();

            while (esIgual)
            {
                if (contador < p.nombre.Length && esIgual)
                {
                    codigo = p.nombre.Substring(0, contador).ToUpper();
                    esIgual = verificarCodigo(codigo);
                }
                if (contador < p.apellido1.Length && esIgual)
                {
                    codigo += p.apellido1.Substring(0, contador).ToUpper();
                    esIgual = verificarCodigo(codigo);
                }
                if (contador < p.apellido2.Length && esIgual)
                {
                    codigo += p.apellido2.Substring(0, contador).ToUpper();
                    esIgual = verificarCodigo(codigo);
                }
                contador++;
            }
            return codigo;
        }

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
            txtCodigo.Text = generarCodigo();
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
