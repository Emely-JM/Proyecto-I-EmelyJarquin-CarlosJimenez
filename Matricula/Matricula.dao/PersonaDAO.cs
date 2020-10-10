using Matricula.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.dao
{
    public class PersonaDAO
    {
        List<Persona> personas = new List<Persona>();
        private string nombreArchivo = "Personas.txt";

        /// <summary>
        /// Método que escribe la lista pasada por parámetro en el archivo
        /// con el nombre especificado
        /// </summary>
        /// <param name="lista"> representa la lista de objeto que se desea escribir en el archivo </param>
        public void crearArchivo(List<Persona> lista)
        {
            try
            {
                //Pase el nombre del archivo al constructor StreamWriter
                StreamWriter sw = new StreamWriter(nombreArchivo);
                //Escribe la línea en el txt
                foreach (Persona persona in lista)
                {
                    sw.WriteLine(persona.toString());
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        /// <summary>
        /// Método que lee el archivo que se asigna al StreamReader y lo ingresa en una lista
        /// </summary>
        /// <returns> retorna una lista de objeto cargada con los datos del archivo </returns>
        public List<Persona> leerArchivo()
        {
            String line;
            try
            {
                //Pase el nombre del archivo al constructor StreamWriter
                StreamReader sr = new StreamReader(nombreArchivo);
                string[] campos;

                //Lee la primera línea de texto
                line = sr.ReadLine();
                //Continua leyendo hasta llegar al final del archivo
                while (line != null)
                {
                    string[] items = line.Trim().Split(',');

                    string idPersona = items[0].Trim();
                    string cedula = items[1].Trim();
                    string nombre = items[2].Trim();
                    string apellido1 = items[3].Trim();
                    string apellido2 = items[4].Trim();
                    char sexo = char.Parse(items[5].Trim());
                    DateTime fechaNacimiento = DateTime.Parse(items[6].Trim());
                    string nivelAcademico = items[7].Trim();
                    DateTime fechaIngreso = DateTime.Parse(items[8].Trim());
                    string usuarioRegistro = items[9].Trim();
                    string tipoPersona = items[10].Trim();
                    string nacionalidad = items[11].Trim();
                    string estado = items[12].Trim();

                    Persona objPersona = new Persona(idPersona, cedula, nombre, apellido1, apellido2, sexo, fechaNacimiento, nivelAcademico, fechaIngreso, usuarioRegistro, tipoPersona, nacionalidad, estado);
                    personas.Add(objPersona);

                    //Lee la siguiente línea
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return personas;
        }
    }
}
