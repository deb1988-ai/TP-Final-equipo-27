<%@ Page Title="" Language="C#" MasterPageFile="~/MasterConSidebar.Master" AutoEventWireup="true" CodeBehind="Motivos.aspx.cs" Inherits="TP_Final_equipo_27.Motivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <asp:GridView runat="server" ID="dgvMotivos" Class="table table-bordered table-condensed table-hover" AutoGenerateColumns="false" DataKeyNames="IdMotivo" OnRowCommand="dgvMotivos_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Motivo">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblMotivo" Text='<%# Eval("motivo") %>' Visible="true"></asp:Label>
                                <asp:TextBox runat="server" ID="txtMotivo" Visible="false" Text='<%# Eval("motivo") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-secondary" Width="100px" />
                                <asp:LinkButton Text="Eliminar" runat="server" ID="btnEliminar" CommandName="btnEliminar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-danger" Width="100px" />
                                <asp:LinkButton Text="Guardar" runat="server" ID="btnGuardar" Visible="false" CommandName="btnGuardar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-primary" Width="100px" />
                            </ItemTemplate>
                            <ItemStyle Width="250px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="col d-flex justify-content-center w-auto">
        <div class="form-row col-6 mx-auto">
            <table>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Motivo" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
                    </td>
                    <td>
                        <div style="display: flex; align-items: center; justify-content: space-between;">
                            <div style="flex-grow: 1; margin-right: 10px;">
                                <asp:TextBox ID="TextBoxMotivos" runat="server" Visible="false" oninput="limpiarMensajeError()" Width="200px" CssClass="form-control"></asp:TextBox>
                                <script type="text/javascript">
                                    function limpiarMensajeError() {
                                        var textBoxValue = document.getElementById('<%= TextBoxMotivos.ClientID %>').value;
                                        var errorLabel = document.getElementById('<%= lblError.ClientID %>');

                                        if (textBoxValue.length < 4) {
                                            errorLabel.textContent = '';
                                            errorLabel.style.display = 'none';
                                        }
                                    }
                                </script>
                            </div>
                            <div style="flex-grow: 1; margin-right: 10px;">
                                <asp:Button ID="btnAgregarMotivo" Text="Agregar Motivo" OnClick="btnAgregarMotivo_Click" runat="server" Visible="false" CssClass="btn btn-outline-secondary" ValidationGroup="motivoValidation" CausesValidation="True" />
                            </div>
                            <div style="display: flex; align-items: center;">
                                <asp:Label ID="lblError" Visible="false" Text="" runat="server" ForeColor="Red" Font-Size="Small" Style="display: inline-block; margin-top: 5px;" />
                                <asp:RequiredFieldValidator Font-Size="Large" ID="rfvMotivo" ErrorMessage="*" ForeColor="Red" ControlToValidate="TextBoxMotivos" runat="server" ValidationGroup="motivoValidation" />
                                <asp:CustomValidator ID="cvTextBoxMotivos" runat="server" ErrorMessage="El campo debe tener al menos 4 caracteres" ControlToValidate="TextBoxMotivos" ClientValidationFunction="validateLength" ValidationGroup="motivoValidation" ForeColor="Red" Font-Size="Small"></asp:CustomValidator>
                                <script type="text/javascript">
                                    function validateLength(sender, args) {
                                        var textBoxValue = document.getElementById('<%= TextBoxMotivos.ClientID %>').value;
                                        args.IsValid = textBoxValue.length >= 4;
                                    }
                                </script>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
