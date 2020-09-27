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

        public String Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public String Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public String Correo
        {
            get { return this.correo; }
            set { this.correo = value; }
        }

        public String Contrasena
        {
            get { return this.contrasena; }
            set { this.contrasena = value; }
        }

        public Boolean Administrador
        {
            get { return this.admin; }
            set { this.admin = value; }
        }

        public Boolean Activo
        {
            get { return this.activo; }
            set { this.activo = value; }
        }

        /// <summary>
        /// Retorna el nombre y entre parentesis el usuario
        /// </summary>
        /// <returns>strign nombre(usuario)</returns>
        public string mensajeAdmin()
        {
            return string.Format("%s (%s)", this.nombre, this.usuario);
        }

        public string toString()
        {
            return this.usuario + "," + this.nombre + "," + this.correo +
                "," + this.contrasena + "," + this.admin + "," + this.activo;
        }
    }
}
