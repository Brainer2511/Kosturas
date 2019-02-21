using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class RegistroPersonal : System.Web.UI.Page
    {
        public Planilla_WCF servicio;

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

            servicio = new Planilla_WCF();

            if (!IsPostBack)
            {
                cargarDepartamento();
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
                ddlSeccion.Items.Add(oItemTodos);

                cargarProyectos();
            }
        }

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

        public void cargarSeccion(int codigoDepartamento)
        {
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
                ddlSeccion.Enabled = true;
            }
            else
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "Se presentó un problema al cargar la página.";
                ErrorMessage.Visible = true;
            }
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

        //TODO
        ///// <summary>
        ///// Método que carga el dorp down de encargado
        ///// segùn lo selecciondo en el departamento
        ///// </summary>
        //public void cargarEncargados(int dpto, int seccion)
        //{
        //    DataTable datos = servicio.ConsultarItemsCatalogo(codCatalogo);

        //    if (datos.Rows.Count > 0)
        //    {
        //        //Se crea un item inicial que sera la opcion TODOS en el dropdown
        //        ListItem oItemTodos = new ListItem();
        //        oItemTodos.Text = "SELECCIONE";
        //        oItemTodos.Value = "0";
        //        ddlProyecto.Items.Add(oItemTodos);
        //        //se iteran las filas obtenidas de la consulta a BD para agregar los valores al dropdown
        //        for (int i = 0; i < datos.Rows.Count; i++)
        //        {
        //            //Se crea un nuevo item por cada fila recupera de BD
        //            ListItem oItem = new ListItem();
        //            //Se setea el texto y el valor para cada item
        //            oItem.Text = (datos.Rows[i]).ItemArray[1].ToString();
        //            oItem.Value = (datos.Rows[i]).ItemArray[0].ToString();
        //            //se agrega el item recien creado al drop down
        //            ddlProyecto.Items.Add(oItem);
        //        }
        //    }
        //    else
        //    {
        //        //En caso de que la consulta no recupere datos se informa del problema.
        //        FailureText.Text = "Se presentó un problema al cargar la página.";
        //        ErrorMessage.Visible = true;
        //    }
        //}

        protected void ddlDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlDpto.SelectedValue.Equals("0"))
            {
                ddlSeccion.Items.Clear();
                var catalogo = Int16.Parse(ddlDpto.SelectedValue);
                cargarSeccion(catalogo);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;
            try
            {
                var persona = new Persona
                {
                    nombre = txtNombre.Text,
                    departamento = Int16.Parse(ddlDpto.SelectedValue),
                    seccion = Int16.Parse(ddlSeccion.SelectedValue),
                    codProyecto = Int32.Parse(ddlProyecto.SelectedValue) 
                };

                if (!txtMSP.Text.Equals(string.Empty))
                    persona.idMarcaSanPedro = Int32.Parse(txtMSP.Text);
                if (!txtMZPT.Text.Equals(string.Empty))
                    persona.idMarcaZapote = Int32.Parse(txtMZPT.Text);
                if (!txtLoginId.Text.Equals(string.Empty))
                    persona.LoginId = Int32.Parse(txtLoginId.Text);
                if (!txtCorreo.Value.Equals(string.Empty))
                    persona.correo = txtCorreo.Value;

                servicio.RegistrarPersonal(persona);
            }
            catch(Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;
            try
            {
                var persona = new Persona
                {
                    nombre = txtNombre.Text,
                    departamento = Int16.Parse(ddlDpto.SelectedValue),
                    seccion = Int16.Parse(ddlSeccion.SelectedValue),
                };

                if (!txtMSP.Text.Equals(string.Empty))
                    persona.idMarcaSanPedro = Int32.Parse(txtMSP.Text);
                if (!txtMZPT.Text.Equals(string.Empty))
                    persona.idMarcaZapote = Int32.Parse(txtMZPT.Text);

                servicio.ModificarPersonal(persona);
            }
            catch (Exception ex)
            {
                FailureText.Text = ex.Message;
                ErrorMessage.Visible = true;
            }
        }
    }
}