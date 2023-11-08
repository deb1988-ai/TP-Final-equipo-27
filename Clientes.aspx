<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TP_Final_equipo_27.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Formulario de Alta cliente</h2>
    <div class="container">
        <div class="row">
            <div class="col">
                <label>Nombre:</label>
                <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNombre" CssClass="alert alert-warning" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="El Nombre es un campo requerido." />
            </div>
            <div class="col">
                <label>Apellido:</label>
                <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="alert alert-warning" runat="server" ControlToValidate="TextBoxApellido" ErrorMessage="El Apellido es un campo requerido." />
            </div>
            <div class="col">
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col">
                <label>Telefono:</label>
                <asp:TextBox ID="TextBoxTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="alert alert-warning" runat="server" ControlToValidate="TextBoxTelefono" ErrorMessage="El Telefono es un campo requerido." />
            </div>
            <div class="col">
                <label>E-Mail:</label>
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="alert alert-warning" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="El E-Mail es un campo requerido." />
            </div>
            <div class="col">
            </div>
        </div>
    </div>
    <div class="container">
        <div class="form-row">
            <div class="col">
            </div>
            <div class="col">
            </div>
        </div>
    </div>


    <div class="container">
        <div class="row">
            <div class="col">
                
            </div>
            <div class="col-6">
                <asp:Button ID="ButtonAgregar" runat="server" Text="Aceptar" OnClick="ButtonAgregar_Click" CssClass="btn btn-primary"/>    
            </div>
            <div class="col">
               
            </div>
        </div>
    </div>




    <h2>Clientes:</h2>
    <asp:GridView ID="dgvClientes" runat="server" AutoGenerateColumns="false" DataKeyNames="IdCliente" OnRowCommand="dgvClientes_RowCommand" CssClass="table table-striped" OnRowEditing="dgvClientes_RowEditing">
        <Columns>
            <asp:BoundField HeaderText="IdCliente" DataField="IdCliente" />
            <asp:BoundField HeaderText="Nombre" DataField="DatosCliente.Nombre" Visible="true" />
            <asp:TemplateField HeaderText="" Visible="false">
                <ItemTemplate>
                    <asp:TextBox ID="TextBoxNombre" runat="server" OnDataBinding="TextBoxNombre_DataBinding"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Apellido" DataField="DatosCliente.Apellido" />
            <asp:BoundField HeaderText="E-Mail" DataField="DatosCliente.Email" />
            <asp:BoundField HeaderText="Telefono" DataField="DatosCliente.Telefono" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton Text="Editar" runat="server" ID="btnEditar" CommandName="btnEditar" CommandArgument='<%#Eval("IdCliente") %>' CssClass="btn btn-secondary" OnClick="btnEditar_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <EditItemTemplate>
                    <asp:LinkButton ID="btnAceptar" runat="server" CommandName="btnAceptar" CssClass="btn btn-primary" Enabled="false" OnClick="btnAceptar_Click">Aceptar cambios</asp:LinkButton>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
