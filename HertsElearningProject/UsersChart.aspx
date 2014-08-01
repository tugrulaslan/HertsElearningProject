<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersChart.aspx.cs" Inherits="HertsElearningProject.UsersChart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
    <table>
        <tr>
            <td><center>Users Per Amount</center></td>
            </tr>
        <tr>
            <td><center><asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="246px">
            <Series>
                <asp:Series ChartType="Pie" Name="Series1" XValueMember="UserRole" YValueMembers="Total">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT UserRole, COUNT(*) AS Total FROM Users GROUP BY UserRole HAVING (COUNT(*) &gt; 1)"></asp:SqlDataSource>
    </center></td>
        </tr>
    </table>
    </div>
</body>
</html>
