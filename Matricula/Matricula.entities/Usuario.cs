﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class Usuario
    {

        public int id { get; set; }
        public string codigo { get; set; }
        public int idPersona { get; set; }
        public string tipoUsuario { get; set; }
        public string contrasena { get; set; }
        public DateTime fechaExpiraContrasena { get; set; }
        public bool activo { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, string codigo, int idPersona, string tipoUsuario,
            string contrasena, DateTime fechaExpiraContrasena, bool activo)
        {
            this.id = id;
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
            return id + "," + codigo + "," + idPersona + "," + tipoUsuario
                + "," + contrasena + "," + fechaExpiraContrasena + "," + activo;
        }
    }
}
