using Matricula.dao;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.bo
{
    public class AsignacionBO
    {
        List<Asignacion> proceso;
        AsignacionDAO objArchivo;

        public AsignacionBO()
        {
            proceso = new List<Asignacion>();
            objArchivo = new AsignacionDAO();
            proceso = objArchivo.leerArchivo();
        }

        public void agregar(int id,string idProf,string idMateria)
        {
            proceso.Add(new Asignacion(id,idProf,idMateria));
        }

        /// <summary>
        /// Elimina todos los datos ligados al id pasado por parámetros
        /// </summary>
        /// <param name="id"> id a buscar </param>
        public void eliminar(int id)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (proceso[i].id == id)
                {
                    proceso.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Busca el id del profesor y los modifica según los
        /// nuevos datos
        /// </summary>
        /// <param name="id"> id a buscar </param>
        /// <param name="idProf"> nuevo id de profesor </param>
        /// <param name="idMateria"> nuevo id de materia </param>
        public void modificar(int id, string idProf, string idMateria)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (proceso[i].id == id)
                {
                    proceso[i].idProf = idProf;
                    proceso[i].idMateria = idMateria;
                }
            }
        }

        /// <summary>
        /// Busca el id de la asignación
        /// </summary>
        /// <param name="id"> id a buscar </param>
        /// <returns> retorna el indice del elemento si lo encuentra</returns>
        public bool BuscarId(int id)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if(proceso[i].id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Válida que no se asigne dos veces la misma materia a un profesor
        /// </summary>
        /// <param name="idProf"> id del profesor a buscar </param>
        /// <param name="idMateria"> id de la materia a buscar </param>
        /// <returns></returns>
        public int permitirAsignacion(string idProf, string idMateria)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (proceso[i].idProf.Equals(idProf) && proceso[i].idMateria.Equals(idMateria))
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
        /// Método que obtiene la lista de la clase Asignacion
        /// </summary>
        /// <returns> retorna la lista cargada con los datos del archivo </returns>
        public List<Asignacion> getLista()
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
