<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="TP_Final_equipo_27.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .espaciado-filas td {
            padding-bottom: 20px;
        }
    </style>
    <form>
        <div class="container mx-auto justify-content-center">
            <div class="card justify-content-center">
                <div class="card-body">
                    <div class="form-row">
                        <div class="d-grid gap-2 col-6 mx-auto">
                            <div class="row gap-2 col-15 mx-auto">
                                <table class="espaciado-filas">
                                    <tr>
                                        <td>
                                            <label for="lblNombreCliente">Nombre</label></td>
                                        <td>
                                            <asp:TextBox ID="txtNombreCliente" runat="server" Class="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvNombre" ErrorMessage="Ingrese Nombre" ForeColor="Red" ControlToValidate="txtNombreCliente" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="lblApellidoCliente">Apellido </label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtApellido" runat="server" Class="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvApellido" ErrorMessage="Ingrese apellido" ForeColor="Red" ControlToValidate="txtApellido" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="lblEmail">Email</label></td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" Class="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:Label ID="lblErrorEmail" Text="" runat="server" Visible="false" ForeColor="Red" Font-Size="Smaller"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="lblTelefono">Telefono</label></td>
                                        <td>
                                            <asp:TextBox ID="txtTelefono" runat="server" Class="form-control" FilterType="Numbers,Custom"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="lblTipoCliente">Tipo de Usuario</label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlTiposUsuario" Class="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtLogin" runat="server" Class="form-control" FilterType="Numbers,Custom"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblErrorLogin" Text="" runat="server" Visible="false" ForeColor="Red" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" Class="form-control" FilterType="Numbers,Custom"></asp:TextBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="width=30%"></td>
                                        <td style="width=40%">
                                            <asp:Button ID="btnAgregar" runat="server" type="submit" OnClick="btnAgregar_Click" class="btn btn-primary" Text="Agregar" CausesValidation="true" /></td>
                                        <td style="width=30%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
