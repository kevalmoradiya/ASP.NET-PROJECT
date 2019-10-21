using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class Timeout : System.Web.UI.Page
{
    static int i=3;
    protected void Page_Load(object sender, EventArgs e)
    {
        
            //Thread.Sleep(1000);
            Timer.Text = "" + i;
            if (i == 0)
            {
                i = 3;
                Response.Redirect("SignIn.aspx");
            }
            i--;
        
    }
}