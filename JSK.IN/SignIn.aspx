<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" MasterPageFile="~/Site.master" Inherits="SignIn" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    
   <%-- <script type="text/javascript" language="javascript">
        javascript: window.history.forward(1);    
    </script>--%>
    <table class="style1" style="height: 50px">
            <tr>
                <td>
                    
                    <asp:Label ID="Label1" runat="server" Font-Size="18pt" Text="Sign In"></asp:Label>
                    
                </td>
            </tr>
        </table>



    
  
  
  <div id="signin">
      <asp:Panel ID="Panel1" runat="server" BackColor="#330066" Font-Size="15pt" 
          ForeColor="White" Height="40px" BackImageUrl="~/img/backpanel.jpg">
          &nbsp; Already a member</asp:Panel>

      <table class="style22">
          <tr>
              <td class="style23" colspan="2">
                  <asp:Label ID="Label11" runat="server" ForeColor="Red"></asp:Label>
              </td>
          </tr>
          <tr>
              <td class="style23">
                  <asp:Label ID="Label8" runat="server" Text="Username or Email :" 
                      style="text-align: right"></asp:Label>
              </td>
              <td class="style23">
                  <asp:TextBox ID="TextBox5" runat="server" Height="22px" 
                      style="text-align: left; margin-left: 0px" Width="160px"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td class="style23">
                  <asp:Label ID="Label9" runat="server" Text="Password :" 
                      style="text-align: right"></asp:Label>
              </td>
              <td class="style23">
                  <asp:TextBox ID="TextBox6" runat="server" Height="22px" 
                      style="text-align: left" Width="160px" TextMode="Password"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td class="style23">
              </td>
              <td class="style23">
                  <asp:Button ID="Button5" runat="server" Height="30px" Text="Sign In" 
                      Width="80px" onclick="Button5_Click" />
              </td>
          </tr>
          <tr>
              <td class="style23">
              </td>
              <td class="style23">
                  <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" 
                      onclick="LinkButton1_Click">Forgot Password</asp:LinkButton>
              </td>
          </tr>
      </table>


           </div>
           
  <div id="email">
      <asp:Panel ID="Panel2" runat="server" BackColor="#330066" Height="40px" 
          Font-Size="14pt" ForeColor="White" BackImageUrl="~/img/backpanel.jpg">
          &nbsp;I don&#39;t have a JSK account - send me a link to access my Ads</asp:Panel>





           <table class="style22">
               <tr>
                   <td class="style24">
                   </td>
                   <td class="style24">
                   </td>
               </tr>
               <tr>
                   <td class="style24">
                       <asp:Label ID="Label10" runat="server" Text="Email :"></asp:Label>
                   </td>
                   <td class="style24">
                       <asp:TextBox ID="TextBox7" runat="server" Height="22px" Width="160px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="style24">
                   </td>
                   <td class="style24">
                   </td>
               </tr>
               <tr>
                   <td class="style24">
                   </td>
                   <td class="style24">
                       <asp:Button ID="Button6" runat="server" Height="30px" Text="Send" 
                           Width="80px" onclick="Button6_Click" />
                       <asp:Label ID="Label12" runat="server"></asp:Label>
                   </td>
               </tr>
      </table>





           </div>
       <br/>
    <div id="signinregister">
          
           <h2>If you do not have an account or never posted an ad on JSK:
           
               <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Register.aspx">Register</asp:HyperLink>
      
           </h2>
          
           </div>       

          </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style22
        {
            width: 100%;
            height: 220px;
        }
        .style23
        {
            height: 40px;
            text-align: justify;
        }
        .style24
        {
            height: 40px;
        }
    </style>




    
</asp:Content>


