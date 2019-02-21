<%@ Page Title="Busqueda de Colaborador" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProgramacion.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmProgramacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4><b><%: Title %>.</b></h4>
    <%--<h3>Establezca los filtros necesarios para realizar la busqueda.</h3>--%>
    <br />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <%--<p>Use this area to provide additional information.</p>--%>
    <div class="container">
        <div class="header" style="background-color: #eee; color: #444; cursor: pointer; padding: 3px; width: 100%; border: none; text-align: left; outline: none; font-size: 15px;">
            <span>- Filtros</span>
        </div>
        <div class="content">
            <div style="width: 100%; margin: auto; align-content: center">
                <table style="width: 33.33%; margin: 0 auto; border: 10px solid white">
                    <tr style="align-content: center">
                        <td style="text-align: right; border: 10px solid white">
                            <asp:Label ID="lblFiltroDpto" Text="Departamento: " runat="server" class="col-md-2 control-label">
                        Departamento:
                            </asp:Label>
                        </td>
                        <td style="text-align: left; border: 10px solid white">
                            <asp:DropDownList ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </td>
                        <td style="text-align: right; border: 10px solid white">
                            <asp:Label ID="lblFiltroSeccion" Text="Sección: " runat="server" class="col-md-2 control-label" Visible="false" />
                        </td>
                        <td style="text-align: left; border: 10px solid white">
                            <asp:DropDownList ID="ddlSeccion" runat="server" Visible="false"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="align-content: center">
                        <td style="text-align: right; border: 10px solid white">
                            <asp:Label ID="lblProyecto" Text="Proyecto: " runat="server" class="col-md-2 control-label">
                        Proyecto:
                            </asp:Label>
                        </td>
                        <td style="text-align: left; border: 10px solid white">
                            <asp:DropDownList ID="ddlProyecto" runat="server" ></asp:DropDownList>
                        </td>
                        <td style="text-align: right; border: 10px solid white">
                            <asp:Label ID="lblDia" Text="Día: " runat="server" class="col-md-2 control-label" />
                        </td>
                        <td style="text-align: left; border: 10px solid white">
                            <asp:DropDownList ID="ddlDias" runat="server" >
                                <asp:ListItem Text="SELECCIONE" Value="Seleccione"/>
                                <asp:ListItem Text="Lunes" Value="Lunes" />
                                <asp:ListItem Text="Martes" Value="Martes" />
                                <asp:ListItem Text="Miércoles" Value="Miércoles" />
                                <asp:ListItem Text="Jueves" Value="Jueves" />
                                <asp:ListItem Text="Viernes" Value="Viernes" />
                                <asp:ListItem Text="Sábado" Value="Sábado" />
                                <asp:ListItem Text="Domingo" Value="Domingo" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="align-content: center">
                        <td style="text-align: right; border: 10px solid white">
                            <asp:Label runat="server" ID="lblNombre" class="col-md-2 control-label">Nombre: </asp:Label>
                        </td>
                        <td style="text-align: left; border: 10px solid white" colspan="5">
                            <asp:TextBox runat="server" ID="txtNombre" MaxLength="60" Width="100%" />

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="lblFechaDesde" Text="Desde: " runat="server" class="col-md-2 control-label" />
                        </td>
                        <td style="text-align: left; border: 10px solid white"" >
                            <input id="dtFecDesde" runat="server" type="date" />
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblFechaHasta" Text="Hasta: " runat="server" class="col-md-2 control-label" />
                        </td>
                        <td style="text-align: left; border: 10px solid white">
                            <input id="dtFecHasta" runat="server" type="date" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divBotonera" style="width: 100%; margin: auto; align-content: center;">
                <table style="width: 50%; margin: 0 auto">
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="btnProcesar" runat="server" CssClass="btn btn-default " Text="Aceptar" OnClick="btnProcesar_Click" Visible="true" AutoPostBack="true" />
                        </td>
                    </tr>
                </table>
            </div>
            <hr />
        </div>
    </div>

    <br />
    <div id="divGV" style="width: 56%; margin: auto; align-self: auto; overflow: auto; height: auto;">
        <asp:GridView ID="gvListado" runat="server" DataKeyNames="Id" OnSelectedIndexChanged="gvListado_SelectedIndexChanged" Style="margin: auto" BackColor="LightGray" AllowPaging="True" OnPageIndexChanging="gvListado_PageIndexChanging">
            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Image" HeaderText="Ver" SelectImageUrl="~/Imagenes/check.png" ShowCancelButton="False" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <br />
        <asp:GridView Id="gvTotales" runat="server" Style="margin: auto" BackColor="LightGray">
            <Columns>
                <%--<asp:BoundField DataField="horasProg" HeaderText="Programadas"></asp:BoundField>
                <asp:BoundField DataField="horasMarc" HeaderText="Marcas"></asp:BoundField>
                <asp:BoundField DataField="horasCMS" HeaderText="CMS"></asp:BoundField>--%>
            </Columns>

            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <div id="divDatos" style="width: 100%; margin: auto; align-self: auto; overflow: auto; height: 300px;">
        <br />
        <table style="margin: auto">
            <tr>
                <td>
                    <div style="margin: auto; align-self: auto; overflow: auto; width: 345px; height: 190px;">
                        <asp:GridView ID="gvProgramacion" runat="server" AutoGenerateColumns="False" OnRowCreated="gvProgramacion_RowCreated" BackColor="LightGray" Width="100%">
                            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="dia" HeaderText="D&#237;a"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" Visible="True"></asp:BoundField>
                                <asp:BoundField DataField="entrada" HeaderText="Entrada"></asp:BoundField>
                                <asp:BoundField DataField="salida" HeaderText="Salida"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
                <td>
                    <div style="margin: auto; align-self: auto; overflow: auto; width: 176px; height: 190px;">
                        <asp:GridView ID="gvMarcasZPT" runat="server" AutoGenerateColumns="False" OnRowCreated="gvMarcasZPT_RowCreated" BackColor="LightGray" Width="100%">
                            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="numeroMarca" HeaderText="N&#250;meroMarca" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="dia" HeaderText="D&#237;a"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="entrada" HeaderText="Entrada"></asp:BoundField>
                                <asp:BoundField DataField="salida" HeaderText="Salida"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
                <td>
                    <br />
                </td>
                <td>
                    <div style="margin: auto; align-self: auto; overflow: auto; width: 176px; height: 190px;">
                        <asp:GridView ID="gvMarcasSP" runat="server" AutoGenerateColumns="False" OnRowCreated="gvMarcasSP_RowCreated" BackColor="LightGray" Width="100%">
                            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="numeroMarca" HeaderText="N&#250;meroMarca" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="dia" HeaderText="D&#237;a"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="entrada" HeaderText="Entrada"></asp:BoundField>
                                <asp:BoundField DataField="salida" HeaderText="Salida"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
                <td>
                    <div style="margin: auto; align-self: auto; overflow: auto; width: 192px; height: 190px;">
                        <asp:GridView ID="gvAACC" runat="server" AutoGenerateColumns="False" OnRowCreated="gvAACC_RowCreated" BackColor="LightGray" Width="100%">
                            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="agentLogin" HeaderText="LoginId" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="dia" HeaderText="D&#237;a"></asp:BoundField>
                                <asp:BoundField DataField="fechaHora" HeaderText="Fecha" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="horaEntrada" HeaderText="LogIn"></asp:BoundField>
                                <asp:BoundField DataField="horaSalida" HeaderText="LogOut"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
                <%--<td>
                    <div style="margin: auto; align-self: auto; overflow: auto; width: 192px; height: 190px;">
                        <asp:GridView ID="gvElite" runat="server" AutoGenerateColumns="False" OnRowCreated="gvElite_RowCreated" BackColor="LightGray" Width="100%">
                            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="logid" HeaderText="LoginId" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="dia" HeaderText="D&#237;a"></asp:BoundField>
                                <asp:BoundField DataField="fecha" HeaderText="Fecha" Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="login" HeaderText="LogIn"></asp:BoundField>
                                <asp:BoundField DataField="logout" HeaderText="LogOut"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>--%>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hdnAcordeon" runat="server" />
    <script>
        $(".header").click(function () {

            $header = $(this);
            //getting the next element
            $content = $header.next();
            //open up the content needed - toggle the slide- if visible, slide up, if not slidedown.
            $content.slideToggle(500, function () {
                //execute this after slideToggle is done
                //change text of header based on visibility of content div
                $header.text(function () {
                    //change text based on condition
                    return $content.is(":visible") ? "- Filtros" : "+ Filtros";
                });
            });

        });
    </script>
</asp:Content>
