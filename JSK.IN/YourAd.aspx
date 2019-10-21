<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YourAd.aspx.cs" MasterPageFile="~/Site.master" Inherits="YourAd" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        <table class="style1">
            <tr>
                <td>
                <div id="refineresult">

                    <asp:Panel ID="Panel4" runat="server" BackColor="#330066" Height="40px" 
                        BackImageUrl="~/img/backpanel.jpg">
                        <asp:Label ID="Label2" runat="server" Text="Refine your Result" 
                            Font-Size="18pt" ForeColor="White"></asp:Label>
                        
                    </asp:Panel>

                    <div id="refineresultq">
                    <br />
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                            DataSourceID="SqlDataSource1" DataTextField="Expr2" DataValueField="Expr1" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="200px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:jskConnectionString %>" 
                            SelectCommand="SELECT - 1 AS Expr1, '---Select---' AS Expr2 FROM state UNION SELECT id, state FROM state AS state_1">
                        </asp:SqlDataSource>
                        <br />
                        <br />
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                            DataSourceID="SqlDataSource2" DataTextField="Expr2" DataValueField="Expr1" 
                            onselectedindexchanged="DropDownList2_SelectedIndexChanged" Width="200px">
                        </asp:DropDownList>
                    
                    
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:jskConnectionString %>" 
                            SelectCommand="SELECT - 1 AS Expr1, '---Select---' AS Expr2, 1 AS Expr3 FROM city UNION SELECT id, city, idc FROM city AS city_1 WHERE (idc = @id)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="DropDownList1" Name="id" 
                                    PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    
                    
                        <br />
                    
                    
                        <br />
                        <asp:TextBox ID="TextBox2" runat="server" Width="40%"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="To" Width="9%"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" Width="40%"></asp:TextBox>
                    
                    
                        <br />
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                            oncheckedchanged="CheckBox1_CheckedChanged" Text="Price" />
                        <br />
                        <br />
                    
                    
                    </div>


                </div>
                <div id="seeadh">
            
                    <asp:Panel ID="Panel5" runat="server" BackColor="#330066" Height="40px" 
                        Font-Size="16pt" ForeColor="White" BackImageUrl="~/img/backpanel.jpg">
                        &nbsp;&nbsp;&nbsp; Image&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date&nbsp;
                        
                    </asp:Panel>

                    

                </div>
                <div id="seead" >

                    <asp:Panel ID="Panel6" runat="server"  BorderStyle="None" 
                        style="text-align: left">
                    </asp:Panel>
                     <asp:Panel ID="Panel1" runat="server"  BorderStyle="None" 
                        style="text-align: center">
                          <asp:Button ID="Button1" runat="server" Text="&lt;&lt; Previous" 
                               style="text-align: justify" onclick="Button1_Click" Font-Bold="True" 
                              ForeColor="White" BackColor="#333333" />
                          <asp:Label ID="Label3" runat="server" style="text-align: center" 
                              Font-Bold="True" Font-Italic="True" ForeColor="Black"></asp:Label>
                          <asp:Button ID="Button2" runat="server" Text="Next &gt;&gt;" 
                        style="text-align: center" onclick="Button2_Click" Font-Bold="True" 
                              ForeColor="White" BackColor="#333333" />
                    </asp:Panel>
                
                </div>

                    &nbsp;</td>
                </tr>
        </table>
    </asp:Content>

