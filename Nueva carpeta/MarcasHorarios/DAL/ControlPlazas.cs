using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BCC_Horarios_Y_Marcas
{
    public class ControlPlazas
    {
        //Variable
        SqlConnection Conexion;

        public ControlPlazas()
        {
            //Se inicializa la Conexion
            Conexion = new SqlConnection();
            Conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        }

        /// <summary>
        /// Método que obtiene los datos del CMS Avaya Elite
        /// </summary>
        /// <returns>DataTable con la información consultada</returns>
        public DataTable ObtenerDatosElite(string desde, string hasta)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("row_date");
                table.Columns.Add("seq_num");
                table.Columns.Add("logid");
                table.Columns.Add("acd");
                table.Columns.Add("split");
                table.Columns.Add("login");
                table.Columns.Add("logout");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ConsultarDatosControlPlazasCMS", cn);
                cmd.Parameters.AddWithValue("@i", desde);
                cmd.Parameters.AddWithValue("@f", hasta);
                cmd.CommandType = CommandType.StoredProcedure;
                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();

                        var datoFechaHora = long.Parse(reader["seq_num"].ToString());
                        var fechaHora = UtilitarioDAL.FromUnixTime(datoFechaHora);

                        var datologin = long.Parse(reader["login"].ToString());
                        var fechalogin = UtilitarioDAL.FromUnixTime(datologin);
                        var login = fechalogin.TimeOfDay;

                        if (reader["logout"].ToString().Equals(String.Empty))
                        {
                            fila["logout"] = login;
                        }
                        else
                        {
                            var datologout = long.Parse(reader["logout"].ToString());
                            var fechalogout = UtilitarioDAL.FromUnixTime(datologout);
                            var logout = fechalogout.TimeOfDay;
                            fila["logout"] = logout;
                        }

                        //Se cargan los datos en la fila
                        fila["row_date"] = fechaHora;
                        fila["split"] = reader["split"].ToString();
                        fila["logid"] = reader["logid"].ToString();
                        fila["login"] = login;

                        //Se agrega la fila a la tabla
                        table.Rows.Add(fila);

                        //RegistrarCMS_Elite(oCMS);
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();
                //se retorna la lista
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerSplits()
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                table.Columns.Add("Código");
                table.Columns.Add("Nombre");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ConsultarSplits", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();
                        //Se cargan los datos en la fila
                        fila["Id"] = Convert.ToInt32(reader["id"]);
                        fila["Código"] = reader["codigoCMS"];
                        fila["Nombre"] = reader["nombre"];

                        //Se agrega la fila a la tabla
                        table.Rows.Add(fila);
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();
                //se retorna la lista
                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RegistrarSplit(int codigo, string nombre, int? id)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("RegistrarSplit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                //cmd.Parameters.AddWithValue("@idequipo", oEquipo.Id);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                //se maneja el parametro opcional para la actualización
                if (id != null)
                {

                    cmd.Parameters.AddWithValue("@id", id);
                }

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

        public DataTable ConsultarLoginIdPersonal()
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("Nombre");
                table.Columns.Add("LoginId");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ConsultarPersonalLoginId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();
                        //Se cargan los datos en la fila
                        fila["Nombre"] = reader["nombre"];
                        fila["LoginId"] = reader["idAvaya"];

                        //Se agrega la fila a la tabla
                        table.Rows.Add(fila);
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();
                //se retorna la lista
                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
