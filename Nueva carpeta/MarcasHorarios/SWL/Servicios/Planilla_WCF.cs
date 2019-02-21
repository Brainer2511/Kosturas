using System;
using System.Data;

namespace BCC_Horarios_Y_Marcas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Planilla_WCF" in both code and config file together.
    public class Planilla_WCF : IPlanilla_WCF
    {
        Catalogos_BLL       logica_catalogos;
        ControlPlazas_BLL   logica_controlPlazas;
        Personal_BLL        logica_personal;
        Planillas_BLL       logica_planillas;
        Usuarios_BLL        logica_usuarios;

        public Planilla_WCF()
        {
            logica_catalogos = new Catalogos_BLL();   
            logica_controlPlazas = new ControlPlazas_BLL();
            logica_personal = new Personal_BLL();
            logica_planillas = new Planillas_BLL();
            logica_usuarios = new Usuarios_BLL();
        }

        #region Catalogos
        /// <summary>
        /// Consulta los datos de un catálogo en especifico a partir de su id
        /// </summary>
        /// <param name="idCatalogo">Identificador único de un catálogo</param>
        /// <returns>DataTable con los items asociados al catálogo</returns>
        public DataTable ConsultarItemsCatalogo(int idCatalogo)
        {
            return logica_catalogos.ConsultarItemsCatalogo(idCatalogo);
        }

        /// <summary>
        /// Consulta los datos de un catálogo en especifico a partir de su id y el item padre
        /// </summary>
        /// <param name="idCatalogo">Identificador único de un catálogo</param>
        /// <param name="itemPadre">Identificador único del item que es padre de otros item en un mismo catálogo</param>
        /// <returns>DataTable con los items asociados al catálogo</returns>
        public DataTable ConsultarItemsCatalogo(int idCatalogo, int itemPadre)
        {
            return logica_catalogos.ConsultarItemsCatalogo(idCatalogo, itemPadre);
        }
        #endregion

        #region ControlPlazas
        public DataTable ObtenerDatosElite(string desde, string hasta)
        {
            return logica_controlPlazas.ObtenerDatosElite(desde, hasta);
        }

        public DataTable ObtenerSplits()
        {
            return logica_controlPlazas.ObtenerSplits();
        }

        public void RegistrarSplit(int codigo, string nombre, int? id)
        {
            logica_controlPlazas.RegistrarSplit(codigo, nombre, id);
        }

        public DataTable ConsultarLoginIdPersonal()
        {
            return logica_controlPlazas.ConsultarLoginIdPersonal();
        }
        #endregion

        #region Personal
        /// <summary>
        /// Método que se encarga del registro de personal en el sistema
        /// </summary>
        /// <param name="persona">Objeto con los datos a registrar</param>
        public void RegistrarPersonal(Persona persona)
        {
            logica_personal.RegistrarPersonal(persona);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarPersonalPlantilla(int dpto = 0, int seccion = 0, int proyecto = 0)
        {
            return logica_personal.ConsultarPersonalPlantilla(dpto, seccion, proyecto);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarPersonal(int dpto = 0, int seccion = 0)
        {
            return logica_personal.ConsultarPersonal(dpto, seccion);
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
            return logica_personal.BuscarPersona(dpto, seccion, proyecto, nombre);
        }

        /// <summary>
        /// Método que se encarga de actualizar los datos de una persona en especifico
        /// </summary>
        /// <param name="persona">Objeto con todos los datos de la persona</param>
        public void ModificarPersonal(Persona persona)
        {
            logica_personal.ModificarPersonal(persona);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public Persona ConsultarPersona(int idPersona)
        {
            return logica_personal.ConsultarPersona(idPersona);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de departamento y sección
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarMarcas(string fechaDesde, string fechaHasta, int dpto = 0, int seccion = 0)
        {
            return logica_personal.ConsultarMarcas(fechaDesde, fechaHasta, dpto, seccion);
        }

        public DataTable ObtenerPersonalACargo(Int32 idPersona)
        {
            return logica_personal.ObtenerPersonalACargo(idPersona);
        }
        #endregion Personal

        #region Carga de Datos (Marcas y Horarios)

        /// <summary>
        /// Método que se encarga de registrar los datos de las marcas en la Base de Datos
        /// </summary>
        /// <param name="oMarcas">Objeto que contiene toda la información correspondiente a las marcas</param>
        public void cargarDatos(Marca oMarcas, Persona oPersona)
        {
            logica_planillas.cargarDatos(oMarcas, oPersona);
        }

        /// <summary>
        /// Método que se encarga de registrar los datos de horarios asignados al personal en la Base de Datos
        /// </summary>
        /// <param name="oProgramacion">Objeto que contiene toda la información correspondiente a los horarios</param>
        public void cargarDatos(Programacion oProgramacion, Persona oPersona)
        {
            logica_planillas.cargarDatos(oProgramacion, oPersona);
        }

        #endregion

        #region Consultas Marcas Avaya Programaciones de Personas x Fecha

        public DataTable ConsultaDatosProgramacion(string desde, string hasta, string nombre, ref string horasProg)
        {
            return logica_planillas.ConsultaDatosProgramacion(desde, hasta, nombre, ref horasProg);
        }

        public DataTable ObtenerProgramacion(string desde, string hasta, Int32 idPersona)
        {
            return logica_planillas.ObtenerProgramacion(desde, hasta, idPersona);
        }

        public void JustificarProgramacion(int idProgramacion, string justificacion, string comentario)
        {
            logica_planillas.JustificarProgramacion(idProgramacion, justificacion, comentario);
        }

        public DataTable ConsultaCMSAACC(string desde, string hasta, string extensiones, ref string horasCMSA)
        {
            return logica_planillas.ConsultaCMSAACC(desde, hasta, extensiones, ref horasCMSA);
        }

        public DataTable ObtenerCMSAACC(string desde, string hasta, string extensiones)
        {
            return logica_planillas.ObtenerCMSAACC(desde, hasta, extensiones);
        }

        public DataTable ConsultaCMSElite(string desde, string hasta, string extensiones, ref string horasCMSE)
        {
            return logica_planillas.ConsultaCMSElite(desde, hasta, extensiones, ref horasCMSE);
        }

        public DataTable ConsultaLogueosEliteXId(string desde, string hasta, int idPersona, ref string horasCMSE)
        {
            return logica_planillas.ConsultaLogueosEliteXId(desde, hasta, idPersona, ref horasCMSE);
        }

        public DataTable ObtenerCMSElite(string desde, string hasta, string extensiones)
        {
            return logica_planillas.ObtenerCMSElite(desde, hasta, extensiones);
        }

        public DataTable ConsultaMarcasZPT(string desde, string hasta, string nombre, ref string horasMarcZ)
        {
            return logica_planillas.ConsultaMarcasZPT(desde, hasta, nombre, ref horasMarcZ);
        }

        public DataTable ObtenerMarcasZPT(string desde, string hasta, Int32 idPersona)
        {
            return logica_planillas.ObtenerMarcasZPT(desde, hasta, idPersona);
        }

        public DataTable ConsultaMarcasSP(string desde, string hasta, string nombre, ref string horasMarcS)
        {
            return logica_planillas.ConsultaMarcasSP(desde, hasta, nombre, ref horasMarcS);
        }

        public DataTable ObtenerMarcasSP(string desde, string hasta, Int32 idPersona)
        {
            return logica_planillas.ObtenerMarcasSP(desde, hasta, idPersona);
        }

        #endregion

        #region Conexion CMS

        /// <summary>
        /// Método que obtiene los datos del CMS Avaya Aura
        /// </summary>
        /// <returns>DataTable con la información consultada</returns>
        public DataTable ObtenerDatosCms(string desde, string hasta)
        {
            return logica_planillas.ObtenerDatosCms(desde, hasta);
        }

        /// <summary>
        /// Método que obtiene los datos del CMS Avaya Elite
        /// </summary>
        /// <returns>DataTable con la información consultada</returns>
        public DataTable ObtenerDatosCmsElite(string desde, string hasta)
        {
            return logica_planillas.ObtenerDatosCmsElite(desde, hasta);
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
            logica_planillas.RegistrarCMS_AACC(oCMS);
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
            logica_planillas.RegistrarCMS_Elite(oCMS);
        }

        /// <summary>
        /// Consulta las extensiones Avaya asociadas a una personas por medio de su id
        /// </summary>
        /// <param name="oPersona">Objeto con el id de persona con el cual se realiza la consulta</param>
        /// <returns>Data Table con todas las extensiones encontradas</returns>
        public DataTable obtenerExtensiones(Persona oPersona)
        {
            return logica_planillas.obtenerExtensiones(oPersona);
        }

        #endregion

        #region Control Asistencia (Justificaciones)

        /// <summary>
        /// Método que se encarga del registro de personal en el sistema
        /// </summary>
        /// <param name="persona">Objeto con los datos a registrar</param>
        public void RegistrarJustificacion(Justificacion oJustificacion)
        {
            logica_planillas.RegistrarJustificacion(oJustificacion);
        }

        /// <summary>
        /// Consulta los datos de acuerdo con los filtros de fechadesde, fechaHasta y idColaborador
        /// </summary>
        /// <param name="dpto">entero que indica el código del departamento</param>
        /// <param name="seccion">entero que indica el código de sección dentro del departamento</param>
        /// <returns>Listado de personas que consuerden con los parametros de filtrado</returns>
        public DataTable ConsultarAsistencia(string fechaDesde, string fechaHasta, int idColaborador, int codSuper)
        {
            return logica_planillas.ConsultarAsistencia(fechaDesde, fechaHasta, idColaborador, codSuper);
        }

        /// <summary>
        /// Método que se encarga de obtener los datos de una justificación en especifico
        /// </summary>
        /// <param name="idRegistro">Identificador único de la justificación a consultar</param>
        /// <returns></returns>
        public Justificacion ConsultarDatosAsistencia(Int32 idRegistro)
        {
            return logica_planillas.ConsultarDatosAsistencia(idRegistro);
        }

        /// <summary>
        /// Método que se encarga de actualizar los datos de una justificación en especifico
        /// </summary>
        /// <param name="oJustificacion">Objeto que contiene todos los datos a actualizar</param>
        public void ActualizarJustificacion(Justificacion oJustificacion)
        {
            logica_planillas.ActualizarJustificacion(oJustificacion);
        }

        #endregion

        #region Reportes

        public DataTable ConsultarPlanillaXProyecto(int proyecto, string fechaDesde, string fechaHasta)
        {
            return logica_planillas.ConsultarPlanillaXProyecto(proyecto, fechaDesde, fechaHasta);
        }

        public DataTable ConsultarHorariosAgentes(int proyecto, string fechaDesde, string fechaHasta, int encargado)
        {
            return logica_planillas.ConsultarHorariosAgentes(proyecto, fechaDesde, fechaHasta, encargado);
        }

        #endregion

        #region Usuarios
        /// <summary>
        /// Método que se encarga de validar el ingreso de usuarios
        /// </summary>
        /// <param name="oUsuario">objeto con los datos del usuario</param>
        /// <returns></returns>
        public Int32 validarUsuario(ref Usuario oUsuario)
        {
            return logica_usuarios.validarUsuario(ref oUsuario);
        }

        /// <summary>
        /// Metodo que registra nuevos usuarios
        /// </summary>
        /// <param name="oUsuario">Objeto con los datos del usuario</param>
        public void RegistrarUsuario(Usuario oUsuario)
        {
            logica_usuarios.RegistrarUsuario(oUsuario);
        }

        public string RegistrarSesion(Usuario oUsuario)
        {
            return logica_usuarios.RegistrarSesion(oUsuario);
        }

        public string FinalizarSesion(Usuario oUsuario, Sesion oSesion)
        {
            return logica_usuarios.FinalizarSesion(oUsuario, oSesion);
        }
        #endregion
    }
}
