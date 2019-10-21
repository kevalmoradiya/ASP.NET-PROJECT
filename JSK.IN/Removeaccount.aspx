<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Removeaccount.aspx.cs" MasterPageFile="~/Adminmaster.master" Inherits="Removeaccount" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="200px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1"
        runat="server" Text="Search" Height="30px" Width="100px" 
        onclick="Button1_Click" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <asp:Panel ID="Panel1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
       
    <ContentTemplate> 
        <asp:Button ID="Button2" runat="server" Text="Select All" 
            onclick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Button ID="Button3"
            runat="server" Text="UnselectAll" onclick="Button3_Click" />&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Button ID="Button4" runat="server" Text="DeleteSelected" 
            onclick="Button4_Click" />
            </ContentTemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="click" />
    <asp:AsyncPostBackTrigger ControlID="Button3" EventName="click" />
    <asp:AsyncPostBackTrigger ControlID="Button4" EventName="click" />
    </Triggers>
     </asp:UpdatePanel>
            </asp:Panel>
    
    </asp:Panel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

    <ContentTemplate>   
     <asp:Panel ID="Panel2" runat="server">

    </asp:Panel>
    </ContentTemplate>
        </asp:UpdatePanel>
  
</asp:Content>


