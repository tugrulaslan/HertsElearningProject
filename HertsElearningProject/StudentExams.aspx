<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentExams.aspx.cs" Inherits="HertsElearningProject.StudentExams" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
            <td><center>Total Correct Questions</center></td>
            <td><center>Total Incorrect Questions</center></td>
        </tr>
        <tr>
            <td>
                <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="TOTAL_QUESTIONS" YValueMembers="CORRECT_CORRECT">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT 
(SELECT COUNT(*) FROM StudentExam WHERE Correct='Correct')  AS CORRECT_CORRECT, 
(SELECT COUNT(Id)  FROM StudentExam) AS TOTAL_QUESTIONS"></asp:SqlDataSource>
                <br />
            </td>
            <td>
        <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2">
                    <Series>
                        <asp:Series Name="Series1" XValueMember="INCORRECT_CORRECT" YValueMembers="TOTAL_QUESTIONS">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT 
(SELECT COUNT(*) FROM StudentExam WHERE Correct='Incorrect')  AS INCORRECT_CORRECT, 
(SELECT COUNT(Id)  FROM StudentExam) AS TOTAL_QUESTIONS"></asp:SqlDataSource>
                <br />
            </td>

        </tr>
    </table>
    </div>
    </form>
</body>
</html>