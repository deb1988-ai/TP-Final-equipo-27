<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="TP_Final_equipo_27.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .espaciado-filas td {
            padding-bottom: 20px;
        }
    </style>
    <div class="container mx-auto justify-content-center">
        <div class="col d-flex justify-content-center">
            <div class="card justify-content-center">
                <div class="card-body">
                    <div class="d-grid gap-2 col-15 mx-auto">
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:TextBox ID="txtNombreCliente" placeholder="Nombre" runat="server" Class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" ErrorMessage="Ingrese Nombre" ForeColor="Red" ControlToValidate="txtNombreCliente" runat="server" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:TextBox ID="txtApellido" placeholder="Apellido" runat="server" Class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvApellido" ErrorMessage="Ingrese apellido" ForeColor="Red" ControlToValidate="txtApellido" runat="server" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" Class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" ErrorMessage="Ingrese Email" ForeColor="Red" ControlToValidate="txtEmail" runat="server" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:TextBox ID="txtTelefono" placeHolder="Telefono" runat="server" Class="form-control" FilterType="Numbers,Custom"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTelefono" ErrorMessage="Ingrese Telefono" ForeColor="Red" ControlToValidate="txtTelefono" runat="server" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto">
                            <label id="lblTiposUsuarios" runat="server" for="lblTiposUsuarios">Tipo de Usuario</label>
                            <asp:DropDownList ID="ddlTiposUsuario" Class="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:TextBox ID="txtLogin" placeholder="Login" runat="server" Class="form-control" FilterType="Numbers,Custom"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLogin" ErrorMessage="Ingrese Login" ForeColor="Red" ControlToValidate="txtLogin" runat="server" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto">
                            <asp:TextBox ID="txtPassword" placeholder="Password" runat="server" textmode="Password" Class="form-control" FilterType="Numbers,Custom"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" ErrorMessage="Ingrese Password" ForeColor="Red" ControlToValidate="txtPassword" runat="server" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto text-center">
                            <asp:Button ID="btnAgregar" runat="server" type="submit" OnClick="btnAgregar_Click" class="btn btn-primary" Text="Agregar" CausesValidation="true" />
                        </div>
                        <div class="row gap-2 col-15 mx-auto text-center">
                            <label class="alert alert-danger" id="lblErrores" for="lblErrores" visible="false" runat="server"></label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
