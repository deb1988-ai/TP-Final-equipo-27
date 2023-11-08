<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TP_Final_equipo_27.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="dgvClientes" runat="server" AutoGenerateColumns="false" DataKeyNames="IdCliente" OnRowCommand="dgvClientes_RowCommand" CssClass="table table-striped">
         <Columns>
     <asp:BoundField HeaderText="IdCliente" DataField="IdCliente" />
     <asp:BoundField HeaderText="Nombre" DataField="DatosCliente.Nombre" />
     <asp:BoundField HeaderText="Apellido" DataField="DatosCliente.Apellido" />
     <asp:BoundField HeaderText="E-Mail" DataField="DatosCliente.Email" />
     <asp:BoundField HeaderText="Telefono" DataField="DatosCliente.Telefono" />
     <asp:TemplateField HeaderText="">
         <ItemTemplate>
             <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%#Eval("IdCliente") %>' />
         </ItemTemplate>
     </asp:TemplateField>

 </Columns>

    </asp:GridView>
</asp:Content>
