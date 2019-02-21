using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class Personal
    {
        //Variables de la clase
        SqlConnection Conexion;

        //Constructor de la clase
        public Personal()
        {
            //Se inicializa la Conexion
            Conexion = new SqlConnection();
            Conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        }

        /// <summary>
        /// Método que se encarga del registro de personal en el sistema
        /// </summary>
        /// <param name="persona">Objeto con los datos a registrar</param>
        public void RegistrarPersonal(Persona persona)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("registrar_persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                //cmd.Parameters.AddWithValue("@idequipo", oEquipo.Id);
                cmd.Parameters.AddWithValue("@nombre", persona.nombre);
                cmd.Parameters.AddWithValue("@departamento", persona.departamento);
                cmd.Parameters.AddWithValue("@seccion", persona.seccion);
                if (persona.idMarcaZapote != 0)
                    cmd.Parameters.AddWithValue("@idMarcaZPT", persona.idMarcaZapote);
                if (persona.idMarcaSanPedro != 0)
                    cmd.Parameters.AddWithValue("@idMarcaSP", persona.idMarcaSanPedro);
                if (!persona.correo.Equals(String.Empty))
                    cmd.Parameters.AddWithValue("@correo", persona.correo);
                if (persona.LoginId != 0)
                    cmd.Parameters.AddWithValue("@loginId", persona.LoginId);
                cmd.Parameters.AddWithValue("@proyecto", persona.codProyecto);
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

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarPersonalPlantilla(int dpto = 0, int seccion = 0, int proyecto = 0)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                table.Columns.Add("Nombre");
                //table.Columns.Add("Fecha");
                table.Columns.Add("Fecha_L");
                table.Columns.Add("Entrada_L");
                table.Columns.Add("Salida_L");
                table.Columns.Add("Fecha_K");
                table.Columns.Add("Entrada_K");
                table.Columns.Add("Salida_K");
                table.Columns.Add("Fecha_M");
                table.Columns.Add("Entrada_M");
                table.Columns.Add("Salida_M");
                table.Columns.Add("Fecha_J");
                table.Columns.Add("Entrada_J");
                table.Columns.Add("Salida_J");
                table.Columns.Add("Fecha_V");
                table.Columns.Add("Entrada_V");
                table.Columns.Add("Salida_V");
                table.Columns.Add("Fecha_S");
                table.Columns.Add("Entrada_S");
                table.Columns.Add("Salida_S");
                table.Columns.Add("Fecha_D");
                table.Columns.Add("Entrada_D");
                table.Columns.Add("Salida_D");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ConsultarPersonal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada

                if (dpto != 0 && seccion != 0)
                {
                    cmd.Parameters.AddWithValue("@piCodDpto", dpto);
                    cmd.Parameters.AddWithValue("@piCodseccion", seccion);
                    if(seccion == 9)
                    {
                        cmd.Parameters.AddWithValue("@piCodProyecto", proyecto);
                    }
                }

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
                        fila["Id"] = Convert.ToInt32(reader["idPersona"]);
                        fila["Nombre"] = reader["nombre"].ToString();

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

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarPersonal(int dpto = 0, int seccion = 0)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                table.Columns.Add("Nombre");
                table.Columns.Add("Departamento");
                table.Columns.Add("Seccion");
                table.Columns.Add("Marca SP");
                table.Columns.Add("Marca ZPT");
                table.Columns.Add("Estado");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ConsultarPersonal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada

                if (dpto != 0 && seccion != 0)
                {
                    cmd.Parameters.AddWithValue("@piCodDpto", dpto);
                    cmd.Parameters.AddWithValue("@piCodseccion", seccion);
                }

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
                        fila["Id"] = Convert.ToInt32(reader["idPersona"]);
                        fila["Nombre"] = reader["nombre"].ToString();
                        fila["Departamento"] = reader["DesDpto"].ToString();
                        fila["Seccion"] = reader["DesSeccion"].ToString();
                        fila["Marca SP"] = reader["idMarcaSP"].ToString();
                        fila["Marca ZPT"] = reader["idMarcaZPT"].ToString();
                        if (Convert.ToBoolean(reader["estado"].ToString()) == true)
                            fila["Estado"] = "Activo";
                        else
                            fila["Estado"] = "Inactivo";
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

        /// <summary>
        /// Sobrecarga del metodo que permite consultar a una persona por departamento, sección o nombre
        /// </summary>
        /// <param name="dpto">codigo del departamento al que pertenece una persona</param>
        /// <param name="seccion">sección del departemento de una persona</param>
        /// <param name="nombre">nombre de la persona que se desea buscar</param>
        /// <returns>DataTable con el listado de personas que coinciden con los datos de busqueda</returns>
        public DataTable BuscarPersona(int dpto = 0, int seccion = 0, int proyecto = 0, string nombre = "")
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                table.Columns.Add("Nombre");
                table.Columns.Add("Departamento");
                table.Columns.Add("Sección");
                table.Columns.Add("Marca SP");
                table.Columns.Add("Marca ZPT");
                table.Columns.Add("Estado");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ObtenerPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada

                if (dpto != 0)
                {
                    cmd.Parameters.AddWithValue("@piCodDpto", dpto);
                }
                if (seccion != 0)
                {
                    cmd.Parameters.AddWithValue("@piCodseccion", seccion);
                }
                if (proyecto != 0)
                {
                    cmd.Parameters.AddWithValue("@piCodProyecto", proyecto);
                }
                if (!nombre.Equals(string.Empty))
                {
                    cmd.Parameters.AddWithValue("@psNombre", nombre);
                }

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
                        fila["Id"] = Convert.ToInt32(reader["idPersona"]);
                        fila["Nombre"] = reader["nombre"].ToString();
                        fila["Departamento"] = reader["DesDpto"].ToString();
                        fila["Sección"] = reader["DesSeccion"].ToString();
                        fila["Marca SP"] = reader["idMarcaSP"].ToString();
                        fila["Marca ZPT"] = reader["idMarcaZPT"].ToString();
                        if (Convert.ToBoolean(reader["estado"].ToString()) == true)
                            fila["Estado"] = "Activo";
                        else
                            fila["Estado"] = "Inactivo";
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

        /// <summary>
        /// Método que se encarga de actualizar los datos de una persona en especifico
        /// </summary>
        /// <param name="persona">Objeto con todos los datos de la persona</param>
        public void ModificarPersonal(Persona persona)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("modificar_persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@idPersona", persona.idPersona);
                cmd.Parameters.AddWithValue("@nombre", persona.nombre);
                cmd.Parameters.AddWithValue("@departamento", persona.departamento);
                cmd.Parameters.AddWithValue("@seccion", persona.seccion);
                if (persona.idMarcaZapote != 0)
                    cmd.Parameters.AddWithValue("@idMarcaZPT", persona.idMarcaZapote);
                if (persona.idMarcaSanPedro != 0)
                    cmd.Parameters.AddWithValue("@idMarcaSP", persona.idMarcaSanPedro);
                if (persona.correo != null)
                    cmd.Parameters.AddWithValue("@correo", persona.correo);
                if (persona.LoginId != 0)
                    cmd.Parameters.AddWithValue("@loginId", persona.LoginId);
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

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public Persona ConsultarPersona(int idPersona)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("Consultar_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@piIdPersona", idPersona);

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();
                var colaborador = new Persona();
                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se cargan los datos en la fila
                        colaborador.idPersona = Convert.ToInt32(reader["idPersona"]);
                        colaborador.nombre = reader["nombre"].ToString();
                        colaborador.departamento = Convert.ToInt32(reader["departamento"]);
                        colaborador.DesDpto = reader["desDepto"].ToString();
                        colaborador.seccion = Convert.ToInt32(reader["seccion"]);
                        colaborador.DesSeccion = reader["desSeccion"].ToString();
                        int number = 0;
                        Int32.TryParse(reader["idMarcaSP"].ToString(), out number);
                        colaborador.idMarcaSanPedro = number;
                        //colaborador.idMarcaSanPedro = Convert.ToInt32(reader["idMarcaSP"]);
                        int value = 0;
                        Int32.TryParse(reader["idMarcaZPT"].ToString(), out value);
                        colaborador.idMarcaZapote = value;
                        int logId = 0;
                        Int32.TryParse(reader["idAvaya"].ToString(), out logId);
                        colaborador.LoginId = logId;
                        colaborador.correo = reader["correo"].ToString();

                        //colaborador.idMarcaZapote = Convert.ToInt32(reader["idMarcaZPT"]);
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();
                //se retorna la lista
                return colaborador;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarMarcas(string fechaDesde, string fechaHasta, int dpto = 0, int seccion = 0)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                table.Columns.Add("Nombre");
                table.Columns.Add("Marca S.Pedro");
                table.Columns.Add("Marca Zapote");
                table.Columns.Add("Fecha Prog");
                table.Columns.Add("Ent Prog");
                table.Columns.Add("Sal Prog");
                table.Columns.Add("Entrada");
                table.Columns.Add("Salida");
                table.Columns.Add("Fec Marca");
                table.Columns.Add("Ubicacion");
                table.Columns.Add("Nom Ubicacion");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("Consultar_Marcas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada

                if (dpto != 0 && seccion != 0)
                {
                    cmd.Parameters.AddWithValue("@piCodDpto", dpto);
                    cmd.Parameters.AddWithValue("@piCodseccion", seccion);
                }
                cmd.Parameters.AddWithValue("@psFechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("@psFechaHasta", fechaHasta);

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
                        fila["Id"] = Convert.ToInt32(reader["idPersona"]);
                        fila["Nombre"] = reader["nombre"];
                        fila["Marca S.Pedro"] = reader["idMarcaSP"];
                        fila["Marca Zapote"] = reader["idMarcaZPT"];
                        fila["Fecha Prog"] = reader["fecProg"];
                        fila["Ent Prog"] = reader["HEProg"];
                        fila["Sal Prog"] = reader["HSProg"];
                        fila["Entrada"] = reader["entrada"];
                        fila["Salida"] = reader["salida"];
                        fila["Fec Marca"] = reader["fecMar"];
                        fila["Ubicacion"] = reader["ubicacion"];
                        fila["Nom Ubicacion"] = reader["NomUbicacion"];

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

        public DataTable ObtenerPersonalACargo(Int32 idPersona)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                table.Columns.Add("Nombre");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ObtenerPersonasACargo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@piIdPersona", idPersona);

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
                        fila["Id"] = Convert.ToInt32(reader["idPersona"]);
                        fila["Nombre"] = reader["nombre"].ToString();
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
