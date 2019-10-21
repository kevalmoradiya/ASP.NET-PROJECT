<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddClassified.aspx.cs" MasterPageFile="~/Site.master" Inherits="AddClassified" %>



<asp:Content runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
   
    <div id="post-box"> 
    <table class="style1">
         
        <tr>
            <td colspan="2">
        
        
                <asp:Panel ID="Panel2" runat="server" BackColor="#330066" Height="50px" 
                    BackImageUrl="~/img/backpanel.jpg">
                    <asp:Label ID="Label12" runat="server" Text="Post a Free Classified Ad:" Font-Bold="True" Font-Size="25" ForeColor="White"></asp:Label>
                </asp:Panel>
             
                   
                 
                   </td>
                   </tr>
                    <tr>
                    <td class="style9">

                            <asp:Label ID="Label16" runat="server" Text="Select a Category :    " 
                                style="text-align: right" Width="150px"></asp:Label>

                    </td>
                    <td class="style9">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                        <ContentTemplate>
                         <asp:DropDownList ID="DropDownList3" runat="server" 
                            
                            Width="200px" Height="22px" 
                            onselectedindexchanged="DropDownList3_SelectedIndexChanged1" 
                            DataSourceID="SqlDataSource1" DataTextField="Expr2" 
                            DataValueField="Expr1" AutoPostBack="True" >
                            <asp:ListItem>---Select---</asp:ListItem>
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                ControlToValidate="DropDownList3" ErrorMessage="*Required" ForeColor="Red" 
                                InitialValue="---Select---"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownList3" EventName="SelectedIndexChanged" />
                        </Triggers> 
                        </asp:UpdatePanel>
                       
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:jskConnectionString %>" 
                            SelectCommand="SELECT - 1 AS Expr1, '---Select---' AS Expr2 FROM selection UNION SELECT id, name FROM selection AS selection_1">
                        </asp:SqlDataSource>
                        
                    </td>
                    </tr>
                    <tr>
                    <td class="style2" style="text-align: right">
                    
                        <asp:Label ID="Label3" runat="server" Text="Select a Sub Category"></asp:Label>
                    </td>
                    <td class="style2">
                          <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                          <ContentTemplate>
                        <asp:DropDownList ID="DropDownList4" runat="server" 
                            Height="22px" onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                            Width="200px">
                            <asp:ListItem>---Select---</asp:ListItem>
                        </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                  ControlToValidate="DropDownList4" ErrorMessage="*Required" ForeColor="Red" 
                                  InitialValue="---Select---"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                          </asp:UpdatePanel>
                    </td>


                    
                    </tr>
                
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label1" runat="server" Text="Ad Title :     " 
                                style="text-align: left"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label2" runat="server" Text="Photo :"></asp:Label>
                        </td>
                        <td class="style3">
                        
                            <asp:FileUpload ID="FileUpload1" runat="server"/>
                                                   
                            <asp:Label ID="Label13" runat="server" Width="200px"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ErrorMessage="*Required" ForeColor="Red" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7" valign="top">
                            <asp:Label ID="Label14" runat="server" Text="Description :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox11" runat="server" Height="139px" Width="550px" 
                                TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox11"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label4" runat="server" Text="Price :"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:Label ID="Label10" runat="server" Text="Rupees"></asp:Label>
                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                            <asp:Label ID="Label11" runat="server" Text=".00"></asp:Label>
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Free" 
                                oncheckedchanged="CheckBox1_CheckedChanged" Visible="False"  />
                        
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox10"></asp:RequiredFieldValidator>
                        
                        </td>
                    </tr>

                    
                    <tr>

                        <td class="style6">
                            <asp:Label ID="Label7" runat="server" Text="Email :"></asp:Label>
                        </td>
                        <td class="style4">
                        <asp:UpdatePanel ID="Email_Edit" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TextBox8" runat="server" Width="300px" AutoPostBack="true" OnTextChanged="TextBox8_OnTextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox8"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="TextBox8" ErrorMessage="Invalid Email" ForeColor="Red" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                       </ContentTemplate>
                       <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="TextBox8" EventName="TextChanged" />
                       </Triggers>
                        </asp:UpdatePanel>
                        </td>
                    </tr>

                    
                    <tr>
                        
                        <td class="style6">
                         
                            <asp:Label ID="Label5" runat="server" Text="I Am :"></asp:Label>
                        </td>
                        <td class="style3">
                        <asp:UpdatePanel ID="Content8" runat="server">
                        <ContentTemplate>
                            <label for="identity_1">
                            
                                <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" 
                                GroupName="same" oncheckedchanged="RadioButton1_CheckedChanged" 
                                Text="An Individual " />
