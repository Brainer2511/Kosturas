<%@ Page Title="Plantilla Horarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPlantillaHorario.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmPlantillaHorario" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Obtenga la plantilla para los horarios del personal.</h3>
    <br />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <div id="tablaPrincipal" style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto">
            <tr style="align-content: center; ">
                <td>
                    <asp:Label runat="server" ID="lblDpto">Departamento: </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="dropdown" AutoPostBack="true" Width="138.5px" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblSeccion" Visible="false">Sección: </asp:Label></td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlSeccion" runat="server" CssClass="dropdown" Width="138.5px" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddlSeccion_SelectedIndexChanged" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblProyecto" Visible="false">Proyecto: </asp:Label></td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlProyecto" runat="server" CssClass="dropdown" Width="138.5px" Visible="false"/>
                </td>
            </tr>
            <%--<tr>
                <td>
                    <asp:Label runat="server" ID="lblCantDias" >Cantidad de días</asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCantDias" Width="138.5px" TextMode="Number" MaxLength="2"/>
                </td>
            </tr>--%>
        </table>
    </div>
    <br />
    <div id="divBotonera" style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnDescarga" runat="server" CssClass="btn btn-default " Text="Descargar" OnClientClick="return confirm('Este proceso puede tardar varios minutos.');" OnClick="btnDescargar_Click" visible="true" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
