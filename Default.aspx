<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Final_equipo_27.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col d-flex justify-content-center">
        <div class="card justify-content-center">
            <div class="card-body">
                <div class="d-grid gap-2 col-15 mx-auto">
                    <div class="row gap-2 col-15 mx-auto">
                        <asp:TextBox class="form-control" ID="txtLogin" runat="server" placeholder="user"></asp:TextBox>
                    </div>
                    <div class="row gap-2 col-15 mx-auto">
                        <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" runat="server" placeholder="password"></asp:TextBox>
                    </div>
                    <div class="row gap-2 col-15 mx-auto">
                        <asp:Label Text="" ID="lblMensaje" Visible="false" runat="server" Font-Size="Smaller" />
                    </div>
                    <asp:Button ID="btnLogin" CssClass="btn btn-primary" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnSignIn" CssClass="btn btn-secondary" runat="server" Text="Crear Usuario" OnClick="btnSignIn_Click" />
                    <div class="row gap-2 col-15 mx-auto text-center">
                        <asp:LinkButton ID="linkBtnContraseña" runat="server" OnClick="linkBtnContraseña_Click">Olvide mi contraseña</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
