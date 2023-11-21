﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contraseña.aspx.cs" Inherits="TP_Final_equipo_27.Contraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col d-flex justify-content-center">
    <div class="card justify-content-center">
        <div class="card-body">
            <div class="d-grid gap-2 col-12 mx-auto">
                <h2>¿Olvidaste tu contraseña?</h2>
                <p>Ingresá el usuario con el que te registraste y la contraseña al E-Mail registrado</p>
                <div class="row gap-2 col-12 mx-auto">
                    <asp:TextBox class="form-control" ID="txtUsuario" runat="server" placeholder="user"></asp:TextBox>
                </div> 
                <asp:Button ID="btnEnviar" CssClass="btn btn-primary" runat="server" Text="Enviar contraseña" OnClick="btnEnviar_Click" />
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</div>
</asp:Content>
