using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    HttpCookie cookie;
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string s = Session["Uname"].ToString();
            this.Page.Master.FindControl("LinkButton1").Visible = true;
            this.Page.Master.FindControl("LinkButton2").Visible = false;
            this.Page.Master.FindControl("LinkButton3").Visible = true;
            this.Page.Master.FindControl("HyperLink2").Visible = false;
        }
        catch
        {
            
            this.Page.Master.FindControl("LinkButton1").Visible = false;
            this.Page.Master.FindControl("LinkButton2").Visible = true;
            this.Page.Master.FindControl("LinkButton3").Visible = false;
            this.Page.Master.FindControl("HyperLink2").Visible = true;
        }
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s1 = "1" + TextBox1.Text;
        Response.Redirect("~/YourAd.aspx?ID=" + s1);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string s = Session["Uname"].ToString();
           
        }
        catch
        {
            
        }

        Response.Redirect("~/AddClassified.aspx");
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("User.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
        try
        {
            cookie = new HttpCookie(Session["Uname"].ToString(), "_Password");
            Response.Cookies.Add(cookie);            
            cookie.Expires = DateTime.Now.AddDays(-2d);
            Session.Abandon();
            Session.Clear();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
           // Response.Write("Successfully Logged out!!!");
            Response.Redirect("Home.aspx");
            
        }
        catch(Exception ee)
        {
            Response.Write(ee);
            
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignIn.aspx");
    }
}
