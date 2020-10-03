using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class Usuario
    {

        public int idUsuario { get; }
        public string codigo { get; set; }
        public int idPersona { get; set; }
        public string tipoUsuario { get; set; }
        public string contrasena { get; set; }
        public DateTime fechaExpiraContrasena { get; set; }
        public bool activo { get; set; }

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string codigo, int idPersona, string tipoUsuario,
            string contrasena, DateTime fechaExpiraContrasena, bool activo)
        {
            this.idUsuario = idUsuario;
            this.codigo = codigo;
            this.idPersona = idPersona;
            this.tipoUsuario = tipoUsuario;
            this.contrasena = contrasena;
            this.fechaExpiraContrasena = fechaExpiraContrasena;
            this.activo = activo;
        }

        /// <summary>
        /// Devuelve la información de un usuario para guardar en un archivo de texto
        /// </summary>
        /// <returns>
        /// String con los atributos de un usuario separados por una , (coma)
        /// </returns>
        public override string ToString()
        {
            return idUsuario + "," + codigo + "," + idPersona + "," + tipoUsuario
                + "," + contrasena + "," + fechaExpiraContrasena + "," + activo;
        }
    }
}
