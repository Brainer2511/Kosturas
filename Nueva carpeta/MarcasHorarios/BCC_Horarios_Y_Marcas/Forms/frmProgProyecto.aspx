<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProgProyecto.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmProgProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Establezca los filtros necesarios para realizar la busqueda.</h3>
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
                    <%--<tr style="align-content: center">
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
                    </tr>--%>
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
    <div id="divGV" style="width: 100%; margin: auto; align-self: auto; overflow: auto; height: auto;">
        <asp:GridView ID="gvListado" runat="server" Style="margin: auto" BackColor="LightGray" OnRowCancelingEdit="gvListado_RowCancelingEdit" OnRowEditing="gvListado_RowEditing" OnRowUpdating="gvListado_RowUpdating">
            <Columns>
                <asp:CommandField CancelImageUrl="~/Imagenes/cancel.png" EditImageUrl="~/Imagenes/editar.png" ShowEditButton="True" UpdateImageUrl="~/Imagenes/check.png" ButtonType="Image"></asp:CommandField>
            </Columns>

            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>    
    <asp:HiddenField ID="hdnAcordeon" runat="server" />
    
</asp:Content>
