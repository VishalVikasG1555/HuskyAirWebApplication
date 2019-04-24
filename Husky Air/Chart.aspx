<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chart.aspx.cs" Inherits="Husky_Air.Chart" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Charts and statistics</title>
   
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
<body style="height: 159px; width: 1230px">

      
     <ul>
  
     <li> <a href="Admin.aspx">Home</a></li>
      <li><a href="Stats.aspx">Flight Stats</a></li>
     
    </ul>

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Select the chart type "></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <asp:Chart ID="Chart1" runat="server" Height="382px" Width="902px" DataSourceID="SqlDataSource1">
            <series>
                <asp:Series XValueMember="Fuel" ChartType="Bar" Name="Series1" YValueMembers="Distance">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX Title="last 7 days"></AxisX>
                    <AxisY Title="Number of Reservation"></AxisY>
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HuskyAirConnectionString %>" SelectCommand="SELECT Fuel, Distance FROM JourneyDetails"></asp:SqlDataSource>
    </form>
</body>
</html>