<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="TP_Final_equipo_27._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <p class="lead">Bienvenido al sistema de gestión de incidentes</p>
        </section>

        <div class="row">

            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="ClienteMasIncidentes">Cliente con mas incidentes reportados:</h2>
                <p>
                    <asp:Label ID="LabelCliebnteMasIncidentes" runat="server" Text="Label"></asp:Label>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="CantidadIncidentesTitle">Cantidad de incidentes Abiertos:</h2>
                <p>
                    <asp:Label ID="lblCantidad" runat="server" Text="Label"></asp:Label>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="CantIncidentesMes">Cantidad de incidentes ùltimo mes</h2>
                <p>
                    <asp:Label ID="lblCantIncidentesUltmes" runat="server" Text="Label"></asp:Label>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
