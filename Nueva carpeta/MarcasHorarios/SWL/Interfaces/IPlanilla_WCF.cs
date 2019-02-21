using System.Data;
using System.ServiceModel;
using System;

namespace BCC_Horarios_Y_Marcas
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlanilla_WCF" in both code and config file together.
    [ServiceContract]
    public interface IPlanilla_WCF
    {
        [OperationContract]
        DataTable ConsultarItemsCatalogo(int idCatalogo);

        [OperationContract]
        DataTable ConsultarItemsCatalogo(int idCatalogo, int itemPadre);

        [OperationContract]
        DataTable ObtenerDatosElite(string desde, string hasta);

        [OperationContract]
        DataTable ObtenerSplits();

        [OperationContract]
        void RegistrarSplit(int codigo, string nombre, int? id);

        [OperationContract]
        DataTable ConsultarLoginIdPersonal();

        [OperationContract]
        void RegistrarPersonal(Persona persona);

        [OperationContract]
        DataTable ConsultarPersonalPlantilla(int dpto = 0, int seccion = 0, int proyecto = 0);

        [OperationContract]
        DataTable ConsultarPersonal(int dpto = 0, int seccion = 0);

        [OperationContract]
        DataTable BuscarPersona(int dpto = 0, int seccion = 0, int proyecto = 0, string nombre = "");

        [OperationContract]
        void ModificarPersonal(Persona persona);

        [OperationContract]
        Persona ConsultarPersona(int idPersona);

        [OperationContract]
        DataTable ConsultarMarcas(string fechaDesde, string fechaHasta, int dpto = 0, int seccion = 0);

        [OperationContract]
        DataTable ObtenerPersonalACargo(Int32 idPersona);

        [OperationContract]
        void cargarDatos(Marca oMarcas, Persona oPersona);

        [OperationContract]
        void cargarDatos(Programacion oProgramacion, Persona oPersona);

        [OperationContract]
        DataTable ConsultaDatosProgramacion(string desde, string hasta, string nombre, ref string horasProg);

        [OperationContract]
        DataTable ObtenerProgramacion(string desde, string hasta, Int32 idPersona);

        [OperationContract]
        void JustificarProgramacion(int idProgramacion, string justificacion, string comentario);

        [OperationContract]
        DataTable ConsultaCMSAACC(string desde, string hasta, string extensiones, ref string horasCMSA);

        [OperationContract]
        DataTable ObtenerCMSAACC(string desde, string hasta, string extensiones);

        [OperationContract]
        DataTable ConsultaCMSElite(string desde, string hasta, string extensiones, ref string horasCMSE);

        [OperationContract]
        DataTable ConsultaLogueosEliteXId(string desde, string hasta, int idPersona, ref string horasCMSE);

        [OperationContract]
        DataTable ObtenerCMSElite(string desde, string hasta, string extensiones);

        [OperationContract]
        DataTable ConsultaMarcasZPT(string desde, string hasta, string nombre, ref string horasMarcZ);

        [OperationContract]
        DataTable ObtenerMarcasZPT(string desde, string hasta, Int32 idPersona);

        [OperationContract]
        DataTable ConsultaMarcasSP(string desde, string hasta, string nombre, ref string horasMarcS);

        [OperationContract]
        DataTable ObtenerMarcasSP(string desde, string hasta, Int32 idPersona);

        [OperationContract]
        DataTable ObtenerDatosCms(string desde, string hasta);

        [OperationContract]
        DataTable ObtenerDatosCmsElite(string desde, string hasta);

        [OperationContract]
        void RegistrarCMS_AACC(CMS_AACC oCMS);

        [OperationContract]
        void RegistrarCMS_Elite(CMS_Elite oCMS);

        [OperationContract]
        DataTable obtenerExtensiones(Persona oPersona);

        [OperationContract]
        void RegistrarJustificacion(Justificacion oJustificacion);

        [OperationContract]
        DataTable ConsultarAsistencia(string fechaDesde, string fechaHasta, int idColaborador, int codSuper);

        [OperationContract]
        Justificacion ConsultarDatosAsistencia(Int32 idRegistro);

        [OperationContract]
        void ActualizarJustificacion(Justificacion oJustificacion);

        [OperationContract]
        DataTable ConsultarPlanillaXProyecto(int proyecto, string fechaDesde, string fechaHasta);

        [OperationContract]
        DataTable ConsultarHorariosAgentes(int proyecto, string fechaDesde, string fechaHasta, int encargado);

        [OperationContract]
        Int32 validarUsuario(ref Usuario oUsuario);

        [OperationContract]
        void RegistrarUsuario(Usuario oUsuario);

        [OperationContract]
        string RegistrarSesion(Usuario oUsuario);

        [OperationContract]
        string FinalizarSesion(Usuario oUsuario, Sesion oSesion);
    }
}
