<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaIncidente.aspx.cs" Inherits="TP_Final_equipo_27.AltaIncidente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .espaciado-filas td {
            padding-bottom: 20px;
        }
    </style>

    <div class="col d-flex justify-content-center w-auto">
        <h3 class="align-content-center">Formulario de alta de Incidente</h3>
    </div>

    <br />
    <div class="col d-flex justify-content-center w-auto">
        <div class="card justify-content-right">
            <div class="card-body">
                <div class="d-grid col-10 mx-auto">
                    <div class="form-row col-15 mx-auto">
                        <table class="espaciado-filas" style="width=100%">
                            <tr>
                                <td colspan="1">
                                    <label>Cliente:</label></td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="Gray" Width="200px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">
                                    <label>Motivo del incidente:</label></td>
                                <td colspan="2">
                                    <div style="flex-grow: 1; margin-right: 10px;">
                                        <asp:DropDownList ID="ddlMotivo" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="Gray" Width="200px"></asp:DropDownList>
                                    </div>
                                </td>
                                <td colspan="1">
                                    <asp:ImageButton ID="ImageButtonAdd" ImageUrl="~/Icons/Add.png" runat="server" OnClick="ImageButtonAdd_Click" Height="15" Width="15" AlternateText="Agregar Motivo" />
                                </td>
                            </tr>
                            <% if (btnAgregarMotivo.Visible == true)
                                { %>
                            <tr>
                                <td colspan="4">
                                    <div style="display: flex; align-items: center; justify-content: space-between;">
                                        <div style="flex-grow: 1; margin-right: 10px;">
                                            <asp:TextBox ID="TextBoxMotivos" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div style="flex-grow: 1; margin-right: 10px;">
                                            <asp:RequiredFieldValidator Font-Size="Large" ID="rfvMotivo" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBoxMotivos" runat="server" ValidationGroup="motivoValidation" />
                                        </div>
                                        <div style="flex-grow: 1; margin-right: 10px;">
                                            <asp:Button ID="btnAgregarMotivo" Text="Agregar Motivo" OnClick="btnAgregarMotivo_Click" runat="server" Visible="false" CssClass="btn btn-outline-secondary" ValidationGroup="motivoValidation" />
                                        </div>
                                        <div>
                                            <asp:Button ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" runat="server" Visible="false" CssClass="btn btn-outline-danger" />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:CustomValidator ID="cvTextBoxMotivos" runat="server" ErrorMessage="El campo debe tener al menos 4 caracteres" ControlToValidate="TextBoxMotivos" ClientValidationFunction="validateLength" ValidationGroup="motivoValidation" ForeColor="Red" Font-Size="Small"></asp:CustomValidator>
                                    <script type="text/javascript">
                                        function validateLength(sender, args) {
                                            var textBoxValue = document.getElementById('<%= TextBoxMotivos.ClientID %>').value;
                                            args.IsValid = textBoxValue.length >= 4;
                                        }
                                    </script>
                                    </>
                            </tr>
                            <% } %>
                            <tr>
                                <td>
                                    <label>Prioridad:</label></td>
                                <td>
                                    <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="gray"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <div class="form-row gap-2 col-15 mx-auto">
                        <label>Descripción:</label>
                        <asp:TextBox CssClass="form-control" ID="txtDescripcion" runat="server" TextMode="MultiLine" Columns="20" Rows="3" Width="600px" Height="100px" onkeyup="updateCharCount()"></asp:TextBox>
                        <asp:Label ID="lblContador" runat="server" Text="0 caracteres" Font-Size="Smaller" />
                        <script type="text/javascript">
                            function updateCharCount() {
                                var textBox = document.getElementById("<%= txtDescripcion.ClientID %>");
                                var label = document.getElementById("<%= lblContador.ClientID %>");
                                label.innerHTML = textBox.value.length + " caracteres.";
                                if (textBox.value.length >= 10) {
                                    label.classList.add("text-success");
                                } else {
                                    label.classList.remove("text-success");
                                }
                            }
                        </script>
                    </div>
                    <div class="form-row gap-2 col-15 mx-auto">
                        <asp:Label ID="lblErrorDescripción" runat="server" Text="" CssClass="text-danger" Font-Size="X-Small"></asp:Label>
                    </div>
                    <div class="form-row gap-2 col-3 mx-auto">
                        <asp:Button ID="btnAgregar" CssClass="btn btn-outline-secondary" runat="server" Text="Alta Incidente" OnClick="btnAgregar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
