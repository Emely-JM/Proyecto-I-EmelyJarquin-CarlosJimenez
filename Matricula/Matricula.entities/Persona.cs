using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.entities
{
    public class Persona
    {
        public string idPersona { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public char sexo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string nivelAcademico { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string usuarioRegistro { get; set; }
        public string tipoPersona { get; set; }
        public string nacionalidad { get; set; }
        public bool estado { get; set; }

        public Persona()
        {
        }

        public Persona(string idPersona, string cedula, string nombre, string apellido1, string apellido2, char sexo, DateTime fechaNacimiento, string nivelAcademico, 
            DateTime fechaIngreso, string usuarioRegistro, string tipoPersona, string nacionalidad, bool estado)
        {
            this.idPersona = idPersona;
            this.cedula = cedula;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.sexo = sexo;
            this.fechaNacimiento = fechaNacimiento;
            this.nivelAcademico = nivelAcademico;
            this.fechaIngreso = fechaIngreso;
            this.usuarioRegistro = usuarioRegistro;
            this.tipoPersona = tipoPersona;
            this.nacionalidad = nacionalidad;
            this.estado = estado;
        }

        public string toString()
        {
            return idPersona + "," + cedula + "," + nombre + "," + apellido1 + "," + apellido2 + "," + sexo + "," + fechaNacimiento + "," + nivelAcademico + "," + 
                fechaIngreso + "," + usuarioRegistro + "," + tipoPersona + "," + nacionalidad + "," + estado;
        }
    }
}
