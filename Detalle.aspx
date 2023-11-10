<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TP_Final_equipo_27.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <div class="card text-center">
        <div class="card-header">
            <asp:Label ID="lblEstado" CssClass="card-title" runat="server" Text=""></asp:Label>
        </div>
        <div class="card-header">
            Incidente N° 
            <asp:Label ID="lbIdIncidente" CssClass="card-title" runat="server" Text=""></asp:Label>
        </div>
        <div class="card-body">
            <h5 class="card-title">Cliente: 
                <asp:Label ID="lblCliente" CssClass="card-title" runat="server" Text=""></asp:Label></h5>
            <h5 class="card-subtitle mb-2 text-muted">Prioridad:
                <asp:Label ID="lblPrioridad" CssClass="card-title" runat="server" Text=""></asp:Label><asp:DropDownList ID="ddlPrioridad" CssClass="dropdown-toggle" runat="server" Visible="false"></asp:DropDownList></h5>
            <p class="card-text">
                Motivo:
                <asp:Label ID="lblmotivo" CssClass="card-title" runat="server" Text=""></asp:Label>
                <asp:DropDownList ID="ddlMotivo" runat="server" Visible="false"></asp:DropDownList>
            </p>
            <p class="card-text">
                Descripción:
                <asp:Label ID="lblDescripcion" CssClass="card-title" runat="server" Text=""></asp:Label>
            </p>
            <asp:TextBox CssClass="form-control mx-auto d-block" ID="txtDescripcion" runat="server" Visible="false"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonEditar" runat="server" class="btn btn-secondary" Text="Editar" OnClick="ButtonEditar_Click" />
            <asp:Button ID="ButtonAceptar" runat="server" class="btn btn-primary" Text="Aceptar cambios" OnClick="ButtonAceptar_Click" Visible="false" />
            <asp:Button ID="ButtonResolver" runat="server" class="btn btn-success" Text="Resolver" OnClick="ButtonResolver_Click" Visible="true" AutoPostBack="true" />
            <asp:Button ID="ButtonReabrir" runat="server" class="btn btn-success" Text="Resolver" OnClick="ButtonReabrir_Click" Visible="false" AutoPostBack="true" />
        </div>
        <footer class="blockquote-footer">
            Responsable: <cite title="Source Title">
                <asp:Label ID="lblResponsable" CssClass="card-title" runat="server" Text=""></asp:Label>
                <asp:DropDownList ID="ddlResponsable" runat="server" Visible="false"></asp:DropDownList>
        </footer>
        <div class="card-footer text-muted">
            Fecha creación: 
            <asp:Label ID="lblFechaCreacion" CssClass="card-title" runat="server" Text=""></asp:Label>
        </div>
        <div class="card-footer text-muted">
            Última modificación:
            <asp:Label ID="lblDias" CssClass="card-title" runat="server" Text=""> </asp:Label>
            días atras.
        </div>
        <div class="card-body">
            <asp:Button ID="ButtonCerrar" runat="server" class="btn btn-dark" Text="Cerrar Incidencia" OnClick="ButtonCerrar_Click" AutoPostBack="true" />
        </div>

    </div>
</asp:Content>
