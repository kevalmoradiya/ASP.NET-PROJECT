<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adminadman.aspx.cs" MasterPageFile="~/Adminmaster.master" Inherits="Adminadman" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">



    <asp:Panel ID="Panel1" runat="server">
    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Select All" 
            CssClass="buttonchange" onclick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2"
            runat="server" Text="Unselect All" CssClass="buttonchange" 
            onclick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Delete Selected" 
            CssClass="buttonchange" onclick="Button3_Click" />
    
             <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">

    </asp:Panel>
        

        
</asp:Content>

 
