<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TP_Final_equipo_27.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <div class="card text-center">
        <div class="card-header">
            Incidente N° 
            <asp:Label ID="lbIdIncidente" CssClass="card-title" runat="server" Text=""></asp:Label>
        </div>
        <div class="card-body">
            <h5 class="card-title">Cliente: 
                <asp:Label ID="lblCliente" CssClass="card-title" runat="server" Text=""></asp:Label></h5>
            <h5 class="card-subtitle mb-2 text-muted">Prioridad: 
                <asp:Label ID="lblPrioridad" CssClass="card-title" runat="server" Text=""></asp:Label></h5>
                <asp:DropDownList ID="ddlPrioridad" runat="server" Visible="false"></asp:DropDownList>
            <p class="card-text">
                Motivo:
                <asp:Label ID="lblmotivo" CssClass="card-title" runat="server" Text=""></asp:Label>
            </p>
            <p class="card-text">
                Descripción:
                <asp:Label ID="lblDescripcion" CssClass="card-title" runat="server" Text=""></asp:Label>
            </p>
            <asp:Button ID="ButtonEditar" runat="server" class="btn btn-primary" Text="Editar" OnClick="ButtonEditar_Click" />
            <asp:Button ID="ButtonResolver" runat="server" class="btn btn-success" Text="Resolver" OnClick="ButtonResolver_Click" />
        </div>
        <footer class="blockquote-footer">
            Responsable: <cite title="Source Title">
                <asp:Label ID="lblResponsable" CssClass="card-title" runat="server" Text=""></asp:Label>
        </footer>
        <div class="card-footer text-muted">
            Fecha creación:  <asp:Label ID="lblFechaCreacion" CssClass="card-title"  runat="server" Text=""></asp:Label>
        </div>
        <div class="card-footer text-muted">
            Última modificación: <asp:Label ID="lblDias" CssClass="card-title"  runat="server" Text=""> </asp:Label> días atras.
        </div>
    </div>
</asp:Content>
