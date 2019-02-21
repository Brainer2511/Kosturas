using DAL;
using System;

namespace BCC_Horarios_Y_Marcas
{
    public class Usuarios_BLL
    {
        //Variables de la clase
        Usuarios datos;

        //Constructor de la clase
        public Usuarios_BLL()
        {
            //Se inicializa la Conexion
            datos = new Usuarios();
        }

        /// <summary>
        /// Método que se encarga de validar el ingreso de usuarios
        /// </summary>
        /// <param name="oUsuario">objeto con los datos del usuario</param>
        /// <returns></returns>
        public Int32 validarUsuario(ref Usuario oUsuario)
        {
            return datos.validarUsuario(ref oUsuario);
        }

        /// <summary>
        /// Metodo que registra nuevos usuarios
        /// </summary>
        /// <param name="oUsuario">Objeto con los datos del usuario</param>
        public void RegistrarUsuario(Usuario oUsuario)
        {
            datos.RegistrarUsuario(oUsuario);
        }

        public string RegistrarSesion(Usuario oUsuario)
        {
            return datos.RegistrarSesion(oUsuario);
        }

        public string FinalizarSesion(Usuario oUsuario, Sesion oSesion)
        {
            return datos.FinalizarSesion(oUsuario, oSesion);
        }
    }
}
