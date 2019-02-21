using System;
using System.Data;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmSeguimiento : System.Web.UI.Page
    {
        //variable publica por medio de la cual se instancia la capa de datos
        public Planilla_WCF servicio;
        //public Personal_BLL servicio;
        //public Catalogos_BLL servicio;

        public int idRegistro = 0;

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

                if (us.seccion == 7)
                {
                    LinkButton mpPersonal = (LinkButton)mpLongView.FindControl("lkbPersonal");
                    mpPersonal.Visible = false;
                    LinkButton mpCargaDatos = (LinkButton)mpLongView.FindControl("lkbCargaDatos");
                    mpCargaDatos.Visible = false;
                }
            }

            //se instancia la clase de base de datos
            servicio = new Planilla_WCF();
            //servicio = new Catalogos_BLL();
            //servicio = new Personal_BLL();

            if (!(Request.QueryString["Id"] == null))
            {
                idRegistro = Convert.ToInt32(Request.QueryString["Id"]);
            }


            if (!IsPostBack)
            {
                tblBotonesEdic.Visible = false;

                //Se carga el drop down de motivos
                cargarMotivos();

                //se obtiene el id de persona
                var id = Int32.Parse(Session["idPersona"].ToString());
                //Se carga el drop down de colaborador
                cargarColaboradores(id);

                if (idRegistro != 0)
                {
                    ConsultarDatosAsistencia(idRegistro);
                }
            }
        }

        /// <summary>
        /// Método que se encarga de cargar datos en el dropdown de Motivos
        /// </summary>
        protected void cargarMotivos()
        {
            var codCatalogo = 5;//Catalogo de Motivos
            DataTable datos = servicio.ConsultarItemsCatalogo(codCatalogo);

            if (datos.Rows.Count > 0)
            {
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
                ddlMotivo.Items.Add(oItemTodos);
                //se iteran las filas obtenidas de la consulta a BD para agregar los valores al dropdown
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //Se crea un nuevo item por cada fila recupera de BD
                    ListItem oItem = new ListItem();
                    //Se setea el texto y el valor para cada item
                    oItem.Text = (datos.Rows[i]).ItemArray[1].ToString();
                    oItem.Value = (datos.Rows[i]).ItemArray[0].ToString();
                    //se agrega el item recien creado al drop down
                    ddlMotivo.Items.Add(oItem);
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
        /// Método que carga los datos en el drop down de colaboradores
        /// </summary>
        /// <param name="id">Identificador de la persona que se loguea en el sistema</param>
        protected void cargarColaboradores(Int32 id)
        {
            DataTable datos = servicio.ObtenerPersonalACargo(id);

            if (datos.Rows.Count > 0)
            {
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
                ddlColaborador.Items.Add(oItemTodos);
                //se iteran las filas obtenidas de la consulta a BD para agregar los valores al dropdown
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //Se crea un nuevo item por cada fila recupera de BD
                    ListItem oItem = new ListItem();
                    //Se setea el texto y el valor para cada item
                    oItem.Text = (datos.Rows[i]).ItemArray[1].ToString();
                    oItem.Value = (datos.Rows[i]).ItemArray[0].ToString();
                    //se agrega el item recien creado al drop down
                    ddlColaborador.Items.Add(oItem);
                }
            }
            else
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "No se recuperaron datos para mostrar.";
                ErrorMessage.Visible = true;
            }
        }

        /// <summary>
        /// Método que da acción al botón registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            var oJustificacion = new Justificacion()
            {
                idPersona = Int32.Parse(ddlColaborador.SelectedValue),
                Motivo = Int32.Parse(ddlMotivo.SelectedValue),
                fechaJustificacion = dtFecha.Value,
                horaInicio = txtHoradesde.Value,
                horaFin = txtHoraHasta.Value,
                observaciones = taObs.Value,
                idPersonaregistro = Int32.Parse(Session["idPersona"].ToString()),
            };

            try
            {
                servicio.RegistrarJustificacion(oJustificacion);
            }catch(Exception ex)
            {
                FailureText.Text = "Se presento un problema al procesar la información.";
                ErrorMessage.Visible = true;
            }
        }

        /// <summary>
        /// Método que da funcionalidad al botón Modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //btnModificar.Visible = false;
            tblBotonesPrinc.Visible = false;
            tblBotonesEdic.Visible = true;
            ddlColaborador.Enabled = true;
            ddlMotivo.Enabled = true;
            dtFecha.Disabled = false;
            taObs.Disabled = false;
        }

        protected void ddlMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var opcion = Int32.Parse(ddlMotivo.SelectedValue);

            if (opcion == 54)
            {
                lblHoraDesde.Visible = true;
                lblHoraHasta.Visible = true;
                txtHoradesde.Visible = true;
                txtHoraHasta.Visible = true;
            }
            else
            {
                lblHoraDesde.Visible = false;
                lblHoraHasta.Visible = false;
                txtHoradesde.Visible = false;
                txtHoraHasta.Visible = false;
            }
        }

        protected void ConsultarDatosAsistencia(int idRegistro)
        {
            var asistencia = servicio.ConsultarDatosAsistencia(idRegistro);
            btnRegistrar.Visible = false;
            btnModificar.Visible = true;

            ddlColaborador.SelectedValue = asistencia.idPersona.ToString();
            ddlMotivo.SelectedValue = asistencia.Motivo.ToString();
            var fecha = DateTime.Parse(asistencia.fechaJustificacion.ToString());

            dtFecha.Value = fecha.ToString("yyyy-MM-dd");
            txtHoradesde.Value = asistencia.horaInicio.ToString();
            txtHoraHasta.Value = asistencia.horaFin.ToString();
            taObs.Value = asistencia.observaciones.ToString();
            
            ddlColaborador.Enabled = false;
            ddlMotivo.Enabled = false;
            dtFecha.Disabled = true;
            taObs.Disabled = true;
        }

        ////Método que da funcionalidad al botón Editar
        //protected void btnEditar_Click(object sender, EventArgs e)
        //{
        //    ////Se coulta el boton Editar
        //    //btnEditar.Visible = false;
        //    ////Se habilitan los campos y acciones
        //    //btnAceptar.Visible = true;
        //    //btnCancelar.Visible = true;
        //    //txtNombre.Enabled = true;
        //    //txtMSP.Enabled = true;
        //    //txtMZPT.Enabled = true;
        //    //ddlDpto.Enabled = true;
        //    //ddlSeccion.Enabled = true;
        //}

        //Método que da funcionalidad al boton Cancelar
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ddlColaborador.Enabled = false;
            ddlMotivo.Enabled = false;
            dtFecha.Disabled = true;
            taObs.Disabled = true;

            tblBotonesPrinc.Visible = true;
            tblBotonesEdic.Visible = false;
        }

        //Método que da funcionalidad al botón Aceptar
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //se crea la nueva instancia del objeto para cargar los datos a modificar
                var oJustificacion = new Justificacion();
                //se cargan los datos
                oJustificacion.idJustificacion = Convert.ToInt32(Request.QueryString["Id"]);
                oJustificacion.Motivo = Int32.Parse(ddlMotivo.SelectedValue);
                oJustificacion.fechaJustificacion = dtFecha.Value;
                oJustificacion.horaInicio = txtHoradesde.Value;
                oJustificacion.horaFin = txtHoraHasta.Value;
                oJustificacion.observaciones = taObs.Value;

                servicio.ActualizarJustificacion(oJustificacion);
                Response.Redirect("~/Forms/frmControlAsistencia.aspx?Id=" + Request.QueryString["Id"]);
            }
            catch (Exception ex)
            {
                FailureText.Text = "Se presento un problema al procesar la información.";
                ErrorMessage.Visible = true;
            }
        }
    }
}