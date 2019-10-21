<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

     <style type="text/css">
        .style1
        {
    height:auto;
	width: 998px;
	margin-top: 15px;
	margin-right: auto;
	margin-left: auto;
	
        }
        .style2
        {
            float:left;
        }
        .style3
        {
            float:right;
        }
        
        
    </style>
    
</head>
<body>
   
<form id="form1" runat="server">
<asp:Panel ID="Panel1" runat="server" CssClass="style1"  >
    
    <asp:Panel ID="Panel2" runat="server" Width="200px" CssClass="style2">
        <br />
        <asp:Button ID="Button1" runat="server" Text="User Management" Width="150px" 
            onclick="Button1_Click" /><br />
        <br />

        <asp:Button ID="Button2" runat="server" Text="Send Message" Width="150px" 
            onclick="Button2_Click1" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
    
    <asp:Panel ID="Panel3" runat="server" Width="798px" CssClass="style3" 
        Height="1000px" Visible="False">
         <br />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Height="35px" Width="200px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Height="35px" Text="Search User" 
                Width="100px" onclick="Button3_Click" />

       
       
         <br />
         <asp:Panel ID="Panel5" runat="server" Visible="False">
         </asp:Panel>

        
         
         <asp:Panel ID="Panel6" runat="server" Visible="False">
             asa</asp:Panel>
            
       
       
    </asp:Panel>
      <asp:Panel ID="Panel4" runat="server" Width="798px" CssClass="style3" 
        Height="1000px" Visible="False">
       
        </asp:Panel>
    
</asp:Panel>
</form>


</body>
</html>
