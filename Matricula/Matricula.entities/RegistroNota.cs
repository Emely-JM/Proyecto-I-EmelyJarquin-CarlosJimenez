using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
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


        public string toString()
        {
            return idPeriodo + "," + idMateria + "," + idEstudiante + "," + nota + "," + estado;
        }



    }
}
