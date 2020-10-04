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
    public partial class NuevaContrasena : Form
    {
        private bool aceptar;
        string nuevaPass;

        public bool isAceptar()
        {
            return this.aceptar;
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

        public string aceptarButton()
        {
            if (txtContrasena1.Text != "")
            {
                errorProvider1.SetError(txtContrasena1, "");
                if (txtContrasena2.Text != "")
                {
                    errorProvider1.SetError(txtContrasena2, "");
                    if (txtContrasena1.Text.Equals(txtContrasena2.Text))
                    {
                        nuevaPass = txtContrasena1.Text;
                        this.aceptar = true;
                        this.Close();
                    }
                    else
                    {
                        mensaje(txtContrasena2, "Las contraseñas no coincides");
                    }
                }
                else
                {
                    mensaje(txtContrasena2, "Debe confirmar la contraseña");
                }
            }
            else
            {
                mensaje(txtContrasena1, "Contraseña es requerida");
            }
            return nuevaPass;
        }

        public NuevaContrasena()
        {
            InitializeComponent();
            aceptar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aceptarButton();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
