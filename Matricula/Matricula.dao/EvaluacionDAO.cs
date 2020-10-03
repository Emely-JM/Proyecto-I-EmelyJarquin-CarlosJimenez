using Matricula.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.dao
{
    public class EvaluacionDAO
    {
        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        private string nombreArchivo = "Evaluaciones.txt";

        /// <summary>
        /// Método que escribe la lista pasada por parámetro en el archivo
        /// con el nombre especificado
        /// </summary>
        /// <param name="lista"> representa la lista de objeto que se desea escribir en el archivo </param>
        public void crearArchivo(List<Evaluacion> lista)
        {
            try
            {
                //Pase el nombre del archivo al constructor StreamWriter
                StreamWriter sw = new StreamWriter(nombreArchivo);
                //Escribe la línea en el txt
                foreach (Evaluacion evalacion in lista)
                {
                    sw.WriteLine(evalacion.toString());
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
        public List<Evaluacion> leerArchivo()
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

                    string idEvaluacion = items[0].Trim();
                    string descripcion = items[1].Trim();
                    string idEstudiante = items[2].Trim();
                    string idMateria = items[3].Trim();
                    string estado = items[4].Trim();
                    DateTime fechaEvaluacion = DateTime.Parse(items[5].Trim());
                    Evaluacion objEvaluacion = new Evaluacion(idEvaluacion,descripcion,idEstudiante,idMateria,estado,fechaEvaluacion);
                    evaluaciones.Add(objEvaluacion);

                    //Lee la siguiente línea
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return evaluaciones;
        }
    }
}
