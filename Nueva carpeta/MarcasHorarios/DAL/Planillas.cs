using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class Planillas
    {
        //Variables de la clase
        SqlConnection Conexion;

        //Constructor de la clase
        public Planillas()
        {
            //Se inicializa la Conexion
            Conexion = new SqlConnection();
            Conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        }

        #region Carga de Datos (Marcas y Horarios)

        /// <summary>
        /// Método que se encarga de registrar los datos de las marcas en la Base de Datos
        /// </summary>
        /// <param name="oMarcas">Objeto que contiene toda la información correspondiente a las marcas</param>
        public void cargarDatos(Marca oMarcas, Persona oPersona)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            //Se setean las variables  rnunez@netcom.com.pa
            cn = new SqlConnection(Conexion.ConnectionString);
            //Se define el procedimiento almacenado a utilizar
            cmd = new SqlCommand("CargarMarcas", cn);

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@piNumMarca", oMarcas.idMarca);
                cmd.Parameters.AddWithValue("@psHoraEntrada", oMarcas.horaEntrada);
                cmd.Parameters.AddWithValue("@psHoraSalida", oMarcas.horaSalida);
                var dtFecha = DateTime.Parse(oMarcas.fecha);
                var dbFecha = dtFecha.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@pdtFecha", dbFecha);
                cmd.Parameters.AddWithValue("@piUbicacion", oMarcas.ubicacion);
                cmd.Parameters.AddWithValue("@piUsuario", oPersona.idPersona);
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
                cn.Close();
                throw new Exception("Se presento un problema al conectar con la Base de Datos.", ex.InnerException);
            }
        }

        /// <summary>
        /// Método que se encarga de registrar los datos de horarios asignados al personal en la Base de Datos
        /// </summary>
        /// <param name="oProgramacion">Objeto que contiene toda la información correspondiente a los horarios</param>
        public void cargarDatos(Programacion oProgramacion, Persona oPersona)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            //Se setean las variables  rnunez@netcom.com.pa
            cn = new SqlConnection(Conexion.ConnectionString);
            //Se define el procedimiento almacenado a utilizar
            cmd = new SqlCommand("CargarProgramacion", cn);

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@piIdPersona", oProgramacion.idPersona);
                cmd.Parameters.AddWithValue("@psNombre", oProgramacion.nombre);
                var dtFecha = DateTime.Parse(oProgramacion.fecha);
                var dbFecha = dtFecha.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@pdtFecha", dbFecha);
                var he = DateTime.Parse(oProgramacion.horaEntrada);
                var dbHoraEnt = he.TimeOfDay.ToString();
                cmd.Parameters.AddWithValue("@psHoraEntrada", dbHoraEnt);
                var hs = DateTime.Parse(oProgramacion.horaSalida);
                var dbHoraSal = hs.TimeOfDay.ToString();
                cmd.Parameters.AddWithValue("@psHoraSalida", dbHoraSal);
                cmd.Parameters.AddWithValue("@piUsuarioReg", oPersona.idPersona);
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
                cn.Close();
                throw new Exception("Se presento un problema al conectar con la Base de Datos.", ex.InnerException);
            }
        }

        #endregion

        #region Consultas Marcas Avaya Programaciones de Personas x Fecha

        public DataTable ConsultaDatosProgramacion(string desde, string hasta, string nombre, ref string horasProg)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("nombre");
                table.Columns.Add("dia");
                table.Columns.Add("fecha");
                table.Columns.Add("entrada");
                table.Columns.Add("salida");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ConsultaDatosProgramaciones", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@psFechaDesde", desde);
                cmd.Parameters.AddWithValue("@psFechaHasta", hasta);
                cmd.Parameters.AddWithValue("@psNombre", nombre);

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();

                var diferencia = TimeSpan.Zero;
                var total = TimeSpan.Zero;

                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();
                        //Se cargan los datos en la fila
                        fila["nombre"] = reader["nombre"].ToString();
                        fila["dia"] = RenombrarDia(reader["dia"].ToString());
                        fila["fecha"] = reader["fecha"].ToString();
                        fila["entrada"] = reader["horaEntrada"].ToString();
                        fila["salida"] = reader["horaSalida"].ToString();

                        //Se agrega la fila a la tabla
                        table.Rows.Add(fila);

                        //Variables para manejo de horas
                        var entrada = fila["entrada"].ToString();
                        var salida = fila["salida"].ToString();

                        //Obtención del total de horas según el horario que se le asigna a un agente
                        if (!entrada.Equals(String.Empty) && !salida.Equals(String.Empty))
                        {
                            if (!(TimeSpan.Parse(salida) < TimeSpan.Parse(entrada)))
                                diferencia = TimeSpan.Parse(salida) - TimeSpan.Parse(entrada);
                            else
                            {
                                diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(entrada);
                                diferencia += TimeSpan.Parse(salida) - TimeSpan.Parse("00:00:00");
                            }
                            total += diferencia;
                        }
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();

                var contienePunto = total.ToString().Contains(".");
                if (contienePunto)
                {
                    //se formatea el total de horas acumuladas
                    var arregloHoras = total.ToString().Split('.');
                    //horasProg = total.ToString();
                    if (arregloHoras.Length > 1)
                    {
                        var horasTotales = Int32.Parse(arregloHoras[0]);
                        horasTotales = horasTotales * 24;
                        var horasRestantes = arregloHoras[1];
                        var splithora = horasRestantes.Split(':');
                        horasTotales += Int32.Parse(splithora[0]);

                        string horasFormateadas = horasTotales + ":" + splithora[1] + ":" + splithora[2];
                        horasProg = horasFormateadas;
                    }
                }
                else
                {
                    horasProg = total.ToString();
                }
                ////se formatea el total de horas acumuladas
                //var arregloHoras = total.ToString().Split('.');
                ////horasProg = total.ToString();
                //if (arregloHoras.Length > 1)
                //{
                //    var horasTotales = Int32.Parse(arregloHoras[0]);
                //    horasTotales = horasTotales * 24;
                //    var horasRestantes = arregloHoras[1];
                //    var splithora = horasRestantes.Split(':');
                //    horasTotales += Int32.Parse(splithora[0]);

                //    string horasFormateadas = horasTotales + ":" + splithora[1] + ":" + splithora[2];
                //    horasProg = horasFormateadas;
                //}

                //se retorna la lista
                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string RenombrarDia(string dia)
        {
            var diaEspanniol = string.Empty;
            var UpDia = dia.ToUpper();
            switch (UpDia)
            {
                case "MONDAY":
                    diaEspanniol = "Lunes";
                    break;
                case "TUESDAY":
                    diaEspanniol = "Martes";
                    break;
                case "WEDNESDAY":
                    diaEspanniol = "Miércoles";
                    break;
                case "THURSDAY":
                    diaEspanniol = "Jueves";
                    break;
                case "FRIDAY":
                    diaEspanniol = "Viernes";
                    break;
                case "SATURDAY":
                    diaEspanniol = "Sábado";
                    break;
                case "SUNDAY":
                    diaEspanniol = "Domingo";
                    break;
            }
            return diaEspanniol;
        }

        public DataTable ObtenerProgramacion(string desde, string hasta, Int32 idPersona)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("nombre");
                table.Columns.Add("dia");
                table.Columns.Add("fecha");
                table.Columns.Add("entrada");
                table.Columns.Add("salida");
                table.Columns.Add("justificacion");
                table.Columns.Add("comentario");
                table.Columns.Add("id");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ObtenerProgramacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@psFechaDesde", desde);
                cmd.Parameters.AddWithValue("@psFechaHasta", hasta);
                cmd.Parameters.AddWithValue("@psIdPersona", idPersona);

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();

                var diferencia = TimeSpan.Zero;
                var total = TimeSpan.Zero;

                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();
                        //Se cargan los datos en la fila
                        //fila["nombre"] = reader["nombre"].ToString();
                        fila["dia"] = reader["dia"].ToString();
                        fila["fecha"] = reader["fecha"].ToString();
                        fila["entrada"] = reader["horaEntrada"].ToString();
                        fila["salida"] = reader["horaSalida"].ToString();
                        fila["justificacion"] = reader["justificacion"].ToString();
                        fila["comentario"] = reader["comentario"].ToString();
                        fila["id"] = reader["idProgramacion"].ToString();

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

        public void JustificarProgramacion(int idProgramacion, string justificacion, string comentario)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("Justificar_Programacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@piIdProg", idProgramacion);
                cmd.Parameters.AddWithValue("@piJustificacion", justificacion);
                cmd.Parameters.AddWithValue("@psComentario", comentario);

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

        //public DataTable ConsultaCMSAACC(string desde, string hasta, string nombre)
        //{
        //    //Variables
        //    SqlConnection cn;
        //    SqlCommand cmd;
        //    try
        //    {
        //        //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
        //        DataTable table = new DataTable();
        //        table.Columns.Add("agentLogin");
        //        table.Columns.Add("dia");
        //        table.Columns.Add("fechaHora");
        //        table.Columns.Add("eventType");
        //        table.Columns.Add("hora");

        //        //Se setean las varaqibles
        //        cn = new SqlConnection(Conexion.ConnectionString);
        //        //Se define el procedimiento almacenado a utilizar
        //        cmd = new SqlCommand("ConsultaDatosCMS_AACC", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        //se pasan los parametros de entrada
        //        cmd.Parameters.AddWithValue("@psFechaDesde", desde);
        //        cmd.Parameters.AddWithValue("@psFechaHasta", hasta);
        //        cmd.Parameters.AddWithValue("@psNombre", nombre);

        //        //se abre la conexión
        //        cn.Open();
        //        //Se ejecuta la consulta y se obtiene el resultado
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            //mientras existan datos
        //            while (reader.Read())
        //            {
        //                //Se crea una fila nueva para cada tupla recuperada en la consulta
        //                DataRow fila = table.NewRow();
        //                //Se cargan los datos en la fila
        //                fila["agentLogin"] = reader["agentLogin"].ToString();
        //                fila["dia"] = reader["dia"].ToString();
        //                fila["fechaHora"] = reader["fechaHora"].ToString();
        //                fila["eventType"] = reader["eventType"].ToString();
        //                fila["hora"] = reader["hora"].ToString();

        //                //Se agrega la fila a la tabla
        //                table.Rows.Add(fila);
        //            }
        //        }
        //        //se cierra el reader
        //        reader.Dispose();
        //        //Se cierra la conexión
        //        cn.Close();
        //        //se retorna la lista
        //        return table;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public DataTable ConsultaCMSAACC(string desde, string hasta, string extensiones, ref string horasCMSA)
        {
            //Variables
            OdbcConnection cn;
            OdbcCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("agentLogin");
                table.Columns.Add("fechahora");
                table.Columns.Add("AgentSurName");
                table.Columns.Add("AgentGivenName");
                table.Columns.Add("horaEntrada");
                table.Columns.Add("horaSalida");
                table.Columns.Add("dia");

                DataTable temporal = new DataTable();
                temporal.Columns.Add("agentLogin");
                temporal.Columns.Add("fechahora");
                temporal.Columns.Add("AgentSurName");
                temporal.Columns.Add("AgentGivenName");
                temporal.Columns.Add("EventType");
                temporal.Columns.Add("hora");
                temporal.Columns.Add("dia");

                //Se setean las varaqibles
                cn = openCMSConnection();

                /*****************************************************************************************************/
                var consulta = "SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE eAgentLoginStat.AgentLogin in (";
                var ext = extensiones.Split(',');
                string lista = string.Empty;

                if (ext.Length == 1)
                {
                    consulta = consulta + ext[0] + ") AND (eAgentLoginStat.EventType Like '%LI%' OR eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') ORDER BY eAgentLoginStat.Timestamp";
                }
                else
                {
                    for (int j = 0; j < ext.Length; j++)
                    {
                        if (j == 0)
                        {
                            consulta = consulta + ext[j];
                        }
                        else
                        {
                            consulta = consulta + "," + ext[j];
                        }
                    }
                    consulta = consulta + ") AND (eAgentLoginStat.EventType Like '%LI%' OR eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') ORDER BY eAgentLoginStat.Timestamp";
                }
                /*******************************************************************************************************/

                //cmd = new OdbcCommand("SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE(eAgentLoginStat.EventType Like '%LI%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') OR(eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') AND eAgentLoginStat.AgentLogin in (13252) ORDER BY eAgentLoginStat.Timestamp", cn);
                cmd = new OdbcCommand(consulta, cn);
                cmd.CommandType = CommandType.Text;
                //Se ejecuta la consulta y se obtiene el resultado
                OdbcDataReader reader = cmd.ExecuteReader();
                OdbcDataReader readerCopia = reader;
                TimeSpan totalAACC = TimeSpan.Zero;
                TimeSpan diferenciaAACC = TimeSpan.Zero;
                if (reader.HasRows)
                {
                    //variables
                    var diaActual = string.Empty;
                    var diaAnterior = string.Empty;
                    string[] datosLilo = new string[7];//0:dia, 1:li, 2:lo, 3:fechahora, 4:AgentSurName, 5:AgentGivenName, 6:agentLogin
                    var contador = 0;

                    while (reader.Read())
                    {
                        DateTime fechahora = Convert.ToDateTime(reader["Timestamp"].ToString());

                        DataRow filaTemp = temporal.NewRow();
                        //Se cargan los datos en la fila
                        filaTemp["agentLogin"] = reader["AgentLogin"].ToString();
                        filaTemp["fechahora"] = reader["Timestamp"].ToString();
                        filaTemp["AgentSurName"] = reader["AgentSurName"].ToString();
                        filaTemp["AgentGivenName"] = reader["AgentGivenName"].ToString();
                        filaTemp["EventType"] = reader["EventType"].ToString();
                        filaTemp["hora"] = reader["Time"].ToString();
                        filaTemp["dia"] = fechahora.ToString("dddd", new CultureInfo("es-ES"));

                        temporal.Rows.Add(filaTemp);
                    }

                    for (int r = 0; r < temporal.Rows.Count; r++)
                    {
                        //var registros = 
                        var valido = false;
                        var extNum = extensiones.Split(',');
                        for (int i = 0; i < extNum.Length; i++)
                        {
                            if (temporal.Rows[r][0].ToString().Equals(extNum[i].ToString()))
                            {
                                valido = true;
                            }
                        }
                        if (valido)
                        {
                            /*************************************************************************************/
                            DateTime fechahora = Convert.ToDateTime(temporal.Rows[r][1].ToString());
                            var dia = fechahora.ToString("dddd", new CultureInfo("es-ES"));

                            if (contador == 0)
                            {
                                if (temporal.Rows[r][4].ToString().Equals("LI"))
                                {
                                    datosLilo[0] = dia;
                                    datosLilo[1] = temporal.Rows[r][5].ToString();
                                    datosLilo[3] = temporal.Rows[r][1].ToString();
                                    datosLilo[4] = temporal.Rows[r][2].ToString();
                                    datosLilo[5] = temporal.Rows[r][3].ToString();
                                    datosLilo[6] = temporal.Rows[r][0].ToString();
                                }
                                diaAnterior = dia;
                                //contador++;
                            }
                            else
                            {
                                diaActual = dia;
                                if (diaActual.Equals(diaAnterior))
                                {
                                    if (temporal.Rows[r][4].ToString().Equals("LO"))
                                    {
                                        datosLilo[2] = temporal.Rows[r][5].ToString();
                                    }
                                    if ((contador + 1) >= temporal.Rows.Count)
                                    {
                                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                                        DataRow fila = table.NewRow();
                                        //Se cargan los datos en la fila
                                        fila["agentLogin"] = datosLilo[6];
                                        fila["fechahora"] = datosLilo[3];
                                        fila["AgentSurName"] = datosLilo[4];
                                        fila["AgentGivenName"] = datosLilo[5];
                                        fila["horaEntrada"] = datosLilo[1];
                                        fila["horaSalida"] = datosLilo[2];
                                        fila["dia"] = datosLilo[0];

                                        //Se agrega la fila a la tabla
                                        table.Rows.Add(fila);

                                        if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                            diferenciaAACC = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                        else
                                        {
                                            diferenciaAACC = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                            diferenciaAACC += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                        }
                                        totalAACC += diferenciaAACC;
                                    }
                                }
                                else
                                {
                                    //Se crea una fila nueva para cada tupla recuperada en la consulta
                                    DataRow fila = table.NewRow();
                                    //Se cargan los datos en la fila
                                    fila["agentLogin"] = datosLilo[6];
                                    fila["fechahora"] = datosLilo[3];
                                    fila["AgentSurName"] = datosLilo[4];
                                    fila["AgentGivenName"] = datosLilo[5];
                                    fila["horaEntrada"] = datosLilo[1];
                                    fila["horaSalida"] = datosLilo[2];
                                    fila["dia"] = datosLilo[0];

                                    //Se agrega la fila a la tabla
                                    table.Rows.Add(fila);

                                    if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                        diferenciaAACC = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                    else
                                    {
                                        diferenciaAACC = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                        diferenciaAACC += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                    }
                                    totalAACC += diferenciaAACC;

                                    datosLilo = new string[7];

                                    if (temporal.Rows[r][4].ToString().Equals("LI"))
                                    {
                                        datosLilo[0] = dia;
                                        datosLilo[1] = temporal.Rows[r][5].ToString();
                                        datosLilo[3] = temporal.Rows[r][1].ToString();
                                        datosLilo[4] = temporal.Rows[r][2].ToString();
                                        datosLilo[5] = temporal.Rows[r][3].ToString();
                                        datosLilo[6] = temporal.Rows[r][0].ToString();
                                        diaAnterior = diaActual;
                                    }
                                }
                            }
                            contador++;

                            /*************************************************************************************/
                        }
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();

                //se formatea el total de horas acumuladas
                var arregloHorasA = totalAACC.ToString().Split('.');
                if (arregloHorasA.Length > 1)
                {
                    var horasTotalesA = Int32.Parse(arregloHorasA[0]);
                    horasTotalesA = horasTotalesA * 24;
                    var horasRestantesA = arregloHorasA[1];
                    var splithoraA = horasRestantesA.Split(':');
                    horasTotalesA += Int32.Parse(splithoraA[0]);

                    string horasFormateadas = horasTotalesA + ":" + splithoraA[1] + ":" + splithoraA[2];
                    horasCMSA = horasFormateadas;
                }

                //se retorna la lista
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerCMSAACC(string desde, string hasta, string extensiones)
        {
            //Variables
            OdbcConnection cn;
            OdbcCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("agentLogin");
                table.Columns.Add("fechahora");
                table.Columns.Add("AgentSurName");
                table.Columns.Add("AgentGivenName");
                table.Columns.Add("horaEntrada");
                table.Columns.Add("horaSalida");
                table.Columns.Add("dia");

                DataTable temporal = new DataTable();
                temporal.Columns.Add("agentLogin");
                temporal.Columns.Add("fechahora");
                temporal.Columns.Add("AgentSurName");
                temporal.Columns.Add("AgentGivenName");
                temporal.Columns.Add("EventType");
                temporal.Columns.Add("hora");
                temporal.Columns.Add("dia");

                //Se setean las varaqibles
                cn = openCMSConnection();

                /*****************************************************************************************************/
                var consulta = "SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE eAgentLoginStat.AgentLogin in (";
                var ext = extensiones.Split(',');
                string lista = string.Empty;

                if (ext.Length == 1)
                {
                    consulta = consulta + ext[0] + ") AND (eAgentLoginStat.EventType Like '%LI%' OR eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') ORDER BY eAgentLoginStat.Timestamp";
                }
                else
                {
                    for (int j = 0; j < ext.Length; j++)
                    {
                        if (j == 0)
                        {
                            consulta = consulta + ext[j];
                        }
                        else
                        {
                            consulta = consulta + "," + ext[j];
                        }
                    }
                    consulta = consulta + ") AND (eAgentLoginStat.EventType Like '%LI%' OR eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') ORDER BY eAgentLoginStat.Timestamp";
                }
                /*******************************************************************************************************/

                //cmd = new OdbcCommand("SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE(eAgentLoginStat.EventType Like '%LI%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') OR(eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') AND eAgentLoginStat.AgentLogin in (13252) ORDER BY eAgentLoginStat.Timestamp", cn);
                cmd = new OdbcCommand(consulta, cn);
                cmd.CommandType = CommandType.Text;
                //Se ejecuta la consulta y se obtiene el resultado
                OdbcDataReader reader = cmd.ExecuteReader();
                OdbcDataReader readerCopia = reader;
                //TimeSpan totalAACC = TimeSpan.Zero;
                //TimeSpan diferenciaAACC = TimeSpan.Zero;
                if (reader.HasRows)
                {
                    //variables
                    var diaActual = string.Empty;
                    var diaAnterior = string.Empty;
                    string[] datosLilo = new string[7];//0:dia, 1:li, 2:lo, 3:fechahora, 4:AgentSurName, 5:AgentGivenName, 6:agentLogin
                    var contador = 0;

                    while (reader.Read())
                    {
                        DateTime fechahora = Convert.ToDateTime(reader["Timestamp"].ToString());

                        DataRow filaTemp = temporal.NewRow();
                        //Se cargan los datos en la fila
                        filaTemp["agentLogin"] = reader["AgentLogin"].ToString();
                        filaTemp["fechahora"] = reader["Timestamp"].ToString();
                        filaTemp["AgentSurName"] = reader["AgentSurName"].ToString();
                        filaTemp["AgentGivenName"] = reader["AgentGivenName"].ToString();
                        filaTemp["EventType"] = reader["EventType"].ToString();
                        filaTemp["hora"] = reader["Time"].ToString();
                        filaTemp["dia"] = fechahora.ToString("dddd", new CultureInfo("es-ES"));

                        temporal.Rows.Add(filaTemp);
                    }

                    for (int r = 0; r < temporal.Rows.Count; r++)
                    {
                        //var registros = 
                        var valido = false;
                        var extNum = extensiones.Split(',');
                        for (int i = 0; i < extNum.Length; i++)
                        {
                            if (temporal.Rows[r][0].ToString().Equals(extNum[i].ToString()))
                            {
                                valido = true;
                            }
                        }
                        if (valido)
                        {
                            /*************************************************************************************/
                            DateTime fechahora = Convert.ToDateTime(temporal.Rows[r][1].ToString());
                            var dia = fechahora.ToString("dddd", new CultureInfo("es-ES"));

                            if (contador == 0)
                            {
                                if (temporal.Rows[r][4].ToString().Equals("LI"))
                                {
                                    datosLilo[0] = dia;
                                    datosLilo[1] = temporal.Rows[r][5].ToString();
                                    datosLilo[3] = temporal.Rows[r][1].ToString();
                                    datosLilo[4] = temporal.Rows[r][2].ToString();
                                    datosLilo[5] = temporal.Rows[r][3].ToString();
                                    datosLilo[6] = temporal.Rows[r][0].ToString();
                                }
                                diaAnterior = dia;
                                //contador++;
                            }
                            else
                            {
                                diaActual = dia;
                                if (diaActual.Equals(diaAnterior))
                                {
                                    if (temporal.Rows[r][4].ToString().Equals("LO"))
                                    {
                                        datosLilo[2] = temporal.Rows[r][5].ToString();
                                    }
                                    if ((contador + 1) >= temporal.Rows.Count)
                                    {
                                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                                        DataRow fila = table.NewRow();
                                        //Se cargan los datos en la fila
                                        fila["agentLogin"] = datosLilo[6];
                                        fila["fechahora"] = datosLilo[3];
                                        fila["AgentSurName"] = datosLilo[4];
                                        fila["AgentGivenName"] = datosLilo[5];
                                        fila["horaEntrada"] = datosLilo[1];
                                        fila["horaSalida"] = datosLilo[2];
                                        fila["dia"] = datosLilo[0];

                                        //Se agrega la fila a la tabla
                                        table.Rows.Add(fila);
                                    }
                                }
                                else
                                {
                                    //Se crea una fila nueva para cada tupla recuperada en la consulta
                                    DataRow fila = table.NewRow();
                                    //Se cargan los datos en la fila
                                    fila["agentLogin"] = datosLilo[6];
                                    fila["fechahora"] = datosLilo[3];
                                    fila["AgentSurName"] = datosLilo[4];
                                    fila["AgentGivenName"] = datosLilo[5];
                                    fila["horaEntrada"] = datosLilo[1];
                                    fila["horaSalida"] = datosLilo[2];
                                    fila["dia"] = datosLilo[0];

                                    //Se agrega la fila a la tabla
                                    table.Rows.Add(fila);

                                    datosLilo = new string[7];

                                    if (temporal.Rows[r][4].ToString().Equals("LI"))
                                    {
                                        datosLilo[0] = dia;
                                        datosLilo[1] = temporal.Rows[r][5].ToString();
                                        datosLilo[3] = temporal.Rows[r][1].ToString();
                                        datosLilo[4] = temporal.Rows[r][2].ToString();
                                        datosLilo[5] = temporal.Rows[r][3].ToString();
                                        datosLilo[6] = temporal.Rows[r][0].ToString();
                                        diaAnterior = diaActual;
                                    }
                                }
                            }
                            contador++;

                            /*************************************************************************************/
                        }
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

        public DataTable ConsultaCMSAACCcopia(string desde, string hasta, string extensiones)
        {
            //Variables
            OdbcConnection cn;
            OdbcCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("agentLogin");
                table.Columns.Add("fechahora");
                table.Columns.Add("AgentSurName");
                table.Columns.Add("AgentGivenName");
                table.Columns.Add("horaEntrada");
                table.Columns.Add("horaSalida");
                table.Columns.Add("dia");

                //Se setean las varaqibles
                cn = openCMSConnection();

                /*****************************************************************************************************/
                //var consulta = "SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE(eAgentLoginStat.EventType Like '%LI%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') OR(eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') AND eAgentLoginStat.AgentLogin in (";
                var consulta = "SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE eAgentLoginStat.AgentLogin in (";
                var ext = extensiones.Split(',');
                string lista = string.Empty;

                if (ext.Length == 1)
                {
                    consulta = consulta + ext[0] + ") AND (eAgentLoginStat.EventType Like '%LI%' OR eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') ORDER BY eAgentLoginStat.Timestamp";
                }
                else
                {
                    for (int j = 0; j < ext.Length; j++)
                    {
                        if (j == 0)
                        {
                            consulta = consulta + ext[j];
                        }
                        else
                        {
                            consulta = consulta + "," + ext[j];
                        }
                    }
                    consulta = consulta + ") AND (eAgentLoginStat.EventType Like '%LI%' OR eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') ORDER BY eAgentLoginStat.Timestamp";
                }
                /*******************************************************************************************************/
                //SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE eAgentLoginStat.AgentLogin in (13417) AND (eAgentLoginStat.EventType Like '%LI%' OR eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='2017-11-06' And eAgentLoginStat.Timestamp <='2017-11-10') ORDER BY eAgentLoginStat.Timestamp
                //cmd = new OdbcCommand("SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE(eAgentLoginStat.EventType Like '%LI%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') OR(eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') AND eAgentLoginStat.AgentLogin in (13252) ORDER BY eAgentLoginStat.Timestamp", cn);
                cmd = new OdbcCommand(consulta, cn);
                cmd.CommandType = CommandType.Text;
                //Se ejecuta la consulta y se obtiene el resultado
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        var valido = false;
                        var extNum = extensiones.Split(',');
                        for (int i = 0; i < extNum.Length; i++)
                        {
                            if (reader["AgentLogin"].ToString().Equals(extNum[i].ToString()))
                            {
                                valido = true;
                            }
                        }
                        if (valido)
                        {
                            //Se crea una fila nueva para cada tupla recuperada en la consulta
                            DataRow fila = table.NewRow();

                            DateTime fechahora = Convert.ToDateTime(reader["Timestamp"].ToString());
                            var dia = fechahora.ToString("dddd", new CultureInfo("es-ES"));

                            //Se cargan los datos en la fila
                            fila["agentLogin"] = reader["AgentLogin"].ToString();
                            fila["fechahora"] = reader["Timestamp"].ToString();
                            fila["AgentSurName"] = reader["AgentSurName"].ToString();
                            fila["AgentGivenName"] = reader["AgentGivenName"].ToString();
                            fila["horaEntrada"] = reader["EventType"].ToString();
                            fila["horaSalida"] = reader["Time"].ToString();
                            fila["dia"] = dia;

                            //Se agrega la fila a la tabla
                            table.Rows.Add(fila);
                        }
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

        //public DataTable ConsultaCMSElite(string desde, string hasta, string nombre)
        //{
        //    //Variables
        //    SqlConnection cn;
        //    SqlCommand cmd;
        //    try
        //    {
        //        //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
        //        DataTable table = new DataTable();
        //        table.Columns.Add("logid");
        //        table.Columns.Add("dia");
        //        table.Columns.Add("fecha");
        //        table.Columns.Add("login");
        //        table.Columns.Add("logout");

        //        //Se setean las varaqibles
        //        cn = new SqlConnection(Conexion.ConnectionString);
        //        //Se define el procedimiento almacenado a utilizar
        //        cmd = new SqlCommand("ConsultaDatosCMS_ELITE", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        //se pasan los parametros de entrada
        //        cmd.Parameters.AddWithValue("@psFechaDesde", desde);
        //        cmd.Parameters.AddWithValue("@psFechaHasta", hasta);
        //        cmd.Parameters.AddWithValue("@psNombre", nombre);

        //        //se abre la conexión
        //        cn.Open();
        //        //Se ejecuta la consulta y se obtiene el resultado
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            //mientras existan datos
        //            while (reader.Read())
        //            {
        //                //Se crea una fila nueva para cada tupla recuperada en la consulta
        //                DataRow fila = table.NewRow();
        //                //Se cargan los datos en la fila
        //                fila["logid"] = reader["logid"].ToString();
        //                fila["dia"] = reader["dia"].ToString();
        //                fila["fecha"] = reader["fecha"].ToString();
        //                fila["login"] = reader["login"].ToString();
        //                fila["logout"] = reader["logout"].ToString();

        //                //Se agrega la fila a la tabla
        //                table.Rows.Add(fila);
        //            }
        //        }
        //        //se cierra el reader
        //        reader.Dispose();
        //        //Se cierra la conexión
        //        cn.Close();
        //        //se retorna la lista
        //        return table;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public DataTable ConsultaCMSElite(string desde, string hasta, string extensiones, ref string horasCMSE)
        {
            //Variables
            OdbcConnection cn;
            OdbcCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("fechahora");
                table.Columns.Add("agentLogin");
                table.Columns.Add("horaEntrada");
                table.Columns.Add("horaSalida");
                table.Columns.Add("dia");

                DataTable temporal = new DataTable();
                temporal.Columns.Add("logid");
                temporal.Columns.Add("fecha");
                temporal.Columns.Add("login");
                temporal.Columns.Add("logout");
                temporal.Columns.Add("dia");

                //Se setean las varaqibles
                cn = openCMSConnectionElite();
                //Se define el procedimiento almacenado a utilizar
                /*****************************************************************************************************/
                var consulta = "SELECT haglog.row_date, haglog.seq_num, haglog.logid, haglog.acd, haglog.split, haglog.login, haglog.logout FROM root.haglog haglog WHERE (haglog.row_date>={d '" + desde + "'} And haglog.row_date<={d '" + hasta + "'}) AND haglog.logid in (";
                var ext = extensiones.Split(',');
                string lista = string.Empty;

                if (ext.Length == 1)
                {
                    consulta = consulta + ext[0] + ") ORDER BY haglog.row_date, haglog.logid, haglog.login";
                }
                else
                {
                    for (int j = 0; j < ext.Length; j++)
                    {
                        if (j == 0)
                        {
                            consulta = consulta + ext[j];
                        }
                        else
                        {
                            consulta = consulta + "," + ext[j];
                        }
                    }
                    consulta = consulta + ") ORDER BY haglog.row_date, haglog.logid, haglog.login";
                }
                /*******************************************************************************************************/

                //cmd = new OdbcCommand("SELECT haglog.row_date, haglog.seq_num, haglog.logid, haglog.acd, haglog.split, haglog.login, haglog.logout FROM root.haglog haglog WHERE (haglog.row_date>={d '" + desde + "'} And haglog.row_date<={d '" + hasta + "'}) ORDER BY haglog.row_date, haglog.logid, haglog.login", cn);
                cmd = new OdbcCommand(consulta, cn);
                cmd.CommandType = CommandType.Text;
                //Se ejecuta la consulta y se obtiene el resultado
                OdbcDataReader reader = cmd.ExecuteReader();

                TimeSpan diferencia = TimeSpan.Zero;
                TimeSpan total = TimeSpan.Zero;

                if (reader.HasRows)
                {
                    //variables
                    var diaActual = string.Empty;
                    var diaAnterior = string.Empty;
                    string[] datosLilo = new string[5];//0:dia, 1:li, 2:lo, 3:fechahora, 6:agentLogin
                    var contador = 0;

                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se toma la fecha y se formatea
                        var datoFechaHora = long.Parse(reader["seq_num"].ToString());
                        var fechaHora = UtilitarioDAL.FromUnixTime(datoFechaHora);

                        var datologin = long.Parse(reader["login"].ToString());
                        var fechalogin = UtilitarioDAL.FromUnixTime(datologin);
                        var login = fechalogin.TimeOfDay;

                        var datologout = long.Parse(reader["logout"].ToString());
                        var fechalogout = UtilitarioDAL.FromUnixTime(datologout);
                        var logout = fechalogout.TimeOfDay;

                        DataRow filaTemp = temporal.NewRow();
                        //Se cargan los datos en la fila
                        filaTemp["logid"] = reader["logid"].ToString();
                        filaTemp["fecha"] = fechaHora;
                        filaTemp["login"] = login;
                        filaTemp["logout"] = logout;
                        filaTemp["dia"] = fechaHora.ToString("dddd", new CultureInfo("es-ES"));

                        temporal.Rows.Add(filaTemp);
                    }

                    for (int x = 0; x < temporal.Rows.Count; x++)
                    {
                        var dia = temporal.Rows[x][4].ToString();

                        datosLilo[0] = temporal.Rows[x][4].ToString();
                        if (contador == 0)
                        {
                            datosLilo[1] = temporal.Rows[x][2].ToString();
                            contador++;
                        }
                        datosLilo[2] = temporal.Rows[x][3].ToString();
                        datosLilo[3] = temporal.Rows[x][1].ToString();
                        datosLilo[4] = temporal.Rows[x][0].ToString();

                        if (dia.Equals(diaAnterior))
                        {
                            datosLilo[2] = temporal.Rows[x][3].ToString();
                            if ((x + 1) >= temporal.Rows.Count)
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                    diferencia = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                else
                                {
                                    diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                    diferencia += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                }
                                total += diferencia;

                                //se reinicia el contador
                                contador = 0;
                            }
                            else if (!dia.Equals(temporal.Rows[x + 1][4].ToString()))
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                    diferencia = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                else
                                {
                                    diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                    diferencia += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                }
                                total += diferencia;

                                //se reinicia el contador
                                contador = 0;
                            }
                        }
                        else
                        {
                            datosLilo[2] = temporal.Rows[x][3].ToString();
                            if ((x + 1) >= temporal.Rows.Count)
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                    diferencia = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                else
                                {
                                    diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                    diferencia += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                }
                                total += diferencia;

                                //se reinicia el contador
                                contador = 0;
                            }
                            else if (!dia.Equals(temporal.Rows[x + 1][4].ToString()))
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                    diferencia = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                else
                                {
                                    diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                    diferencia += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                }
                                total += diferencia;

                                //se reinicia el contador
                                contador = 0;
                            }
                        }

                        diaAnterior = dia;
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();

                var contienePunto = total.ToString().Contains(".");
                if (contienePunto)
                {
                    //se formatea el total de horas acumuladas
                    var arregloHoras = total.ToString().Split('.');

                    if (arregloHoras.Length > 1)
                    {
                        var horasTotales = Int32.Parse(arregloHoras[0]);
                        horasTotales = horasTotales * 24;
                        var horasRestantes = arregloHoras[1];
                        var splithora = horasRestantes.Split(':');
                        horasTotales += Int32.Parse(splithora[0]);

                        string horasFormateadas = horasTotales + ":" + splithora[1] + ":" + splithora[2];
                        horasCMSE = horasFormateadas;
                    }
                }
                else
                {
                    horasCMSE = total.ToString();
                }


                //se retorna la lista
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ConsultaLogueosEliteXId(string desde, string hasta, int idPersona, ref string horasCMSE)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("fechahora");
                table.Columns.Add("agentLogin");
                table.Columns.Add("horaEntrada");
                table.Columns.Add("horaSalida");
                table.Columns.Add("dia");

                DataTable temporal = new DataTable();
                temporal.Columns.Add("logid");
                temporal.Columns.Add("fecha");
                temporal.Columns.Add("login");
                temporal.Columns.Add("logout");
                temporal.Columns.Add("dia");

                /*****************************************************************************************************/
                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("Obtener_DatosLiLo_Elite_X_Persona", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                cmd.Parameters.AddWithValue("@idPersona", idPersona);

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();
                /*******************************************************************************************************/

                TimeSpan diferencia = TimeSpan.Zero;
                TimeSpan total = TimeSpan.Zero;

                if (reader.HasRows)
                {
                    //variables
                    var diaActual = string.Empty;
                    var diaAnterior = string.Empty;
                    string[] datosLilo = new string[5];//0:dia, 1:li, 2:lo, 3:fechahora, 6:agentLogin
                    var contador = 0;

                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se toma la fecha y se formatea
                        var datoFechaHora = long.Parse(reader["seq_num"].ToString());
                        var fechaHora = UtilitarioDAL.FromUnixTime(datoFechaHora);

                        var datologin = long.Parse(reader["login"].ToString());
                        var fechalogin = UtilitarioDAL.FromUnixTime(datologin);
                        var login = fechalogin.TimeOfDay;

                        var datologout = long.Parse(reader["logout"].ToString());
                        var fechalogout = UtilitarioDAL.FromUnixTime(datologout);
                        var logout = fechalogout.TimeOfDay;

                        DataRow filaTemp = temporal.NewRow();
                        //Se cargan los datos en la fila
                        filaTemp["logid"] = reader["logid"].ToString();
                        filaTemp["fecha"] = fechaHora;
                        filaTemp["login"] = login;
                        filaTemp["logout"] = logout;
                        filaTemp["dia"] = fechaHora.ToString("dddd", new CultureInfo("es-ES"));

                        temporal.Rows.Add(filaTemp);
                    }

                    for (int x = 0; x < temporal.Rows.Count; x++)
                    {
                        var dia = temporal.Rows[x][4].ToString();

                        datosLilo[0] = temporal.Rows[x][4].ToString();
                        if (contador == 0)
                        {
                            datosLilo[1] = temporal.Rows[x][2].ToString();
                            contador++;
                        }
                        datosLilo[2] = temporal.Rows[x][3].ToString();
                        datosLilo[3] = temporal.Rows[x][1].ToString();
                        datosLilo[4] = temporal.Rows[x][0].ToString();

                        if (dia.Equals(diaAnterior))
                        {
                            datosLilo[2] = temporal.Rows[x][3].ToString();
                            if ((x + 1) >= temporal.Rows.Count)
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                    diferencia = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                else
                                {
                                    diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                    diferencia += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                }
                                total += diferencia;

                                //se reinicia el contador
                                contador = 0;
                            }
                            else if (!dia.Equals(temporal.Rows[x + 1][4].ToString()))
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                    diferencia = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                else
                                {
                                    diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                    diferencia += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                }
                                total += diferencia;

                                //se reinicia el contador
                                contador = 0;
                            }
                        }
                        else
                        {
                            datosLilo[2] = temporal.Rows[x][3].ToString();
                            if ((x + 1) >= temporal.Rows.Count)
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                    diferencia = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                else
                                {
                                    diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                    diferencia += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                }
                                total += diferencia;

                                //se reinicia el contador
                                contador = 0;
                            }
                            else if (!dia.Equals(temporal.Rows[x + 1][4].ToString()))
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                if (!(TimeSpan.Parse(datosLilo[2]) < TimeSpan.Parse(datosLilo[1])))
                                    diferencia = TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse(datosLilo[1]);
                                else
                                {
                                    diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(datosLilo[1]);
                                    diferencia += TimeSpan.Parse(datosLilo[2]) - TimeSpan.Parse("00:00:00");
                                }
                                total += diferencia;

                                //se reinicia el contador
                                contador = 0;
                            }
                        }

                        diaAnterior = dia;
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();

                var contienePunto = total.ToString().Contains(".");
                if (contienePunto)
                {
                    //se formatea el total de horas acumuladas
                    var arregloHoras = total.ToString().Split('.');

                    if (arregloHoras.Length > 1)
                    {
                        var horasTotales = Int32.Parse(arregloHoras[0]);
                        horasTotales = horasTotales * 24;
                        var horasRestantes = arregloHoras[1];
                        var splithora = horasRestantes.Split(':');
                        horasTotales += Int32.Parse(splithora[0]);

                        string horasFormateadas = horasTotales + ":" + splithora[1] + ":" + splithora[2];
                        horasCMSE = horasFormateadas;
                    }
                }
                else
                {
                    horasCMSE = total.ToString();
                }


                //se retorna la lista
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerCMSElite(string desde, string hasta, string extensiones)
        {
            //Variables
            OdbcConnection cn;
            OdbcCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("fechahora");
                table.Columns.Add("agentLogin");
                table.Columns.Add("horaEntrada");
                table.Columns.Add("horaSalida");
                table.Columns.Add("dia");

                DataTable temporal = new DataTable();
                temporal.Columns.Add("logid");
                temporal.Columns.Add("fecha");
                temporal.Columns.Add("login");
                temporal.Columns.Add("logout");
                temporal.Columns.Add("dia");

                //Se setean las varaqibles
                cn = openCMSConnectionElite();
                //Se define el procedimiento almacenado a utilizar
                /*****************************************************************************************************/
                var consulta = "SELECT haglog.row_date, haglog.seq_num, haglog.logid, haglog.acd, haglog.split, haglog.login, haglog.logout FROM root.haglog haglog WHERE (haglog.row_date>={d '" + desde + "'} And haglog.row_date<={d '" + hasta + "'}) AND haglog.logid in (";
                var ext = extensiones.Split(',');
                string lista = string.Empty;

                if (ext.Length == 1)
                {
                    consulta = consulta + ext[0] + ") ORDER BY haglog.row_date, haglog.logid, haglog.login";
                }
                else
                {
                    for (int j = 0; j < ext.Length; j++)
                    {
                        if (j == 0)
                        {
                            consulta = consulta + ext[j];
                        }
                        else
                        {
                            consulta = consulta + "," + ext[j];
                        }
                    }
                    consulta = consulta + ") ORDER BY haglog.row_date, haglog.logid, haglog.login";
                }
                /*******************************************************************************************************/

                //cmd = new OdbcCommand("SELECT haglog.row_date, haglog.seq_num, haglog.logid, haglog.acd, haglog.split, haglog.login, haglog.logout FROM root.haglog haglog WHERE (haglog.row_date>={d '" + desde + "'} And haglog.row_date<={d '" + hasta + "'}) ORDER BY haglog.row_date, haglog.logid, haglog.login", cn);
                cmd = new OdbcCommand(consulta, cn);
                cmd.CommandType = CommandType.Text;
                //Se ejecuta la consulta y se obtiene el resultado
                OdbcDataReader reader = cmd.ExecuteReader();

                //TimeSpan diferencia = TimeSpan.Zero;
                //TimeSpan total = TimeSpan.Zero;

                if (reader.HasRows)
                {
                    //variables
                    var diaActual = string.Empty;
                    var diaAnterior = string.Empty;
                    string[] datosLilo = new string[5];//0:dia, 1:li, 2:lo, 3:fechahora, 6:agentLogin
                    var contador = 0;

                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se toma la fecha y se formatea
                        var datoFechaHora = long.Parse(reader["seq_num"].ToString());
                        var fechaHora = UtilitarioDAL.FromUnixTime(datoFechaHora);

                        var datologin = long.Parse(reader["login"].ToString());
                        var fechalogin = UtilitarioDAL.FromUnixTime(datologin);
                        var login = fechalogin.TimeOfDay;

                        var datologout = long.Parse(reader["logout"].ToString());
                        var fechalogout = UtilitarioDAL.FromUnixTime(datologout);
                        var logout = fechalogout.TimeOfDay;

                        DataRow filaTemp = temporal.NewRow();
                        //Se cargan los datos en la fila
                        filaTemp["logid"] = reader["logid"].ToString();
                        filaTemp["fecha"] = fechaHora;
                        filaTemp["login"] = login;
                        filaTemp["logout"] = logout;
                        filaTemp["dia"] = fechaHora.ToString("dddd", new CultureInfo("es-ES"));

                        temporal.Rows.Add(filaTemp);
                    }

                    for (int x = 0; x < temporal.Rows.Count; x++)
                    {
                        var dia = temporal.Rows[x][4].ToString();

                        datosLilo[0] = temporal.Rows[x][4].ToString();
                        if (contador == 0)
                        {
                            datosLilo[1] = temporal.Rows[x][2].ToString();
                            contador++;
                        }
                        datosLilo[2] = temporal.Rows[x][3].ToString();
                        datosLilo[3] = temporal.Rows[x][1].ToString();
                        datosLilo[4] = temporal.Rows[x][0].ToString();

                        if (dia.Equals(diaAnterior))
                        {
                            datosLilo[2] = temporal.Rows[x][3].ToString();
                            if ((x + 1) >= temporal.Rows.Count)
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                //se reinicia el contador
                                contador = 0;
                            }
                            else if (!dia.Equals(temporal.Rows[x + 1][4].ToString()))
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                //se reinicia el contador
                                contador = 0;
                            }
                        }
                        else
                        {
                            datosLilo[2] = temporal.Rows[x][3].ToString();
                            if ((x + 1) >= temporal.Rows.Count)
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                //se reinicia el contador
                                contador = 0;
                            }
                            else if (!dia.Equals(temporal.Rows[x + 1][4].ToString()))
                            {
                                //Se crea una fila nueva para cada tupla recuperada en la consulta
                                DataRow fila = table.NewRow();
                                //Se cargan los datos en la fila
                                fila["agentLogin"] = datosLilo[4];
                                fila["fechahora"] = datosLilo[3];
                                fila["horaEntrada"] = datosLilo[1];
                                fila["horaSalida"] = datosLilo[2];
                                fila["dia"] = datosLilo[0];

                                //Se agrega la fila a la tabla
                                table.Rows.Add(fila);

                                //se reinicia el contador
                                contador = 0;
                            }
                        }

                        diaAnterior = dia;
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

        public DataTable ConsultaMarcasZPT(string desde, string hasta, string nombre, ref string horasMarcZ)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("numeroMarca");
                table.Columns.Add("dia");
                table.Columns.Add("fecha");
                table.Columns.Add("entrada");
                table.Columns.Add("salida");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ConsultaDatosMarcasZPT", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@psFechaDesde", desde);
                cmd.Parameters.AddWithValue("@psFechaHasta", hasta);
                cmd.Parameters.AddWithValue("@psNombre", nombre);

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();

                var diferencia = TimeSpan.Zero;
                var total = TimeSpan.Zero;

                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();
                        //Se cargan los datos en la fila
                        fila["numeroMarca"] = reader["numeroMarca"].ToString();
                        fila["dia"] = RenombrarDia(reader["dia"].ToString());
                        fila["fecha"] = reader["fecha"].ToString();
                        fila["entrada"] = reader["entrada"].ToString();
                        fila["salida"] = reader["salida"].ToString();

                        //Se agrega la fila a la tabla
                        table.Rows.Add(fila);

                        //Variables para manejo de horas
                        var entrada = fila["entrada"].ToString();
                        var salida = fila["salida"].ToString();

                        //Obtención del total de horas según el horario que se le asigna a un agente
                        if (!entrada.Equals(String.Empty) && !salida.Equals(String.Empty))
                        {
                            if (!(TimeSpan.Parse(salida) < TimeSpan.Parse(entrada)))
                                diferencia = TimeSpan.Parse(salida) - TimeSpan.Parse(entrada);
                            else
                            {
                                diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(entrada);
                                diferencia += TimeSpan.Parse(salida) - TimeSpan.Parse("00:00:00");
                            }
                            total += diferencia;
                        }

                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();

                var contienePunto = total.ToString().Contains(".");
                if (contienePunto)
                {
                    //se formatea el total de horas acumuladas
                    var arregloHoras = total.ToString().Split('.');
                    if (arregloHoras.Length > 1)
                    {
                        var horasTotales = Int32.Parse(arregloHoras[0]);
                        horasTotales = horasTotales * 24;
                        var horasRestantes = arregloHoras[1];
                        var splithora = horasRestantes.Split(':');
                        horasTotales += Int32.Parse(splithora[0]);

                        string horasFormateadas = horasTotales + ":" + splithora[1] + ":" + splithora[2];
                        horasMarcZ = horasFormateadas;
                    }
                }
                else
                {
                    horasMarcZ = total.ToString();
                }

                //se retorna la lista
                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObtenerMarcasZPT(string desde, string hasta, Int32 idPersona)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("numeroMarca");
                table.Columns.Add("dia");
                table.Columns.Add("fecha");
                table.Columns.Add("entrada");
                table.Columns.Add("salida");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ObtenerMarcasZPT", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@psFechaDesde", desde);
                cmd.Parameters.AddWithValue("@psFechaHasta", hasta);
                cmd.Parameters.AddWithValue("@piIdPersona", idPersona);

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();

                var diferencia = TimeSpan.Zero;
                var total = TimeSpan.Zero;

                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();
                        //Se cargan los datos en la fila
                        fila["numeroMarca"] = reader["numeroMarca"].ToString();
                        fila["dia"] = reader["dia"].ToString();
                        fila["fecha"] = reader["fecha"].ToString();
                        fila["entrada"] = reader["entrada"].ToString();
                        fila["salida"] = reader["salida"].ToString();

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

        public DataTable ConsultaMarcasSP(string desde, string hasta, string nombre, ref string horasMarcS)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("numeroMarca");
                table.Columns.Add("dia");
                table.Columns.Add("fecha");
                table.Columns.Add("entrada");
                table.Columns.Add("salida");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ConsultaDatosMarcasSP", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@psFechaDesde", desde);
                cmd.Parameters.AddWithValue("@psFechaHasta", hasta);
                cmd.Parameters.AddWithValue("@psNombre", nombre);

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();

                var diferencia = TimeSpan.Zero;
                var total = TimeSpan.Zero;

                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();
                        //Se cargan los datos en la fila
                        fila["numeroMarca"] = reader["numeroMarca"].ToString();
                        fila["dia"] = RenombrarDia(reader["dia"].ToString());
                        fila["fecha"] = reader["fecha"].ToString();
                        fila["entrada"] = reader["entrada"].ToString();
                        fila["salida"] = reader["salida"].ToString();

                        //Se agrega la fila a la tabla
                        table.Rows.Add(fila);

                        //Variables para manejo de horas
                        var entrada = fila["entrada"].ToString();
                        var salida = fila["salida"].ToString();

                        //Obtención del total de horas según el horario que se le asigna a un agente
                        if (!entrada.Equals(String.Empty) && !salida.Equals(String.Empty))
                        {
                            if (!(TimeSpan.Parse(salida) < TimeSpan.Parse(entrada)))
                                diferencia = TimeSpan.Parse(salida) - TimeSpan.Parse(entrada);
                            else
                            {
                                diferencia = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(entrada);
                                diferencia += TimeSpan.Parse(salida) - TimeSpan.Parse("00:00:00");
                            }
                            total += diferencia;
                        }
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();

                //se formatea el total de horas acumuladas
                var arregloHoras = total.ToString().Split('.');
                if (arregloHoras.Length > 1)
                {
                    var horasTotales = Int32.Parse(arregloHoras[0]);
                    horasTotales = horasTotales * 24;
                    var horasRestantes = arregloHoras[1];
                    var splithora = horasRestantes.Split(':');
                    horasTotales += Int32.Parse(splithora[0]);

                    string horasFormateadas = horasTotales + ":" + splithora[1] + ":" + splithora[2];
                    horasMarcS = horasFormateadas;
                }

                //se retorna la lista
                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ObtenerMarcasSP(string desde, string hasta, Int32 idPersona)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("numeroMarca");
                table.Columns.Add("dia");
                table.Columns.Add("fecha");
                table.Columns.Add("entrada");
                table.Columns.Add("salida");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ObtenerMarcasSP", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@psFechaDesde", desde);
                cmd.Parameters.AddWithValue("@psFechaHasta", hasta);
                cmd.Parameters.AddWithValue("@piIdPersona", idPersona);

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();

                var diferencia = TimeSpan.Zero;
                var total = TimeSpan.Zero;

                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();
                        //Se cargan los datos en la fila
                        fila["numeroMarca"] = reader["numeroMarca"].ToString();
                        fila["dia"] = reader["dia"].ToString();
                        fila["fecha"] = reader["fecha"].ToString();
                        fila["entrada"] = reader["entrada"].ToString();
                        fila["salida"] = reader["salida"].ToString();

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

        #endregion

        #region Conexion CMS

        /// <summary>
        /// Método para crear una conexión al CMS Avaya
        /// </summary>
        /// <returns>OdbcConnection con la conexión creada</returns>
        public static OdbcConnection openCMSConnection()
        {
            try
            {
                OdbcConnectionStringBuilder csb = new OdbcConnectionStringBuilder();
                csb.Dsn = "Netcom-AACC";//"cms";

                OdbcConnection cn = new OdbcConnection(csb.ConnectionString);
                cn.Open();
                return cn;

            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Método que obtiene los datos del CMS Avaya Aura
        /// </summary>
        /// <returns>DataTable con la información consultada</returns>
        public DataTable ObtenerDatosCms(string desde, string hasta)
        {
            //Variables
            OdbcConnection cn;
            OdbcCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("AgentLogin");
                table.Columns.Add("Timestamp");
                table.Columns.Add("AgentSurName");
                table.Columns.Add("AgentGivenName");
                table.Columns.Add("EventType");
                table.Columns.Add("Time");

                //Se setean las varaqibles
                cn = openCMSConnection();
                //Se define el procedimiento almacenado a utilizar
                //SELECT haglog.row_date, haglog.logid, haglog.acd, haglog.split, haglog.login, haglog.logout FROM root.haglog haglog WHERE(haglog.row_date >={ d '2017-10-01'} And haglog.row_date <={ d '2017-10-31'}) ORDER BY haglog.row_date, haglog.logid, haglog.login
                //SELECT eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE(eAgentLoginStat.EventType Like '%LI%') AND(eAgentLoginStat.Timestamp >='2017-10-20' And eAgentLoginStat.Timestamp <='2017-10-21') OR(eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='2017-10-20' And eAgentLoginStat.Timestamp <='2017-10-21') ORDER BY eAgentLoginStat.Timestamp
                cmd = new OdbcCommand("SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat WHERE(eAgentLoginStat.EventType Like '%LI%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') OR(eAgentLoginStat.EventType Like '%LO%') AND(eAgentLoginStat.Timestamp >='" + desde + "' And eAgentLoginStat.Timestamp <='" + hasta + "') ORDER BY eAgentLoginStat.Timestamp", cn);
                //cmd = new OdbcCommand("SELECT eAgentLoginStat.AgentLogin, eAgentLoginStat.Timestamp, eAgentLoginStat.AgentSurName, eAgentLoginStat.AgentGivenName, eAgentLoginStat.EventType, eAgentLoginStat.Time FROM dbo.eAgentLoginStat eAgentLoginStat ORDER BY eAgentLoginStat.AgentLogin", cn);
                cmd.CommandType = CommandType.Text;
                //se pasan los parametros de entrada
                //cmd.Parameters.AddWithValue("@codigoCatalogo", idCatalogo);
                //se abre la conexión
                //cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    CMS_AACC oCMS;
                    //mientras existan datos
                    while (reader.Read())
                    {
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();

                        //Se cargan los datos en la fila
                        fila["AgentLogin"] = reader["AgentLogin"].ToString();
                        fila["Timestamp"] = reader["Timestamp"].ToString();
                        fila["AgentSurName"] = reader["AgentSurName"].ToString();
                        fila["AgentGivenName"] = reader["AgentGivenName"].ToString();
                        fila["EventType"] = reader["EventType"].ToString();
                        fila["Time"] = reader["Time"].ToString();

                        //Se agrega la fila a la tabla
                        table.Rows.Add(fila);

                        oCMS = new CMS_AACC
                        {
                            agentLogin = reader["AgentLogin"].ToString(),
                            fechaHora = reader["Timestamp"].ToString(),
                            apellidos = reader["AgentSurName"].ToString(),
                            nombre = reader["AgentGivenName"].ToString(),
                            tipoEvento = reader["EventType"].ToString(),
                            hora = reader["Time"].ToString()
                        };
                        //RegistrarCMS_AACC(oCMS);
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

        /// <summary>
        /// Método que obtiene los datos del CMS Avaya Elite
        /// </summary>
        /// <returns>DataTable con la información consultada</returns>
        public DataTable ObtenerDatosCmsElite(string desde, string hasta)
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
                cmd = new SqlCommand("Obtener_DatosLiLo_Elite", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    CMS_Elite oCMS;
                    //mientras existan datos
                    while (reader.Read())
                    {
                        oCMS = new CMS_Elite();
                        //Se crea una fila nueva para cada tupla recuperada en la consulta
                        DataRow fila = table.NewRow();

                        if (!reader["seq_num"].ToString().Equals(""))
                        {
                            var datoFechaHora = long.Parse(reader["seq_num"].ToString());
                            var fechaHora = UtilitarioDAL.FromUnixTime(datoFechaHora);
                            fila["row_date"] = fechaHora;
                            oCMS.fecha = fechaHora.ToString();
                        }

                        if (!reader["login"].ToString().Equals(""))
                        {
                            var datologin = long.Parse(reader["login"].ToString());
                            var fechalogin = UtilitarioDAL.FromUnixTime(datologin);
                            var login = fechalogin.TimeOfDay;
                            fila["login"] = login;
                            oCMS.login = login.ToString();
                        }

                        if (!reader["logout"].ToString().Equals(""))
                        {
                            var datologout = long.Parse(reader["logout"].ToString());
                            var fechalogout = UtilitarioDAL.FromUnixTime(datologout);
                            var logout = fechalogout.TimeOfDay;
                            fila["logout"] = logout;
                            oCMS.logout = logout.ToString();
                        }

                        //Se cargan los datos en la fila
                        //fila["row_date"] = fechaHora;
                        fila["seq_num"] = reader["seq_num"].ToString();
                        fila["logid"] = reader["logid"].ToString();
                        fila["acd"] = reader["acd"].ToString();
                        fila["split"] = reader["split"].ToString();
                        //fila["login"] = login;
                        //fila["logout"] = logout;

                        //Se agrega la fila a la tabla
                        table.Rows.Add(fila);

                        //var fecha = DateTime.Parse(desde,"G");

                        //oCMS = new CMS_Elite
                        //{
                        ////fecha = fechaHora.ToString(),//reader["row_date"].ToString(),
                        //acd = reader["acd"].ToString(),
                        oCMS.logid = reader["logid"].ToString();
                            //acd = reader["acd"].ToString(),
                            //split = reader["split"].ToString(),
                            //login = login.ToString(),//reader["login"].ToString(),
                            //logout = logout.ToString()//reader["logout"].ToString()
                        //};
                        RegistrarCMS_Elite(oCMS);
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

        /// <summary>
        /// Método que se encarga del registro de los datos de log in y log out desde el CMS AACC de AVAYA
        /// </summary>
        /// <param name="fechahora">fecha y hora del log in o log out</param>
        /// <param name="apellidos">apellidos del agente</param>
        /// <param name="nombre">nombre del agente</param>
        /// <param name="tipoEvento">Identificador para saber si el evento es un log in o un log out</param>
        /// <param name="hora">hora en que se registro el evento</param>
        public void RegistrarCMS_AACC(CMS_AACC oCMS)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("CargaLiloAvaya", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@psLogin", oCMS.agentLogin);
                //cmd.Parameters.AddWithValue("@psTimeStamp", oCMS.fechaHora.Substring(0, 10));

                var dtFecha = DateTime.Parse(oCMS.fechaHora);
                var dia = dtFecha.Day;
                var mes = dtFecha.Month;
                var annio = dtFecha.Year;

                var fechaDb = annio.ToString() + "/" + mes.ToString() + "/" + dia.ToString() + " " + dtFecha.TimeOfDay;

                cmd.Parameters.AddWithValue("@psTimeStamp", fechaDb);

                cmd.Parameters.AddWithValue("@psApellidos", oCMS.apellidos);
                cmd.Parameters.AddWithValue("@psNombre", oCMS.nombre);
                cmd.Parameters.AddWithValue("@psTipoEvento", oCMS.tipoEvento);
                cmd.Parameters.AddWithValue("@psHora", oCMS.hora);
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
                throw ex;
            }
        }

        /// <summary>
        /// Método para crear una conexión al CMS Avaya
        /// </summary>
        /// <returns>OdbcConnection con la conexión creada</returns>
        public static OdbcConnection openCMSConnectionElite()
        {
            try
            {
                OdbcConnectionStringBuilder csb = new OdbcConnectionStringBuilder();
                csb.Dsn = "cms_net";

                OdbcConnection cn = new OdbcConnection(csb.ConnectionString);
                cn.Open();
                return cn;

            }
            catch (Exception exc)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que se encarga del registro de los datos de log in y log out desde el CMS AACC de AVAYA
        /// </summary>
        /// <param name="fechahora">fecha y hora del log in o log out</param>
        /// <param name="apellidos">apellidos del agente</param>
        /// <param name="nombre">nombre del agente</param>
        /// <param name="tipoEvento">Identificador para saber si el evento es un log in o un log out</param>
        /// <param name="hora">hora en que se registro el evento</param>
        public void RegistrarCMS_Elite(CMS_Elite oCMS)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("CargaLiloElite", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                //cmd.Parameters.AddWithValue("@idequipo", oEquipo.Id);
                // cmd.Parameters.AddWithValue("@pvFecha", oCMS.fecha.Substring(0, 18));

                var dtFecha = DateTime.Parse(oCMS.fecha);
                var dia = dtFecha.Day;
                var mes = dtFecha.Month;
                var annio = dtFecha.Year;

                var fechaDb = annio.ToString() + "/" + mes.ToString() + "/" + dia.ToString() + " " + dtFecha.TimeOfDay;

                cmd.Parameters.AddWithValue("@pvFecha", fechaDb);

                cmd.Parameters.AddWithValue("@piLogId", oCMS.logid.Trim());
                cmd.Parameters.AddWithValue("@psLogin", oCMS.login.Trim());
                if(oCMS.logout is null)
                {
                    oCMS.logout = "";
                }
                cmd.Parameters.AddWithValue("@psLogout", oCMS.logout);
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
        /// Consulta las extensiones Avaya asociadas a una personas por medio de su id
        /// </summary>
        /// <param name="oPersona">Objeto con el id de persona con el cual se realiza la consulta</param>
        /// <returns>Data Table con todas las extensiones encontradas</returns>
        public DataTable obtenerExtensiones(Persona oPersona)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Extension");
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            //Se setean las varaqibles
            cn = new SqlConnection(Conexion.ConnectionString);
            //Se define el procedimiento almacenado a utilizar
            cmd = new SqlCommand("ObtenerExtensiones", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //se pasan los parametros de entrada

            cmd.Parameters.AddWithValue("@piIdPErsona", oPersona.idPersona);

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
                    fila["Extension"] = reader["idAvaya"].ToString();
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

        #endregion

        #region Control Asistencia (Justificaciones)

        /// <summary>
        /// Método que se encarga del registro de personal en el sistema
        /// </summary>
        /// <param name="persona">Objeto con los datos a registrar</param>
        public void RegistrarJustificacion(Justificacion oJustificacion)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("RegistrarJustificicacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                //cmd.Parameters.AddWithValue("@idequipo", oEquipo.Id);
                cmd.Parameters.AddWithValue("@idPersona", oJustificacion.idPersona);
                cmd.Parameters.AddWithValue("@Motivo", oJustificacion.Motivo);
                var fecha = DateTime.Parse(oJustificacion.fechaJustificacion);
                var strFecha = fecha.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@fechaJustificacion", strFecha);
                cmd.Parameters.AddWithValue("@horaInicio", oJustificacion.horaInicio);
                cmd.Parameters.AddWithValue("@horaFin", oJustificacion.horaFin);
                cmd.Parameters.AddWithValue("@Observaciones", oJustificacion.observaciones);
                cmd.Parameters.AddWithValue("@idPersonaRegistro", oJustificacion.idPersonaregistro);
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
        /// Consulta los datos de acuerdo con los filtros de fechadesde, fechaHasta y idColaborador
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarAsistencia(string fechaDesde, string fechaHasta, int idColaborador, int codSuper)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                //table.Columns.Add("idPersona");
                table.Columns.Add("Fecha Justificación");
                table.Columns.Add("Motivo");
                table.Columns.Add("Hora Inicio");
                table.Columns.Add("Hora Fin");
                table.Columns.Add("Observaciones");
                table.Columns.Add("Fecha Registro");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("Consultar_Control_Asistencia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@idColaborador", idColaborador);
                cmd.Parameters.AddWithValue("@idSuper", codSuper);
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
                        fila["Id"] = Convert.ToInt32(reader["idJustificacion"]);
                        //fila["idPersona"] = reader["idPersona"];
                        fila["Fecha Justificación"] = reader["fechaJustificada"];
                        fila["Motivo"] = reader["DetalleMotivo"];
                        fila["Hora Inicio"] = reader["horaInicio"];
                        fila["Hora Fin"] = reader["horaFin"];
                        fila["Observaciones"] = reader["observaciones"];
                        fila["Fecha Registro"] = reader["fechaRegistro"];

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
        /// Método que se encarga de obtener los datos de una justificación en especifico
        /// </summary>
        /// <param name="idRegistro">Identificador único de la justificación a consultar</param>
        /// <returns></returns>
        public Justificacion ConsultarDatosAsistencia(Int32 idRegistro)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                var objJustificacion = new Justificacion();
                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ObtenerJustificacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@idRegistro", idRegistro);

                //se abre la conexión
                cn.Open();
                //Se ejecuta la consulta y se obtiene el resultado
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    //mientras existan datos
                    while (reader.Read())
                    {
                        objJustificacion.idJustificacion = idRegistro;
                        objJustificacion.fechaJustificacion = reader["fechaJustificada"].ToString();
                        objJustificacion.horaFin = reader["horaFin"].ToString();
                        objJustificacion.horaInicio = reader["horaInicio"].ToString();
                        objJustificacion.idPersona = Int32.Parse(reader["idPersona"].ToString());
                        objJustificacion.idPersonaregistro = Int32.Parse(reader["idPersonaRegistro"].ToString());
                        objJustificacion.Motivo = Int32.Parse(reader["motivo"].ToString());
                        objJustificacion.observaciones = reader["observaciones"].ToString();
                    }
                }
                //se cierra el reader
                reader.Dispose();
                //Se cierra la conexión
                cn.Close();
                //se retorna el objeto
                return objJustificacion;


            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que se encarga de actualizar los datos de una justificación en especifico
        /// </summary>
        /// <param name="oJustificacion">Objeto que contiene todos los datos a actualizar</param>
        public void ActualizarJustificacion(Justificacion oJustificacion)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;

            try
            {
                //Se setean las variables  rnunez@netcom.com.pa
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("ActualizarJustificacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@idJustificacion", oJustificacion.idJustificacion);
                //cmd.Parameters.AddWithValue("@idPersona", oJustificacion.idPersona);
                cmd.Parameters.AddWithValue("@motivo", oJustificacion.Motivo);
                var fecha = DateTime.Parse(oJustificacion.fechaJustificacion);
                var strFecha = fecha.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@fecha", strFecha);
                cmd.Parameters.AddWithValue("@horaInicio", oJustificacion.horaInicio);
                cmd.Parameters.AddWithValue("@horaFin", oJustificacion.horaFin);
                cmd.Parameters.AddWithValue("@Observaciones", oJustificacion.observaciones);
                cmd.Parameters.AddWithValue("@idPersonaModif", oJustificacion.idPersonaregistro);
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

        #endregion

        #region Reportes

        public DataTable ConsultarPlanillaXProyecto(int proyecto, string fechaDesde, string fechaHasta)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            //try
            //{
            //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
            DataTable table = new DataTable();
            table.Columns.Add("Colaborador(a)");
            table.Columns.Add("Fecha");
            table.Columns.Add("Entrada_Programada");
            table.Columns.Add("Salida_Programada");
            table.Columns.Add("Marca_Entrada");
            table.Columns.Add("Marca_Salida");
            table.Columns.Add("LogIn_Elite");
            table.Columns.Add("LogOut_Elite");
            table.Columns.Add("Motivo");
            table.Columns.Add("Observaciones");

            //Se setean las varaqibles
            cn = new SqlConnection(Conexion.ConnectionString);
            //Se define el procedimiento almacenado a utilizar
            cmd = new SqlCommand("Consulta_Planilla_X_Proyecto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //se pasan los parametros de entrada
            cmd.Parameters.AddWithValue("@codProyecto", proyecto);
            cmd.Parameters.AddWithValue("@fdesde", fechaDesde);
            cmd.Parameters.AddWithValue("@fHasta", fechaHasta);
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
                    fila["Colaborador(a)"] = reader["Colaborador(a)"];
                    fila["Fecha"] = reader["Fecha"];
                    fila["Entrada_Programada"] = reader["Entrada_Programada"];
                    fila["Salida_Programada"] = reader["Salida_Programada"];
                    fila["Marca_Entrada"] = reader["Marca_Entrada"];
                    fila["Marca_Salida"] = reader["Marca_Salida"];
                    fila["LogIn_Elite"] = reader["LogIn_Elite"];
                    fila["LogOut_Elite"] = reader["LogOut_Elite"];
                    fila["Motivo"] = reader["Motivo"];
                    fila["Observaciones"] = reader["Observaciones"];

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
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        public DataTable ConsultarHorariosAgentes(int proyecto, string fechaDesde, string fechaHasta, int encargado)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("Colaborador(a)");
                table.Columns.Add("Fecha");
                table.Columns.Add("Entrada_Programada");
                table.Columns.Add("Salida_Programada");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("Consultar_Horarios_Agentes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@codProyecto", proyecto);
                cmd.Parameters.AddWithValue("@fdesde", fechaDesde);
                cmd.Parameters.AddWithValue("@fHasta", fechaHasta);
                if (encargado != 0)
                {
                    cmd.Parameters.AddWithValue("@encargado", encargado);
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
                        fila["Colaborador(a)"] = reader["Colaborador(a)"];
                        fila["Fecha"] = reader["Fecha"];
                        fila["Entrada_Programada"] = reader["Entrada_Programada"];
                        fila["Salida_Programada"] = reader["Salida_Programada"];

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

        #endregion
    }
}
