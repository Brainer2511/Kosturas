using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmProgProyecto : System.Web.UI.Page
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

            //se valida el postback
            if (!IsPostBack)
            {
                //se cargan los datos en el ddl de departamento la primera vez que se carga la página
                cargarProyectos();
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
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
            var codCatalogo = 4;//Catalogo de Proyectos
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

        /// <summary>
        /// método de acción del boton listar que se encarga de iniciar el proceso de consulta de datos
        /// según los filtros especificados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            cargarListado();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;

            var proyecto = 0;

            if (!ddlProyecto.SelectedValue.Equals("0"))
            {
                proyecto = Int16.Parse(ddlProyecto.SelectedValue);
            }
            DataTable datos = servicio.BuscarPersona(0, 0, proyecto, string.Empty);

            if (datos.Rows.Count > 0)
            {
                //con la respuesta obtenida se carga el gridview
                gvListado.DataSource = datos;
                gvListado.DataBind();
            }
        }

        protected void gvListado_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Se indica que el componente entra en modo de edicion indicando el indice de la fila seleccionada
            gvListado.EditIndex = e.NewEditIndex;
            //Complementariamente, se recargan los datos del componente para que al momento de entrar en modo de edicion se visualicen los datos de la fila seleccionada
            //cargarListado();
            gvListado.DataSource = Session["listado"];
            //Se enlaza con el origen de datos inidicado anteriormente el cual se almaceno en una variable de sesion.
            gvListado.DataBind();

            gvListado.Rows[e.NewEditIndex].Cells[1].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[2].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[3].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[4].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[7].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[8].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[9].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[10].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[11].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[12].Enabled = false;
            gvListado.Rows[e.NewEditIndex].Cells[13].Enabled = false;
        }

        protected void gvListado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Manejo de errores
            try
            {
                //Asignar los valores proporcionados por el usuario a los parametros
                //Los valores se encontraran almacenados en la variable e que controla el evento de edicion, recordar que los elementos se enumeran desde 0 a n -1
                var idProg = e.NewValues[6].ToString();
                //var idPersona = e.NewValues[1].ToString();
                var justificacion = e.NewValues[4].ToString();
                var comentario = e.NewValues[5].ToString();

                servicio.JustificarProgramacion(Int32.Parse(idProg), justificacion, comentario);

                //Se cancela el modo de edición
                gvListado.EditIndex = -1;

                //Se recarla la tabla con la funcion creada para llenarla
                //cargarListado();

                //cargarListado();
                cargarListado(); // gvListado.DataSource = Session["listado"];
                //Se enlaza con el origen de datos inidicado anteriormente el cual se almaceno en una variable de sesion.
                //gvListado.DataBind();

            }
            catch (Exception ex)
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "Se presento un problema al actualizar la información";
                ErrorMessage.Visible = true;
            }
        }

        protected void gvListado_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Se cancela el modo de edición
            gvListado.EditIndex = -1;
            //Se vuelve a cargar la data
            //cargarListado();

            //cargarListado();
            gvListado.DataSource = Session["listado"];
            //Se enlaza con el origen de datos inidicado anteriormente el cual se almaceno en una variable de sesion.
            gvListado.DataBind();
        }

        protected void cargarListado()
        {
            //se limpian los mensajes de error
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;
            //se limpian los gridview
            gvListado.DataSource = null;
            gvListado.DataBind();

            var proyecto = 0;
            var diaSemana = "SELECCIONE";

            try
            {
                if (!ddlProyecto.SelectedValue.Equals("0"))
                {
                    proyecto = Int16.Parse(ddlProyecto.SelectedValue);
                }
                if (!ddlDias.SelectedValue.ToString().ToUpper().Equals("SELECCIONE"))
                {
                    diaSemana = ddlDias.SelectedValue;
                }

                //variable para determinar su al menos hay un valor de busqueda
                var valido = true;

                if (proyecto == 0 || dtFecDesde.Value.Equals(string.Empty) || dtFecHasta.Value.Equals(string.Empty))
                {
                    valido = false;
                }
                if (valido)
                {
                    var fechaDesde = Convert.ToDateTime(dtFecDesde.Value);
                    var fechaHasta = Convert.ToDateTime(dtFecHasta.Value);
                    var desde = Convert.ToDateTime(dtFecDesde.Value).ToString("dd-MM-yyyy");
                    var hasta = Convert.ToDateTime(dtFecHasta.Value).ToString("dd-MM-yyyy");
                    var dias = fechaHasta - fechaDesde;
                    var aura = new DataTable();
                    var elite = new DataTable();
                    DataTable tablaGeneral = new DataTable();

                    DataTable datos = servicio.BuscarPersona(0, 0, proyecto, string.Empty);

                    if (datos.Rows.Count > 0)
                    {
                        //DataTable tablaGeneral = new DataTable();
                        tablaGeneral.Columns.Add("Nombre");
                        tablaGeneral.Columns.Add("P.Día");
                        tablaGeneral.Columns.Add("P.Ent");
                        tablaGeneral.Columns.Add("P.Sal");
                        tablaGeneral.Columns.Add("Justificación");
                        tablaGeneral.Columns.Add("Comentario");
                        tablaGeneral.Columns.Add("id");
                        tablaGeneral.Columns.Add("M.Día");
                        tablaGeneral.Columns.Add("M.Ent");
                        tablaGeneral.Columns.Add("M.Sal");
                        tablaGeneral.Columns.Add("C.Día");
                        tablaGeneral.Columns.Add("C.Ent");
                        tablaGeneral.Columns.Add("C.Sal");

                        for (int i = 0; i < datos.Rows.Count; i++)
                        {
                            var id = datos.Rows[i][0].ToString();
                            var idPersona = Int32.Parse(id);
                            var horasProg = string.Empty;
                            //DataRow fila = tablaGeneral.NewRow();
                            //fila["nombre"] = datos.Rows[i][1].ToString();
                            var nombre = datos.Rows[i][1].ToString();

                            //se obtiene el horario asignado
                            DataTable Progra = servicio.ObtenerProgramacion(desde, hasta, idPersona);
                            //se obtienen las marcas realizadas (Zapote)
                            DataTable Marcas = servicio.ObtenerMarcasZPT(desde, hasta, idPersona);
                            //se obtienen las marcas realizadas (San Pedro)
                            DataTable MarcaSP = servicio.ObtenerMarcasSP(desde, hasta, idPersona);
                            //Se crea una instancia del objeto persona
                            var oPersona = new Persona { idPersona = idPersona };
                            //Obtención de extensiones de cada agente
                            var extensiones = servicio.obtenerExtensiones(oPersona);
                            //se valida si se recuperaron datos
                            if (extensiones.Rows.Count > 0)
                            {
                                //se crea una lista con las extensiones obtenidas
                                var listaExt = string.Empty;
                                var contador = 0;
                                for (int y = 0; y < extensiones.Rows.Count; y++)
                                {
                                    if (contador == 0)
                                        listaExt = listaExt + extensiones.Rows[y].ItemArray[0];
                                    else
                                        listaExt = listaExt + "," + extensiones.Rows[y].ItemArray[0];

                                    contador++;
                                }
                                //se obtiene la informacion de LiLo del CMS Aura
                                aura = servicio.ObtenerCMSAACC(dtFecDesde.Value, dtFecHasta.Value, listaExt);
                                //se obtiene la informacion de LiLo del CMS Elite
                                elite = servicio.ObtenerCMSElite(dtFecDesde.Value, dtFecHasta.Value, listaExt);
                            }
                            //se recorren los diferentes DataTable obtenidos para conformar un unico dataTable con toda la información

                            for (int x = 0; x < dias.Days; x++)
                            {
                                //Se crea una nueva fila para la tabla general
                                DataRow filaGen = tablaGeneral.NewRow();

                                //Programacion de horario
                                if (Progra.Rows.Count > 0)
                                {
                                    if (x < Progra.Rows.Count)
                                    {
                                        filaGen["Nombre"] = nombre;
                                        filaGen["P.Día"] = Progra.Rows[x][1].ToString();
                                        filaGen["P.Ent"] = Progra.Rows[x][3].ToString();
                                        filaGen["P.Sal"] = Progra.Rows[x][4].ToString();
                                        filaGen["Justificación"] = Progra.Rows[x][5].ToString();
                                        filaGen["Comentario"] = Progra.Rows[x][6].ToString();
                                        filaGen["id"] = Progra.Rows[x][7].ToString();
                                    }
                                }

                                //MarcasZapote
                                if (Marcas.Rows.Count > 0)
                                {
                                    if (x < Marcas.Rows.Count)
                                    {
                                        filaGen["M.Día"] = Marcas.Rows[x][1].ToString();
                                        filaGen["M.Ent"] = Marcas.Rows[x][3].ToString();
                                        filaGen["M.Sal"] = Marcas.Rows[x][4].ToString();
                                    }
                                }
                                //MarcasSanPedro
                                else if (MarcaSP.Rows.Count > 0)
                                {
                                    if (x < MarcaSP.Rows.Count)
                                    {
                                        filaGen["M.Día"] = MarcaSP.Rows[x][1].ToString();
                                        filaGen["M.Ent"] = MarcaSP.Rows[x][3].ToString();
                                        filaGen["M.Sal"] = MarcaSP.Rows[x][4].ToString();
                                    }
                                }

                                //CMS Aura
                                if (aura.Rows.Count > 0)
                                {
                                    if (x < aura.Rows.Count)
                                    {
                                        filaGen["C.Día"] = aura.Rows[x][6].ToString();
                                        filaGen["C.Ent"] = aura.Rows[x][4].ToString();
                                        filaGen["C.Sal"] = aura.Rows[x][5].ToString();
                                    }
                                }
                                //CMS Elite
                                else if (elite.Rows.Count > 0)
                                {
                                    if (x < elite.Rows.Count)
                                    {
                                        filaGen["C.Día"] = elite.Rows[x][4].ToString();
                                        filaGen["C.Ent"] = elite.Rows[x][2].ToString();
                                        filaGen["C.Sal"] = elite.Rows[x][3].ToString();
                                    }

                                }

                                tablaGeneral.Rows.Add(filaGen);
                            }
                        }

                        if (!diaSemana.ToUpper().Equals("SELECCIONE"))
                        {
                            DataTable tablaPorDia = new DataTable();

                            //DataTable tablaGeneral = new DataTable();
                            tablaPorDia.Columns.Add("Nombre");
                            tablaPorDia.Columns.Add("P.Día");
                            tablaPorDia.Columns.Add("P.Ent");
                            tablaPorDia.Columns.Add("P.Sal");
                            tablaPorDia.Columns.Add("M.Día");
                            tablaPorDia.Columns.Add("M.Ent");
                            tablaPorDia.Columns.Add("M.Sal");
                            tablaPorDia.Columns.Add("C.Día");
                            tablaPorDia.Columns.Add("C.Ent");
                            tablaPorDia.Columns.Add("C.Sal");

                            for (int a = 0; a < tablaGeneral.Rows.Count; a++)
                            {
                                if (tablaGeneral.Rows[a][1].ToString().ToUpper().Equals(diaSemana.ToUpper()))
                                {
                                    //Se crea una nueva fila para la tabla general
                                    DataRow filaPorDia = tablaPorDia.NewRow();
                                    filaPorDia["Nombre"] = tablaGeneral.Rows[a][0].ToString();
                                    filaPorDia["P.Día"] = tablaGeneral.Rows[a][1].ToString();
                                    filaPorDia["P.Ent"] = tablaGeneral.Rows[a][2].ToString();
                                    filaPorDia["P.Sal"] = tablaGeneral.Rows[a][3].ToString();
                                    filaPorDia["M.Día"] = tablaGeneral.Rows[a][4].ToString();
                                    filaPorDia["M.Ent"] = tablaGeneral.Rows[a][5].ToString();
                                    filaPorDia["M.Sal"] = tablaGeneral.Rows[a][6].ToString();
                                    filaPorDia["C.Día"] = tablaGeneral.Rows[a][7].ToString();
                                    filaPorDia["C.Ent"] = tablaGeneral.Rows[a][8].ToString();
                                    filaPorDia["C.Sal"] = tablaGeneral.Rows[a][9].ToString();

                                    tablaPorDia.Rows.Add(filaPorDia);

                                }
                            }
                            Session["listado"] = tablaPorDia;
                            gvListado.DataSource = tablaPorDia;
                            gvListado.DataBind();
                        }
                        else
                        {
                            Session["listado"] = tablaGeneral;
                            gvListado.DataSource = tablaGeneral;
                            gvListado.DataBind();
                        }
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
                else
                {
                    //En caso de que la consulta no recupere datos se informa del problema.
                    FailureText.Text = "Debe establecer al menos un elemento para la busqueda. El rancho de fechas es obligatorio.";
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
    }
}