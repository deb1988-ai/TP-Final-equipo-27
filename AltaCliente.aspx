<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="TP_Final_equipo_27.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="lblNombreCliente">Nombre</label>
                <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6">
                <label for="lblApellidoCliente">Apellido </label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>             
            </div>
            <div class="form-group col-md-6">
                <label for="lblEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="lblTelefono">Telefono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" FilterType="Numbers,Custom"></asp:TextBox>
        </div>
        <br />
        <button type="submit" class="btn btn-primary">Agregar</button>
    </form>
</asp:Content>
