<%@ Page Title="Carga Datos CMS AACC" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCargaDatosAvaya.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmCargaDatosAvaya" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Obtenga los datos de Log In y Log Out de los agentes a partir de un rango de fechas.</h3>
    <br />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <style type="text/css">
        @import url('http://localhost:63762/Content/calendar-estilo.css');
    </style>
    <%--<p>Use this area to provide additional information.</p>--%>
    <div style="width: 100%; margin: auto; align-content: center">
        <table style="width: 33.33%; margin: 0 auto">
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblFechaDesde" Text="Fecha desde: " runat="server" class="col-md-2 control-label" />
                </td>
                <td style="text-align: left">
                    <input id="dtFecDesde" runat="server" type="date" />
                </td>
                <td style="text-align: right">
                    <asp:Label ID="lblFechaHasta" Text="Fecha hasta: " runat="server" class="col-md-2 control-label" />
                </td>
                <td style="text-align: left">
                    <input id="dtFecHasta" runat="server" type="date" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divBotonera" style="width: 100%; margin: auto; align-content: center;">
        <table style="width: 50%; margin: 0 auto">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnProcesar" runat="server" CssClass="btn btn-default " Text="Procesar" OnClick="btnCargarCMS_Click" Visible="true" AutoPostBack="true" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divGV" style="width: 50%; margin: auto; align-self: auto; overflow: auto; height: 300px;">
        <asp:GridView ID="gvListado" runat="server" Style="margin: auto">
        </asp:GridView>
    </div>
</asp:Content>
