<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addetail.aspx.cs" MasterPageFile="~/Site.master" Inherits="Addetail" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        
        
        
        
        
        <table class="style4">
            <tr>
                <td>
                
                <div id="detail">
                
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="18pt" 
                        Height="50px" style="text-align: center" Text="Ad title" Width="610px"></asp:Label>
                    <asp:Image ID="Image2" runat="server" CssClass="imagedetail" Height="399px" 
                        Width="450px" ImageUrl="~/img/samsung_galaxy_s_duos.jpg" />
                
                
                    <br />
                    


                    <table class="style4">
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style5">
                                <asp:Label ID="Label8" runat="server" BackColor="#333333" CssClass="labl1" 
                                    Font-Size="16pt" ForeColor="White" Height="50px" Text="Label" 
                                    Width="150px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" BackColor="#666666" CssClass="labl2" 
                                    Font-Size="16pt" ForeColor="White" Height="50px" Text="Label" 
                                    Width="150px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style5">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    


                <hr />
                    <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True" TextMode="MultiLine" 
                        Width="350px" Rows="8"></asp:TextBox>

                </div>

  
                <div id="responseemail">
                
                
                
                    <asp:Panel ID="Panel3" runat="server" Height="654px" 
                        BackImageUrl="~/img/backemailpanel.jpg" BackColor="#333333">


                    <div id="sendemail1">
                        <asp:Label ID="Label4" runat="server" Text="Jaimin" Font-Size="15pt" 
                            Height="50px" style="text-align: left" Width="200px" CssClass="emiallable"></asp:Label>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Jaimin" Font-Size="15pt" 
                            Height="50px" style="text-align: left" Width="200px" CssClass="emiallable"></asp:Label>
                            <br />

                        <asp:Label ID="Label5" runat="server" Text="Baroda,India" Font-Size="15pt" 
                            Height="50px" style="text-align: left" Width="250px" CssClass="emiallable"></asp:Label>
                        <br />

                        <asp:Label ID="Label6" runat="server" Text="9825254121" Font-Bold="True" 
                            Font-Size="20pt" Height="50px" style="text-align: left" Width="200px" 
                            CssClass="emiallable"></asp:Label>
                        <br />
                    
                    <h2>&nbsp; Send Email ::
                    </h2>

                    
                    
                        &nbsp; Name :
                        <br />
                        &nbsp;
                        <asp:TextBox ID="TextBox1" runat="server" Width="200px" Height="30px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        <asp:Label ID="Label2" runat="server" Text="*Required" Visible="false" ForeColor="Red"></asp:Label>
                        <br />
                        &nbsp; Email :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        &nbsp;
                        <asp:TextBox ID="TextBox2" runat="server" Width="200px" Height="30px"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            <asp:Label ID="Label10" runat="server" Text="*Required" Visible="false" ForeColor="Red"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="Invalid" ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <br />
                        &nbsp; Phone Number :<br />&nbsp;
                        <asp:TextBox ID="TextBox3" runat="server" Width="200px" Height="30px"></asp:TextBox>
                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            <asp:Label ID="Label11" runat="server" Text="*Required" Visible="false" ForeColor="Red"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="Invalid" ForeColor="Red" 
                            ValidationExpression="^((\\+91-?)|0)?[0-9]{10}$"></asp:RegularExpressionValidator>
                        <br />
                        &nbsp; Message :&nbsp;<br />&nbsp;
                        <asp:TextBox ID="TextBox4" runat="server" Height="100px" TextMode="MultiLine" 
                            Width="200px" CssClass="textemail"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            <asp:Label ID="Label12" runat="server" Text="*Required" Visible="false" ForeColor="Red"></asp:Label>
                            <br />
                       &nbsp; <asp:Button ID="Button1" runat="server" Text="Send" 
                            CssClass="buttonchange" Font-Bold="True" Font-Size="15pt" 
                            onclick="Button1_Click" />
                    
                    
                        
                    
                    
                    
                        <br />
                        <asp:Label ID="Label9" runat="server" Width="200px"></asp:Label>
                        
                    
                    
                        
                    
                    
                    
                    </div>
                    </asp:Panel>
                
                
                
                </div>
               
                   
               
                    

                    &nbsp;</td>
            </tr>
        </table>
        <table>
        <tr>
        <td>
            &nbsp;</td>
        </tr>
        
        </table>
        
        
        
        
    </asp:Content>

    <asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
        <style type="text/css">
        
     .imagedetail
     {
      margin-left:75px;
     
     }  
        
     .labl1
     {
       margin-left:80px;
            text-align: center;
           
        }
     
     .labl2
     {
         
        margin-left:0px;
            text-align: center;
           
        }   
        
      .emiallable
      {
       margin-left:15px;   
        
          
      }  
      .textemail
      {
          margin-bottom:20px; 
        
        
    }
        .style5
        {
            width: 245px;
        }
       .buttonchange:hover 
        {
           background: #660066;
           color:White;
        }
        
        
    </style>
</asp:Content>