<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Incidentes.aspx.cs" Inherits="TP_Final_equipo_27.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" CssClass="table" ID="dgvIncidentes" AutoGenerateColumns="false" DataKeyNames="IdIncidente" OnRowCommand="dgvIncidentes_RowCommand">
    <Columns>
        <asp:BoundField HeaderText="IdIncidente" DataField="IdIncidente" />
    </Columns>
</asp:GridView>
</asp:Content>
