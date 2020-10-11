using Matricula.dao;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.bo
{
    public class CarreraBO
    {
        List<Carrera> proceso;
        CarreraDAO objArchivo;

        public CarreraBO()
        {
            proceso = new List<Carrera>();
            objArchivo = new CarreraDAO();
            proceso = objArchivo.leerArchivo();
        }

        /// <summary>
        /// Agrega los datos pasados por parámetro al constructor de la clase Carrera 
        /// y agregar esta clase a la lista de objeto Carrera
        /// </summary>
        /// <param name="idCarrera"> id de la carrera ingresado para registrar </param>
        /// <param name="nombre"> nombre de la carrera ingresado para registrar </param>
        /// <param name="creditosTotales"> cantidad de créditos totales que posee la carrera </param>
        /// <param name="estado"> estado de la carrera; en oferta o cerrada </param>
        /// <param name="fechaApertura"> fecha de apertura de la carrera </param>
        /// <param name="fechaCierre"> fecha en la que termina la fecha de apertura </param>
        public void agregar(string idCarrera, string nombre, int creditosTotales, string estado, DateTime fechaApertura, DateTime fechaCierre)
        {
            proceso.Add(new Carrera(idCarrera,nombre,creditosTotales,estado,fechaApertura,fechaCierre));
        }

        /// <summary>
        /// Elimina todos los datos ligados al id de la carrera pasada por parámetro
        /// </summary>
        /// <param name="idCarrera"> representa el id de la carrera que se desea eliminar </param>
        public void eliminar(string idCarrera)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (idCarrera.Equals(proceso[i].idCarrera))
                {
                    proceso.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Modifica los datos de las carreras especificadas por el id 
        /// se asignan los datos a los métodos sets.
        /// </summary>
        /// <param name="idCarrera"> id de la carrera a modificar </param>
        /// <param name="nombre"> nuevo nombre asignado a la carrera </param>
        /// <param name="creditosTotales"> nueva cantidad de creditos totales asignada a la carrera </param>
        /// <param name="estado"> nuevo estado asignado a la carrera </param>
        /// <param name="fechaApertura"> representa la nueva fecha de apertura asignada a la carrera </param>
        /// <param name="fechaCierre"> representa la nueva fecha de cierre asignada a la carrera </param>
        public void modificar(string idBuscar,string idCarrera, string nombre, int creditosTotales, string estado, DateTime fechaApertura, DateTime fechaCierre)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (idBuscar.Equals(proceso[i].idCarrera))
                {
                    proceso[i].idCarrera = idCarrera;
                    proceso[i].nombre = nombre;
                    proceso[i].creditosTotales = creditosTotales;
                    proceso[i].estado = estado;
                    proceso[i].FechaApertura = fechaApertura;
                    proceso[i].FechaCierrre = fechaCierre;
                }
            }
        }

        /// <summary>
        /// Desactiva la carrera
        /// </summary>
        /// <param name="id"> id de la carrera a desactivar </param>
        public void modificaEstado(string id)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (id.Equals(proceso[i].idCarrera))
                {
                    proceso[i].estado = "Cerrada";
                }
            }
        }

        /// <summary>
        /// Busca el nombre de la carrera en la lista y retorna el indice, de no 
        /// existir retorna un -1. Este método se utiliza para no permitir datos 
        /// duplicados
        /// </summary>
        /// <param name="nombre"> nombre de la carrera a buscar </param>
        /// <returns> retorna el indice de la carrea si existe o un -1 si no la encuentra </returns>
        public int buscarNombre(string nombre)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (proceso[i].nombre.Equals(nombre))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Recorre la lista y busca el id ingresado
        /// </summary>
        /// <param name="id"> id de carrera que se desea buscar </param>
        /// <returns> retorna el indice de la carrera perteneciente al id ingresado o un -1 si no está registrado </returns>
        public int buscarId(string id)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (proceso[i].idCarrera.Equals(id))
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
        /// Método que obtiene la lista de la clase Carrera
        /// </summary>
        /// <returns> retorna la lista cargada con los datos del archivo </returns>
        public List<Carrera> getLista()
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
