using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class Admin
    {
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public bool admin { get; set; }
        public bool activo { get; set; }

        public Admin()
        {
            this.activo = true;

        }

        public Admin(string usuario, string nombre, string correo, string contrasena, bool admin, bool activo)
        {
            this.usuario = usuario;
            this.nombre = nombre;
            this.correo = correo;
            this.contrasena = contrasena;
            this.admin = admin;
            this.activo = activo;
        }

        public string toString()
        {
            return this.usuario + "," + this.nombre + "," + this.correo +
                "," + this.contrasena + "," + this.admin + "," + this.activo;
        }
    }
}
