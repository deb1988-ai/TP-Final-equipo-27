<%@ Page Title="" Language="C#" MasterPageFile="~/MasterConSidebar.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TP_Final_equipo_27.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Datos Personales</h3>
    <div>
        <p>Nombre: </p>
        <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <p>Apellido: </p>
        <asp:Label ID="lblApellido" runat="server" Text="Label"></asp:Label>
    </div>

    <div>
        <p>Teléfono</p>
        <asp:Label ID="lblTelefono" runat="server" Text="Label"></asp:Label>
    </div>
    <h3>Detalles de usuario</h3>
    <div>
        <p>E-Mail:</p>
        <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <p>Usuario:</p>
        <asp:Label ID="lblLogin" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
        <p>Perfil de usuario:</p>
        <asp:Label ID="lblPerfil" runat="server" Text="Label"></asp:Label>
    </div>


    <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar sesión" OnClick="btnCerrarSesion_Click" CssClass="btn btn-secondary"/>
</asp:Content>
