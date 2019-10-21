<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User.aspx.cs" MasterPageFile="~/Site.master" Inherits="User" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
         <script type="text/javascript">
             window.onload = function () {
                 var e = document.getElementById("refreshed");
                 if (e.value == "no") e.value = "yes";
                 else { e.value = "no"; location.reload(); }
             }
    
    </script>
    <input type="hidden" id="refreshed" value="no" />
        
        
        
        <table class="style4">
        

      
            <tr>
                <td>
            <div id="userfieldm">
            <div id="menu">
           
			
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="menu" 
                    BackColor="#999999" ImageUrl="~/img/button1.jpg" Height="70px" 
                    Width="230px">My Ads</asp:HyperLink><br />
                <asp:HyperLink ID="HyperLink2" runat="server" CssClass="menu" 
                    ImageUrl="~/img/button2.jpg" Height="70px" Width="230px">My Msg</asp:HyperLink><br />
                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="menu" 
                    ImageUrl="~/img/button3.jpg" Height="70px" Width="230px">Change Password</asp:HyperLink><br />
                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="menu" 
                    ImageUrl="~/img/button4.jpg" Height="70px" Width="230px">Edit Profile</asp:HyperLink>
			
		   </div>



            </div>
            <div id="userfieldmi">
                <asp:Panel ID="Panel2" runat="server">
                    
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        
                        Height="25px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        Width="200px" DataSourceID="SqlDataSource1" DataTextField="Expr2" 
                        DataValueField="Expr1">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:jskConnectionString %>" 
                        SelectCommand="SELECT - 1 AS Expr1, '---Select---' AS Expr2 FROM selection UNION SELECT id, name FROM selection AS selection_1">
                    </asp:SqlDataSource>
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                       
                        Height="25px" Width="200px" DataSourceID="SqlDataSource2" 
                        DataTextField="Expr2" DataValueField="Expr1">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:jskConnectionString %>" 
                        SelectCommand="SELECT - 1 AS Expr1, '---Select---' AS Expr2 FROM selection UNION SELECT id, name FROM selection AS selection_1">
                    </asp:SqlDataSource>
                </asp:Panel>
                <div id="seead">
                <asp:Panel ID="Panel1" runat="server">
                </asp:Panel>
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Panel ID="Panel3" runat="server" BorderColor="#330066" BorderStyle="Solid" 
                    BorderWidth="1px">
                    <table class="style4">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" BackColor="#333333" Font-Bold="True" 
                                    ForeColor="White" Height="25px" style="text-align: center" Text="Ad Title" 
                                    Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                </td>
                            <td class="style5">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:Button ID="Button3" runat="server" CssClass="buttonchange" 
                                    Font-Bold="True" Height="30px" onclick="Button3_Click" Text="Ok" Width="70px" />
                                    </ContentTemplate>
                                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
                        </Triggers> 
                                    </asp:UpdatePanel>
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
                                <asp:Label ID="Label2" runat="server" BackColor="#333333" Font-Bold="True" 
                                    ForeColor="White" Height="25px" style="text-align: center" Text="Price" 
                                    Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" Height="25px" Width="200px"></asp:TextBox>
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
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                           <ContentTemplate>
                                <asp:Button ID="Button4" runat="server" CssClass="buttonchange" 
                                    Font-Bold="True" Height="30px" onclick="Button4_Click" Text="Ok" Width="70px" />
                                         </ContentTemplate>
                                         <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button4" EventName="Click" />
                        </Triggers> 
                                         </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                </td>
                            <td class="style6">
                                </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" BackColor="#333333" Font-Bold="True" 
                                    ForeColor="White" Height="25px" style="text-align: center" Text="Image" 
                                    Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:Label ID="Label5" runat="server"></asp:Label>
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
                             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                           <ContentTemplate>
                                <asp:Button ID="Button5" runat="server" CssClass="buttonchange" 
                                    Font-Bold="True" Height="30px" onclick="Button5_Click" Text="Ok" Width="70px" />
                                    </ContentTemplate>
                                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button5" EventName="Click" />
                        </Triggers> 
                                    </asp:UpdatePanel>
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
                                <asp:Label ID="Label4" runat="server" BackColor="#333333" Font-Bold="True" 
                                    ForeColor="White" Height="25px" style="text-align: center" Text="Description" 
                                    Width="80px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server" Height="100px" Width="250px" 
                                    Columns="200" Rows="7" TextMode="MultiLine"></asp:TextBox>
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
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                           <ContentTemplate>
                                <asp:Button ID="Button6" runat="server" CssClass="buttonchange" 
                                    Font-Bold="True" Height="30px" onclick="Button6_Click" Text="Ok" Width="70px" />
                                    </ContentTemplate>
                                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button6" EventName="Click" />
                        </Triggers> 
                                    </asp:UpdatePanel>
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
                    </table>

                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" Visible="False">
                </asp:Panel>

            </div>
                    &nbsp;</td>
            </tr>
           
        </table>
         
        
        
        
        
    </asp:Content>


    <asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
        <style type="text/css">
       
       .menu
       {
           display: block;
	letter-spacing: 1px;
	line-height: 70px;
	text-decoration: none;
	text-align: center;
	font-size: 20px;
	font-weight: 600;
	border: none;
	color: #ffffff;
	
	background: #330066;
           
           
       }
       
        .buttonchange:hover 
        {
           background: #660066;
           color:White;
        }
        .style5
        {
            height: 34px;
        }
        .style6
        {
            height: 23px;
        }
       
        </style>
</asp:Content>