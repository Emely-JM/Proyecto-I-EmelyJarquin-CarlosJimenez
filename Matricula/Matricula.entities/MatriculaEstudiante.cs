using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class MatriculaEstudiante
    {
        public string idFactura { get; set; }
        public string idPersona { get; set; }
        public string idPeriodo { get; set; }
        public string idProfesor { get; set; }
        public DateTime fechaMatricula { get; set; }
        public string idMateria { get; set; }
        public string estado { get; set; }
        public string comprobante { get; set; }
        public DateTime fechaPago { get; set; }

        public MatriculaEstudiante()
        {
        }

        public MatriculaEstudiante(string idFactura, string idPersona, string idPeriodo, DateTime fechaMatricula, string idMateria, string idProfesor, string estado, string comprobante, DateTime fechaPago)
        {
            this.idFactura = idFactura;
            this.idPersona = idPersona;
            this.idPeriodo = idPeriodo;
            this.idProfesor = idProfesor;
            this.fechaMatricula = fechaMatricula;
            this.idMateria = idMateria;
            this.estado = estado;
            this.comprobante = comprobante;
            this.fechaPago = fechaPago;
        }

        public string toString()
        {
            return idFactura + "," + idPersona + "," + idPeriodo + "," + fechaMatricula + "," + idMateria + "," + idProfesor + "," + estado + "," + comprobante + "," + fechaPago;
        }

    }
}
