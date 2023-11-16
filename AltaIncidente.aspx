<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaIncidente.aspx.cs" Inherits="TP_Final_equipo_27.AltaIncidente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col d-flex justify-content-center w-auto">
        <h3 class="align-content-center">Formulario de alta de Incidente</h3>
    </div>

    <br />
    <div class="col d-flex justify-content-center w-auto">
        <div class="card justify-content-right">
            <div class="card-body">
                <div class="d-grid gap-2 col-15 mx-auto">
                    <div class="form-row gap-2 col-15 mx-auto">
                        <div class="form-group col-md-15">
                            <label>Cliente:</label>
                            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="Gray"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-row gap-2 col-15 mx-auto">
                        <div class="form-group col-md-15">
                            <label>Motivo del incidente:</label>
                            <asp:DropDownList ID="ddlMotivo" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="Gray"></asp:DropDownList>
                            <asp:ImageButton ID="ImageButtonAdd" ImageUrl="~/Icons/Add.png" runat="server" OnClick="ImageButtonAdd_Click" Height="15" Width="15" AlternateText="Agregar Motivo" />
                        </div>
                    </div>
                    <div class="form-row gap-2 col-15 mx-auto">
                        <div class="form-group col-md-15">
                            <asp:TextBox ID="TextBoxMotivos" runat="server" Visible="false"></asp:TextBox>
                            <asp:Button ID="btnAgregarMotivo" Text="Agregar Motivo" OnClick="btnAgregarMotivo_Click" runat="server" Visible="false" CssClass="btn btn-outline-secondary" />
                            <asp:Label ID="lblErrorMotivo" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div class="form-row gap-2 col-15 mx-auto">
                        <div class="form-group col-md-15">
                            <label>Prioridad:</label>
                            <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="btn btn-outline-secondary dropdown-toggle" BackColor="white" ForeColor="gray"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-row gap-2 col-15 mx-auto">
                        <label>Descripción:</label>
                        <asp:TextBox CssClass="form-control" ID="txtDescripcion" runat="server" TextMode="MultiLine" Columns="20" Rows="3" Width="600px" Height="100px" onkeyup="updateCharCount()"></asp:TextBox>
                        <asp:Label ID="lblContador" runat="server" Text="0 caracteres" Font-Size="Smaller"/>
                        <script type="text/javascript">
                            function updateCharCount() {
                                var textBox = document.getElementById("<%= txtDescripcion.ClientID %>");
                                var label = document.getElementById("<%= lblContador.ClientID %>");
                                label.innerHTML = textBox.value.length + " caracteres.";
                                if (textBox.value.length >= 10) {
                                    label.classList.add("text-success");
                                } else {
                                    label.classList.remove("text-success");
                                }
                            }
                        </script>
                    </div>
                    <div class="form-row gap-2 col-15 mx-auto">
                        <asp:Label ID="lblErrorDescripción" runat="server" Text="" cssclass="text-danger" Font-Size="X-Small"></asp:Label>
                    </div>
                    <div class="form-row gap-2 col-3 mx-auto">
                        <asp:Button ID="btnAgregar" CssClass="btn btn-outline-secondary" runat="server" Text="Alta Incidente" OnClick="btnAgregar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
