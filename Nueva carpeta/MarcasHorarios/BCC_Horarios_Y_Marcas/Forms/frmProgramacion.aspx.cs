using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmProgramacion : System.Web.UI.Page
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
            //servicio = new Catalogos_BLL();
            //servicio = new Personal_BLL();

            //se valida el postback
            if (!IsPostBack)
            {
                //se cargan los datos en el ddl de departamento la primera vez que se carga la página
                cargarDepartamento();
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
        /// Método que carga el dorp down de Departamento
        /// </summary>
        public void cargarDepartamento()
        {
            var bll = new Planilla_WCF();
            var codCatalogo = 1;//Catalogo de Departamento
            DataTable datos = bll.ConsultarItemsCatalogo(codCatalogo);

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
        /// Método que carga el dorp down de Proyecto
        /// </summary>
        public void cargarProyectos()
        {
            var bll = new Planilla_WCF();
            var codCatalogo = 4;//Catalogo de Proyectos
            DataTable datos = bll.ConsultarItemsCatalogo(codCatalogo);

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
        /// Método que Carga el dorp down de Sección que depende de lo seleccionado en el ddl de departamento
        /// </summary>
        /// <param name="codigoDepartamento"></param>
        public void cargarSeccion(int codigoDepartamento)
        {
            var bll = new Planilla_WCF();
            ddlSeccion.Items.Clear();
            var codCatalogo = 2;//Catalogo de Sección
            var codItem = codigoDepartamento; //Convert.ToInt32(ddlDepartamento.SelectedValue);
            DataTable datos = bll.ConsultarItemsCatalogo(codCatalogo, codItem);

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
            var bll = new Planilla_WCF();
            //se limpian los mensajes de error
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;
            //se limpian los gridview
            gvListado.DataSource = null;
            gvListado.DataBind();
            //se limpian los gridview
            gvProgramacion.DataSource = null;
            gvProgramacion.DataBind();
            //se limpian los gridview
            gvAACC.DataSource = null;
            gvAACC.DataBind();
            //se limpian los gridview
            gvTotales.DataSource = null;
            gvTotales.DataBind();
            //se limpian los gridview
            gvMarcasSP.DataSource = null;
            gvMarcasSP.DataBind();
            //se limpian los gridview
            gvMarcasZPT.DataSource = null;
            gvMarcasZPT.DataBind();

            var codigoDpto = 0;
            var codigoSeccion = 0;
            var proyecto = 0;
            var diaSemana = "SELECCIONE";

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
                if (!ddlProyecto.SelectedValue.Equals("0"))
                {
                    proyecto = Int16.Parse(ddlProyecto.SelectedValue);
                }
                if (!ddlDias.SelectedValue.Equals("SELECCIONE"))
                {
                    diaSemana = ddlDias.SelectedValue;
                }

                var nombre = txtNombre.Text;

                //variable para determinar su al menos hay un valor de busqueda
                var valido = true;

                if (codigoDpto == 0 && codigoSeccion == 0 && nombre.Equals(string.Empty) && proyecto == 0)
                {
                    valido = false;
                }
                if (valido)
                {
                    var fechaDesde = Convert.ToDateTime(dtFecDesde.Value);
                    var fechaHasta = Convert.ToDateTime(dtFecHasta.Value);
                    //var desde = Convert.ToDateTime(dtFecDesde.Value).ToString("dd-MM-yyyy");
                    //var hasta = Convert.ToDateTime(dtFecHasta.Value).ToString("dd-MM-yyyy");

                    var desde = Convert.ToDateTime(dtFecDesde.Value).ToString("yyyy-MM-dd");
                    var hasta = Convert.ToDateTime(dtFecHasta.Value).ToString("yyyy-MM-dd");

                    DataTable datos = bll.BuscarPersona(codigoDpto, codigoSeccion, proyecto, nombre);

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
                else
                {
                    //En caso de que la consulta no recupere datos se informa del problema.
                    FailureText.Text = "Debe establecer al menos un elemento para la busqueda.";
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

        protected void consultarAgenteSeleccionado(int id, string extensiones)
        {
            var bll = new Planilla_WCF();
            //se limpian los gridview
            gvListado.DataSource = null;
            gvListado.DataBind();
            //se limpian los gridview
            gvProgramacion.DataSource = null;
            gvProgramacion.DataBind();
            //se limpian los gridview
            gvAACC.DataSource = null;
            gvAACC.DataBind();
            //se limpian los gridview
            gvTotales.DataSource = null;
            gvTotales.DataBind();
            //se limpian los gridview
            gvMarcasSP.DataSource = null;
            gvMarcasSP.DataBind();
            //se limpian los gridview
            gvMarcasZPT.DataSource = null;
            gvMarcasZPT.DataBind();

            var fechaDesde = Convert.ToDateTime(dtFecDesde.Value);
            var fechaHasta = Convert.ToDateTime(dtFecHasta.Value);
            //var desde = Convert.ToDateTime(dtFecDesde.Value).ToString("dd-MM-yyyy");
            //var hasta = Convert.ToDateTime(dtFecHasta.Value).ToString("dd-MM-yyyy");

            var desde = Convert.ToDateTime(dtFecDesde.Value).ToString("yyyy-MM-dd");
            var hasta = Convert.ToDateTime(dtFecHasta.Value).ToString("yyyy-MM-dd");

            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Nombre");
            table.Columns.Add("Departamento");
            table.Columns.Add("Sección");
            table.Columns.Add("Marca SP");
            table.Columns.Add("Marca ZPT");
            table.Columns.Add("Estado");

            Persona oPersona = bll.ConsultarPersona(id);

            DataRow fila = table.NewRow();
            //Se cargan los datos en la fila
            fila["Id"] = oPersona.idPersona;
            fila["Nombre"] = oPersona.nombre;
            fila["Departamento"] = oPersona.DesDpto;
            fila["Sección"] = oPersona.DesSeccion;
            fila["Marca SP"] = oPersona.idMarcaSanPedro;
            fila["Marca ZPT"] = oPersona.idMarcaZapote;
            if (Convert.ToBoolean(oPersona.estado) == true)
                fila["Estado"] = "Activo";
            else
                fila["Estado"] = "Inactivo";
            //Se agrega la fila a la tabla
            table.Rows.Add(fila);

            if (table.Rows.Count > 0)
            {
                //con la respuesta obtenida se carga el gridview
                gvListado.DataSource = table;
                gvListado.DataBind();
            }

            var bll_Planillas = new Planilla_WCF();
            var horasProg = string.Empty;
            DataTable Progra = bll_Planillas.ConsultaDatosProgramacion(desde, hasta, oPersona.nombre, ref horasProg);
            if (Progra.Rows.Count > 0)
            {
                //con la respuesta obtenida se carga el gridview
                gvProgramacion.DataSource = Progra;
                gvProgramacion.DataBind();
            }
            else
            {
                var dias = fechaHasta - fechaDesde;
                for (int i = 0; i < dias.Days + 1; i++)
                {
                    Progra.Rows.Add(Progra.NewRow());
                    gvProgramacion.DataSource = Progra;
                    gvProgramacion.DataBind();
                }
            }

            var horasMarcZ = string.Empty;
            DataTable MarcaZPT = bll_Planillas.ConsultaMarcasZPT(desde, hasta, oPersona.nombre, ref horasMarcZ);
            if (MarcaZPT.Rows.Count > 0)
            {
                //con la respuesta obtenida se carga el gridview
                gvMarcasZPT.DataSource = MarcaZPT;
                gvMarcasZPT.DataBind();
            }
            else
            {
                var dias = fechaHasta - fechaDesde;
                for (int i = 0; i < dias.Days + 1; i++)
                {
                    MarcaZPT.Rows.Add(MarcaZPT.NewRow());
                    gvMarcasZPT.DataSource = MarcaZPT;
                    gvMarcasZPT.DataBind();
                }
            }

            var horasMarcS = string.Empty;
            DataTable MarcaSP = bll_Planillas.ConsultaMarcasSP(desde, hasta, oPersona.nombre, ref horasMarcS);
            if (MarcaSP.Rows.Count > 0)
            {
                //con la respuesta obtenida se carga el gridview
                gvMarcasSP.DataSource = MarcaSP;
                gvMarcasSP.DataBind();
            }
            else
            {
                var dias = fechaHasta - fechaDesde;
                for (int i = 0; i < dias.Days + 1; i++)
                {
                    MarcaSP.Rows.Add(MarcaSP.NewRow());
                    gvMarcasSP.DataSource = MarcaSP;
                    gvMarcasSP.DataBind();
                }
            }

            var horasCMS = string.Empty;
            //ConsultasDatosCMS(extensiones, ref horasCMS);
            ConsultasDatosCMS(oPersona, ref horasCMS);

            DataTable tableTotales = new DataTable();
            tableTotales.Columns.Add("H. Programadas");
            tableTotales.Columns.Add("Horas Marcas");
            tableTotales.Columns.Add("Horas CMS");

            DataRow filaTotales = tableTotales.NewRow();
            //Se cargan los datos en la fila
            filaTotales["H. Programadas"] = horasProg;

            if (horasMarcS.Equals(string.Empty))
                filaTotales["Horas Marcas"] = horasMarcZ;
            else
                filaTotales["Horas Marcas"] = horasMarcS;
            filaTotales["Horas CMS"] = horasCMS;

            tableTotales.Rows.Add(filaTotales);

            gvTotales.DataSource = tableTotales;
            gvTotales.DataBind();
        }

        /// <summary>
        /// Método que se encarga de habilitar la edición del item seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var bll = new Planilla_WCF();
                GridViewRow row = gvListado.SelectedRow;
                int id = Convert.ToInt32(gvListado.DataKeys[row.RowIndex].Value);
                var oPersona = new Persona
                {
                    idPersona = id
                };
                var extensiones = bll.obtenerExtensiones(oPersona);

                if (extensiones.Rows.Count > 0)
                {
                    var listaExt = string.Empty;
                    var contador = 0;
                    for (int i = 0; i < extensiones.Rows.Count; i++)
                    {
                        if (contador == 0)
                            listaExt = listaExt + extensiones.Rows[i].ItemArray[0];
                        else
                            listaExt = listaExt + "," + extensiones.Rows[i].ItemArray[0];

                        contador++;
                    }

                    consultarAgenteSeleccionado(id, listaExt);
                }
            }
            catch (Exception ex)
            {
                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "Se presento al procesar la información.";
                ErrorMessage.Visible = true;
            }

        }

        protected void gvProgramacion_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Programación";
                HeaderCell.Font.Bold = true;
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);
                gvProgramacion.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
        }

        protected void gvMarcasZPT_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Marcas Zapote";
                HeaderCell.Font.Bold = true;
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);
                gvMarcasZPT.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
        }

        protected void gvMarcasSP_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Marcas San Pedro";
                HeaderCell.Font.Bold = true;
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);
                gvMarcasSP.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
        }

        protected void gvAACC_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "CMS";
                HeaderCell.Font.Bold = true;
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);
                gvAACC.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;

            var codigoDpto = 0;
            var codigoSeccion = 0;
            var proyecto = 0;
            if (!ddlDepartamento.SelectedValue.Equals("0"))
            {
                codigoDpto = Int16.Parse(ddlDepartamento.SelectedValue);
            }
            if (!ddlSeccion.SelectedValue.Equals("0") && !ddlSeccion.SelectedValue.Equals(string.Empty))
            {
                codigoSeccion = Int16.Parse(ddlSeccion.SelectedValue);
            }
            if (!ddlProyecto.SelectedValue.Equals("0"))
            {
                proyecto = Int16.Parse(ddlProyecto.SelectedValue);
            }
            var nombre = txtNombre.Text;
            var bll = new Planilla_WCF();
            DataTable datos = bll.BuscarPersona(codigoDpto, codigoSeccion, proyecto, nombre);

            if (datos.Rows.Count > 0)
            {
                //con la respuesta obtenida se carga el gridview
                gvListado.DataSource = datos;
                gvListado.DataBind();
                //btnExportar.Visible = true;
            }
        }

        protected void ConsultasDatosCMS_Original(string extensiones, ref string horasCMS)
        {
            var desde = Convert.ToDateTime(dtFecDesde.Value).ToString("dd-MM-yyyy");
            var hasta = Convert.ToDateTime(dtFecHasta.Value).ToString("dd-MM-yyyy");
            var fechaDesde = Convert.ToDateTime(dtFecDesde.Value);
            var fechaHasta = Convert.ToDateTime(dtFecHasta.Value);
            var gridCargado = false;

            var horasCMSA = string.Empty;
            var bll = new Planilla_WCF();
            var aura = bll.ConsultaCMSAACC(dtFecDesde.Value, dtFecHasta.Value, extensiones, ref horasCMSA);

            if (aura.Rows.Count > 0)
            {
                //con la respuesta obtenida se carga el gridview
                gvAACC.DataSource = aura;
                gvAACC.DataBind();
                gridCargado = true;
                //btnExportar.Visible = true;
                horasCMS = horasCMSA;
            }
            else
            {
                var dias = fechaHasta - fechaDesde;
                for (int i = 0; i < dias.Days + 1; i++)
                {
                    aura.Rows.Add(aura.NewRow());
                    gvAACC.DataSource = aura;
                    gvAACC.DataBind();
                    //gvAACC.Rows[0].Visible = false;
                }
            }
            if (!gridCargado)
            {
                var horasCMSE = string.Empty;
                var elite = bll.ConsultaCMSElite(dtFecDesde.Value, dtFecHasta.Value, extensiones, ref horasCMSE);

                if (elite.Rows.Count > 0)
                {
                    //con la respuesta obtenida se carga el gridview
                    //gvElite.DataSource = elite;
                    //gvElite.DataBind();
                    //btnExportar.Visible = true;

                    gvAACC.DataSource = elite;
                    gvAACC.DataBind();
                    horasCMS = horasCMSE;
                }
                else
                {
                    var dias = fechaHasta - fechaDesde;
                    for (int i = 0; i < dias.Days + 1; i++)
                    {
                        elite.Rows.Add(elite.NewRow());
                        gvAACC.DataSource = elite;
                        gvAACC.DataBind();
                        //gvElite.Rows[0].Visible = false;
                    }
                    horasCMS = horasCMSE;
                }
            }
        }

        protected void ConsultasDatosCMS(Persona persona, ref string horasCMS)
        {
            var fechaDesde = Convert.ToDateTime(dtFecDesde.Value);
            var fechaHasta = Convert.ToDateTime(dtFecHasta.Value);

            var horasCMSE = string.Empty;
            var bll = new Planilla_WCF();
            //var elite = servicio.ConsultaCMSElite(dtFecDesde.Value, dtFecHasta.Value, extensiones, ref horasCMSE);
            var elite = bll.ConsultaLogueosEliteXId(dtFecDesde.Value, dtFecHasta.Value, persona.idPersona, ref horasCMSE);

            if (elite.Rows.Count > 0)
            {
                gvAACC.DataSource = elite;
                gvAACC.DataBind();
                horasCMS = horasCMSE;
            }
            else
            {
                var dias = fechaHasta - fechaDesde;
                for (int i = 0; i < dias.Days + 1; i++)
                {
                    elite.Rows.Add(elite.NewRow());
                    gvAACC.DataSource = elite;
                    gvAACC.DataBind();
                }
                horasCMS = horasCMSE;
            }
        }

    }
}