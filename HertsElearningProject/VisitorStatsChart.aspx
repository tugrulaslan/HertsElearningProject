<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitorStatsChart.aspx.cs" Inherits="HertsElearningProject.VisitorStatsChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
    
        <table>
            <tr>
                <td><center>Visitors Per Country</center>
        <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Width="544px" Height="264px">
            <Series>
                <asp:Series Name="Series1" XValueMember="Country" YValueMembers="Total">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT Country, COUNT(*) AS Total FROM VisitorStatistics GROUP BY Country HAVING (COUNT(*) &gt; 1)"></asp:SqlDataSource></td>
                <td><center>Visitors Per Operating System</center>
        <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2" Width="544px" Height="264px">
            <Series>
                <asp:Series ChartType="Bar" Name="Series1" XValueMember="OperatingSystem" YValueMembers="Total" YValuesPerPoint="2">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT OperatingSystem, COUNT(*) AS Total FROM VisitorStatistics GROUP BY OperatingSystem HAVING (COUNT(*) &gt; 1)"></asp:SqlDataSource></td>
            </tr>
            <tr>
                <td><center>Visitors Per Device</center>
       <center> <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource3" Height="264px">
            <Series>
                <asp:Series ChartType="Pie" Name="Series1" XValueMember="Device" YValueMembers="Total">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart></center>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT Device, COUNT(*) AS Total FROM VisitorStatistics GROUP BY Device HAVING (COUNT(*) &gt; 1)"></asp:SqlDataSource></td>
                <td><center>Visitors Per Browser</center>
        <asp:Chart ID="Chart4" runat="server" DataSourceID="SqlDataSource4" Width="544px" Height="264px">
            <Series>
                <asp:Series ChartType="Area" Name="Series1" XValueMember="BrowserName" YValueMembers="Total">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT BrowserName, COUNT(*) AS Total FROM VisitorStatistics GROUP BY BrowserName HAVING (COUNT(*) &gt; 1)"></asp:SqlDataSource></td>
            </tr>
        </table>
    </div>
</body>
</html>
