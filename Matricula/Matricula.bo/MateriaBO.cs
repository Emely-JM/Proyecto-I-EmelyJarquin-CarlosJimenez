using Matricula.dao;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.bo
{
    public class MateriaBO
    {
        List<Materias> proceso;
        MateriaDAO objArchivo;

        public MateriaBO()
        {
            proceso = new List<Materias>();
            objArchivo = new MateriaDAO();
            proceso = objArchivo.leerArchivo();
        }

        /// <summary>
        /// Agrega los datos pasados por parámetro al constructor de la clase Materias
        /// y agregar esta clase a la lista
        /// </summary>
        /// <param name="idMateria"> id de la materia para registrar </param>
        /// <param name="nombre"> nombre de la materia para registrar </param>
        /// <param name="cantidadCreditos"> cantidad de créditos por materia a registrar </param>
        /// <param name="idCarrera"> id de la carrera a la que pertenece la materia </param>
        /// <param name="precio"> precio de cada materia a registrar </param>
        /// <param name="costo"> costos totales por materia, incluye salarios </param>
        public void agregar(string idMateria, string nombre, int cantidadCreditos, string idCarrera, double precio, double costo)
        {
            proceso.Add(new Materias(idMateria,nombre,cantidadCreditos,idCarrera,precio,costo));
        }

        /// <summary>
        /// Elimina todos los datos relacionados al id de la materia 
        /// pasado por parámetro
        /// </summary>
        /// <param name="idMateria"> id de la materia a eliminar </param>
        public void eliminar(string idMateria)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (idMateria.Equals(proceso[i].idMateria))
                {
                    proceso.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Buscar el id de la materia que se desea modificar y asigna los datos a los 
        /// métodos sets correspondientes
        /// </summary>
        /// <param name="idBuscar"> id de la materia que se desea modificar </param>
        /// <param name="idMateria"> nuevo id de la materia </param>
        /// <param name="nombre"> nuevo nombre de materia </param>
        /// <param name="cantidadCreditos"> nueva cantidad de créditos de la materia </param>
        /// <param name="idCarrera"> nuevo id de la carrera a la que está ligada la materia </param>
        /// <param name="precio"> nuevo precio de la materia </param>
        /// <param name="costo"> nuevo costo total de la materia </param>
        public void modificar(string idBuscar, string idMateria, string nombre, int cantidadCreditos, string idCarrera, double precio, double costo)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (idBuscar.Equals(proceso[i].idMateria))
                {
                    proceso[i].idMateria = idMateria;
                    proceso[i].nombre = nombre;
                    proceso[i].cantidadCreditos = cantidadCreditos;
                    proceso[i].idCarrera = idCarrera;
                    proceso[i].precio = precio;
                    proceso[i].costo = costo;

                }
            }
        }

        /// <summary>
        /// Busca el id de la materia pasada por parámetro
        /// para evitar datos duplicados
        /// </summary>
        /// <param name="idMateria"> id de la materia a buscar </param>
        /// <returns> retorna el indice del id si lo encuentra, de lo contrario retorna un -1 </returns>
        public int buscarIdMateria(string idMateria)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (proceso[i].idMateria.Equals(idMateria))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Busca el nombre de la materia pasado por parámetro
        /// para evitar datos duplicados
        /// </summary>
        /// <param name="nombre"> nombre de la materia a buscar </param>
        /// <returns> retorna el indice del nombre o un -1 sino lo encuentra </returns>
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
        /// Llama al método de crear archivo y le pasa la lista
        /// de proceso como parámetro para escribirla en archivo
        /// </summary>
        public void crearArchivo()
        {
            objArchivo.crearArchivo(proceso);
        }

        /// <summary>
        /// Método que obtiene la lista de la clase Materias
        /// </summary>
        /// <returns> retorna la lista cargada con los datos del archivo </returns>
        public List<Materias> getLista()
        {
            return proceso = objArchivo.leerArchivo();

        }

        /// <summary>
        /// Limpia los datos de la lista
        /// </summary>
        public void limpiarLista()
        {
            proceso.Clear();
        }

    }
}
