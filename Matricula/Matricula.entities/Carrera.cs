using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class Carrera
    {
        public int idCarrera { get; set; }
        public string nombre { get; set; }
        public int creditosTotales { get; set; }
        public string estado { get; set; }

        private DateTime fechaApertura;
        private DateTime fechaCierre;

        public Carrera()
        {
        }

        public Carrera(int idCarrera, string nombre, int creditosTotales, string estado, DateTime fechaApertura, DateTime fechaCierre)
        {
            this.idCarrera = idCarrera;
            this.nombre = nombre;
            this.creditosTotales = creditosTotales;
            this.estado = estado;
            this.fechaApertura = fechaApertura;
            this.fechaCierre = fechaCierre;
        }


        public DateTime FechaApertura
        {
            get { return this.fechaApertura; }

            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception("La fecha ingresada no puede ser mayor a hoy");

                }
                else
                {
                    this.fechaApertura = value;
                }
            }
        }

        public DateTime FechaCierrre
        {
            get { return this.fechaCierre; }

            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception("La fecha ingresada no puede ser mayor a hoy");

                }
                else
                {
                    this.fechaCierre = value;
                }
            }
        }

        public string toString()
        {
            return this.idCarrera + "," + this.nombre + "," + this.creditosTotales + "," + this.estado + "," + this.fechaApertura + "," + fechaCierre;
        }

    }
}
