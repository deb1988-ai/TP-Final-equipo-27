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
            <div class="form-group text-center">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Motivo" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        <div class="form-row col-6 mx-auto">
            <div class="form-group text-center">
                <asp:TextBox ID="TextBoxMotivos" runat="server" Visible="false"></asp:TextBox>
                <asp:Button ID="btnAgregarMotivo" Text="Agregar Motivo" OnClick="btnAgregarMotivo_Click" runat="server" Visible="false" CssClass="btn btn-outline-secondary" />
                <asp:Label ID="lblErrorMotivo" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
