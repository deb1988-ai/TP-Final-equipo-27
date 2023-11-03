<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaIncidente.aspx.cs" Inherits="TP_Final_equipo_27.AltaIncidente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <label>Motivo</label>
        <asp:DropDownList ID="ddlMotivo" runat="server"></asp:DropDownList>
        <br />
    </div>
    <div>
        <label>Descripción</label>
        <br />
        <asp:TextBox CssClass="form-control" ID="txtDescripcion" runat="server" Rows="3"></asp:TextBox>
        <br />
        <br />
    </div>

    <asp:Button ID="btnAgregar" CssClass="btn-primary" runat="server" Text="Alta Incidente" OnClick="btnAgregar_Click" />

</asp:Content>
