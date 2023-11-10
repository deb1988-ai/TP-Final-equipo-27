<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TP_Final_equipo_27.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
            </div>
            <div class="col-6">
                <asp:Button ID="ButtonAgregar" runat="server" Text="Aceptar" OnClick="ButtonAgregar_Click" CssClass="btn btn-primary" />
            </div>
            <div class="col">
            </div>
        </div>
        <h2>Clientes:</h2>
        <asp:GridView ID="dgvClientes" runat="server" AutoGenerateColumns="false" DataKeyNames="IdUsuario" OnRowCommand="dgvClientes_RowCommand" Class="table table-bordered table-condensed table-hover">
            <Columns>
                <asp:BoundField HeaderText="IdCliente" DataField="IdUsuario"/>
                <asp:BoundField HeaderText="Nombre" DataField="DatosPersonales.Nombre" Visible="true" />
                <asp:BoundField HeaderText="Apellido" DataField="DatosPersonales.Apellido" />
                <asp:BoundField HeaderText="E-Mail" DataField="DatosPersonales.Email" />
                <asp:BoundField HeaderText="Telefono" DataField="DatosPersonales.Telefono" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%#Eval("IdUsuario") %>' CssClass="btn btn-secondary" OnClick="btnEditar_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
