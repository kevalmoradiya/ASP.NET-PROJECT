<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" MasterPageFile="~/Site.master" Inherits="Register" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        <table class="style1" style="height: 50px">
            <tr>
                <td>
                 <asp:Label ID="Label1" runat="server" Font-Size="18pt" Text="Register"></asp:Label>

                    &nbsp;</td>
            </tr>
        </table>

       

        <div id="register">
        
        <table>
        <tr>
        <td class="style6">
            <asp:Label ID="Label8" runat="server" Text="Name"></asp:Label>
        </td>
        <td class="style7">
            <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBox1" ErrorMessage="* Mandatory Field" ForeColor="Red"></asp:RequiredFieldValidator>--%>
            <asp:Label ID="Label7" runat="server" Text="*Mandatory Field" Visible="false" ForeColor="Red"></asp:Label>
        </td>
        </tr>
        
         <tr>
        <td class="style6">
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
        </td>
        <td class="style7">
            <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox3" ErrorMessage="Invalid Email" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ForeColor="Red"></asp:RegularExpressionValidator>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="TextBox3" ErrorMessage="* Mandatory Field" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:Label ID="Label11" runat="server" Text="*Mandatory Field" Visible="false" ForeColor="Red"></asp:Label>
        </td>
        </tr>

         <tr>
        <td class="style6">
        </td>
        <td class="style7">
            <asp:Label ID="Label6" runat="server" Text="Your email address won't be shared"></asp:Label>
          
        </td>
        </tr>
        <tr>
        <td class="style6">
            <asp:Label ID="Label9" runat="server" Text="Phone Number"></asp:Label>
        </td>
        <td class="style7">
            <asp:TextBox ID="TextBox5" runat="server" Width="200px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="TextBox5" ErrorMessage="Invalid PhoneNumber" ForeColor="Red" 
                ValidationExpression="^((\\+91-?)|0)?[0-9]{10}$"></asp:RegularExpressionValidator>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="TextBox5" ErrorMessage="* Mandatory Field" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:Label ID="Label12" runat="server" Text="*Mandatory Field" Visible="false" ForeColor="Red"></asp:Label>
        </td>
        </tr>
        <tr>
        <td class="style6">
            <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
        </td>
        <td class="style7">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
              <asp:UpdatePanel ID="Email_Edit" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Width="200px" AutoPostBack="true" 
                                OnTextChanged="TextBox8_OnTextChanged"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TextBox8" ErrorMessage="* Mandatory Field" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                <asp:Label ID="Label13" runat="server" Text="*Mandatory Field" Visible="false" ForeColor="Red"></asp:Label>
                       </ContentTemplate>
                       <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="TextBox8" EventName="TextChanged" />
                       </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel runat="server" ID="Label_Update">
                        <ContentTemplate>
                   <asp:Label ID="User_Validation" runat="server" ForeColor="Red"></asp:Label>
                   </ContentTemplate>
                   </asp:UpdatePanel>
        </td>
        </tr>
         <tr>
        <td class="style6">
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
        </td>
        <td class="style7">
            <asp:TextBox ID="TextBox4" runat="server" Width="200px"></asp:TextBox>
           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="TextBox4" ErrorMessage="* Mandatory Field" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:Label ID="Label14" runat="server" Text="*Mandatory Field" Visible="false" ForeColor="Red"></asp:Label>
        </td>
        </tr>
        <tr>
        <td class="style6">
            <asp:Label ID="Label10" runat="server" Text="Confirm Password"></asp:Label>
        </td>
        <td class="style7">
            <asp:TextBox ID="TextBox6" runat="server" Width="200px"></asp:TextBox>
           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="TextBox6" ErrorMessage="* Mandatory Field" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                <asp:Label ID="Label15" runat="server" Text="*Mandatory Field" Visible="false" ForeColor="Red"></asp:Label>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="TextBox4" ControlToValidate="TextBox6" 
                ErrorMessage="Password Mismatch" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
        </td>
        </tr>
         <tr>
        <td class="style6">
            <asp:Label ID="Label5" runat="server" Text="I Am"></asp:Label>
        </td>
        <td class="style7">
            <asp:RadioButton ID="RadioButton1" runat="server" Text="An Individual" 
                Checked="true" GroupName="group"/>
            <asp:RadioButton ID="RadioButton2" runat="server" 
                Text="A Professional/Business " GroupName="group" />
        </td>
        </tr> 
        <tr>
        <td class="style6">
        </td>
        <td class="style7">
&nbsp;</td>
        </tr> <tr>
        <td class="style6">
        </td>
        <td class="style7">
            <asp:Button ID="Button3" runat="server" Text="Register" Width="76px" 
                onclick="Button3_Click" />
        </td>
        </tr> <tr>
        <td class="style3">
        </td>
        <td class="style2">
            &nbsp;</td>
        </tr>
        
        </table>
        
        
        
        
        
        
        </div>



    </asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 977px;
        }
        .style3
        {
            width: 157px;
        }
        .style6
        {
            width: 157px;
            height: 30px;
        }
        .style7
        {
            width: 977px;
            height: 30px;
        }
    </style>
</asp:Content>



