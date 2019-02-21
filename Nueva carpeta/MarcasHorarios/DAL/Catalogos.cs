using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BCC_Horarios_Y_Marcas
{
    public class Catalogos
    {
        //Variables de la clase
        SqlConnection Conexion;
        
        //Constructor de la clase
        public Catalogos()
        {
            //Se inicializa la Conexion
            Conexion = new SqlConnection();
            Conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        }

        /// <summary>
        /// Consulta los datos de un catálogo en especifico a partir de su id
        /// </summary>
        /// <param name="idCatalogo">Identificador único de un catálogo</param>
        /// <returns>DataTable con los items asociados al catálogo</returns>
        public DataTable ConsultarItemsCatalogo(int idCatalogo)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("idItem");
                table.Columns.Add("nombre");
                table.Columns.Add("idCatalogo");
                table.Columns.Add("itemPadre");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("Consultar_Items_Catalogos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@codigoCatalogo", idCatalogo);
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
                        fila["idItem"] = Convert.ToInt32(reader["idItem"]);
                        fila["nombre"] = reader["nombre"].ToString();
                        fila["idCatalogo"] = Convert.ToInt32(reader["idCatalogo"]);
                        int salida = 0;
                        fila["itemPadre"] = Int32.TryParse(reader["itemPadre"].ToString(), out salida);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consulta los datos de un catálogo en especifico a partir de su id y el item padre
        /// </summary>
        /// <param name="idCatalogo">Identificador único de un catálogo</param>
        /// <param name="itemPadre">Identificador único del item que es padre de otros item en un mismo catálogo</param>
        /// <returns>DataTable con los items asociados al catálogo</returns>
        public DataTable ConsultarItemsCatalogo(int idCatalogo, int itemPadre)
        {
            //Variables
            SqlConnection cn;
            SqlCommand cmd;
            try
            {
                //Se crea la estructura DataTable en donde se cargaran los datos obtenidos de la consulta
                DataTable table = new DataTable();
                table.Columns.Add("idItem");
                table.Columns.Add("nombre");
                table.Columns.Add("idCatalogo");
                table.Columns.Add("itemPadre");

                //Se setean las varaqibles
                cn = new SqlConnection(Conexion.ConnectionString);
                //Se define el procedimiento almacenado a utilizar
                cmd = new SqlCommand("Consultar_Items_Catalogos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //se pasan los parametros de entrada
                cmd.Parameters.AddWithValue("@codigoCatalogo", idCatalogo);
                cmd.Parameters.AddWithValue("@itemPadre", itemPadre);

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
                        fila["idItem"] = Convert.ToInt32(reader["idItem"]);
                        fila["idCatalogo"] = Convert.ToInt32(reader["idCatalogo"]);
                        fila["nombre"] = reader["nombre"].ToString();
                        fila["itemPadre"] = Convert.ToInt32(reader["itemPadre"]);
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
                //cn.Close();
                throw;
            }
        }
    }
}
