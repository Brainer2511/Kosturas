<%@ Page Title="Asignación de Horario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAsignacionHorario.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmAsignacionHorario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3 id="ComentReg">Establezca el horario respectivo. </h3>
    <br />
    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>
    <div style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto;border: 10px solid white">
            <tr style="align-content: center">
                <td style="border: 10px solid white">
                    <asp:Label runat="server" ID="lblNombre">Nombre: </asp:Label>
                </td>
                <td style="text-align: left;border: 10px solid white" colspan="5">
                    <asp:TextBox runat="server" ID="txtNombre" MaxLength="60" Width="100%" Enabled="false" />
                </td>
            </tr>
            <tr>
                <td style="border: 10px solid white">
                    <asp:Label runat="server" ID="lblDpto">Departamento: </asp:Label>
                </td>
                <td style="border: 10px solid white">
                    <asp:DropDownList runat="server" ID="ddlDpto" AutoPostBack="true" Enabled="False"></asp:DropDownList>
                </td>
                <td style="border: 10px solid white">
                    <asp:Label runat="server" ID="lblSeccion">Sección: </asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:DropDownList runat="server" ID="ddlSeccion" Enabled="False"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="gvHorario" runat="server">
            <Columns>
                <asp:CommandField AccessibleHeaderText="Editar" ButtonType="Image" CancelText="Cancelar" EditImageUrl="~/Imagenes/editar.png" EditText="Editar" ShowEditButton="True" UpdateText="Actualizar" />
                <asp:BoundField AccessibleHeaderText="Id" HeaderText="Id">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Fecha" />
                <asp:BoundField HeaderText="Entrada" />
                <asp:BoundField HeaderText="Salida" />
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
