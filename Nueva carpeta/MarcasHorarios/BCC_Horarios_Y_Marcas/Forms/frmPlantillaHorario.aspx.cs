using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmPlantillaHorario : System.Web.UI.Page
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

                var usuario = Session["DatosUsuario"];
                Usuario us = (Usuario)usuario;

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

            servicio = new Planilla_WCF();
            if (!IsPostBack)
            {
                cargarDepartamento();
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            DataTable datos;
            var cantDias = "1";//txtCantDias.Text;
            int diasProgramacion;
            int cantidad;
            var resultado = Int32.TryParse(cantDias, out cantidad);
            if (resultado)
            {
                if (cantidad < 0 || cantidad > 21)
                {
                    diasProgramacion = 1;
                }
                else
                {
                    diasProgramacion = cantidad;
                }
            }
            else
            {
                diasProgramacion = 1;
            }

            if (ddlDepartamento.SelectedValue.Equals("0"))
            {
                datos = servicio.ConsultarPersonalPlantilla();
            }
            else
            {
                var dpto = Convert.ToInt32(ddlDepartamento.SelectedValue);
                var secc = Convert.ToInt32(ddlSeccion.SelectedValue);
                var proy = 0;

                if (secc == 9)
                {
                    proy = Convert.ToInt32(ddlProyecto.SelectedValue);
                }

                datos = servicio.ConsultarPersonalPlantilla(dpto, secc, proy);
            }

            if (datos.Rows.Count != 0)
            {
                ExportToExcel(datos, diasProgramacion);
            }
        }

        private void ExportToExcel(DataTable tablaDatos, int cantDias)
        {
            string attachment = "attachment; filename=PlantillaHorarios" + DateTime.Today + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.ms-excel";
            string tab = "";
            foreach (DataColumn dc in tablaDatos.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            int i;
            var texto = String.Empty;
            foreach (DataRow dr in tablaDatos.Rows)
            {
                for (int k = 0; k < cantDias; k++)
                {
                    tab = "";
                    for (i = 0; i < tablaDatos.Columns.Count; i++)
                    {
                        texto = dr[i].ToString();
                        limpiarCaracteresEsp(ref texto);
                        Response.Write(tab + texto);
                        tab = "\t";
                    }
                    Response.Write("\n");
                }
            }
            Response.End();
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
                ddlSeccion.Visible = true;
                lblSeccion.Visible = true;
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
                ddlProyecto.Visible = true;
                ddlProyecto.Visible = true;
            }
            else
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "No se recuperaron datos para mostrar.";
                ErrorMessage.Visible = true;
            }
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartamento.SelectedValue.Equals("0"))
            {
                ddlSeccion.Items.Clear();
                ddlSeccion.Visible = false;
                lblSeccion.Visible = false;
            }
            else
            {
                ddlSeccion.Items.Clear();
                var catalogo = Int16.Parse(ddlDepartamento.SelectedValue);
                cargarSeccion(catalogo);
            }
        }

        protected void ddlSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlSeccion.SelectedValue.Equals("9"))
            {
                ddlProyecto.Items.Clear();
                ddlProyecto.Visible = false;
                ddlProyecto.Visible = false;
            }
            else
            {
                ddlProyecto.Items.Clear();
                cargarProyectos();
            }
        }

        protected void limpiarCaracteresEsp(ref string texto)
        {
            texto = texto.Replace('á', 'a');
            texto = texto.Replace('é', 'e');
            texto = texto.Replace('í', 'i');
            texto = texto.Replace('ó', 'o');
            texto = texto.Replace('ú', 'u');

            texto = texto.Replace('Á', 'A');
            texto = texto.Replace('É', 'E');
            texto = texto.Replace('Í', 'I');
            texto = texto.Replace('Ó', 'O');
            texto = texto.Replace('Ú', 'U');

            texto = texto.Replace('ñ', 'n');
            texto = texto.Replace('ü', 'u');
        }
    }
}