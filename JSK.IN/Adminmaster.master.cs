using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adminmaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Adminhome.aspx");
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Adminsendmessage.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Adminlogin.aspx");
    }
  
    protected void Button5_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Removeaccount.aspx");
    }
}
