<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adminsendmessage.aspx.cs" MasterPageFile="~/Adminmaster.master" Inherits="Adminsendmessage" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
   
   <h1>&nbsp; Enter Message::</h1>
    &nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Height="164px" TextMode="MultiLine" 
        Width="456px"></asp:TextBox>

    &nbsp;<asp:Button ID="Button3" runat="server" Font-Size="11pt" Text="Send" 
        Width="70px" onclick="Button3_Click" CssClass="buttonchange" />
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" 
        Width="150px"></asp:Label>
    <asp:Panel ID="Panel1" runat="server">
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Height="30px" Width="180px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" Height="30px" onclick="Button4_Click" 
            Text="Search" Width="80px" CssClass="buttonchange" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <asp:Button ID="Button1" runat="server" Text="Select All" 
            onclick="Button1_Click" CssClass="buttonchange" />
        &nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Button ID="Button2"
            runat="server" Text="Unselect All" onclick="Button2_Click" 
                CssClass="buttonchange" />
            <br />
            </ContentTemplate>
            <Triggers>
    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="click" />
    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="click" />
    </Triggers>
            </asp:UpdatePanel>
    </asp:Panel>
    


     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <ContentTemplate>    <asp:Panel ID="Panel2" runat="server">
    </asp:Panel>
    </ContentTemplate>

    
      </asp:UpdatePanel>
      

</asp:Content>


