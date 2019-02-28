﻿<%@ Page Title="Listado de Control de Plazas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCP_ConsultaPlazas.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmCP_ConsultaPlazas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Establezca los filtros.</h3>
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
            <%--<tr style="align-content: center">
                <td style="text-align: right">
                    <asp:Label ID="lblFiltroDpto" Text="Departamento: " runat="server" class="col-md-2 control-label">
                        Departamento
                    </asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="lblFiltroSeccion" Text="Sección: " runat="server" class="col-md-2 control-label" Visible="false" />
                </td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlSeccion" runat="server"></asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblFechaDesde" Text="Fecha desde: " runat="server" class="col-md-12 control-label" />
                </td>
                <td style="text-align: left">
                    <input id="dtFecDesde" runat="server" type="date" />
                </td>
                <td style="text-align: right">
                    <asp:Label ID="lblFechaHasta" Text="Fecha hasta: " runat="server" class="col-md-12 control-label" />
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
                    <asp:Button ID="btnProcesar" runat="server" CssClass="btn btn-default " Text="Listar" OnClick="btnProcesar_Click" Visible="true" AutoPostBack="true" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divGV" style="width: 50%; margin: auto; align-self: auto; overflow: auto; height: 300px; ">
        <asp:GridView ID="gvListado" runat="server" OnSelectedIndexChanged="gvListado_SelectedIndexChanged" Style="margin: auto">
            <%--<Columns>
                <asp:CommandField ButtonType="Image" HeaderText="Editar" SelectImageUrl="~/Imagenes/editar.png" ShowCancelButton="False" ShowSelectButton="True" />
            </Columns>--%>
        </asp:GridView>
    </div>
        <br />
    <div id="descargar" style="width: 50%; margin: auto; align-self: auto; overflow: auto; height: 300px; ">
        <asp:Label ID="lblAviso" runat="server"  text="<b>Para descargar la información de click </b>"></asp:Label><asp:HyperLink NavigateUrl="" id="btnDescargar" runat="server" Text="<b>Aquí</b>" />
    </div>
</asp:Content>