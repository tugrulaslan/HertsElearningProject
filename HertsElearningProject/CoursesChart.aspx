<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoursesChart.aspx.cs" Inherits="HertsElearningProject.CoursesChart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td><center>Top 10 Courses</center></td>
        </tr>
        <tr>
            <td><asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="264px" Width="544px">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="CourseName" YValueMembers="CourseCredits"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT TOP 10 CourseName, CourseCredits FROM Courses ORDER BY CourseCredits DESC"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
