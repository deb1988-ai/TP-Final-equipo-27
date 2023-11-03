<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Final_equipo_27.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col d-flex justify-content-center">
        <div class="card">
            <div class="row">
                <div class="col-3"></div>
                <div class="col-6">
                    <label id="lblUsuario">User:</label>
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </div>
                <div class="col-3"></div>
            </div>
            <div class="row">
                <div class="col-3"></div>
                <div class="col-6">
                    <label id="lblPassword">Pass:</label>
                    <asp:TextBox ID="txtPass" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div class="col-3"></div>
            </div>
            <div class="row">
                <div class="col-12">
                    <asp:Button ID="btnLogin" CssClass="btn btn-primary" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
