<%@ Page Title="Registro de Colaboradores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistroPersonal.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.RegistroPersonal" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3 id="ComentReg">Complete los datos para el registro de personal </h3>
    <h3 id="ComentMod" style="visibility:hidden">Actualice los datos para el registro de personal </h3>
    <br />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <div style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto; ">
            <tr style="align-content: center">
                <td style="text-align: right">
                    <asp:Label runat="server" ID="lblNombre" class="col-md-2 control-label">Nombre: </asp:Label>
                </td>
                <td style="text-align: left" colspan="5">
                    <asp:TextBox runat="server" ID="txtNombre" MaxLength="60" Width="100%" />
                    
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
                <td style="width: 191px">
                    <asp:DropDownList runat="server" ID="ddlDpto" OnSelectedIndexChanged="ddlDpto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label runat="server" ID="lblMZ" >Marca Zapote: </asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMZPT" style="width: 115px; height: 20px;" TextMode="Number"/>
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
                <td style="text-align: left; width: 191px;">
                    <asp:DropDownList runat="server" ID="ddlSeccion" Enabled="False" ></asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label runat="server" ID="lblMS" >Marca San Pedro: </asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMSP" style="width: 115px; height: 20px;" TextMode="Number" />
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
                    <input name="correo" type="email" id="txtCorreo" runat="server">
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Label runat="server" ID="Label2" >LoginId: </asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtLoginId" style="width: 115px; height: 20px;" TextMode="Number"/>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label3">Proyecto: </asp:Label>
                </td>
                <td style="text-align: left; width: 191px; column-span:all">
                    <asp:DropDownList runat="server" ID="ddlProyecto" ></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label4">Encargado: </asp:Label>
                </td>
                <td style="text-align: left; width: 191px; column-span:3">
                    <asp:DropDownList runat="server" ID="ddlJefaturas" Enabled="False" ></asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <td colspan="3">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCorreo" InitialValue="0"
                                CssClass="text-danger" ErrorMessage="El campo Departamento es requerido." />
                </td>
            </tr>--%>
        </table>
    </div>
    <br />
    <div id="divBotonera" style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-default " Text="Registrar" OnClick="btnRegistrar_Click" visible="true" AutoPostBack="true" />
                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default " Text="Modificar" OnClick="btnModificar_Click" visible="false" AutoPostBack="true" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
