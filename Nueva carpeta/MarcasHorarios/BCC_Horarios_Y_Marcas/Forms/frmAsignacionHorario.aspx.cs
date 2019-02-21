using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmAsignacionHorario : System.Web.UI.Page
    {
        //variable publica por medio de la cual se instancia la capa de datos
        ////public Planillas_BLL servicio;
        ////public Catalogos_BLL servicio;
        ////public Personal_BLL servicio;

        public Planilla_WCF servicio;

        public int idPersona;
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
            //servicio = new Planillas_BLL();
            //servicio = new Catalogos_BLL();
            //servicio = new Personal_BLL();
            servicio = new Planilla_WCF();

            //Se obtiene el id
            idPersona = Convert.ToInt32(Request.QueryString["Id"]);

            //se valida el postback
            if (!IsPostBack)
            {
                //se cargan los datos en el ddl de departamento la primera vez que se carga la página
                cargarDepartamento();
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";

                //Se cargan los datos
                ConsultarDatosPersona(idPersona);

                //Se cargan datos en el gridView
                //ñcargarGrid();
                var fecha = DateTime.Now;
                CultureInfo ci = new CultureInfo("Es-Es");
                var dia = ci.DateTimeFormat.GetDayName(fecha.DayOfWeek);//fecha.DayOfWeek.ToString();
                dia = dia.ToUpper();
                if (!dia.Equals("LUNES"))
                {
                    int agregarDia = 1;

                    while(!dia.Equals("LUNES"))
                    {
                        dia = ci.DateTimeFormat.GetDayName((fecha.AddDays(agregarDia).DayOfWeek));
                        dia = dia.ToUpper();
                        agregarDia = agregarDia + 1;
                    }
                }
                
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
            servicio = new Planilla_WCF();
            DataTable datos = servicio.ConsultarItemsCatalogo(codCatalogo);

            if (datos.Rows.Count > 0)
            {
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
                ddlDpto.Items.Add(oItemTodos);
                //se iteran las filas obtenidas de la consulta a BD para agregar los valores al dropdown
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //Se crea un nuevo item por cada fila recupera de BD
                    ListItem oItem = new ListItem();
                    //Se setea el texto y el valor para cada item
                    oItem.Text = (datos.Rows[i]).ItemArray[1].ToString();
                    oItem.Value = (datos.Rows[i]).ItemArray[0].ToString();
                    //se agrega el item recien creado al drop down
                    ddlDpto.Items.Add(oItem);
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
            }
            else
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "Se presentó un problema al cargar la página.";
                ErrorMessage.Visible = true;
            }
        }

        protected void ConsultarDatosPersona(int idPersona)
        {
            var persona = servicio.ConsultarPersona(idPersona);

            txtNombre.Text = persona.nombre;
            ddlDpto.SelectedValue = persona.departamento.ToString();
            cargarSeccion(persona.departamento);
            ddlSeccion.SelectedValue = persona.seccion.ToString();
        }

        protected void CargarGrid()
        {
            var table = new DataTable();
            table.Columns.Add("id");
            table.Columns.Add("fecha");
            table.Columns.Add("entrada");
            table.Columns.Add("salida");

            DataRow fila = table.NewRow();
            //Se cargan los datos en la fila
            //fila["idItem"] = Convert.ToInt32(reader["idItem"]);
            //fila["nombre"] = reader["nombre"].ToString();
            //fila["idCatalogo"] = Convert.ToInt32(reader["idCatalogo"]);
        }
    }
}