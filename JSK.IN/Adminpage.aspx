<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adminpage.aspx.cs"  Inherits="Adminpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        .style3
        {
            float:right;
        }
         .buttonchange:hover 
        {
           background: #660066;
           color:White;
        }
        
        
    </style>
    
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    
</head>
<body background="img/jskbackground.jpg">
   
<form id="form1" runat="server">

    
    <asp:Panel ID="Panel3" runat="server" Width="798px" CssClass="style3" 
        Height="1000px" Visible="False" BackColor="Silver">
         <br />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;

       
       
         <br />
         <asp:Panel ID="Panel5" runat="server" Visible="False">
         </asp:Panel>

        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="ButtonPanel" runat="server">
        <ContentTemplate>
        <asp:Panel ID="Panel7" runat="server" Visible="False">
        <asp:Button ID="Button7" runat="server" Text="Select All" 
                 CssClass="buttonchange" onclick="Button5_Click" />
             &nbsp;
             <asp:Button ID="Button8" runat="server" Text="Unselect All" 
                 CssClass="buttonchange" onclick="Button6_Click" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="Button9" runat="server" onclick="Button4_Click" 
                 Text="Delete Selected" CssClass="buttonchange" />
             <br />

        </asp:Panel>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button7" EventName="click" />
        </Triggers>
        </asp:UpdatePanel>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
         <asp:Panel ID="Panel6" runat="server" Visible="False" Height="436px">
             
             
           </asp:Panel>
             </ContentTemplate>
             
             </asp:UpdatePanel>

       
       
    </asp:Panel>
      <asp:Panel ID="Panel4" runat="server" Width="798px" CssClass="style3" 
        Height="1000px" Visible="False">
       
        </asp:Panel>
    

</form>


</body>
</html>
