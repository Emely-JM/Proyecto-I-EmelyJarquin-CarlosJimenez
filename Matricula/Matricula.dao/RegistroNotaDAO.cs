using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matricula.entities;


namespace Matricula.dao
{
    public class RegistroNotaDAO
    {
        List<RegistroNota> notas = new List<RegistroNota>();
        private string nombreArchivo = "Notas.txt";

        /// <summary>
        /// Método que escribe la lista pasada por parámetro en el archivo
        /// con el nombre especificado
        /// </summary>
        /// <param name="lista"> representa la lista de objeto que se desea escribir en el archivo </param>
        public void crearArchivo(List<RegistroNota> lista)
        {
            try
            {
                //Pase el nombre del archivo al constructor StreamWriter
                StreamWriter sw = new StreamWriter(nombreArchivo);
                //Escribe la línea en el txt
                foreach (RegistroNota nota in lista)
                {
                    sw.WriteLine(nota.toString());
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
        public List<RegistroNota> leerArchivo()
        {
            String line;
            try
            {
                if (!File.Exists(nombreArchivo))//Sino existe lo crea
                {
                    StreamWriter sw = new StreamWriter(nombreArchivo);
                    sw.Close();
                }

                //Pase el nombre del archivo al constructor StreamWriter
                StreamReader sr = new StreamReader(nombreArchivo);
                string[] campos;

                //Lee la primera línea de texto
                line = sr.ReadLine();
                //Continua leyendo hasta llegar al final del archivo
                while (line != null)
                {
                    string[] items = line.Trim().Split(',');

                    string idPeriodo = items[0].Trim();
                    string idMateria = items[1].Trim();
                    string idEstudiante = items[2].Trim();
                    float nota = float.Parse(items[3].Trim());
                    string estado = items[4].Trim();
                    RegistroNota objNotas = new RegistroNota(idPeriodo,idMateria,idEstudiante,nota,estado);
                    notas.Add(objNotas);

                    //Lee la siguiente línea
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return notas;
        }

    }
}
