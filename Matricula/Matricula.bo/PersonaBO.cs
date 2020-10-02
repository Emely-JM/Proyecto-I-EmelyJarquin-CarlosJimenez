using Matricula.dao;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.bo
{
    public class PersonaBO
    {
        List<Persona> proceso;
        PersonaDAO objArchivo;

        public PersonaBO()
        {
            proceso = new List<Persona>();
            objArchivo = new PersonaDAO();
            proceso = objArchivo.leerArchivo();
        }

        /// <summary>
        /// Agrega los datos pasados por parámetro al constructor de la clase Persona
        /// y agregar esta clase a la lista
        /// </summary>
        /// <param name="idPersona"> id único de la persona a registrar generado por el sistema </param>
        /// <param name="cedula"> cédula de la persona a registrar </param>
        /// <param name="nombre"> nombre de la persona a registrar </param>
        /// <param name="apellido1"> primer apellido de la persona a registrar </param>
        /// <param name="apellido2"> segundo apellido de la persona a registrar </param>
        /// <param name="sexo"> sexo de la persona a registrar </param>
        /// <param name="fechaNacimiento"> fecha en que nació la persona a registrar </param>
        /// <param name="nivelAcademico"> nivel académico de la persona a registrar </param>
        /// <param name="fechaIngreso"> fecha en que ingresa la persona </param>
        /// <param name="usuarioRegistro"> usuario que lo registro </param>
        /// <param name="tipoPersona"> tipo de persona que se registra; estudiante o profesor </param>
        /// <param name="nacionalidad"> nacionalidad de la persona a registrar </param>
        /// <param name="estado"> estado actual de la persona en el sistema; activo o inactivo </param>
        public void agregar(int idPersona, int cedula, string nombre, string apellido1, string apellido2, char sexo, 
            DateTime fechaNacimiento, string nivelAcademico, DateTime fechaIngreso, string usuarioRegistro, string tipoPersona, string nacionalidad, string estado)
        {
            proceso.Add(new Persona(idPersona,cedula,nombre,apellido1,apellido2,sexo,fechaNacimiento,nivelAcademico,fechaIngreso,usuarioRegistro,tipoPersona,nacionalidad,estado));
        }

        /// <summary>
        /// Elimina todos los datos relacionados al id
        /// pasado por parámetro
        /// </summary>
        /// <param name="idBuscar"> representa el id que se desea eliminar </param>
        public void eliminar(int idBuscar)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (idBuscar == proceso[i].idPersona)
                {
                    proceso.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Buscar el id que se desea modificar y asigna los datos a los 
        /// métodos sets correspondientes
        /// </summary>
        /// <param name="idBuscar"> id a buscar </param>
        /// <param name="idPersona"> nuevo valor del id </param>
        /// <param name="cedula"> nuevo valor para la cédula </param>
        /// <param name="nombre"> nuevo valor para el nombre </param>
        /// <param name="apellido1"> nuevo valor para el primer apellido </param>
        /// <param name="apellido2"> nuevo valor para el segundo apellido </param>
        /// <param name="sexo"> nuevo valor del sexo </param>
        /// <param name="fechaNacimiento"> nueva fecha de nacimiento </param>
        /// <param name="nivelAcademico"> nuevo valor para el nivel académico </param>
        /// <param name="fechaIngreso"> nuevo valor para la fecha de ingreso </param>
        /// <param name="usuarioRegistro"> nuevo valor para el usuario que registro </param>
        /// <param name="tipoPersona"> nuevo valor para el tipo de persona </param>
        /// <param name="nacionalidad"> nuevo valor para la nacionalidad </param>
        /// <param name="estado"> nuevo valor para el estado </param>
        public void modificar(int idBuscar, int idPersona, int cedula, string nombre, string apellido1, string apellido2, char sexo,
            DateTime fechaNacimiento, string nivelAcademico, DateTime fechaIngreso, string usuarioRegistro, string tipoPersona, string nacionalidad, string estado)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (idBuscar == proceso[i].idPersona)
                {
                    proceso[i].idPersona = idPersona;
                    proceso[i].cedula = cedula;
                    proceso[i].nombre = nombre;
                    proceso[i].apellido1 = apellido1;
                    proceso[i].apellido2 = apellido2;
                    proceso[i].sexo = sexo;
                    proceso[i].fechaNacimiento = fechaNacimiento;
                    proceso[i].nivelAcademico = nivelAcademico;
                    proceso[i].fechaIngreso = fechaIngreso;
                    proceso[i].usuarioRegistro = usuarioRegistro;
                    proceso[i].tipoPersona = tipoPersona;
                    proceso[i].nacionalidad = nacionalidad;
                    proceso[i].estado = estado;

                }
            }
        }

        /// <summary>
        /// Busca la cédula de la persona pasada por parámetro
        /// para evitar datos duplicados
        /// </summary>
        /// <param name="cedula"> representa la cédula que se desea buscar </param>
        /// <returns> retorna el indice de la cédula o un -1 sino la encuentra </returns>
        public int buscarCedula(int cedula)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (proceso[i].cedula == cedula)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Llama al método de crear archivo y le pasa la lista
        /// de proceso como parámetro para escribirla en archivo
        /// </summary>
        public void crearArchivo()
        {
            objArchivo.crearArchivo(proceso);
        }

        /// <summary>
        /// Método que obtiene la lista de la clase Persona
        /// </summary>
        /// <returns> retorna la lista cargada con los datos del archivo </returns>
        public List<Persona> getLista()
        {
            limpiarLista();
            return proceso = objArchivo.leerArchivo();

        }

        /// <summary>
        /// Limpia los datos de la lista
        /// </summary>
        private void limpiarLista()
        {
            proceso.Clear();
        }
    }
}
