﻿using Matricula.dao;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.bo
{
    public class EvaluacionBO
    {
        List<Evaluacion> proceso;
        EvaluacionDAO objArchivo;

        public EvaluacionBO()
        {
            proceso = new List<Evaluacion>();
            objArchivo = new EvaluacionDAO();
            proceso = objArchivo.leerArchivo();
        }

        /// <summary>
        /// Ingresa los datos pasados por parámetro al constructor de la clase Evaluacion
        /// e ingresa los datos de la clase a la lista
        /// </summary>
        /// <param name="idEvalucion"> id de la evaluación </param>
        /// <param name="descripcion"> descripción de la evaluación </param>
        /// <param name="idEstudiante"> id del estudiante que realiza la evaluación </param>
        /// <param name="estado"> estado de la evaluación </param>
        /// <param name="fechaEvaluacion"> fecha en que se realiza la evaluación </param>
        public void agregar(string idEvalucion, string descripcion, string idEstudiante,string idMateria, string estado, DateTime fechaEvaluacion)
        {
            proceso.Add(new Evaluacion(idEvalucion,descripcion,idEstudiante,idMateria,estado,fechaEvaluacion));
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
        /// Método que obtiene la lista de la clase Evaluacion
        /// </summary>
        /// <returns> retorna la lista cargada con los datos del archivo </returns>
        public List<Evaluacion> getLista()
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
