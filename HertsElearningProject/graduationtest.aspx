<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="graduationtest.aspx.cs" Inherits="HertsElearningProject.graduationtest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
<asp:ScriptManager ID= "SM1" runat="server"></asp:ScriptManager>
<asp:Timer ID="timer1" runat="server" 
Interval="1000" OnTick="timer1_tick"></asp:Timer>
<asp:UpdatePanel id="updPnl" 
runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:Label ID="lblTimer" runat="server"></asp:Label>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="timer1" EventName ="tick" />
</Triggers>
</asp:UpdatePanel>
</div>
    <div>
    
        <h2>Questions</h2><hr />
        <b>1.What is the file format of an Asp page?</b>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>ASPX</asp:ListItem>
            <asp:ListItem>PHP</asp:ListItem>
            <asp:ListItem>CLASS</asp:ListItem>
            <asp:ListItem>JAVA</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <b>2.Which of the following operating system belongs to Microsoft?</b>
        <asp:RadioButtonList ID="RadioButtonList2" runat="server">
            <asp:ListItem>LINUX</asp:ListItem>
            <asp:ListItem>MAC</asp:ListItem>
            <asp:ListItem>WINDOWS</asp:ListItem>
            <asp:ListItem>ANDROID</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <b>3.Which of the following RDBMS belongs to Microsoft?</b>
        <asp:RadioButtonList ID="RadioButtonList3" runat="server">
            <asp:ListItem>MYSQL</asp:ListItem>
            <asp:ListItem>MSACCESS</asp:ListItem>
            <asp:ListItem>NOSQL</asp:ListItem>
            <asp:ListItem>ORACLE</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <b>4.Which of the following IDE belongs to Microsoft?</b>
        <asp:RadioButtonList ID="RadioButtonList4" runat="server">
            <asp:ListItem>INTELLIJ</asp:ListItem>
            <asp:ListItem>NETBEANS</asp:ListItem>
            <asp:ListItem>ECLIPSE</asp:ListItem>
            <asp:ListItem>VS</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <b>5.Which of the following framework belongs to Microsoft?</b>
        <asp:RadioButtonList ID="RadioButtonList5" runat="server">
            <asp:ListItem>SPRING</asp:ListItem>
            <asp:ListItem>.NET</asp:ListItem>
            <asp:ListItem>JSF</asp:ListItem>
            <asp:ListItem>ZKOSS</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Finish" />
        <br />
    
    </div>
    </form>
</body>
</html>
