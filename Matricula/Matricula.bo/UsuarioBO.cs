﻿using Matricula.entities;
using Matricula.dao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matricula.utilitario;

namespace Matricula.bo
{
    /// <summary>
    /// Contiene los métodos para guardar, eliminar y obtener los usuarios de la aplicación
    /// Los usuarios pertenecen a la clase Usuario
    /// </summary>
    public class UsuarioBO
    {
        /// <summary>
        /// Verifica que los datos ingresados del usuario esten correctos y lo guarda en la aplicación
        /// </summary>
        /// <param name="u">
        /// Isntancia de la clase Usuario
        /// </param>
        public void guardar(Usuario u)
        {   
            foreach (Usuario usuario in GetUsuarios(""))
            {
                if (u.idPersona.Equals(usuario.idPersona) && u.id != usuario.id)
                {
                    throw new ArgumentException("La persona ingresada ya tiene un usuario registrado");
                }
            }

            if (u.id == 0)
            {
                if (String.IsNullOrEmpty(u.contrasena))
                {
                    throw new ArgumentNullException("La contraseña es requerida");
                }
                u.contrasena = new Encripta().Encriptar(u.contrasena); //Encripta la contraseña
                new UsuarioDAO().agregar(u);
            }
            else
            {
                new UsuarioDAO().editar(u);
            }
        }

        /// <summary>
        /// Cambia la contraseña de un usuario
        /// </summary>
        /// <param name="u">
        /// Isntancia de la clase Usuario
        /// </param>
        public void cambiarContrasena(Usuario u)
        {
            u.contrasena = new Encripta().Encriptar(u.contrasena); //Encripta la contraseña
            
            new UsuarioDAO().cambiarContrasena(u);
        }

        /// <summary>
        /// Desactiva un usuario de la aplicación
        /// </summary>
        /// <param name="u">
        /// Isntancia de la clase Usuario
        /// </param>
        public void eliminar(Usuario u)
        {
            new UsuarioDAO().eliminar(u);
        } 

        /// <summary>
        /// Obtiene una lista con los usuarios de la aplicación
        /// </summary>
        /// <returns>
        /// Lista con los usuarios
        /// </returns>
        public List<Usuario> GetUsuarios(string filtro)
        {
            return new UsuarioDAO().GetUsuarios(filtro);
        }

        /// <summary>
        /// Verifica los los datos de inicio de sesión del usuario sean correctos
        /// </summary>
        /// <param name="u">
        /// Instancia de la clase Usuario
        /// </param>
        /// <returns>
        /// Un usuario si el inicio de sesión es exitoso
        /// </returns>
        public Usuario iniciarSesion(Usuario u)
        {
            u.contrasena = new Encripta().Encriptar(u.contrasena); //Encripta la contraseña

            return new UsuarioDAO().iniciarSesion(u);
        }

    }
}
