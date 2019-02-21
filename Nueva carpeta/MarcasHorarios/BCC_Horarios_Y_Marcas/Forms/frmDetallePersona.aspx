<%@ Page Title="Detalle de Personal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDetallePersona.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmDetallePersona" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3 id="ComentReg">Para actualizar algún dato presione el botón "Editar" </h3>
    <br />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <div style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto;">
            <tr style="align-content: center">
                <td>
                    <asp:Label runat="server" ID="lblNombre">Nombre: </asp:Label>
                </td>
                <td style="text-align: left" colspan="5">
                    <asp:TextBox runat="server" ID="txtNombre" MaxLength="60" Width="100%" Enabled="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
                        CssClass="text-danger" ErrorMessage="El campo Nombre es requerido." />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblDpto">Departamento: </asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlDpto" OnSelectedIndexChanged="ddlDpto_SelectedIndexChanged" AutoPostBack="true" Enabled="False"></asp:DropDownList>
                </td>
                <td>&nbsp;
                </td>
                <td>
                    <asp:Label runat="server" ID="lblMZ">Marca Zapote: </asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMZPT" Style="width: 115px; height: 20px;" TextMode="Number" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlDpto" InitialValue="0"
                        CssClass="text-danger" ErrorMessage="El campo Departamento es requerido." />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblSeccion">Sección: </asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:DropDownList runat="server" ID="ddlSeccion" Enabled="False"></asp:DropDownList>
                </td>
                <td>&nbsp;
                </td>
                <td>
                    <asp:Label runat="server" ID="lblMS">Marca San Pedro: </asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMSP" Style="width: 115px; height: 20px;" TextMode="Number" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlSeccion" InitialValue="0"
                        CssClass="text-danger" ErrorMessage="El campo Departamento es requerido." />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label1">Correo: </asp:Label>
                </td>
                <td style="text-align: left; width: 191px;">
                    <input name="correo" type="email" id="txtCorreo" runat="server" disabled="disabled">
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label runat="server" ID="Label2" >LoginId: </asp:Label >
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLoginId" style="width: 115px; height: 20px;" TextMode="Number" Enabled="False"/>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divBotonera" style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-default " Text="Editar" OnClick="btnEditar_Click" Visible="true" AutoPostBack="true" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-default" Visible="false" OnClick="Aceptar_Click" />
                <asp:Button ID="btnCancelar" runat="server" CausesValidation="false" Text="Cancelar" class="btn btn-default" Visible="false" OnClick="btnCancelar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
