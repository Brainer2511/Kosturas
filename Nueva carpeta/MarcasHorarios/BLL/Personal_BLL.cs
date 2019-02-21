using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class Personal_BLL
    {
        Personal datos;

        public Personal_BLL()
        {
            datos = new Personal();
        }

        /// <summary>
        /// Método que se encarga del registro de personal en el sistema
        /// </summary>
        /// <param name="persona">Objeto con los datos a registrar</param>
        public void RegistrarPersonal(Persona persona)
        {
            datos.RegistrarPersonal(persona);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarPersonalPlantilla(int dpto = 0, int seccion = 0, int proyecto = 0)
        {
            return datos.ConsultarPersonalPlantilla(dpto, seccion, proyecto);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarPersonal(int dpto = 0, int seccion = 0)
        {
            return datos.ConsultarPersonal(dpto, seccion);
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
            return datos.BuscarPersona(dpto, seccion, proyecto, nombre);
        }

        /// <summary>
        /// Método que se encarga de actualizar los datos de una persona en especifico
        /// </summary>
        /// <param name="persona">Objeto con todos los datos de la persona</param>
        public void ModificarPersonal(Persona persona)
        {
            datos.ModificarPersonal(persona);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public Persona ConsultarPersona(int idPersona)
        {
            return datos.ConsultarPersona(idPersona);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarMarcas(string fechaDesde, string fechaHasta, int dpto = 0, int seccion = 0)
        {
            return datos.ConsultarMarcas(fechaDesde, fechaHasta, dpto, seccion);
        }

        public DataTable ObtenerPersonalACargo(Int32 idPersona)
        {
            return datos.ObtenerPersonalACargo(idPersona);
        }
    }
}
