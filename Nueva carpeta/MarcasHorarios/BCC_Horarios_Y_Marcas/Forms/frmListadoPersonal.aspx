<%@ Page Title="Listado de Personal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListadoPersonal.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmListadoPersonal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Para ver el detalle seleccione un elemento de la lista</h3>
    <br />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <%--<p>Use this area to provide additional information.</p>--%>
    <div style="width: 100%; margin: auto; align-content: center">
        <table style="width: 33.33%; margin: 0 auto" >
            <tr style="align-content: center">
                <td style="text-align: right">
                    <asp:Label ID="lblFiltroDpto" Text="Departamento: " runat="server" class="col-md-2 control-label">
                        Departamento
                    </asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlDepartamento" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="lblFiltroSeccion" Text="Sección: " runat="server" class="col-md-2 control-label" visible="false"/>
                </td>
                <td style="text-align: left">
                    <asp:DropDownList ID="ddlSeccion" runat="server" visible="false" ></asp:DropDownList>
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
    <div id="divBotonera" style="width: 100%; margin: auto; align-content: center; ">
        <table style="width: 50%; margin: 0 auto">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnProcesar" runat="server" CssClass="btn btn-default " Text="Listar" OnClick="btnProcesar_Click" visible="true" AutoPostBack="true" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divGV" style="width: 50%; margin: auto; align-self: auto; overflow: auto; height:300px;">
        <asp:GridView ID="gvListado" runat="server" DataKeyNames="Id" OnSelectedIndexChanged="gvListado_SelectedIndexChanged" style="margin:auto">
            <Columns>
                <asp:CommandField ButtonType="Image" HeaderText="Editar" SelectImageUrl="~/Imagenes/editar.png" ShowCancelButton="False" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
