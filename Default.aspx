<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Final_equipo_27.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="user" runat="server"></asp:TextBox>
            <asp:TextBox ID="pass" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonLogin" cssclass="btn btn-primary" runat="server" Text="Ingresar" />
        </div>
    </form>
</body>
</html>
