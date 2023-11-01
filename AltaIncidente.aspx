<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaIncidente.aspx.cs" Inherits="TP_Final_equipo_27.AltaIncidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <label>Motivo</label>
<asp:DropDownList ID="DropDownListMotivo" runat="server"></asp:DropDownList>
        <br />
    </div>
    <div>   
        <label>Descripción</label>
<br />
<asp:TextBox cssclass=form-control ID="TextBoxDescripcion" runat="server" Rows="3"></asp:TextBox>
<br />
<br />
    </div>

<asp:Button ID="ButtonAgregar" cssclass=btn-primary runat="server" Text="Alta Incidente" />
    
</asp:Content>
