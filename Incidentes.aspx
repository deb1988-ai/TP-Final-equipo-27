﻿<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Incidentes.aspx.cs" Inherits="TP_Final_equipo_27.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" CssClass="table" ID="dgvIncidentes" AutoGenerateColumns="false" DataKeyNames="IdIncidente" OnRowCommand="dgvIncidentes_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="IdIncidente" DataField="IdIncidente" />
            <asp:BoundField HeaderText="Motivo" DataField="Motivo.motivo" />
            <asp:BoundField HeaderText="Responsable" DataField="responsable.Nombre" />
            <asp:BoundField HeaderText="Estado" DataField="estado.estado" />
            <asp:BoundField HeaderText="Fecha de alta" DataField="fechaCreacion" />
            <asp:BoundField HeaderText="Fecha última modificación" DataField="fechaUltimaModificacion" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton Text="Ver detalle" runat="server" ID="btnDetalle" CommandName="btnDetalle" CommandArgument='<%#Eval("IdIncidente") %>' />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
</asp:Content>
