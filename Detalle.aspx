<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TP_Final_equipo_27.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <div> 
<h3>Número de Incidente</h3>
<p>
<asp:Label ID="lbIdIncidente" CssClass="card-title" runat="server" Text=""></asp:Label>
</p>
<h3>Cliente</h3>
<p>
<asp:Label ID="lblCliente" CssClass="card-title" runat="server" Text=""></asp:Label>
</p>
<h3>Motivo</h3>
<p>
<asp:Label ID="lblmotivo" CssClass="card-title" runat="server" Text=""></asp:Label>
</p>
<h3>Responsable</h3>
<p>
<asp:Label ID="lblResponsable" CssClass="card-title" runat="server" Text=""></asp:Label>
</p>
<h3>Prioridad</h3>
<p>
<asp:Label ID="lblPrioridad" CssClass="card-title" runat="server" Text=""></asp:Label>
</p>
<h3>Descripción</h3>
<p>
<asp:Label ID="lblDescripcion" CssClass="card-title" runat="server" Text=""></asp:Label>
</p>
    </div>
    <br />
    <asp:Button ID="ButtonEditar" runat="server" class="btn btn-primary" Text="Editar" OnClick="ButtonEditar_Click" />
    <br />
    <br />
    <asp:Button ID="ButtonResolver" runat="server" class="btn btn-primary" Text="Resolver" OnClick="ButtonResolver_Click" />
</asp:Content>
