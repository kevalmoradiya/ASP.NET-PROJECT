<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adminlogin.aspx.cs" Inherits="Adminlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
         .buttonchange:hover 
        {
           background: #660066;
           color:White;
           
        }
        
        .style4
        {
            margin-left:50px;
            margin-top:50px;
        }
        .style5
        {
            margin-left:50px;
            margin-top:50px;
        }
        .style1
        {
        height:auto;
	width: 998px;
	margin-top: 300px;
	margin-right: auto;
	margin-left: auto;
        }
    </style>
     <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body background="img/jskbackground.jpg">
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" BackColor="#333333" Width="500px" 
            CssClass="style1">
            <asp:Label ID="Label1" runat="server" Text="Username" CssClass="style4" 
                Font-Size="15pt" ForeColor="White"></asp:Label>
            <asp:TextBox ID="TextBox1"
                runat="server" CssClass="style5"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="Password" CssClass="style4" 
                Font-Size="15pt" ForeColor="White"></asp:Label>
            <asp:TextBox ID="TextBox2"
                runat="server" CssClass="style5" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Login" CssClass="buttonchange" 
                Font-Size="12pt" onclick="Button1_Click" />

            <asp:Label ID="Label3" runat="server" Font-Size="12pt" ForeColor="#CC0000" 
                Text="Label" Visible="False" Width="200px"></asp:Label>
            <br />

            <br />

        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
