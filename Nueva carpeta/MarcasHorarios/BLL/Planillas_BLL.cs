using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCC_Horarios_Y_Marcas
{
    public class Planillas_BLL
    {
        //Variable
        Planillas datos;

        //Contructor
        public Planillas_BLL()
        {
            datos = new Planillas();
        }

        #region Carga de Datos (Marcas y Horarios)

        /// <summary>
        /// Método que se encarga de registrar los datos de las marcas en la Base de Datos
        /// </summary>
        /// <param name="oMarcas">Objeto que contiene toda la información correspondiente a las marcas</param>
        public void cargarDatos(Marca oMarcas, Persona oPersona)
        {
            datos.cargarDatos(oMarcas, oPersona);
        }

        /// <summary>
        /// Método que se encarga de registrar los datos de horarios asignados al personal en la Base de Datos
        /// </summary>
        /// <param name="oProgramacion">Objeto que contiene toda la información correspondiente a los horarios</param>
        public void cargarDatos(Programacion oProgramacion, Persona oPersona)
        {
            datos.cargarDatos(oProgramacion, oPersona);
        }

        #endregion

        #region Consultas Marcas Avaya Programaciones de Personas x Fecha

        public DataTable ConsultaDatosProgramacion(string desde, string hasta, string nombre, ref string horasProg)
        {
            return datos.ConsultaDatosProgramacion(desde,hasta,nombre,ref horasProg);
        }

        public DataTable ObtenerProgramacion(string desde, string hasta, Int32 idPersona)
        {
            return datos.ObtenerProgramacion(desde, hasta, idPersona);
        }

        public void JustificarProgramacion(int idProgramacion, string justificacion, string comentario)
        {
            datos.JustificarProgramacion(idProgramacion, justificacion, comentario);
        }

        public DataTable ConsultaCMSAACC(string desde, string hasta, string extensiones, ref string horasCMSA)
        {
            return datos.ConsultaCMSAACC(desde, hasta, extensiones, ref horasCMSA);
        }

        public DataTable ObtenerCMSAACC(string desde, string hasta, string extensiones)
        {
            return datos.ObtenerCMSAACC(desde, hasta, extensiones);
        }

        public DataTable ConsultaCMSElite(string desde, string hasta, string extensiones, ref string horasCMSE)
        {
            return datos.ConsultaCMSElite(desde, hasta, extensiones, ref horasCMSE);
        }

        public DataTable ConsultaLogueosEliteXId(string desde, string hasta, int idPersona, ref string horasCMSE)
        {
            return datos.ConsultaLogueosEliteXId(desde, hasta, idPersona, ref horasCMSE);
        }

        public DataTable ObtenerCMSElite(string desde, string hasta, string extensiones)
        {
            return datos.ObtenerCMSElite(desde, hasta, extensiones);
        }

        public DataTable ConsultaMarcasZPT(string desde, string hasta, string nombre, ref string horasMarcZ)
        {
            return datos.ConsultaMarcasZPT(desde, hasta, nombre, ref horasMarcZ);
        }

        public DataTable ObtenerMarcasZPT(string desde, string hasta, Int32 idPersona)
        {
            return datos.ObtenerMarcasZPT(desde, hasta, idPersona);
        }

        public DataTable ConsultaMarcasSP(string desde, string hasta, string nombre, ref string horasMarcS)
        {
            return datos.ConsultaMarcasSP(desde, hasta, nombre, ref horasMarcS);
        }

        public DataTable ObtenerMarcasSP(string desde, string hasta, Int32 idPersona)
        {
            return datos.ObtenerMarcasSP(desde, hasta, idPersona);
        }

        #endregion

        #region Conexion CMS

        /// <summary>
        /// Método que obtiene los datos del CMS Avaya Aura
        /// </summary>
        /// <returns>DataTable con la información consultada</returns>
        public DataTable ObtenerDatosCms(string desde, string hasta)
        {
            return datos.ObtenerDatosCms(desde, hasta);
        }

        /// <summary>
        /// Método que obtiene los datos del CMS Avaya Elite
        /// </summary>
        /// <returns>DataTable con la información consultada</returns>
        public DataTable ObtenerDatosCmsElite(string desde, string hasta)
        {
            return datos.ObtenerDatosCmsElite(desde, hasta);
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
            datos.RegistrarCMS_AACC(oCMS);
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
            datos.RegistrarCMS_Elite(oCMS);
        }

        /// <summary>
        /// Consulta las extensiones Avaya asociadas a una personas por medio de su id
        /// </summary>
        /// <param name="oPersona">Objeto con el id de persona con el cual se realiza la consulta</param>
        /// <returns>Data Table con todas las extensiones encontradas</returns>
        public DataTable obtenerExtensiones(Persona oPersona)
        {
            return datos.obtenerExtensiones(oPersona);
        }

        #endregion

        #region Control Asistencia (Justificaciones)

        /// <summary>
        /// Método que se encarga del registro de personal en el sistema
        /// </summary>
        /// <param name="persona">Objeto con los datos a registrar</param>
        public void RegistrarJustificacion(Justificacion oJustificacion)
        {
            datos.RegistrarJustificacion(oJustificacion);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de fechadesde, fechaHasta y idColaborador
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarAsistencia(string fechaDesde, string fechaHasta, int idColaborador, int codSuper)
        {
            return datos.ConsultarAsistencia(fechaDesde, fechaHasta, idColaborador, codSuper);
        }

        /// <summary>
        /// Método que se encarga de obtener los datos de una justificación en especifico
        /// </summary>
        /// <param name="idRegistro">Identificador único de la justificación a consultar</param>
        /// <returns></returns>
        public Justificacion ConsultarDatosAsistencia(Int32 idRegistro)
        {
            return datos.ConsultarDatosAsistencia(idRegistro);
        }

        /// <summary>
        /// Método que se encarga de actualizar los datos de una justificación en especifico
        /// </summary>
        /// <param name="oJustificacion">Objeto que contiene todos los datos a actualizar</param>
        public void ActualizarJustificacion(Justificacion oJustificacion)
        {
            datos.ActualizarJustificacion(oJustificacion);
        }

        #endregion

        #region Reportes

        public DataTable ConsultarPlanillaXProyecto(int proyecto, string fechaDesde, string fechaHasta)
        {
            return datos.ConsultarPlanillaXProyecto(proyecto, fechaDesde, fechaHasta);
        }

        public DataTable ConsultarHorariosAgentes(int proyecto, string fechaDesde, string fechaHasta, int encargado)
        {
            return datos.ConsultarHorariosAgentes(proyecto, fechaDesde, fechaHasta, encargado);
        }

        #endregion
    }
}