</label>
                            <label for="identity_2">
                                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="same" 
                                oncheckedchanged="RadioButton2_CheckedChanged" Text="A Professional/Business" />

</label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label6" runat="server" Text="Contact Name :" Width="112px" 
                                style="margin-left: 0px"></asp:Label>
                        </td>
                        <td class="style4">
                        <asp:UpdatePanel ID="Content9" runat="server">
                            <ContentTemplate>
                            <asp:TextBox ID="TextBox7" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                    ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>
                       </ContentTemplate>
                       </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            <asp:Label ID="Label8" runat="server" Text="Phone Number :"></asp:Label>
                        </td>
                        <td class="style5">
                        <asp:UpdatePanel ID="Content7" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="TextBox9" runat="server" OnTextChanged="TextBox9_OnTextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                ErrorMessage="*Required" ForeColor="Red" ControlToValidate="TextBox9"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="TextBox9" ErrorMessage="Invalid PhoneNumber" ForeColor="Red" 
                                ValidationExpression="^((\\+91-?)|0)?[0-9]{10}$"></asp:RegularExpressionValidator>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6" valign="middle">
                            <asp:Label ID="Label9" runat="server" Text="State  :"></asp:Label>
                        </td>
                        <td class="style3">
                         <asp:UpdatePanel ID="UpdatePanel3" runat="server" >
                        <ContentTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="132px" AutoPostBack="True" 
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged1" 
                                DataSourceID="SqlDataSource2" DataTextField="Expr2" DataValueField="Expr1"  >
                                <asp:ListItem>----Select----</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                ControlToValidate="DropDownList1" ErrorMessage="*Required" ForeColor="Red" 
                                InitialValue="---Select---"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                             <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
                        </Triggers> 
                            </asp:UpdatePanel>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="style6" valign="top">
                            <asp:Label ID="Label17" runat="server" Text="City  :"></asp:Label>
                        </td>
                        <td class="style3">
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:jskConnectionString %>" 
                                SelectCommand="SELECT - 1 AS Expr1, '---Select---' AS Expr2 FROM state UNION SELECT id AS Expr1, state AS Expr2 FROM state AS state_1">
                            </asp:SqlDataSource>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" >
                            <ContentTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="132px" 
                                onselectedindexchanged="DropDownList2_SelectedIndexChanged" >
                                <asp:ListItem>----Select----</asp:ListItem>
                            </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                    ControlToValidate="DropDownList2" ErrorMessage="*Required" ForeColor="Red" 
                                    InitialValue="---Select---"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                           </asp:UpdatePanel>&nbsp;</td>
                    </tr>
                    <tr>
                    <td>
                    
                    
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Post" BackColor="#333333" 
                            ForeColor="White" Height="35px" onclick="Button1_Click" Width="70px" 
                            CssClass="buttonchange" />
                    </td>
                    </tr>



     </table>
         
    
</div>
   
</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        
        .style2
        {
            height: 50px;
        }
        .style3
        {
            height: 50px;
        }
        .style4
        {
            height: 50px;
        }
        .style5
        {
            height: 50px;
        }
        .style6
        {
            height: 50px;
            width: 545px;
            text-align: right;
        }
        .style7
        {
            width: 545px;
            text-align: right;
            
        }
        .style9
        {
            height: 52px;
        }
        </style>
</asp:Content>



