using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class Evaluacion
    {
        public string idEvalucion { get; set; }
        public string descripcion { get; set; }
        public string idEstudiante { get; set; }
        public string idMateria { get; set; }
        public string estado { get; set; }


        public DateTime fechaEvaluacion { get; set; }

        public Evaluacion()
        {
        }

        public Evaluacion(string idEvalucion, string descripcion, string idEstudiante, string idMateria, string estado, DateTime fechaEvaluacion)
        {
            this.idEvalucion = idEvalucion;
            this.descripcion = descripcion;
            this.idEstudiante = idEstudiante;
            this.idMateria = idMateria;
            this.estado = estado;
            this.fechaEvaluacion = fechaEvaluacion;
        }

        public string toString()
        {
            return idEvalucion + "," + descripcion + "," + idEstudiante + "," + idMateria + "," + estado + "," + fechaEvaluacion;
        }
    }
}
