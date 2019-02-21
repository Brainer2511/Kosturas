using ClosedXML.Excel;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmCP_ConsultaPlazas : System.Web.UI.Page
    {
        //Variables
        public Planilla_WCF servicio;

        protected void Page_Load(object sender, EventArgs e)
        {
            //se instancia la clase de base de datos
            servicio = new Planilla_WCF();

            //se valida el postback
            if (!IsPostBack)
            {

            }

            if (Session["Usuario"] == null) { Response.Redirect("../Default.aspx"); }
            LoginView mpLongView = (LoginView)Master.FindControl("LoginView1");
            LinkButton mpLinkButton = (LinkButton)mpLongView.FindControl("LoginTag");
            LinkButton mpLogoffButton = (LinkButton)mpLongView.FindControl("LogoffTag");
            mpLinkButton.Visible = false;
            mpLogoffButton.Visible = true;

            if (Session["Usuario"].Equals("Administrador") == false)
            {
                LinkButton mpLkbPlanillas = (LinkButton)mpLongView.FindControl("lkbPlanillas");
                LinkButton mpLkbPlazass = (LinkButton)mpLongView.FindControl("lkbPlazas");
                LinkButton mpLkbUsuarios = (LinkButton)mpLongView.FindControl("lkbUsuarios");

                mpLkbPlanillas.Visible = true;
                mpLkbPlazass.Visible = false;
            }
                //si alguna acción genera un postback se limpian los mensajes de error
                FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;
        }

        /// <summary>
        /// método de acción del boton listar que se encarga de iniciar el proceso de consulta de datos
        /// según los filtros especificados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //se limpian los mensajes de error
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;

            try
            {
                var fechaDesde = dtFecDesde.Value;
                var fechaHasta = dtFecHasta.Value;

                if(fechaHasta == DateTime.Today.ToString("yyyy-MM-dd"))
                {
                    fechaHasta = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
                    dtFecHasta.Value = fechaHasta;
                }

                DataTable datos = servicio.ObtenerDatosElite(fechaDesde, fechaHasta);
                DataTable personal = servicio.ConsultarLoginIdPersonal();
                DataTable splits = servicio.ObtenerSplits();

                DataTable listado = new DataTable();
                listado.Columns.Add("Colaborador");
                listado.Columns.Add("Log_Id");
                listado.Columns.Add("split");
                listado.Columns.Add("Horas");
                listado.Columns.Add("Proyecto");
                listado.Columns.Add("Fecha");

                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    DataRow fila = listado.NewRow();

                    fila["Log_Id"] = datos.Rows[i][2];
                    fila["split"] = datos.Rows[i][4];
                    fila["Fecha"] = datos.Rows[i][0];

                    var login = datos.Rows[i][5];
                    var logout = datos.Rows[i][6];
                    var diff = TimeSpan.Zero;

                    if(logout.Equals(login))
                    {
                        fila["Horas"] = "Sin LogOut";
                    }
                    else {
                        if (!(TimeSpan.Parse(logout.ToString()) < TimeSpan.Parse(login.ToString())))
                            diff = TimeSpan.Parse(logout.ToString()) - TimeSpan.Parse(login.ToString());
                        else
                        {
                            diff = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(login.ToString());
                            diff += TimeSpan.Parse(logout.ToString()) - TimeSpan.Parse("00:00:00");
                        }

                        //var diff = (DateTime.Parse(logout.ToString()).TimeOfDay - DateTime.Parse(login.ToString()).TimeOfDay);
                        fila["Horas"] = diff;
                    }

                    //if (!(TimeSpan.Parse(logout.ToString()) < TimeSpan.Parse(login.ToString())))
                    //    diff = TimeSpan.Parse(logout.ToString()) - TimeSpan.Parse(login.ToString());
                    //else
                    //{
                    //    diff = TimeSpan.Parse("23:59:59") - TimeSpan.Parse(login.ToString());
                    //    diff += TimeSpan.Parse(logout.ToString()) - TimeSpan.Parse("00:00:00");
                    //}

                    ////var diff = (DateTime.Parse(logout.ToString()).TimeOfDay - DateTime.Parse(login.ToString()).TimeOfDay);
                    //fila["Horas"] = diff;

                    for (int j = 0; j < personal.Rows.Count; j++)
                    {
                        if (datos.Rows[i][2].ToString().Trim().Equals(personal.Rows[j][1]))
                        {
                            fila["Colaborador"] = personal.Rows[j][0];
                        }
                    }

                    for (int k = 0; k < splits.Rows.Count; k++)
                    {
                        if (datos.Rows[i][4].Equals(splits.Rows[k][1]))
                        {
                            fila["Proyecto"] = splits.Rows[k][2];
                        }
                    }
                    listado.Rows.Add(fila);
                }

                if (listado.Rows.Count > 0)
                {
                    //con la respuesta obtenida se carga el gridview
                    gvListado.DataSource = listado;
                    gvListado.DataBind();
                    btnDescargar.Visible = true;
                    Exportar(listado);
                }
                else
                {
                    DataTable table = new DataTable();
                    table = null;
                    gvListado.DataSource = table;
                    gvListado.DataBind();

                    //En caso de que la consulta no recupere datos se informa del problema.
                    FailureText.Text = "No se recuperaron datos con los filtros especificados.";
                    ErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "Se presento un problema al realizar la consulta";
                ErrorMessage.Visible = true;
            }
        }

        /// <summary>
        /// Método que se encarga de habilitar la edición del item seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow row = gvListado.SelectedRow;
            //int id = Convert.ToInt32(gvListado.DataKeys[row.RowIndex].Value);
            //Response.Redirect("frmDetallePersona?Id=" + id);
        }

        protected void Exportar(DataTable tabla)
        {
            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(tabla, "Reportes");
            String filename = "Control_Plazas_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            wb.SaveAs(MapPath("~/descargas/" + filename));
            btnDescargar.NavigateUrl = "~/descargas/" + filename;
        }
    }
}