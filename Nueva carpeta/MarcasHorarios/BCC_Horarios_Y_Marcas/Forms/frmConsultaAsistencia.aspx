<%@ Page Title="Consulta de Reportes de Asistencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultaAsistencia.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmConsultaAsistencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3 id="ComentReg">Complete los datos para el registro. </h3>
    <br />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <div style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto;">
            <tr style="align-content: center">
                <td style="text-align: right">
                    <asp:Label runat="server" ID="lblNombre" class="col-md-12 control-label">Colaborador: </asp:Label>
                </td>
                <td style="text-align: left" colspan="5">
                    <asp:DropDownList runat="server" ID="ddlColaborador" MaxLength="60" Width="100%" />

                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlColaborador" InitialValue="0"
                        CssClass="text-danger" ErrorMessage="El campo Colaborador es requerido." />
                </td>
            </tr>
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
                <td colspan="2" style="text-align: right">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlColaborador" InitialValue="0"
                        CssClass="text-danger" ErrorMessage="El campo Colaborador es requerido." />
                </td>
                <td colspan="2" style="text-align: right">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlColaborador" InitialValue="0"
                        CssClass="text-danger" ErrorMessage="El campo Colaborador es requerido." />
                </td>
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
    <div id="divGV" style="width: 50%; margin: auto; align-self: auto; overflow: auto; height: 300px;" >
        <asp:GridView ID="gvListado" runat="server" DataKeyNames="Id" OnSelectedIndexChanged="gvListado_SelectedIndexChanged" Style="margin: auto" >
            <Columns>
                <asp:CommandField ButtonType="Image" HeaderText="Editar" SelectImageUrl="~/Imagenes/editar.png" ShowCancelButton="False" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
