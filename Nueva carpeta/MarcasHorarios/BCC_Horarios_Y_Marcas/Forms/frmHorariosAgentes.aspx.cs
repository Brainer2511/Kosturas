using ClosedXML.Excel;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmHorariosAgentes : System.Web.UI.Page
    {
        //variable publica por medio de la cual se instancia la capa de datos
        public Planilla_WCF servicio;
        //public Personal_BLL servicio;
        //public Catalogos_BLL servicio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) { Response.Redirect("../Default.aspx"); }
            LoginView mpLongView = (LoginView)Master.FindControl("LoginView1");
            LinkButton mpLinkButton = (LinkButton)mpLongView.FindControl("LoginTag");
            LinkButton mpLogoffButton = (LinkButton)mpLongView.FindControl("LogoffTag");
            mpLinkButton.Visible = false;
            mpLogoffButton.Visible = true;

            if (Session["Usuario"].Equals("Administrador") == false)
            {
                var usuario = Session["DatosUsuario"];
                Usuario us = (Usuario)usuario;

                LinkButton mpLkbPlanillas = (LinkButton)mpLongView.FindControl("lkbPlanillas");
                //LinkButton mpLkbPlazass = (LinkButton)mpLongView.FindControl("lkbPlazas");
                LinkButton mpLkbUsuarios = (LinkButton)mpLongView.FindControl("lkbUsuarios");

                mpLkbPlanillas.Visible = true;
                //mpLkbPlazass.Visible = false;
                mpLkbUsuarios.Visible = false;

                //LinkButton mpCargaDatos = (LinkButton)mpLongView.FindControl("lkbCargaDatos");
                //LinkButton mpPersonal = (LinkButton)mpLongView.FindControl("lkbPersonal");
                LinkButton mpProgramacion = (LinkButton)mpLongView.FindControl("lkbProgramacion");
                LinkButton mpUsuarios = (LinkButton)mpLongView.FindControl("lkbUsuarios");

                LinkButton mpAvaya = (LinkButton)mpLongView.FindControl("lkbAvaya");
                LinkButton mpElite = (LinkButton)mpLongView.FindControl("lkbElite");
                LinkButton mpRegPersonal = (LinkButton)mpLongView.FindControl("lkbRegistroPersonal");

                //mpCargaDatos.Visible = false;
                //mpPersonal.Visible = false;
                mpProgramacion.Visible = false;
                mpUsuarios.Visible = false;
                mpAvaya.Visible = false;
                mpElite.Visible = false;
                mpRegPersonal.Visible = false;

                if (us.departamento == 2)
                {
                    LinkButton mpPersonal = (LinkButton)mpLongView.FindControl("lkbPersonal");
                    mpPersonal.Visible = false;
                    LinkButton mpJefaturas = (LinkButton)mpLongView.FindControl("lkbJefaturas");
                    mpJefaturas.Visible = true;
                    LinkButton mpHorario = (LinkButton)mpLongView.FindControl("lbkSupHorarios");
                    mpHorario.Visible = true;
                    LinkButton mpAsistencia = (LinkButton)mpLongView.FindControl("lkbAsistencia");
                    mpAsistencia.Visible = false;
                    LinkButton mpConsultaA = (LinkButton)mpLongView.FindControl("lkbConsulta");
                    mpConsultaA.Visible = false;
                }
                else if (us.seccion == 7)
                {
                    LinkButton mpPersonal = (LinkButton)mpLongView.FindControl("lkbPersonal");
                    mpPersonal.Visible = false;
                    LinkButton mpCargaDatos = (LinkButton)mpLongView.FindControl("lkbCargaDatos");
                    mpCargaDatos.Visible = false;
                }
            }

            //se instancia la clase de base de datos
            servicio = new Planilla_WCF();

            //se valida el postback
            if (!IsPostBack)
            {
                //se cargan los datos en el ddl de Proecto
                cargarProyectos();
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";

                var objUsuario = (Usuario)Session["DatosUsuario"];
                if (!objUsuario.departamento.ToString().Equals(GetGlobalResourceObject("Catalogos", "DeptoRRHH")))                    
                {
                    if (!objUsuario.departamento.ToString().Equals(GetGlobalResourceObject("Catalogos", "dptoWFM")))
                    {
                        ddlProyecto.SelectedValue = objUsuario.proyecto.ToString();
                        ddlProyecto.Enabled = false;
                    }
                }
            }
            //si alguna acción genera un postback se limpian los mensajes de error
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;
        }

        /// <summary>
        /// Método que carga el dorp down de Proyecto
        /// </summary>
        public void cargarProyectos()
        {
            var codCatalogo = Int32.Parse(GetGlobalResourceObject("Catalogos", "catProyectos").ToString());// 4;//Catalogo de Proyectos
            DataTable datos = servicio.ConsultarItemsCatalogo(codCatalogo);

            if (datos.Rows.Count > 0)
            {
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
                ddlProyecto.Items.Add(oItemTodos);
                //se iteran las filas obtenidas de la consulta a BD para agregar los valores al dropdown
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //Se crea un nuevo item por cada fila recupera de BD
                    ListItem oItem = new ListItem();
                    //Se setea el texto y el valor para cada item
                    oItem.Text = (datos.Rows[i]).ItemArray[1].ToString();
                    oItem.Value = (datos.Rows[i]).ItemArray[0].ToString();
                    //se agrega el item recien creado al drop down
                    ddlProyecto.Items.Add(oItem);
                }
            }
            else
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "Se presentó un problema al cargar la página.";
                ErrorMessage.Visible = true;
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {

            //se limpian los mensajes de error
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;
            //Se obtiene el proyecto seleccionado
            var proyecto = 0;
            if (!ddlProyecto.SelectedValue.Equals("0"))
            {
                proyecto = Int16.Parse(ddlProyecto.SelectedValue);
            }
            var fechaDesde = Convert.ToDateTime(dtFecDesde.Value);
            var fechaHasta = Convert.ToDateTime(dtFecHasta.Value);

            var desde = Convert.ToDateTime(dtFecDesde.Value).ToString("yyyy-MM-dd");
            var hasta = Convert.ToDateTime(dtFecHasta.Value).ToString("yyyy-MM-dd");

            var usuario = (Usuario)Session["DatosUsuario"];
            var encargado = 0;

            if (!usuario.departamento.ToString().Equals(GetGlobalResourceObject("Catalogos", "DeptoRRHH")))
            {
                encargado = usuario.idPersona;
            }

            try
            {
                DataTable datos = servicio.ConsultarHorariosAgentes(proyecto, desde, hasta, encargado);

                if (datos.Rows.Count > 0)
                {
                    //con la respuesta obtenida se carga el gridview
                    gvProgramacion.DataSource = datos;
                    gvProgramacion.DataBind();
                    divDescargar.Visible = true;
                    Exportar(datos);
                }
                else
                {
                    DataTable table = new DataTable();
                    table = null;
                    gvProgramacion.DataSource = table;
                    gvProgramacion.DataBind();

                    //En caso de que la consulta no recupere datos se informa del problema.
                    FailureText.Text = "No se recuperaron datos con los filtros especificados.";
                    ErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message + " \n" + ex.Source + "\n" + ex.StackTrace;
                ErrorMessage.Visible = true;
            }
        }

        protected void Exportar(DataTable tablaDatos)
        {
            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(tablaDatos, "Horarios");
            String filename = "HorariosAgentes_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            wb.SaveAs(MapPath("~/descargas/" + filename));
            btnDescargar.NavigateUrl = "~/descargas/" + filename;

            //string attachment = "attachment; filename=Horarios" + DateTime.Today + ".xls";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", attachment);
            //Response.ContentType = "application/vnd.ms-excel";
            //string tab = "";
            //foreach (DataColumn dc in tablaDatos.Columns)
            //{
            //    Response.Write(tab + dc.ColumnName);
            //    tab = "\t";
            //}
            //Response.Write("\n");
            //int i;
            //var texto = String.Empty;
            //foreach (DataRow dr in tablaDatos.Rows)
            //{
            //    tab = "";
            //    for (i = 0; i < tablaDatos.Columns.Count; i++)
            //    {
            //        texto = dr[i].ToString();
            //        limpiarCaracteresEsp(ref texto);
            //        Response.Write(tab + texto);
            //        tab = "\t";
            //    }
            //    Response.Write("\n");

            //}
            //Response.End();
        }

        //protected void limpiarCaracteresEsp(ref string texto)
        //{
        //    texto = texto.Replace('á', 'a');
        //    texto = texto.Replace('é', 'e');
        //    texto = texto.Replace('í', 'i');
        //    texto = texto.Replace('ó', 'o');
        //    texto = texto.Replace('ú', 'u');

        //    texto = texto.Replace('Á', 'A');
        //    texto = texto.Replace('É', 'E');
        //    texto = texto.Replace('Í', 'I');
        //    texto = texto.Replace('Ó', 'O');
        //    texto = texto.Replace('Ú', 'U');

        //    texto = texto.Replace('ñ', 'n');
        //    texto = texto.Replace('ü', 'u');
        //}
    }
}