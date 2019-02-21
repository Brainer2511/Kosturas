using BCC_Horarios_Y_Marcas;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Usuarios
    {
        //Variables de la clase
        SqlConnection Conexion;
        
        //Constructor de la clase
        public Usuarios()
        {
            //Se inicializa la Conexion
            Conexion = new SqlConnection();
            Conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        }

        /// <summary>
        /// Método que se encarga de validar el ingreso de usuarios
        /// </summary>
        /// <param name="oUsuario">objeto con los datos del usuario</param>
        /// <returns></returns>
        public Int32 validarUsuario(ref Usuario oUsuario)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            //se crea la varaible codigoRespuesta
            var codigoRespuesta = 0;
            var nombreUsuario = String.Empty;
            try
            {
                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("consultar_datos_login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@usuario", oUsuario.email);
                cmd.Parameters.AddWithValue("@password", oUsuario.password);
                //cmd.Parameters.AddWithValue("@pass", oUsuario.password);
                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader resultado = cmd.ExecuteReader();
                if (resultado.HasRows)
                {
                    var user = new Usuario();

                    //mientras existan datos
                    while (resultado.Read())
                    {
                        user.idUsuario = Convert.ToInt32(resultado["idUsuario"]);
                        user.email = resultado["usuario"].ToString();
                        user.password = resultado["contrasena"].ToString();
                        user.departamento = Convert.ToInt16(resultado["departamento"]);
                        user.NomDepartamento = resultado["NomDepartamento"].ToString();
                        user.seccion = Convert.ToInt16(resultado["seccion"]);
                        user.NomSeccion = resultado["NomSeccion"].ToString();
                        if (!(resultado["proyecto"].ToString().Equals(string.Empty)))
                            user.proyecto = Convert.ToInt32(resultado["proyecto"].ToString());
                        user.idPersona = Convert.ToInt16(resultado["idPersona"]);
                    }

                    if (user.idUsuario != 0)
                    {
                        if (user.email.Equals(oUsuario.email) && user.password.Equals(oUsuario.password))
                        {
                            if (user.departamento == 22 || user.departamento == 20)
                            {
                                codigoRespuesta = 1;
                            }
                            else
                            {
                                if (user.departamento == 1 && user.seccion == 4)
                                {
                                    codigoRespuesta = 1;
                                }
                                else
                                {
                                    codigoRespuesta = 2;
                                }
                            }
                            oUsuario = user;
                        }
                        else
                        {
                            codigoRespuesta = 3;
                        }
                    }

                }
                //se cierra la conexión
                cn.Close();
                //se retorna el resultado
                return codigoRespuesta; //1;
            }
            catch (Exception ex)
            {
                //se lanza la excepción
                throw (ex);
            }
        }

        /// <summary>
        /// Metodo que registra nuevos usuarios
        /// </summary>
        /// <param name="oUsuario">Objeto con los datos del usuario</param>
        public void RegistrarUsuario(Usuario oUsuario)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("registrar_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                //cmd.Parameters.AddWithValue("@idequipo", oEquipo.Id);
                //cmd.Parameters.AddWithValue("@nombre", oUsuario.nombre);
                cmd.Parameters.AddWithValue("@usuario", oUsuario.email);
                cmd.Parameters.AddWithValue("@contrasenna", oUsuario.password);
                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();
            }
            catch (Exception ex)
            {
                //En caso de error se lanza la excepción
                //cn.Close();
                throw new Exception("Se presento un problema al conectar con la Base de Datos.", ex.InnerException);
            }
        }

        public string RegistrarSesion(Usuario oUsuario)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("RegistrarSesion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                //cmd.Parameters.AddWithValue("@idequipo", oEquipo.Id);
                cmd.Parameters.AddWithValue("@idUsuario", oUsuario.idUsuario);
                cmd.Parameters.AddWithValue("@tipoEvento", 1);
                cmd.Parameters.Add("@identity", SqlDbType.Int).Direction = ParameterDirection.Output;
                //DataAdapter.Cmd.Parameters.Add("@identity", SqlDbType.Int).Direction = ParameterDirection.Output;
                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();
                string returnValue = cmd.Parameters["@identity"].Value.ToString();
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();
                return returnValue;
            }
            catch (Exception ex)
            {
                //En caso de error se lanza la excepción
                //cn.Close();
                throw new Exception("Se presento un problema al conectar con la Base de Datos.", ex.InnerException);
            }
        }

        public string FinalizarSesion(Usuario oUsuario, Sesion oSesion)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("RegistrarSesion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                //cmd.Parameters.AddWithValue("@idequipo", oEquipo.Id);
                cmd.Parameters.AddWithValue("@idUsuario", oUsuario.idUsuario);
                cmd.Parameters.AddWithValue("@idSesion", oSesion.idSesion);
                cmd.Parameters.AddWithValue("@tipoEvento", 0);
                cmd.Parameters.Add("@identity", SqlDbType.Int).Direction = ParameterDirection.Output;
                //DataAdapter.Cmd.Parameters.Add("@identity", SqlDbType.Int).Direction = ParameterDirection.Output;
                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();
                string returnValue = cmd.Parameters["@identity"].Value.ToString();
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();
                return returnValue;
            }
            catch (Exception ex)
            {
                //En caso de error se lanza la excepción
                //cn.Close();
                throw new Exception("Se presento un problema al conectar con la Base de Datos.", ex.InnerException);
            }
        }

    }
}
