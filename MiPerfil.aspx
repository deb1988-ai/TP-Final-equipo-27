<%@ Page Title="" Language="C#" MasterPageFile="~/MasterConSidebar.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TP_Final_equipo_27.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="main-body">

            <div class="row gutters-sm">
                <div class="col-md-4 mb-3">
                    <div class="card">
                        <div class="card-body">
                            <div class="d-flex flex-column align-items-center text-center">
                                <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="Admin" class="rounded-circle" width="150">
                                <div class="mt-3">
                                    <h4>
                                        <asp:Label ID="lblLogin" runat="server" Text="Label"></asp:Label></h4>
                                    <asp:Label ID="lblPerfil" runat="server" Text="Label" CssClass="text-secondary mb-1"></asp:Label>

                                    <p class="text-muted font-size-sm"></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="card mb-3">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Nombre</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
                                    <asp:TextBox ID="txtNombre" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Apellido</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="lblApellido" runat="server" Text="Label"></asp:Label>
                                     <asp:TextBox ID="txtApellido" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Email</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                                     <asp:TextBox ID="txtEmail" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Telefono</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="lblTelefono" runat="server" Text="Label"></asp:Label>
                                     <asp:TextBox ID="txtTelefono" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Contraseña</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    <asp:Label ID="lblContraseña" runat="server" Text="************"></asp:Label>
                                     <asp:TextBox ID="txtContraseña" runat="server" Visible="false" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:ImageButton ID="btnMostrarContraseña" runat="server" ImageUrl="~/Icons/view.png" OnClick="btnMostrarContraseña_Click" Width="24" Height="24"/>
                                </div>
                            </div>
                            <hr>
                            <div class="row">
                                <div class="col-sm-12">
                                     <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" CssClass="btn btn-info" />
                                     <asp:Button ID="btnAceptarCambios" runat="server" Text="Aceptar" OnClick="btnAceptarCambios_Click" CssClass="btn btn-info" Visible="false"/>
                                     <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="btnCerrarSesion_Click" CssClass="btn btn-secondary" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

   
</asp:Content>
