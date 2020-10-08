using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class Asignacion
    {
        public int id { get; set; }
        public string idProf { get; set; }
        public string idMateria { get; set; }

        public Asignacion()
        {
        }

        public Asignacion(int id, string idProf, string idMateria)
        {
            this.id = id;
            this.idProf = idProf;
            this.idMateria = idMateria;
        }

        public string toString()
        {
            return id + "," + idProf + "," + idMateria;
        }

    }
}
