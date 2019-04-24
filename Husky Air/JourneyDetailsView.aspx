<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JourneyDetailsView.aspx.cs" Inherits="Husky_Air.JourneyDetailsView" %>

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
 <li><a href="PilotView.aspx">Pilot</a></li>
     <li> <a href="AircraftView.aspx">Aircraft</a></li>
      <li><a href="CargoView.aspx">Cargo</a></li>
      <li><a href="HospitalView.aspx">Hospital</a></li>
       <li><a href="PatientView.aspx">Patient</a></li>
        <li><a href="Stats.aspx">Stats</a></li>
       <li><a href="Report.aspx">Generate Report</a></li> 
   <li><a href="DoctorView.aspx">Doctor</a></li> 
    </ul>

    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Orderid" HeaderText="Orderid" SortExpression="Orderid" />
                <asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="Duration" />
                <asp:BoundField DataField="Distance" HeaderText="Distance" SortExpression="Distance" />
                <asp:BoundField DataField="Fuel" HeaderText="Fuel" SortExpression="Fuel" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HuskyAirConnectionString %>" SelectCommand="SELECT * FROM [JourneyDetails]"></asp:SqlDataSource>
    </form>
</body>
</html>
