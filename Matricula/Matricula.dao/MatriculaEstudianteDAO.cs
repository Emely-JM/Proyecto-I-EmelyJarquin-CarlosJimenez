using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matricula.entities;

namespace Matricula.dao
{
    public class MatriculaEstudianteDAO
    {
        List<MatriculaEstudiante> matriculas = new List<MatriculaEstudiante>();
        private string nombreArchivo = "Matriculas.txt";

        /// <summary>
        /// Método que escribe la lista pasada por parámetro en el archivo
        /// con el nombre especificado
        /// </summary>
        /// <param name="lista"> representa la lista de objeto que se desea escribir en el archivo </param>
        public void crearArchivo(List<MatriculaEstudiante> lista)
        {
            try
            {
                //Pase el nombre del archivo al constructor StreamWriter
                StreamWriter sw = new StreamWriter(nombreArchivo);
                //Escribe la línea en el txt
                foreach (MatriculaEstudiante matricula in lista)
                {
                    sw.WriteLine(matricula.toString());
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
        public List<MatriculaEstudiante> leerArchivo()
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

                    string idFactura = items[0].Trim();
                    string idPersona = items[1].Trim();
                    string idPeriodo = items[2].Trim();
                    DateTime fechaMatricula = DateTime.Parse(items[3].Trim());
                    string estado = items[4].Trim();
                    string comprobante = items[5].Trim();
                    DateTime fechaPago = DateTime.Parse(items[6].Trim());

                    MatriculaEstudiante objMatricula = new MatriculaEstudiante(idFactura,idPersona,idPeriodo,fechaMatricula,estado,comprobante,fechaPago);
                    matriculas.Add(objMatricula);

                    //Lee la siguiente línea
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return matriculas;
        }

    }
}
