<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TP_Final_equipo_27.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container justify-content-center">
        <div class="row">
            <div class="col">
            </div>
            <div class="col d-flex justify-content-center">
                <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar cliente" OnClick="ButtonAgregar_Click" CssClass="btn btn-secondary" />
            </div>
            <div class="col">
            </div>
        </div>
    </div>
    <div class="container justify-content-center">
        <h2>Clientes:</h2>
        <asp:GridView ID="dgvClientes" runat="server" AutoGenerateColumns="false" DataKeyNames="IdUsuario" OnRowCommand="dgvClientes_RowCommand" CssClass="table table-bordered table-condensed table-hover">
            <Columns>
                <asp:BoundField HeaderText="IdCliente" DataField="IdUsuario" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="Nombre" DataField="DatosPersonales.Nombre" Visible="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="Apellido" DataField="DatosPersonales.Apellido" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="E-Mail" DataField="DatosPersonales.Email" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="Telefono" DataField="DatosPersonales.Telefono" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="center" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%#Eval("IdUsuario") %>' CssClass="btn btn-secondary" Width="100px" />
                        <asp:LinkButton Text="Eliminar" runat="server" ID="btnEliminar" CommandName="btnEliminar" CommandArgument='<%#Eval("IdUsuario") %>' CssClass="btn btn-danger" Width="100px" />
                    </ItemTemplate>
                    <ItemStyle Width="250px" HorizontalAlign="Center"/>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
