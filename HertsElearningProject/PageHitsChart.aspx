<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageHitsChart.aspx.cs" Inherits="HertsElearningProject.PageHitsChart" %>

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
            <td><center>Top 10 Page Hits Per Page </center></td>
        </tr>
        <tr>
            <td><asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="289px" Width="661px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Area" XValueMember="PageName" YValueMembers="Hit"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT TOP 10 PageName, Hit FROM PageHits ORDER BY Hit DESC"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
