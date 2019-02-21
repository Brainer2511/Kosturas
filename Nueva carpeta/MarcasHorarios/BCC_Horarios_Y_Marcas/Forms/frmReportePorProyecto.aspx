<%@ Page Title="Reporte por Proyecto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportePorProyecto.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmReportePorProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
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
                            <asp:Label ID="lblProyecto" Text="Proyecto: " runat="server" class="col-md-2 control-label">
                        Proyecto:
                            </asp:Label>
                        </td>
                        <td style="text-align: left; border: 10px solid white">
                            <asp:DropDownList ID="ddlProyecto" runat="server" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProyecto" InitialValue="0"
                                CssClass="text-danger" ErrorMessage="Debe seleccionar un proyecto." />
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
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="dtFecDesde" 
                                CssClass="text-danger" ErrorMessage="Debe seleccionar una fecha inicial." />
                        </td> 
                        <td colspan="2" style="text-align: right">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="dtFecHasta" 
                                CssClass="text-danger" ErrorMessage="Debe seleccionar un fecha final." />
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
            <%--<hr />--%>
        </div>
    </div>
    <br />    
    <div id="divDatos" style="width: 100%; margin: auto; align-self: auto; overflow: auto; height: 300px;">
        <%--<br />--%>
        <table style="margin: auto">
            <tr>
                <td>
                    <div style="margin: auto; align-self: auto; overflow: auto; width: auto; height: auto;">
                        <asp:GridView ID="gvProgramacion" runat="server" BackColor="LightGray" Width="100%">
                            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" BorderColor="White" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divDescargar" runat="server" style="width: auto; margin: auto; align-self: auto; overflow: auto; height: auto " visible ="false">
        <asp:Label ID="lblAviso" runat="server"  text="<b>Para descargar la información de click </b>"></asp:Label><asp:HyperLink NavigateUrl="" id="btnDescargar" runat="server" Text="<b>Aquí</b>" />
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
