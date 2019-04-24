<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JourneyDetails.aspx.cs" Inherits="Husky_Air.JourneyDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>Journey Details</title>
    <style>
ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  overflow: hidden;
  background-color: #333;
}

li {
  float: left;
}

li a {
  display: block;
  color: white;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
}

li a:hover:not(.active) {
  background-color: #111;
}

.active {
  background-color: #4CAF50;
}
</style>
</head>
<body>
    <ul>
   <li><a href="Pilot.aspx">Pilot</a></li>
     <li> <a href="Index.aspx">Home</a></li>
      <li><a href="Stats.aspx">Flight Stats</a></li>
     
    </ul>


    <form id="form1" runat="server">
    <center><h1>Journey Details</h1></center>
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Orderid</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="id" DataValueField="id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Duration of Flight</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Distance Traveled</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Total Fuel Used</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HuskyAirConnectionString %>" SelectCommand="SELECT [id] FROM [Services]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
        <div>
        </div>
    </form>
</body>
</html>
