﻿using Matricula.dao;
using Matricula.entities;
using Matricula.utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.bo
{
    public class AdminBO
    {
        List<Admin> proceso;
        AdminDAO objArchivo;
        Encripta encripta;

        public AdminBO()
        {
            proceso = new List<Admin>();
            objArchivo = new AdminDAO();
            proceso = objArchivo.leerArchivo();
        }

        /// <summary>
        /// Agrega los datos pasados por parámetro al constructor de la clase Admin 
        /// y agregar esta clase a la lista de objeto Admin
        /// </summary>
        /// <param name="usuario"> nombre de usuario ingresado para registrar</param>
        /// <param name="nombre"> nombre de la persona ingresado para registrar</param>
        /// <param name="correo"> correo de la persona ingresado para registrar</param>
        /// <param name="contrasena"> contraseña de la persona ingresada para registrar</param>
        /// <param name="admin"> indica si la persona ingresada es administrador </param>
        /// <param name="activo"> indica si la persona ingresada está activa </param>
        public void agregar(string usuario, string nombre, string correo, string contrasena, bool admin, bool activo)
        {
            proceso.Add(new Admin(usuario, nombre, correo, encripta.Encriptar(contrasena), admin, activo));
        }

        /// <summary>
        /// Elimina todos los datos del usuario pasado por parámetro
        /// </summary>
        /// <param name="usuario"> representa al usuario que se desea eliminar </param>
        public void eliminar(string usuario)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (usuario.Equals(proceso[i].usuario.ToString()))
                {
                    proceso.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Modifica los datos del administrador especificado por el nombre de usuario
        /// </summary>
        /// <param name="usuario"> usuario que se desea modificar y nuevo usuario</param>
        /// <param name="nombre"> nuevo nombre </param>
        /// <param name="correo"> nuevo correo </param>
        /// <param name="admin"> asigna si es o deja de ser administrador </param>
        /// <param name="activo"> asigna si está o deja de estar activo </param>
        public void modificar(string usuario, string nombre, string correo, bool admin, bool activo)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (usuario.Equals(proceso[i].usuario.ToString()))
                {
                    proceso[i].usuario = usuario;
                    proceso[i].nombre = nombre;
                    proceso[i].correo = correo;
                    proceso[i].admin = admin;
                    proceso[i].activo = activo;
                }
            }
        }

        /// <summary>
        /// Método que permite modifcar la contraseña el usuario indicado por parámetro
        /// y encripta la nueva contraseña
        /// </summary>
        /// <param name="usuario"> usuario al que se desea cambiarle la contraseña </param>
        /// <param name="nuevaContrasena"> nueva contrasena </param>
        public void modificarContrasena(string usuario, string nuevaContrasena)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (usuario.Equals(proceso[i].usuario.ToString()))
                {
                    proceso[i].contrasena = encripta.Encriptar(nuevaContrasena);
                }
            }
        }

        /// <summary>
        /// Busca al usuario especificado por parámetro y 
        /// lo activa o desactiva según sea el caso.
        /// </summary>
        /// <param name="usuario"> usuario a buscar </param>
        /// <param name="dato"> booleano que especifica si activa o desactiva al usuario</param>
        public void activaDesactiva(string usuario, bool dato)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (usuario.Equals(proceso[i].usuario.ToString()))
                {
                    proceso[i].activo = dato;
                }
            }
        }

        /// <summary>
        /// Busca en la lista si el usuario ingresado ya existe
        /// </summary>
        /// <param name="usuario"> representa al usuario que se desea buscar </param>
        /// <returns> retorna el indice si encuentra al usuario o un -1 sino </returns>
        public int buscarUsuario(string usuario)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (usuario.Equals(proceso[i].Usuario))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Busca en la lista si el correo ingresado ya existe
        /// </summary>
        /// <param name="correo"> representa el correo que se desea buscar </param>
        /// <returns> retorna el indice si encuentra el correo o un -1 sino </returns>
        public int buscarCorreo(string correo)
        {
            for (int i = 0; i < proceso.Count; i++)
            {
                if (correo.Equals(proceso[i].Correo))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
