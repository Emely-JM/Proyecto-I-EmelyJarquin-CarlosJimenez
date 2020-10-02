using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class Materias
    {
        public string idMateria { get; set; }
        public string nombre { get; set; }
        public int cantidadCreditos { get; set; }
        public string idCarrera { get; set; }
        public double precio { get; set; }
        public double costo { get; set; }

        public Materias()
        {
        }

        public Materias(string idMateria, string nombre, int cantidadCreditos, string idCarrera, double precio, double costo)
        {
            this.idMateria = idMateria;
            this.nombre = nombre;
            this.cantidadCreditos = cantidadCreditos;
            this.idCarrera = idCarrera;
            this.precio = precio;
            this.costo = costo;
        }

        public string toString()
        {
            return idMateria + "," + nombre + "," + cantidadCreditos + "," + idCarrera + "," + precio + "," + costo;
        }
    }
}
