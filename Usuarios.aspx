<%@ Page Title="" Language="C#" MasterPageFile="~/MasterConSidebar.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TP_Final_equipo_27.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" Class="table table-bordered table-condensed table-hover" ID="dgvUsuarios" AutoGenerateColumns="false" DataKeyNames="IdUsuario" OnRowCommand="dgvUsuarios_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="IdUsuario" DataField="IdUsuario" />
            <asp:BoundField HeaderText="Nombre" DataField="DatosPersonales.Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="DatosPersonales.Apellido" />
            <asp:BoundField HeaderText="Perfil" DataField="TipoUsuario.tipoUsuario" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%#Eval("IdUsuario") %>' CssClass="btn btn-secondary" Width="100px" />
                    <asp:LinkButton Text="Eliminar" runat="server" ID="btnEliminar" CommandName="btnEliminar" CommandArgument='<%#Eval("IdUsuario") %>' CssClass="btn btn-danger" Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="form-group text-center">
    <asp:Button ID="btnAgregarUsuario" Text="Agregar usuario" OnClick="btnAgregarUsuario_Click" runat="server" CssClass="btn btn-outline-secondary" />
</div>
</asp:Content>
