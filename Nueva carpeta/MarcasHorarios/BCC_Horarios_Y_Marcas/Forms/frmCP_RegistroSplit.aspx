<%@ Page Title="Mant. de Splits" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCP_RegistroSplit.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmCP_RegistroSplit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3 id="ComentReg">Establezca un código y nombre para un nuevo split. </h3>
    <h3 id="ComentMod" style="visibility: hidden">Actualice los datos para el split seleccionado </h3>
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
                    <asp:Label runat="server" ID="lblCodigo" class="col-md-12 control-label">Código: </asp:Label>
                </td>
                <td style="text-align: left" >
                    <asp:TextBox runat="server" ID="txtCodigo" Style="width: 115px; height: 20px;" TextMode="Number"/>
                </td>
                <td style="text-align: right">
                    <asp:Label runat="server" ID="lblMZ" class="col-md-12 control-label">Nombre: </asp:Label>
                </td>
                <td style="text-align: left" >
                    <asp:TextBox runat="server" ID="txtNombre" Style="width: 115px; height: 20px;" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodigo"
                        CssClass="text-danger" ErrorMessage="El campo Código es requerido." />
                </td>
                <td colspan="2" style="text-align: right">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombre"
                        CssClass="text-danger" ErrorMessage="El campo Nombre es requerido." />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divBotonera" style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto" runat="server" id="tbBtnPrinc">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-default " Text="Registrar" OnClick="btnRegistrar_Click" visible="true" AutoPostBack="true" />
                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default " Text="Modificar" OnClick="btnModificar_Click" visible="false" AutoPostBack="true" />
                </td>
            </tr>
        </table>
        <table style="width: 50%; margin: 0 auto" runat="server" id="tbBtnSec" visible ="false">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-default " Text="Aceptar" OnClick="btnAceptar_Click" visible="true" AutoPostBack="true" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default " Text="Cancelar" OnClick="btnCancelar_Click" visible="true" AutoPostBack="true" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divGV" style="width: 25%; margin: auto; align-self: auto; overflow: auto; height: 150px;" >
        <asp:GridView ID="gvListado" runat="server" DataKeyNames="Id" OnSelectedIndexChanged="gvListado_SelectedIndexChanged" Style="margin: auto" >
            <Columns>
                <asp:CommandField ButtonType="Image" HeaderText="Editar" SelectImageUrl="~/Imagenes/editar.png" ShowCancelButton="False" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:HiddenField ID="idSplit" runat="server" />
</asp:Content>
