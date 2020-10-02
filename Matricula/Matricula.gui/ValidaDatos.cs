using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matricula.gui
{
    public class ValidaDatos
    {
        public void soloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))//Permite borrar
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))//Permite espaciop
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer parámetro: " + ex.StackTrace);
            }
        }

        public void soloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))//Permite borrar
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))//Permite espacio
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer parámetro: " + ex.StackTrace);
            }
        }

    }
}
