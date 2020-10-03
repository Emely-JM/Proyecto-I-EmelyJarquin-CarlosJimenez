using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matricula.entities;

namespace Matricula.dao
{
    /// <summary>
    /// Contiene los métodos para leer y escribir los usuarios de la aplicación en un archivo de texto
    /// Los usuarios pertenecen a la clase Usuario
    /// </summary>
    class UsuarioDAO
    {

        private string archivo = "Usuario.txt";

        /// <summary>
        /// Lee los usuarios de la aplicación desde un archivo de texto
        /// </summary>
        /// <returns>
        /// Lista con los usuarios de la aplicación
        /// </returns>
        public List<Usuario> leer()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string linea;

            try
            {
                StreamReader sr = new StreamReader(archivo);
                linea = sr.ReadLine();

                //Ciclo para recorrer todas la líneas del archivo hasta encontrar una línea vacía
                while (linea != null)
                {
                    string[] datos = linea.Split(','); //Separa los datos del usuario
                    //Asigna los datos del usuario a una variable
                    int idUsuario = int.Parse(datos[0]);
                    string codigo = datos[1];
                    int idPersona = int.Parse(datos[2]);
                    string tipoUsuario = datos[3];
                    string contrasena = datos[4];
                    DateTime fechaExpiraContrasena = DateTime.Parse(datos[5]);
                    bool activo = bool.Parse(datos[6]);

                    //Agrega el usuario a la lista de usuarios
                    usuarios.Add(new Usuario(idUsuario, codigo, idPersona, tipoUsuario, contrasena, fechaExpiraContrasena, activo));

                    linea = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al leer el archivo");
            }
            return usuarios;
        }

        /// <summary>
        /// Escribe los usuarios de la aplicación a un archivo de texto
        /// </summary>
        /// <param name="usuarios">
        /// Lista con los usuarios de la aplicación
        /// </param>
        public void escribir(List<Usuario> usuarios)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo);

                //Ciclo para recorrer la lista de usuarios
                foreach (Usuario u in usuarios)
                {
                    sw.WriteLine(u.ToString()); //Escribe cada usuario de la lista en una línea nueva
                }
                sw.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al escribir el archivo");
            }
        }

    }
}
