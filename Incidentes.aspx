<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Incidentes.aspx.cs" Inherits="TP_Final_equipo_27.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <p>Filtrar por:</p>
    <asp:DropDownList ID="DropDownListFiltro" runat="server" OnSelectedIndexChanged="DropDownListFiltro_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

    <%if (DropDownListFiltro.SelectedIndex > 0)
        {
    %>
    <%if (DropDownListFiltro.SelectedIndex == 1)
        {
    %>
    <asp:DropDownList ID="ddlFechaAnio" runat="server" OnSelectedIndexChanged="ddlFechaAnio_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <asp:DropDownList ID="ddlFechaMes" runat="server" OnSelectedIndexChanged="ddlFechaMes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

    <%  }
        else if (DropDownListFiltro.SelectedIndex == 2)
        { %>
    <asp:DropDownList ID="ddlClientes" runat="server" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <% }
        else if (DropDownListFiltro.SelectedIndex == 3)
        { %>
    <asp:DropDownList ID="ddlResponsable" runat="server" OnSelectedIndexChanged="ddlResponsable_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <% }%>

    <asp:Button ID="ButtonFiltrar" runat="server" Text="Filtrar" OnClick="ButtonFiltrar_Click" CssClass="btn btn-light" AutoPostBack="true" />
    <%  } %>

    <br />
    <br />
<asp:GridView runat="server" Class="table table-bordered table-condensed table-hover" ID="dgvIncidentes" AutoGenerateColumns="false" DataKeyNames="IdIncidente" OnRowCommand="dgvIncidentes_RowCommand" OnRowDataBound="dgvIncidentes_RowDataBound">
    <Columns>
            <asp:BoundField HeaderText="IdIncidente" DataField="IdIncidente" />
            <asp:BoundField HeaderText="Motivo" DataField="Motivo.motivo" />
            <asp:BoundField HeaderText="Responsable" DataField="Responsable.DatosPersonales.Nombre"/>
            <asp:BoundField HeaderText="Prioridad" DataField="Prioridad.Prioridad" />
            <asp:BoundField HeaderText="Estado" DataField="Estado.estado" SortExpression="Estado"/>
            <asp:BoundField HeaderText="Fecha de alta" DataField="FechaCreacion" DataFormatString="{0:d}" />
            <asp:BoundField HeaderText="Fecha última modificación" DataField="FechaUltimaModificacion" DataFormatString="{0:d}" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton Text="Ver detalle" runat="server" ID="btnDetalle" CommandName="btnDetalle" CommandArgument='<%#Eval("IdIncidente") %>' />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
</asp:Content>
