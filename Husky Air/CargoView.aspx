<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargoView.aspx.cs" Inherits="Husky_Air.CargoView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HuskyAirConnectionString %>" SelectCommand="SELECT * FROM [Cargo]"></asp:SqlDataSource>
    </form>
</body>
</html>
