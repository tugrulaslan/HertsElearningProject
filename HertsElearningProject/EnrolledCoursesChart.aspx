<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnrolledCoursesChart.aspx.cs" Inherits="HertsElearningProject.EnrolledCoursesChart" %>

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
            <td><center>Top 10 Enrolled Courses Per Course</center></td>
        </tr>
        <tr>
            <td><asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="264px" Width="544px">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="CourseName" YValueMembers="Total"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT CourseName, COUNT(*) AS Total FROM StudentCourses GROUP BY CourseName HAVING (COUNT(*) &gt; 1)"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
