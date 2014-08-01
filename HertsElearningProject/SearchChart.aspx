<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchChart.aspx.cs" Inherits="HertsElearningProject.SearchChart" %>

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
            <td><center>Top 5 Search Keywords</center></td>
        </tr>
        <tr>
            <td><asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="285px" Width="313px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Pie" XValueMember="Keyword" YValueMembers="Hit"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HertsOnlineEntities %>" SelectCommand="SELECT TOP 5 Keyword, Hit FROM Search ORDER BY Hit DESC"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>

