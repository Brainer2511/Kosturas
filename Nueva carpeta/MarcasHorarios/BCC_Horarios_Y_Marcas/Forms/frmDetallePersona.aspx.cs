using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmDetallePersona : System.Web.UI.Page
    {
        //variable publica por medio de la cual se instancia la capa de datos
        public Planilla_WCF servicio;
        //public Personal_BLL servicio;
        //public Catalogos_BLL servicio;

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
            servicio = new Planilla_WCF();

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

        /// <summary>
        /// Método que se encarga de validar cualquier cambio en el ddl para aplicar alguna acción
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDpto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlDpto.SelectedValue.Equals("0"))
            {
                ddlSeccion.Items.Clear();
                var catalogo = Int16.Parse(ddlDpto.SelectedValue);
                cargarSeccion(catalogo);
                ddlSeccion.Enabled = true;
            }
            else
            {
                ddlSeccion.Enabled = false;
            }
        }

        protected void ConsultarDatosPersona(int idPersona)
        {
            var persona = servicio.ConsultarPersona(idPersona);

            txtNombre.Text = persona.nombre;
            ddlDpto.SelectedValue = persona.departamento.ToString();
            cargarSeccion(persona.departamento);
            ddlSeccion.SelectedValue = persona.seccion.ToString();
            txtMSP.Text = persona.idMarcaSanPedro.ToString();
            txtMZPT.Text = persona.idMarcaZapote.ToString();
            txtCorreo.Value = persona.correo.ToString();
            txtLoginId.Text = persona.LoginId.ToString();
        }

        //Método que da funcionalidad al botón Editar
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //Se coulta el boton Editar
            btnEditar.Visible = false;
            //Se habilitan los campos y acciones
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;
            txtNombre.Enabled = true;
            txtMSP.Enabled = true;
            txtMZPT.Enabled = true;
            ddlDpto.Enabled = true;
            ddlSeccion.Enabled = true;
            txtCorreo.Disabled = false;
            txtLoginId.Enabled = true;
        }

        //Método que da funcionalidad al boton Cancelar
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Se coulta el boton Editar
            btnEditar.Visible = true;
            //Se habilitan los campos y acciones
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
            txtNombre.Enabled = false;
            txtMSP.Enabled = false;
            txtMZPT.Enabled = false;
            ddlDpto.Enabled = false;
            ddlSeccion.Enabled = false;
            txtCorreo.Disabled = true;
            txtLoginId.Enabled = false;
        }

        //Método que da funcionalidad al botón Aceptar
        protected void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //se crea la nueva instancia del objeto para cargar los datos a modificar
                var colaborador = new Persona();
                //se cargan los datos
                colaborador.idPersona = Convert.ToInt32(Request.QueryString["Id"]);
                colaborador.nombre = txtNombre.Text;
                colaborador.departamento = Convert.ToInt32(ddlDpto.SelectedValue);
                colaborador.seccion = Convert.ToInt32(ddlSeccion.SelectedValue);
                int number = 0;
                bool resultado = Int32.TryParse(txtMSP.Text, out number);
                if (resultado)
                {
                    colaborador.idMarcaSanPedro = number;
                }
                else
                {
                    colaborador.idMarcaSanPedro = number;
                }
                int valor = 0;
                bool convertido = Int32.TryParse(txtMZPT.Text, out valor);
                if (convertido)
                {
                    colaborador.idMarcaZapote = valor;
                }
                else
                {
                    colaborador.idMarcaZapote = valor;
                }
                if (!txtCorreo.Value.Equals(String.Empty))
                {
                    colaborador.correo = txtCorreo.Value;
                }
                if (!txtLoginId.Text.Equals(String.Empty))
                {
                    colaborador.LoginId = Int32.Parse(txtLoginId.Text);
                }

                servicio.ModificarPersonal(colaborador);
                ConsultarDatosPersona(idPersona);
                //Response.Redirect("~/frmDetallePersona.aspx?Id=" + Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                FailureText.Text = "Se presento un problema al procesar la información.";
                ErrorMessage.Visible = true;
            }
            Response.Redirect("~/Forms/frmDetallePersona.aspx?Id=" + Request.QueryString["Id"]);
        }
    }
}