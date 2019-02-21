<%@ Page Title="Control de Asistencia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmControlAsistencia.aspx.cs" Inherits="BCC_Horarios_Y_Marcas.Forms.frmSeguimiento" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
            <tr style="align-content: center">
                <td style="text-align: right">
                    <asp:Label runat="server" ID="lblMovimiento" class="col-md-12 control-label">Motivo: </asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:DropDownList runat="server" ID="ddlMotivo" OnSelectedIndexChanged="ddlMotivo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td style="text-align: right">
                    <asp:Label runat="server" ID="lblFecha" class="col-md-12 control-label">Fecha: </asp:Label>
                </td>
                <td>
                    <input id="dtFecha" runat="server" type="date" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlMotivo" InitialValue="0"
                        CssClass="text-danger" ErrorMessage="El campo Motivo es requerido." />
                </td>
                <td colspan="2" style="text-align: right">
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="dtFecha"
                        CssClass="text-danger" ErrorMessage="El campo Fecha es requerido." />
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label runat="server" ID="lblHoraDesde" class="col-md-12 control-label" Visible="false">Hora desde: </asp:Label>
                </td>
                <td>
                    <input id="txtHoradesde" runat="server" type="time" visible="false" />
                </td>
                <td style="text-align: right">
                    <asp:Label runat="server" ID="lblHoraHasta" class="col-md-12 control-label" Visible="false">Hora hasta: </asp:Label>
                </td>
                <td>
                    <input id="txtHoraHasta" runat="server" type="time" visible="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtHoradesde"
                        CssClass="text-danger" ErrorMessage="Debe asignar una hora inicio." />--%>
                    <asp:CustomValidator ID="CustomValidator1" runat="server"
                        ClientValidationFunction="ValidaDDL" ControlToValidate="txtHoradesde" CssClass="text-danger"
                        ErrorMessage="Debe asignar una hora inicio." ValidateEmptyText="True">
                    </asp:CustomValidator>
                </td>
                <td colspan="2" style="text-align: right">
                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtHoraHasta"
                        CssClass="text-danger" ErrorMessage="Debe asignar una hora fin." />--%>
                    <asp:CustomValidator ID="CustomValidator2" runat="server"
                        ClientValidationFunction="ValidaDDL2" ControlToValidate="txtHoradesde" CssClass="text-danger"
                        ErrorMessage="Debe asignar una hora fin." ValidateEmptyText="True">
                    </asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label runat="server" ID="lblComentario" class="col-md-2 control-label">Observaciones: </asp:Label>
                </td>
                <td colspan="4" style="text-align: left">
                    <textarea cols="60" rows="5" runat="server" id="taObs" enabled="False"></textarea>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divBotonera" style="width: 100%; margin: auto; align-content: center">
        <table style="width: 50%; margin: 0 auto" runat="server" id="tblBotonesPrinc">
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-default " Text="Registrar" OnClick="btnRegistrar_Click" Visible="true" AutoPostBack="true" />
                    <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-default " Text="Modificar" OnClick="btnModificar_Click" Visible="false" AutoPostBack="true" CausesValidation="false"/>
                </td>
            </tr>
        </table>
        <table style="width: 50%; margin: 0 auto" runat="server" id="tblBotonesEdic">
            <tr>
                <td style="text-align: right">
                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-default " Text="Aceptar" OnClick="btnAceptar_Click" Visible="true" AutoPostBack="true" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default " Text="Cancelar" OnClick="btnCancelar_Click" Visible="true" AutoPostBack="true" CausesValidation="false"/>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function ValidaDDL(source, arguments) {
            var combo = document.getElementById("MainContent_ddlMotivo");
            var text = combo.options[combo.selectedIndex].text;
            if (text == 'Extras') {
                if ($("#MainContent_txtHoradesde").val() == "") {
                    arguments.IsValid = false;
                } else {
                    arguments.IsValid = true;
                }
            }
            else {
                arguments.IsValid = true;
            }
        }

        function ValidaDDL2(source, arguments) {
            var combo = document.getElementById("MainContent_ddlMotivo");
            var text = combo.options[combo.selectedIndex].text;
            if (text == 'Extras') {
                if ($("#MainContent_txtHoraHasta").val() == "") {
                    arguments.IsValid = false;
                } else {
                    arguments.IsValid = true;
                }
            }
            else {
                arguments.IsValid = true;
            }
        }
    </script>
</asp:Content>
