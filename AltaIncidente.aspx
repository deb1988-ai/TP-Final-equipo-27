<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaIncidente.aspx.cs" Inherits="TP_Final_equipo_27.AltaIncidente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Formulario de alta de Incidente</h3>
    <br />

    <div>
        <label>Cliente:</label>
        <asp:DropDownList ID="ddlCliente" runat="server"></asp:DropDownList>
        <br />
        <br />
    </div>

    <div>
        <label>Motivo del incidente:</label>
        <asp:DropDownList ID="ddlMotivo" runat="server"></asp:DropDownList>
        <asp:ImageButton ID="ImageButtonAdd" ImageUrl="~/Icons/Add.png" runat="server" OnClick="ImageButtonAdd_Click" Height="15" Width="15" AlternateText="Agregar Motivo" />
        <asp:TextBox ID="TextBoxMotivos" runat="server" Visible="false"></asp:TextBox>
        <asp:Button ID="btnAgregarMotivo" Text="Agregar Motivo" OnClick="btnAgregarMotivo_Click" runat="server" Visible="false" />
        <br />
        <br />
    </div>
    <div>
        <label>Prioridad:</label>
        <asp:DropDownList ID="ddlPrioridad" runat="server"></asp:DropDownList>
        <br />
        <br />
    </div>
    <div>
        <label>Descripción:</label>
        <br />
        <asp:TextBox CssClass="form-control" ID="txtDescripcion" runat="server" Rows="3"></asp:TextBox>
        <br />
        <br />
    </div>

    <asp:Button ID="btnAgregar" CssClass="btn-primary" runat="server" Text="Alta Incidente" OnClick="btnAgregar_Click" />

</asp:Content>
