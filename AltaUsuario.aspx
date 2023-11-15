<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="TP_Final_equipo_27.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form>
        <div class="container mx-auto justify-content-center">
            <div class="card justify-content-center">
                <div class="card-body">
                    <div class="form-row">
                        <div class="d-grid gap-2 col-6 mx-auto">
                            <div class="row gap-2 col-12 mx-auto">
                                <label for="lblNombreCliente">Nombre</label>
                                <asp:TextBox ID="txtNombreCliente" runat="server" Class="form-control"></asp:TextBox>
                            </div>
                            <div class="row gap-2 col-12 mx-auto">
                                <label for="lblApellidoCliente">Apellido </label>
                                <asp:TextBox ID="txtApellido" runat="server" Class="form-control"></asp:TextBox>
                            </div>
                            <div class="row gap-2 col-12 mx-auto">
                                <label for="lblEmail">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" Class="form-control"></asp:TextBox>
                            </div>
                            <div class="row gap-2 col-12 mx-auto">
                                <label for="lblTelefono">Telefono</label>
                                <asp:TextBox ID="txtTelefono" runat="server" Class="form-control" FilterType="Numbers,Custom"></asp:TextBox>
                            </div>
                            <div class="row gap-2 col-12 mx-auto">
                                <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
                                <asp:TextBox ID="txtLogin" runat="server" Class="form-control" FilterType="Numbers,Custom"></asp:TextBox>
                            </div>
                            <div class="row gap-2 col-12 mx-auto">
                                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" Class="form-control" FilterType="Numbers,Custom"></asp:TextBox>
                            </div>
                            <div class="row gap-2 col-12 mx-auto">
                                <label for="lblTipoCliente">TipoUsuario</label>
                                <asp:DropDownList ID="ddlTiposUsuario" Class="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <br />
                            <div class="row gap-2 col-3 mx-auto">
                                <asp:Button ID="btnAgregar" runat="server" type="submit" OnClick="btnAgregar_Click" class="btn btn-primary" Text="Agregar" />
                            </div>   
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
