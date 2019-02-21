using ClosedXML.Excel;
using System;
using System.Web.UI.WebControls;
using zExcelWrapper.net;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmCargaDatos : System.Web.UI.Page
    {
        public Planilla_WCF servicio;
        //public Personal_BLL servicio;
        //public Catalogos_BLL servicio;

        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = new Planilla_WCF();
            //servicio = new Catalogos_BLL();
            //servicio = new Personal_BLL();

            if (!IsPostBack)
            {
                cargarUbicaciones();
            }
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;

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

                ddlTipoDatos.SelectedIndex = 2;
                ddlTipoDatos.Enabled = false;

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
        }

        /// <summary>
        /// Método que se encarga de cargar los datos del drop down de ubicaciones
        /// </summary>
        public void cargarUbicaciones()
        {
            var idCatalogo = 3;
            var datos = servicio.ConsultarItemsCatalogo(idCatalogo);

            //Se valida si se obtuvieron datos
            if (datos.Rows.Count > 0)
            {
                //Se crea un item inicial que sera la opcion TODOS en el dropdown
                ListItem oItemTodos = new ListItem();
                oItemTodos.Text = "SELECCIONE";
                oItemTodos.Value = "0";
                ddlUbicaciones.Items.Add(oItemTodos);
                //se iteran las filas obtenidas de la consulta a BD para agregar los valores al dropdown
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    //Se crea un nuevo item por cada fila recupera de BD
                    ListItem oItem = new ListItem();
                    //Se setea el texto y el valor para cada item
                    oItem.Text = (datos.Rows[i]).ItemArray[1].ToString();
                    oItem.Value = (datos.Rows[i]).ItemArray[0].ToString();
                    //se agrega el item recien creado al drop down
                    ddlUbicaciones.Items.Add(oItem);
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
        /// Método que le acción al botón Cargar para iniciar el proceso de carga de datos a la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            FailureText.Text = String.Empty;
            ErrorMessage.Visible = false;
            //variable para manipulación del archivo del cual se obtendran los datos a cargar
            string FN = "";
            try
            {
                var tipoDato = Int16.Parse(ddlTipoDatos.SelectedValue);
                switch (tipoDato)
                {
                    case 0:
                        FailureText.Text = "Debe especificar el tipo de datos a cargar.";
                        ErrorMessage.Visible = true;
                        gifProcesando.Visible = false;
                        break;
                    case 1:
                        //se valida si se selecciono algún valor de ubicación
                        if (ddlUbicaciones.SelectedValue == "" || ddlUbicaciones.SelectedValue.Equals("0"))
                        {
                            //se muestra el mensaje de error
                            FailureText.Text = "Debe especificar a que site corresponden los datos.";
                            ErrorMessage.Visible = true;
                            //Se habilita el botón
                            btnCargar.Enabled = true;
                            btnCargar.Visible = true;
                            gifProcesando.Visible = false;
                        }
                        else
                        {
                            if (fileUpload.HasFile)
                            {
                                lblProcesando.Visible = true;
                                var ubicacion = Convert.ToInt32(ddlUbicaciones.SelectedValue);
                                hfArchivoCarga.Value = MapPath("~/uploaded/ArchivoDeCarga-" + DateTime.Now.ToString("yyMMdd-hhmmss") + ".xlsx");
                                fileUpload.SaveAs(hfArchivoCarga.Value);
                                gifProcesando.Visible = true;
                                fileUpload.Dispose();
                                CargarDatos(ubicacion);
                                lblProcesando.Visible = false;
                                lblFinProceso.Visible = true;
                                //Se habilita el botón
                                btnCargar.Enabled = true;
                                gifProcesando.Visible = false;
                            }
                            else
                            {
                                //se muestra el mensaje de error
                                FailureText.Text = "Debe especificar un archivo con los datos a cargar.";
                                ErrorMessage.Visible = true;
                            }
                        }

                        break;
                    case 2:
                        if (fileUpload.HasFile)
                        {
                            lblProcesando.Visible = true;
                            var ubicacion = Convert.ToInt32(ddlUbicaciones.SelectedValue);
                            hfArchivoCarga.Value = MapPath("~/uploaded/ArchivoDeCarga-" + DateTime.Now.ToString("yyMMdd-hhmmss") + ".xlsx");
                            fileUpload.SaveAs(hfArchivoCarga.Value);
                            gifProcesando.Visible = true;
                            fileUpload.Dispose();
                            CargarHorarios();
                            lblProcesando.Visible = false;
                            lblFinProceso.Visible = true;
                            //Se habilita el botón
                            btnCargar.Enabled = true;
                            gifProcesando.Visible = false;
                        }
                        else
                        {
                            //se muestra el mensaje de error
                            FailureText.Text = "Debe especificar un archivo con los datos a cargar.";
                            ErrorMessage.Visible = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                //se muestra el mensaje de error
                FailureText.Text = "Se presento un error al conectar con la base de datos.";
                ErrorMessage.Visible = true;
                btnCargar.Enabled = true;
                btnCargar.Visible = true;
                gifProcesando.Visible = false;
            }
        }

        /// <summary>
        /// Método que inicia el proceso de carga de datos
        /// </summary>
        private void CargarDatos(int ubicacion)
        {
            try
            {
                //System.Threading.Thread.Sleep(3000);
                ProcesarXLS(hfArchivoCarga.Value, ubicacion);
            }
            catch (Exception ex)
            {
                //se muestra el mensaje de error
                FailureText.Text = "Se presento un error al procesar el archivo indicado.";
                ErrorMessage.Visible = true;
            }
        }

        /// <summary>
        /// Método que inicia el proceso de carga de datos
        /// </summary>
        private void CargarHorarios()
        {
            try
            {
                //System.Threading.Thread.Sleep(3000);
                ProcesarXLS(hfArchivoCarga.Value);
            }
            catch (Exception ex)
            {
                //se muestra el mensaje de error
                FailureText.Text = "Se presento un error al procesar el archivo indicado.";
                ErrorMessage.Visible = true;
            }
        }

        /// <summary>
        /// Método que se encarga de procesar el excel con los datos de carga de MArcas
        /// </summary>
        /// <param name="FN">Documento excel con los datos de la carga (seleccionado en el file upload)</param>
        /// <param name="ubicacion">Determina a que site corresponden las marcas a cargar</param>
        private void ProcesarXLS_OriginalMarcas(string FN, int ubicacion)
        {
            zExcelWrapper.net.document App;

            //string numeroActual = string.Empty;
            //string numeroSiguiente = string.Empty;

            try
            {
                //se abre el documento
                App = document.open(FN);

                //se recorre cada fila omitiendo los encabezados
                for (uint Fila = 2; Fila < 200000; Fila++)
                {
                    try
                    {
                        //variable que almacena el id de Marca que se recorre actualmente
                        var idMarca = string.Empty;
                        try
                        {
                            //se lee el id de marca de la fila en curso que se encuentra en la columna 1
                            idMarca = App.getValue(1, Fila);
                        }
                        catch
                        {
                            //En caso de error o de no haber datos idMArca se establece en blanco
                            idMarca = "";
                        }
                        //Se valida si el id de Marca esta blanco para determinar el final del recorrido por las filas del documento
                        if (idMarca.Trim() == "")
                        {
                            //TODO: Mensaje de finalización
                            break;
                        }

                        var filaSig = Fila + 1;

                        //se obtienen las 4 posibles marcas realizadas para 
                        //determinar una de entrada y una de fin
                        var marca1 = LeerCelda(App, 4, Fila).Trim();
                        var marca2 = LeerCelda(App, 5, Fila).Trim();
                        var marca3 = LeerCelda(App, 6, Fila).Trim();
                        var marca4 = LeerCelda(App, 7, Fila).Trim();
                        //se procesan las marcas
                        var horaEntradaSalida = procesarHorasMarcas(marca1, marca2, marca3, marca4);

                        //Se obtienen los valores de las diferentes columnas de la fila actual
                        var objMarcas = new Marca();
                        objMarcas.idMarca = Convert.ToInt32(idMarca);
                        objMarcas.fecha = FormatearFecha(LeerCelda(App, 3, Fila));
                        objMarcas.horaEntrada = horaEntradaSalida[0];
                        objMarcas.horaSalida = horaEntradaSalida[1];
                        objMarcas.ubicacion = ubicacion;

                        var id = Convert.ToInt32(((BCC_Horarios_Y_Marcas.Usuario)Session["DatosUsuario"]).idUsuario);
                        var oPersona = new Persona
                        {
                            idPersona = id
                        };

                        //Se registran los datos en la Base de Datos
                        servicio.cargarDatos(objMarcas, oPersona);
                    }
                    catch (Exception Ex)
                    {
                        //EscribirLB("-----Cliente: " + adm.ClienteActual.Telefono1 + " -> Error : " + Ex.Message);
                    }
                }
                //EscribirLB("Fin del Archivo");
                App.close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Se presento un error al procesar la información del archivo a cargar.");
            }
        }
        private void ProcesarXLS(string FN, int ubicacion)
        {
            try
            {
                for (int Fila = 2; Fila < 200000; Fila++)
                {
                    //variable que almacena el id de Marca que se recorre actualmente
                    var idMarca = string.Empty;

                    string fileName = FN;
                    var workbook = new XLWorkbook(fileName);
                    var ws1 = workbook.Worksheet(1);

                    var row = ws1.Row(Fila);
                    bool empty = row.IsEmpty();
                    if (!empty)
                    {
                        idMarca = row.Cell(1).Value.ToString();

                        //determinar una de entrada y una de fin
                        var marca1 = row.Cell(4).Value.ToString().Trim();
                        var marca2 = row.Cell(5).Value.ToString().Trim();
                        var marca3 = row.Cell(6).Value.ToString().Trim();
                        var marca4 = row.Cell(7).Value.ToString().Trim();
                        //se procesan las marcas
                        var horaEntradaSalida = procesarHorasMarcas(marca1, marca2, marca3, marca4);

                        //Se obtienen los valores de las diferentes columnas de la fila actual
                        var objMarcas = new Marca();
                        objMarcas.idMarca = Convert.ToInt32(idMarca);
                        objMarcas.fecha = FormatearFecha(row.Cell(3).Value.ToString());
                        objMarcas.horaEntrada = horaEntradaSalida[0];
                        objMarcas.horaSalida = horaEntradaSalida[1];
                        objMarcas.ubicacion = ubicacion;

                        var id = Convert.ToInt32(((BCC_Horarios_Y_Marcas.Usuario)Session["DatosUsuario"]).idUsuario);
                        var oPersona = new Persona
                        {
                            idPersona = id
                        };

                        //Se registran los datos en la Base de Datos
                        servicio.cargarDatos(objMarcas, oPersona);
                    }



                    //Se valida si el id de Marca esta blanco para determinar el final del recorrido por las filas del documento
                    if (idMarca.Trim() == "")
                    {
                        //TODO: Mensaje de finalización
                        break;
                    }

                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Se presento un error al procesar la información del archivo a cargar.");
            }
        }

        /// <summary>
        /// Método que se encarga de procesar el excel con los datos de carga de horarios
        /// </summary>
        /// <param name="FN">Documento excel con los datos de la carga (seleccionado en el file upload)</param>
        //private void ProcesarXLS_Original(string FN)
        //{
        //    zExcelWrapper.net.document App;

        //    //string numeroActual = string.Empty;
        //    //string numeroSiguiente = string.Empty;

        //    try
        //    {
        //        //se abre el documento
        //        App = document.open(FN);

        //        //se recorre cada fila omitiendo los encabezados
        //        for (uint Fila = 2; Fila < 200000; Fila++)
        //        {
        //            try
        //            {
        //                //variable que almacena el id de Marca que se recorre actualmente
        //                var idPersona = string.Empty;
        //                try
        //                {
        //                    //se lee el id de marca de la fila en curso que se encuentra en la columna 1
        //                    idPersona = App.getValue(1, Fila);
        //                }
        //                catch
        //                {
        //                    //En caso de error o de no haber datos idMArca se establece en blanco
        //                    idPersona = "";
        //                }
        //                //Se valida si el id de Marca esta blanco para determinar el final del recorrido por las filas del documento
        //                if (idPersona.Trim() == "")
        //                {
        //                    //TODO: Mensaje de finalización
        //                    break;
        //                }

        //                //var filaSig = Fila + 1;

        //                //se obtienen los datos de las columnas especificas
        //                var id = LeerCelda(App, 1, Fila).Trim();

        //                //Se obtienen los valores de las diferentes columnas de la fila actual
        //                var objProgramacion = new Programacion();
        //                objProgramacion.idPersona = Convert.ToInt32(id);
        //                objProgramacion.nombre = LeerCelda(App, 2, Fila);
        //                objProgramacion.fecha = FormatearFecha(LeerCelda(App, 3, Fila));
        //                objProgramacion.horaEntrada = LeerCelda(App, 4, Fila);
        //                objProgramacion.horaSalida = LeerCelda(App, 5, Fila);

        //                var idPer = Convert.ToInt32(((BCC_Horarios_Y_Marcas.Usuario)Session["DatosUsuario"]).idUsuario);
        //                var oPersona = new Persona
        //                {
        //                    idPersona = idPer
        //                };

        //                //Se registran los datos en la Base de Datos
        //                servicio.cargarDatos(objProgramacion, oPersona);
        //            }
        //            catch (Exception Ex)
        //            {
        //                //EscribirLB("-----Cliente: " + adm.ClienteActual.Telefono1 + " -> Error : " + Ex.Message);
        //            }
        //        }
        //        //EscribirLB("Fin del Archivo");
        //        App.close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        throw new Exception("Se presento un error al procesar la información del archivo a cargar.");
        //    }
        //}

        private void ProcesarXLS(string FN)
        {
            try
            {
                string fileName = FN;
                var workbook = new XLWorkbook(fileName);
                var ws1 = workbook.Worksheet(1);

                var idPer = Convert.ToInt32(((BCC_Horarios_Y_Marcas.Usuario)Session["DatosUsuario"]).idUsuario);
                var oPersona = new Persona
                {
                    idPersona = idPer
                };

                //se recorre cada fila omitiendo los encabezados
                for (int Fila = 2; Fila < 200000; Fila++)
                {
                    var row = ws1.Row(Fila);
                    bool empty = row.IsEmpty();
                    if (!empty)
                    {
                        //var objProgramacion = new Programacion();
                        //var id = row.Cell(1).Value.ToString();
                        //objProgramacion.idPersona = Convert.ToInt32(id);
                        //var nombre = row.Cell(2).Value.ToString();
                        //objProgramacion.nombre = nombre;
                        //var fecha = row.Cell(3).Value.ToString();
                        //objProgramacion.fecha = FormatearFecha(fecha);
                        //var he = row.Cell(4).Value.ToString();
                        //objProgramacion.horaEntrada = he;
                        //var hs = row.Cell(5).Value.ToString();
                        //objProgramacion.horaSalida = hs;

                        //Datos de la persona
                        var objProgramacion = new Programacion();
                        var id = row.Cell(1).Value.ToString();
                        objProgramacion.idPersona = Convert.ToInt32(id);
                        var nombre = row.Cell(2).Value.ToString();
                        objProgramacion.nombre = nombre;

                        //Datos de la semana (fecha - horaEntrada - horaSalida)
                        for (int x = 3; x <= 23; x += 3)
                        {
                            var fecha = row.Cell(x).Value.ToString();
                            objProgramacion.fecha = FormatearFecha(fecha);
                            var he = row.Cell(x + 1).Value.ToString();
                            if (!he.Equals("Libre"))
                                objProgramacion.horaEntrada = he;
                            else
                                objProgramacion.horaEntrada = TimeSpan.Zero.ToString();
                            var hs = row.Cell(x + 2).Value.ToString();
                            if (!hs.Equals("Libre"))
                                objProgramacion.horaSalida = hs;
                            else
                                objProgramacion.horaSalida = TimeSpan.Zero.ToString();
                            if (!fecha.Equals(String.Empty))
                            {
                                //Se registran los datos en la Base de Datos
                                servicio.cargarDatos(objProgramacion, oPersona);
                            }
                        }

                        //var fecha = row.Cell(3).Value.ToString();
                        //objProgramacion.fecha = FormatearFecha(fecha);
                        //var he = row.Cell(4).Value.ToString();
                        //objProgramacion.horaEntrada = he;
                        //var hs = row.Cell(5).Value.ToString();
                        //objProgramacion.horaSalida = hs;

                        //var idPer = Convert.ToInt32(((BCC_Horarios_Y_Marcas.Usuario)Session["DatosUsuario"]).idUsuario);
                        //var oPersona = new Persona
                        //{
                        //    idPersona = idPer
                        //};

                        ////Se registran los datos en la Base de Datos
                        //servicio.cargarDatos(objProgramacion, oPersona);
                    }
                    else
                    {
                        break;
                    }

                }
                //EscribirLB("Fin del Archivo");
                //App.close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Se presento un error al procesar la información del archivo a cargar.");
            }
        }

        /// <summary>
        /// Método que se encarga de la lectura de los datos del archivo
        /// </summary>
        /// <param name="App">Archivo del cual se obtienen los datos</param>
        /// <param name="Col">Especifica la columna en la cual se debe posicionar para leer los datos</param>
        /// <param name="Fila">Especifica la fila en la cual se debe posicionar para leer los datos</param>
        /// <returns>cadena string con el valor obtenido</returns>
        private string LeerCelda(zExcelWrapper.net.document App, uint Col, uint Fila)
        {
            //variable que almacena el valor que se obtenga del archivo
            string Valor = "";
            try
            {
                //se obtiene el valor de una ubicación especificada por la fila y la columna
                Valor = App.getValue(Col, Fila);
            }
            catch
            { }
            return Valor;
        }

        /// <summary>
        /// Da formato de fecha cuando el valor obtenido es un decimal.
        /// </summary>
        /// <param name="FechaDecimal">Valor de fecha en decimal</param>
        /// <returns></returns>
        private string FormatearFecha(string FechaDecimal)
        {
            try
            {
                DateTime Fecha;
                //a veces la fecha puede venir lista, y no en decimal
                if (DateTime.TryParse(FechaDecimal, out Fecha))
                {
                    return FechaDecimal;
                }
                else
                {
                    return new DateTime(1899, 12, 30).AddDays(Convert.ToDouble(FechaDecimal)).ToString("dd/MM/yyyy");
                }
            }
            catch
            {
                return FechaDecimal;
            }

        }

        /// <summary>
        /// método que se encarga de procesar y validar las marcas realizadas por una persona 
        /// para determinar una sola marca de entrada y una sola marca de salida
        /// </summary>
        /// <param name="m1">corresponde a la primer marca realizada</param>
        /// <param name="m2">se r</param>
        /// <param name="m3"></param>
        /// <param name="m4"></param>
        /// <returns>Arreglo de string con la marca de entrada y marca de salida</returns>
        private string[] procesarHorasMarcas(string m1, string m2, string m3, string m4)
        {
            var marcaEntradaYSalida = new string[2];
            var mEntrada = string.Empty;
            var mSalida = string.Empty;
            var primerMarca = 0;

            if (!m1.Equals(string.Empty))
            {
                mEntrada = m1;
                primerMarca = 1;
            }
            else
            {
                if (!m2.Equals(string.Empty))
                {
                    mEntrada = m2;
                    primerMarca = 2;
                }
                else
                {
                    if (!m3.Equals(string.Empty))
                    {
                        mEntrada = m3;
                        primerMarca = 3;
                    }
                    else
                    {
                        mEntrada = m4;
                        primerMarca = 4;
                    }
                }
            }

            switch (primerMarca)
            {
                case 1:
                    if (!m4.Equals(string.Empty))
                    {
                        mSalida = m4;
                    }
                    else
                    {
                        if (!m3.Equals(string.Empty))
                        {
                            mSalida = m3;
                        }
                        else
                        {
                            mSalida = m2;
                        }
                    }
                    break;
                case 2:
                    if (!m4.Equals(string.Empty))
                    {
                        mSalida = m4;
                    }
                    else
                    {
                        mSalida = m3;
                    }
                    break;
                case 3:
                    if (!m4.Equals(string.Empty))
                    {
                        mSalida = m4;
                    }
                    break;
                case 4:
                    mSalida = string.Empty;
                    break;
            }
            marcaEntradaYSalida[0] = mEntrada;
            marcaEntradaYSalida[1] = mSalida;
            return marcaEntradaYSalida;
        }

        protected void ddlTipoDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var opcion = ddlTipoDatos.SelectedValue;
            switch (opcion)
            {
                case "0":
                    lblSite.Visible = false;
                    ddlUbicaciones.Visible = false;
                    break;
                case "1":
                    lblSite.Visible = true;
                    ddlUbicaciones.Visible = true;
                    break;
                case "2":
                    lblSite.Visible = false;
                    ddlUbicaciones.Visible = false;
                    break;
            }
        }

        #region RESPALDO BORRAR LUEGO
        protected void btnCargar_ClickRESPALDO(object sender, EventArgs e)
        {
            //variable para manipulación del archivo del cual se obtendran los datos a cargar
            string FN = "";
            try
            {
                if (ddlTipoDatos.SelectedValue.Equals("0"))
                {
                    FailureText.Text = "Debe especificar el tipo de datos a cargar.";
                    ErrorMessage.Visible = true;
                    gifProcesando.Visible = false;
                }
                else
                {
                    var tipoDato = Int16.Parse(ddlTipoDatos.SelectedValue);
                    switch (tipoDato)
                    {
                        case 0:
                            //se muestra el mensaje de error
                            FailureText.Text = "Debe especificar a que site corresponden los datos.";
                            ErrorMessage.Visible = true;
                            //Se habilita el botón
                            btnCargar.Enabled = true;
                            btnCargar.Visible = true;
                            gifProcesando.Visible = false;
                            break;
                        case 1:
                            if (fileUpload.HasFile)
                            {
                                lblProcesando.Visible = true;
                                var ubicacion = Convert.ToInt32(ddlUbicaciones.SelectedValue);
                                hfArchivoCarga.Value = MapPath("~/uploaded/ArchivoDeCarga-" + DateTime.Now.ToString("yyMMdd-hhmmss") + ".xml");
                                fileUpload.SaveAs(hfArchivoCarga.Value);
                                gifProcesando.Visible = true;
                                fileUpload.Dispose();
                                CargarDatos(ubicacion);
                                lblProcesando.Visible = false;
                                lblFinProceso.Visible = true;
                                //Se habilita el botón
                                btnCargar.Enabled = true;
                                gifProcesando.Visible = false;
                            }
                            else
                            {
                                //se muestra el mensaje de error
                                FailureText.Text = "Debe especificar el tipo de datos a cargar.";
                                ErrorMessage.Visible = true;
                            }
                            break;
                        case 2:
                            if (fileUpload.HasFile)
                            {
                                lblProcesando.Visible = true;
                                var ubicacion = Convert.ToInt32(ddlUbicaciones.SelectedValue);
                                hfArchivoCarga.Value = MapPath("~/uploaded/ArchivoDeCarga-" + DateTime.Now.ToString("yyMMdd-hhmmss") + ".xml");
                                fileUpload.SaveAs(hfArchivoCarga.Value);
                                gifProcesando.Visible = true;
                                fileUpload.Dispose();
                                CargarHorarios();
                                lblProcesando.Visible = false;
                                lblFinProceso.Visible = true;
                                //Se habilita el botón
                                btnCargar.Enabled = true;
                                gifProcesando.Visible = false;
                            }
                            else
                            {
                                //se muestra el mensaje de error
                                FailureText.Text = "Debe especificar el tipo de datos a cargar.";
                                ErrorMessage.Visible = true;
                            }
                            break;
                    }
                    //Se valida el tipo de datos a cargar
                    if (ddlTipoDatos.SelectedValue.Equals("1"))
                    {
                        //se valida si se selecciono algún valor de ubicación
                        if (ddlUbicaciones.SelectedValue == "" || ddlUbicaciones.SelectedValue.Equals("0"))
                        {
                            //se muestra el mensaje de error
                            FailureText.Text = "Debe especificar a que site corresponden los datos.";
                            ErrorMessage.Visible = true;
                            //Se habilita el botón
                            btnCargar.Enabled = true;
                            btnCargar.Visible = true;
                            gifProcesando.Visible = false;
                        }
                    }
                    else if (fileUpload.HasFile)
                    {
                        lblProcesando.Visible = true;
                        var ubicacion = Convert.ToInt32(ddlUbicaciones.SelectedValue);
                        hfArchivoCarga.Value = MapPath("~/uploaded/ArchivoDeCarga-" + DateTime.Now.ToString("yyMMdd-hhmmss") + ".xml");
                        fileUpload.SaveAs(hfArchivoCarga.Value);
                        gifProcesando.Visible = true;
                        fileUpload.Dispose();
                        if (ddlTipoDatos.SelectedValue.Equals("1"))
                        {
                            CargarDatos(ubicacion);
                            lblProcesando.Visible = false;
                            lblFinProceso.Visible = true;
                            //Se habilita el botón
                            btnCargar.Enabled = true;
                            gifProcesando.Visible = false;
                        }
                        else if (ddlTipoDatos.SelectedValue.Equals("2"))
                        {
                            CargarHorarios();
                            lblProcesando.Visible = false;
                            lblFinProceso.Visible = true;
                            //Se habilita el botón
                            btnCargar.Enabled = true;
                            gifProcesando.Visible = false;
                        }
                        else
                        {
                            //se muestra el mensaje de error
                            FailureText.Text = "Debe especificar el tipo de datos a cargar.";
                            ErrorMessage.Visible = true;
                        }
                    }
                    else
                    {
                        //se muestra el mensaje de error
                        FailureText.Text = "Debe indicar un archivo.";
                        ErrorMessage.Visible = true;
                        btnCargar.Enabled = true;
                        btnCargar.Visible = true;
                        gifProcesando.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //se muestra el mensaje de error
                FailureText.Text = "Se presento un error al conectar con la base de datos.";
                ErrorMessage.Visible = true;
                btnCargar.Enabled = true;
                btnCargar.Visible = true;
                gifProcesando.Visible = false;
            }
        }
        #endregion RESPALDO BORRAR LUEGO

    }
}