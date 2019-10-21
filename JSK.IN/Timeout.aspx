<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Timeout.aspx.cs" Inherits="Timeout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style5
        {
            height: 23px;
        }
    </style>
    <meta http-equiv="refresh" content="1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style4">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                    ForeColor="Red" Text="Session has been Time OUT..."></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="2" style="text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Text="You will be redirected to SignIn Page in "></asp:Label>
                <asp:Label ID="Timer" runat="server"></asp:Label>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text=" Seconds..."></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

