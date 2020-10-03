using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class Matricula
    {
        public string idFactura { get; set; }
        public string idPersona { get; set; }
        public string idPeriodo { get; set; }
        public DateTime fechaMatricula { get; set; }
        public string estado { get; set; }
        public string comprobante { get; set; }
        public DateTime fechaPago { get; set; }

        public Matricula()
        {
        }

        public Matricula(string idFactura, string idPersona, string idPeriodo, DateTime fechaMatricula, string estado, string comprobante, DateTime fechaPago)
        {
            this.idFactura = idFactura;
            this.idPersona = idPersona;
            this.idPeriodo = idPeriodo;
            this.fechaMatricula = fechaMatricula;
            this.estado = estado;
            this.comprobante = comprobante;
            this.fechaPago = fechaPago;
        }

        public string toString()
        {
            return idFactura + "," + idPersona + "," + idPeriodo + "," + fechaMatricula + "," + estado + "," + comprobante + "," + fechaPago;
        }

    }
}
