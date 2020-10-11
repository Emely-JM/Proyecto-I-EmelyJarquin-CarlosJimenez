using Matricula.bo;
using Matricula.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliminaDatos
{
    public class Elimina
    {
        UsuarioBO usuario;
        List<Usuario> listaUsuarios;
        MateriaBO materia;
        List<Materias> listaMaterias;
        MatriculaEstudianteBO matricula;
        List<MatriculaEstudiante> listaMatricula;
        PersonaBO persona;
        List<Persona> listaPersona;

        public Elimina()
        {
            usuario = new UsuarioBO();
            listaUsuarios = new List<Usuario>();
            materia = new MateriaBO();
            listaMaterias = new List<Materias>();
            matricula = new MatriculaEstudianteBO();
            listaMatricula = new List<MatriculaEstudiante>();
            persona = new PersonaBO();
            listaPersona = new List<Persona>();
        }

        /// <summary>
        /// Busca el id de la persona en la lista de los usuarios 
        /// </summary>
        /// <param name="id"> cédula de la persona a buscar </param>
        /// <returns> retona el indice si encuentra el dato o un -1 sino </returns>
        public int eliminarPersona(string id)
        {
            listaUsuarios = usuario.GetUsuarios();
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios[i].idPersona.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Busca el id ingresado en la lista de los materias 
        /// </summary>
        /// <param name="id"> id de la carrera que se desea eliminar </param>
        /// <returns> retona el indice si encuentra el dato o un -1 sino </returns>
        public int eliminarCarrera(string id)
        {
            listaMaterias = materia.getLista();
            for (int i = 0; i < listaMaterias.Count; i++)
            {
                if (listaMaterias[i].idCarrera.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Busca el id ingresado en la lista de las matriculas
        /// </summary>
        /// <param name="id"> id de la materia a buscar </param>
        /// <returns> retona el indice si encuentra el dato o un -1 sino </returns>
        public int eliminarMateria(string id)
        {
            listaMatricula = matricula.getLista();
            for (int i = 0; i < listaMatricula.Count; i++)
            {
                if (listaMatricula[i].idMateria.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }


    }
}
