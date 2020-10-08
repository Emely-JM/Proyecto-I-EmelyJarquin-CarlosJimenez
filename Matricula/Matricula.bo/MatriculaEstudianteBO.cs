using Matricula.dao;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.bo
{
    public class MatriculaEstudianteBO
    {
        List<MatriculaEstudiante> proceso;
        MatriculaEstudianteDAO objArchivo;

        public MatriculaEstudianteBO()
        {
            proceso = new List<MatriculaEstudiante>();
            objArchivo = new MatriculaEstudianteDAO();
            proceso = objArchivo.leerArchivo();
        }

        /// <summary>
        /// Agrega los datos pasados por parámetro al constructor de MatriculaEstudiante e ingresa los datos del
        /// constructor a la lista
        /// </summary>
        /// <param name="idFactura"> id de la factura a registrar </param>
        /// <param name="idPersona"> id de la persona a la cuál está ligada la factura </param>
        /// <param name="idPeriodo"> id del periodo que se matricula </param>
        /// <param name="fechaMatricula"> fecha en que se matricula </param>
        /// <param name="estado"> estado de la matricula </param>
        /// <param name="comprobante"> comprobante de la matricula </param>
        /// <param name="fechaPago"> fecha del pago </param>
        public void agregar(string idFactura, string idPersona, string idPeriodo, DateTime fechaMatricula,string idMateria,string idProf, string estado, string comprobante, DateTime fechaPago)
        {
            proceso.Add(new MatriculaEstudiante(idFactura,idPersona,idPeriodo,fechaMatricula,idMateria,idProf,estado,comprobante,fechaPago));
        }

        /// <summary>
        /// Busca el indice del id de la persona pasada por parámetro y el id
        /// de la materia que desea matricular y si encuentra el id de la materia
        /// no permitirá que se matricule de nuevo en ella.
        /// </summary>
        /// <param name="idPersona"> id de la persona que matricula </param>
        /// <param name="idMateria"> id de la materia que se desea matricular </param>
        /// <returns> retorna el indice si encuentra el id de la materia  o un -1 si no hay registros </returns>
        public int permitirMatricula(string idPersona,string idMateria)
        {
            for(int i = 0; i < proceso.Count; i++)
            {
                if (proceso[i].idPersona.Equals(idPersona))
                {
                    if (proceso[i].idMateria.Equals(idMateria))
                    {
                        return i;
                    }
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
        /// Método que obtiene la lista de la clase MatriculaEstudiante
        /// </summary>
        /// <returns> retorna la lista cargada con los datos del archivo </returns>
        public List<MatriculaEstudiante> getLista()
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
