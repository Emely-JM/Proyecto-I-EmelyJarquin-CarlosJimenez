using Matricula.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.dao
{
    public class MateriaDAO
    {
        List<Materias> materias = new List<Materias>();
        private string nombreArchivo = "Materias.txt";

        /// <summary>
        /// Método que escribe la lista pasada por parámetro en el archivo
        /// con el nombre especificado
        /// </summary>
        /// <param name="lista"> representa la lista de objeto que se desea escribir en el archivo </param>
        public void crearArchivo(List<Materias> lista)
        {
            try
            {
                //Pase el nombre del archivo al constructor StreamWriter
                StreamWriter sw = new StreamWriter(nombreArchivo);
                //Escribe la línea en el txt
                foreach (Materias materia in lista)
                {
                    sw.WriteLine(materia.toString());
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
        public List<Materias> leerArchivo()
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

                    string idMateria = items[0].Trim();
                    string nombre = items[1].Trim();
                    int creditos = int.Parse(items[2].Trim());
                    string idCarrera = items[3].Trim();
                    double precio = double.Parse(items[4].Trim());
                    double costo = double.Parse(items[5].Trim());
                    bool estado = bool.Parse(items[6].Trim());
                    Materias objMateria = new Materias(idMateria,nombre,creditos,idCarrera,precio,costo,estado);
                    materias.Add(objMateria);

                    //Lee la siguiente línea
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return materias;
        }
    }
}
