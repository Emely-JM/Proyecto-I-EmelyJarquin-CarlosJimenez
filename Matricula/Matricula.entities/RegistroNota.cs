using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.gui
{
    public class RegistroNota
    {
        public string idPeriodo { get; set; }
        public string idMateria { get; set; }
        public string idEstudiante { get; set; }
        public float nota { get; set; }
        public string estado { get; set; }

        public RegistroNota()
        {
        }

        public RegistroNota(string idPeriodo, string idMateria, string idEstudiante, float nota, string estado)
        {
            this.idPeriodo = idPeriodo;
            this.idMateria = idMateria;
            this.idEstudiante = idEstudiante;
            this.nota = nota;
            this.estado = estado;
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


        public string toString()
        {
            return idPeriodo + "," + idMateria + "," + idEstudiante + "," + nota + "," + estado;
        }



    }
}
