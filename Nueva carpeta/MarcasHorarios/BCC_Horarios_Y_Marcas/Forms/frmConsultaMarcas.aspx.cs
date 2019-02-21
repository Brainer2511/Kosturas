using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmConsultaMarcas : System.Web.UI.Page
    {
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
            }

            //se instancia la clase de base de datos
            servicio = new Planilla_WCF();
            //servicio = new Catalogos_BLL();
            //servicio = new Personal_BLL();

            //se valida el postback
            if (!IsPostBack)
            {
                //se cargan los datos en el ddl de departamento la primera vez que se carga la página
                cargarDepartamento();
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
                ddlSeccion.Items.Add(oItemTodos);
            }
            //si alguna acción genera un postback se limpian los mensajes de error
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;
        }

        /// <summary>
        /// Método que carga el dorp down de Departamento
        /// </summary>
        public void cargarDepartamento()
        {
            var codCatalogo = 1;//Catalogo de Departamento
            DataTable datos = servicio.ConsultarItemsCatalogo(codCatalogo);

            if (datos.Rows.Count > 0)
            {
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
                ddlDepartamento.Items.Add(oItemTodos);
                //se iteran las filas obtenidas de la consulta a BD para agregar los valores al dropdown
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //Se crea un nuevo item por cada fila recupera de BD
                    ListItem oItem = new ListItem();
                    //Se setea el texto y el valor para cada item
                    oItem.Text = (datos.Rows[i]).ItemArray[1].ToString();
                    oItem.Value = (datos.Rows[i]).ItemArray[0].ToString();
                    //se agrega el item recien creado al drop down
                    ddlDepartamento.Items.Add(oItem);
                }
            }
            else
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "Se presentó un problema al cargar la página.";
                ErrorMessage.Visible = true;
            }
        }

        /// <summary>
        /// Método que Carga el dorp down de Sección que depende de lo seleccionado en el ddl de departamento
        /// </summary>
        /// <param name="codigoDepartamento"></param>
        public void cargarSeccion(int codigoDepartamento)
        {
            ddlSeccion.Items.Clear();
            var codCatalogo = 2;//Catalogo de Sección
            var codItem = codigoDepartamento; //Convert.ToInt32(ddlDepartamento.SelectedValue);
            DataTable datos = servicio.ConsultarItemsCatalogo(codCatalogo, codItem);

            if (datos.Rows.Count > 0)
            {
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
                ddlSeccion.Items.Add(oItemTodos);
                //se iteran las filas obtenidas de la consulta a BD para agregar los valores al dropdown
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //Se crea un nuevo item por cada fila recupera de BD
                    ListItem oItem = new ListItem();
                    //Se setea el texto y el valor para cada item
                    oItem.Text = (datos.Rows[i]).ItemArray[1].ToString();
                    oItem.Value = (datos.Rows[i]).ItemArray[0].ToString();
                    //se agrega el item recien creado al drop down
                    ddlSeccion.Items.Add(oItem);
                }
                ddlSeccion.Visible = true;
                lblFiltroSeccion.Visible = true;
            }
            else
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "Se presentó un problema al cargar la página.";
                ErrorMessage.Visible = true;
            }
        }

        /// <summary>
        /// Método que se encarga de validar cualquier cambio en el ddl para aplicar alguna acción
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlDepartamento.SelectedValue.Equals("0"))
            {
                ddlSeccion.Items.Clear();
                var catalogo = Int16.Parse(ddlDepartamento.SelectedValue);
                cargarSeccion(catalogo);
                ddlSeccion.Enabled = true;
            }
            else
            {
                ddlSeccion.Enabled = false;
            }
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

            var codigoDpto = 0;
            var codigoSeccion = 0;

            try
            {
                if (!ddlDepartamento.SelectedValue.Equals("0"))
                {
                    codigoDpto = Int16.Parse(ddlDepartamento.SelectedValue);
                }
                if (!ddlSeccion.SelectedValue.Equals("0") && !ddlSeccion.SelectedValue.Equals(string.Empty))
                {
                    codigoSeccion = Int16.Parse(ddlSeccion.SelectedValue);
                }

                var fechaDesde = dtFecDesde.Value;
                var fechaHasta = dtFecHasta.Value;

                DataTable datos = servicio.ConsultarMarcas(fechaDesde, fechaHasta, codigoDpto, codigoSeccion);

                if (datos.Rows.Count > 0)
                {
                    //con la respuesta obtenida se carga el gridview
                    gvListado.DataSource = datos;
                    gvListado.DataBind();
                    //btnExportar.Visible = true;
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
            catch
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
            GridViewRow row = gvListado.SelectedRow;
            int id = Convert.ToInt32(gvListado.DataKeys[row.RowIndex].Value);
            Response.Redirect("frmDetallePersona?Id=" + id);
        }
    }
}