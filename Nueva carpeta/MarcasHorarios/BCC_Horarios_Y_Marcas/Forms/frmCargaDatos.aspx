<%@ Page Title="Marcas de Personal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCargaDatos.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmCargaDatos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Carga de datos de Marcas de Zapote y San Pedro</h3>
    <br />
    <script>
        function desactiva() {
            alert('Este proceso puede tardar varios minutos. Por favor espere!');
            document.getElementById('MainContent_btnFiltrar').style.display = 'none';
            document.getElementById('MainContent_divMensaje').style.visibility = 'visible';
            return true;
        }
    </script>
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <div style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto">
            <tr style="align-content: center">
                <td>
                    <asp:Label runat="server">Archivo a cargar: </asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:FileUpload ID="fileUpload" runat="server" Width="308px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="fileUpload"
                                CssClass="text-danger" ErrorMessage="El archivo a cargar es requerido." />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" >Datos a cargar: </asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTipoDatos" runat="server" CssClass="dropdown" OnSelectedIndexChanged="ddlTipoDatos_SelectedIndexChanged" AutoPostBack="true" Width="138.5px" >
                        <asp:ListItem Value="0">Seleccione</asp:ListItem>
                        <asp:ListItem Value="1">Marcas</asp:ListItem>
                        <asp:ListItem Value="2">Horarios</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTipoDatos"
                                CssClass="text-danger" ErrorMessage="El tipo de datos a cargar es requerido." InitialValue="0"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblSite" Visible="false">Site de marcas: </asp:Label></td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlUbicaciones" runat="server" CssClass="dropdown" Width="138.5px" Visible="false"/>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divBotonera" style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnCargar" runat="server" CssClass="btn btn-default " Text="Cargar" OnClientClick="return confirm('Este proceso puede tardar varios minutos.');" OnClick="btnCargar_Click" visible="true" AutoPostBack="true"/>
                </td>
            </tr>
            <%--<tr>
                <td style="text-align: center">
                    <asp:Button ID="btnCMS" runat="server" CssClass="btn btn-default " Text="CargarCMS" OnClick="btnCargarCMS_Click" visible="true" AutoPostBack="true"/>
                </td>
            </tr>--%>
        </table>
    </div>
    <br />
    <div id="avanceCarga" style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto">
            <tr>
                <td style="text-align: center">
                    <asp:Image ID="gifProcesando" src="../Imagenes/procesando.gif" runat="server" visible="false"/>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="lblProcesando" runat="server" Visible="false">Procesando la carga de datos...</asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="FinCarga" style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto">
            <tr>
                <td style="text-align: center">
                    <asp:Label ID="lblFinProceso" runat="server" Visible="false">Finalizó el proceso de carga.</asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <asp:HiddenField ID="hfArchivoCarga" runat="server" Value="alex" />

    <asp:HiddenField ID="hfPanCarga" runat="server" />

</asp:Content>
