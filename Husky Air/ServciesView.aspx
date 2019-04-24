<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServciesView.aspx.cs" Inherits="Husky_Air.ServciesView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        <br />
    </p>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
                <asp:BoundField DataField="No_of_Passengers" HeaderText="No_of_Passengers" SortExpression="No_of_Passengers" />
                <asp:BoundField DataField="source" HeaderText="source" SortExpression="source" />
                <asp:BoundField DataField="destination" HeaderText="destination" SortExpression="destination" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HuskyAirConnectionString %>" SelectCommand="SELECT * FROM [Services]"></asp:SqlDataSource>
        <div>
        </div>
    </form>
</body>
</html>
