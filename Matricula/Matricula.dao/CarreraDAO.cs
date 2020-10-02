﻿using Matricula.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.dao
{
    public class CarreraDAO
    {
        List<Carrera> carrera = new List<Carrera>();
        private string nombreArchivo = "Carreras.txt";

        /// <summary>
        /// Método que escribe la lista pasada por parámetro en el archivo
        /// con el nombre especificado
        /// </summary>
        /// <param name="lista"> representa la lista de objeto que se desea escribir en el archivo </param>
        public void crearArchivo(List<Carrera> lista)
        {
            try
            {
                //Pase el nombre del archivo al constructor StreamWriter
                StreamWriter sw = new StreamWriter(nombreArchivo);
                //Escribe la línea en el txt
                foreach (Carrera carreras in lista)
                {
                    sw.WriteLine(carreras.toString());
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
        public List<Carrera> leerArchivo()
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
                    string idCarrera = items[0].Trim();
                    string nombre = items[1].Trim();
                    int creditosTotales = int.Parse(items[2].Trim());
                    string estado = items[3].Trim();
                    DateTime fechaApertura = DateTime.Parse(items[4].Trim());
                    DateTime fechaCierre = DateTime.Parse(items[5].Trim());

                    Carrera objCarreara = new Carrera(idCarrera,nombre,creditosTotales,estado,fechaApertura,fechaCierre);
                    carrera.Add(objCarreara);

                    //Lee la siguiente línea
                    line = sr.ReadLine();

                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return carrera;
        }
    }
}
