<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formularioCierre.aspx.cs" Inherits="TP_Final_equipo_27.formularioCierre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div "form-group">
            <label for="exampleFormControlInput1">Motivo de cierre:</label>
            <br />
            <asp:TextBox ID="TextBoxCierre" runat="server" CssClass="form-control" TextMode="MultiLine" Columns="20" rows="3" Width="300px" Height="100px"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="ButtonCerrar" runat="server" CssClass="btn btn-dark" Text="Cerrar Incidencia" OnClick="ButtonCerrar_Click"/>
    </form>
</body>
</html>
