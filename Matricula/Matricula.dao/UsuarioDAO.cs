using Matricula.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.dao
{
    /// <summary>
    /// Contiene los métodos para leer y escribir los usuarios de la aplicación en un archivo de texto
    /// Los usuarios pertenecen a la clase Usuario
    /// </summary>
    public class UsuarioDAO
    {
        List<Usuario> usuarios = new List<Usuario>();
        private string archivo = "Usuario.txt";

        /// <summary>
        /// Escribe los usuarios de la aplicación a un archivo de texto
        /// </summary>
        /// <param name="usuarios">
        /// Lista con los usuarios de la aplicación
        /// </param>
        public void escribir()
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo);

                // Ciclo para recorrer la lista de usuarios
                foreach (Usuario u in usuarios)
                {
                    sw.WriteLine(u.ToString()); // Escribe cada usuario de la lista en una línea nueva
                }
                sw.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al escribir el archivo");
            }
        }

        /// <summary>
        /// Agrega un usuario nuevo a la aplicación
        /// </summary>
        /// <param name="u">
        /// Isntancia de la clase Usuario
        /// </param>
        public void agregar(Usuario u)
        {
            try
            {
                GetUsuarios();

                // Obtiene el id del último usuario de la lista, le suma un número más
                // y se lo asigna al nuevo usuario
                int ultimo = usuarios.Count();
                int id = 1;
                if (ultimo != 0)
                {
                    id = usuarios[ultimo - 1].id + 1;
                }
                u.id = id;

                usuarios.Add(u);
                escribir();
            }
            catch (Exception)
            {
                throw new Exception("Error al agregar el usuario");
            }
        }

        /// <summary>
        /// Edita los datos de un usuario existente
        /// </summary>
        /// <param name="u">
        /// Isntancia de la clase Usuario
        /// </param>
        public void editar(Usuario u)
        {
            try
            {
                GetUsuarios();

                // Ciclo para recorrer la lista de usuarios
                foreach (Usuario usuario in usuarios)
                {
                    if (u.id == usuario.id)
                    {
                        // Sobreescribe los datos de un usuario existente con los datos nuevos
                        usuario.codigo = u.codigo;
                        usuario.idPersona = u.idPersona;
                        usuario.fechaExpiraContrasena = u.fechaExpiraContrasena;
                        usuario.activo = u.activo;
                        break;
                    }
                }
                escribir();
            }
            catch (Exception)
            {
                throw new Exception("Error al editar el usuario");
            }
        }

        /// <summary>
        /// Desactiva un usuario de la aplicación
        /// </summary>
        /// <param name="u">
        /// Isntancia de la clase Usuario
        /// </param>
        public void eliminar(Usuario u)
        {
            try
            {
                GetUsuarios();

                // Ciclo para recorrer la lista de usuarios
                foreach (Usuario usuario in usuarios)
                {
                    if (u.id == usuario.id)
                    {
                        usuario.activo = false; // Desactiva un usuario
                        break;
                    }
                }
                escribir();
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar el usuario");
            }
        }

        /// <summary>
        /// Cambia la contraseña de un usuario
        /// </summary>
        /// <param name="u">
        /// Isntancia de la clase Usuario
        /// </param>
        public void cambiarContrasena(Usuario u)
        {
            try
            {
                GetUsuarios();

                // Ciclo para recorrer la lista de usuarios
                foreach (Usuario usuario in usuarios)
                {
                    if (u.id == usuario.id)
                    {
                        usuario.contrasena = u.contrasena;
                        usuario.fechaExpiraContrasena = u.fechaExpiraContrasena;
                        break;
                    }
                }
                escribir();
            }
            catch (Exception)
            {
                throw new Exception("Error al cambiar la contraseña del usuario");
            }
        }

        /// <summary>
        /// Lee los usuarios de la aplicación desde un archivo de texto
        /// </summary>
        /// <returns>
        /// Lista con los usuarios de la aplicación
        /// </returns>
        public List<Usuario> GetUsuarios()
        {
            string linea;

            try
            {
                StreamReader sr = new StreamReader(archivo);
                linea = sr.ReadLine();

                // Ciclo para recorrer todas la líneas del archivo hasta encontrar una línea vacía
                while (linea != null)
                {
                    string[] datos = linea.Split(','); // Separa los datos del usuario
                    // Asigna los datos del usuario a una variable
                    int idUsuario = int.Parse(datos[0]);
                    string codigo = datos[1];
                    string idPersona = datos[2];
                    string contrasena = datos[3];
                    DateTime fechaExpiraContrasena = DateTime.Parse(datos[4]);
                    bool activo = bool.Parse(datos[5]);

                    // Agrega el usuario a la lista de usuarios
                    usuarios.Add(new Usuario(idUsuario, codigo, idPersona, contrasena, fechaExpiraContrasena, activo));

                    linea = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error al cargar los usuarios");
            }
            return usuarios;
        }

        /// <summary>
        /// Verifica que los datos de inicio de sesión coincidan con los de un usuario existente
        /// </summary>
        /// <param name="u">
        /// Instancia de la clase Usuario
        /// </param>
        /// <returns>
        /// Un usuario si el inicio de sesión es exitoso
        /// </returns>
        public Usuario iniciarSesion(Usuario u)
        {
            try
            {
                foreach (Usuario usuario in GetUsuarios())
                {
                    if (u.codigo == usuario.codigo && u.contrasena == u.contrasena)
                    {
                        if (DateTime.Compare(u.fechaExpiraContrasena, DateTime.Now) > 0)
                        {
                            throw new Exception("La contraseña ha caducado" + Environment.NewLine
                                + "Solicitar a un administrador una nueva contraseña");
                        }
                        else
                        {
                            return usuario;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al iniciar sesión");
            }
            return null;
        }

    }
}
