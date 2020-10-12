using Matricula.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.dao
{
    public class AsignacionDAO
    {
        List<Asignacion> asignaciones = new List<Asignacion>();
        private string nombreArchivo = "Asignacion.txt";

        /// <summary>
        /// Método que escribe la lista pasada por parámetro en el archivo
        /// con el nombre especificado
        /// </summary>
        /// <param name="lista"> representa la lista de objeto que se desea escribir en el archivo </param>
        public void crearArchivo(List<Asignacion> lista)
        {
            try
            {
                //Pase el nombre del archivo al constructor StreamWriter
                StreamWriter sw = new StreamWriter(nombreArchivo);
                //Escribe la línea en el txt
                foreach (Asignacion asig in lista)
                {
                    sw.WriteLine(asig.toString());
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
        public List<Asignacion> leerArchivo()
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
                    int id = int.Parse(items[0].Trim());
                    string idProf = items[1].Trim();
                    string idMateria = items[2].Trim();
                    Asignacion objAsignacions = new Asignacion(id,idProf,idMateria);
                    asignaciones.Add(objAsignacions);

                    //Lee la siguiente línea
                    line = sr.ReadLine();

                }
                sr.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return asignaciones;
        }

    }
}
