using Matricula.dao;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.bo
{
    public class RegistroNotaBO
    {
        List<RegistroNota> proceso;
        RegistroNotaDAO objArchivo;
        RegistroNota nota;
        public RegistroNotaBO()
        {
            proceso = new List<RegistroNota>();
            objArchivo = new RegistroNotaDAO();
            proceso = objArchivo.leerArchivo();
            nota = new RegistroNota();
        }

        /// <summary>
        /// Agrega los datos pasados por parámetro al constructor de RegistroNota e ingresa los datos del
        /// constructor a la lista
        /// </summary>
        /// <param name="idPeriodo"> representa el periodo en el cuál se registra la nota </param>
        /// <param name="idMateria"> id de la materia a calificar </param>
        /// <param name="idEstudiante"> id del estudiante a calificar </param>
        /// <param name="nota"> nota obtenida </param>
        /// <param name="estado"> estado del estudiante según la nota obtenida </param>
        public void agregar(string idPeriodo, string idMateria, string idEstudiante, float nota, string estado)
        {
            proceso.Add(new RegistroNota(idPeriodo, idMateria, idEstudiante, nota, estado));
        }

        /// <summary>
        /// Busca el id de la materia, estudiante y periodo para válidar que
        /// no se califiqué dos veces el mismo estudiante en la misma materia y
        /// periodo
        /// </summary>
        /// <param name="idPeriodo"> id del periodo que se desea calificar </param>
        /// <param name="idEstudiante"> id del estudiante que se desea calificar </param>
        /// <param name="idMateria"> id de la materia que se desea calificar </param>
        /// <returns> retorna un indice si encuentra los datos o un -1 sino </returns>
        public int permitirNota(string idPeriodo, string idEstudiante, string idMateria)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (proceso[i].idPeriodo.Equals(idPeriodo) && proceso[i].idEstudiante.Equals(idEstudiante))
                {
                    if (proceso[i].idMateria.Equals(idMateria))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Calcula la nota de los estudiantes según los datos obtenidos
        /// </summary>
        /// <param name="proyectos"> representa la cantidad de puntos ganados en proyectos </param>
        /// <param name="laboratorios"> representa la cantidad de puntos ganados en laboratorios </param>
        /// <param name="examenes"> representa la cantidad de puntos ganados en examenes </param>
        /// <param name="pruebasCortas"> representa la cantidad de puntos ganados en pruebas cortas</param>
        /// <returns></returns>
        public float calculaNota(int proyectos, int laboratorios, int examenes, int pruebasCortas)
        {
            float resultado = 0;
            resultado = (proyectos + laboratorios + examenes + pruebasCortas) / 4;
            return resultado;
        }

        /// <summary>
        /// Llama al método de crear archivo y le pasa la lista
        /// de proceso como parámetro para escribirla en archivo
        /// </summary>
        public void crearArchivo()
        {
            objArchivo.crearArchivo(proceso);
        }

        /// <summary>
        /// Método que obtiene la lista de la clase RegistroNota
        /// </summary>
        /// <returns> retorna la lista cargada con los datos del archivo </returns>
        public List<RegistroNota> getLista()
        {
            limpiarLista();
            return proceso = objArchivo.leerArchivo();

        }

        /// <summary>
        /// Limpia los datos de la lista
        /// </summary>
        private void limpiarLista()
        {
            proceso.Clear();
        }

    }
}
