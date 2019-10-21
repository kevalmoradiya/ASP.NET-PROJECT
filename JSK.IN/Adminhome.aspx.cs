using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Admin123 : System.Web.UI.Page
{

    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    static int check = 0;
    Panel[] pp;
    CheckBox[] ch1;
    static int id;
    static int no;
    static int uid;
    protected void Page_Load(object sender, EventArgs e)
    {
        cnn.Open();
            cmd.Connection = cnn;
        
        if(check==1)
        {
            string s1 = TextBox1.Text;
            string que;
    
            if (s1 != null || s1 != "")
            {
                que = "cname LIKE '%" + s1 + "%'";
            }
            else
            {
                que = "1=2";
            }
           
          

            ds = new DataSet();
            cmd.CommandText = "select id,uid,cname,email from userinfo where " + que + " order by uid ";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);



            int no1 = ds.Tables[0].Rows.Count;


            for (int i = 0; i < no1; i++)
            {
                Panel p = new Panel();
                p.Attributes.CssStyle.Add("margin-top", "10px");
                p.BorderStyle = BorderStyle.Solid;
                p.BorderColor = System.Drawing.Color.Black;
                p.BorderWidth = Unit.Pixel(1);
                p.Height = Unit.Pixel(30);




                Button b1 = new Button();


                Label l1 = new Label();
                Label l2 = new Label();

                l1.Attributes.CssStyle.Add("Position", "Absolute");
                l2.Attributes.CssStyle.Add("Position", "Absolute");

                l1.Attributes.CssStyle.Add("margin-left", "10px");
                l2.Attributes.CssStyle.Add("margin-left", "300px");
                l2.Text = ds.Tables[0].Rows[i][3].ToString();
                l1.Text = ds.Tables[0].Rows[i][1].ToString();

                b1.Attributes.CssStyle.Add("margin-left", "50px");
                b1.Attributes.CssStyle.Add("Position", "Absolute");


                b1.Attributes.CssStyle.Add("Width", "150px");
                b1.Attributes.CssStyle.Add("Height", "25px");
                b1.Text = ds.Tables[0].Rows[i][2].ToString();

                b1.Attributes.CssStyle.Add("text-align", "center");
                b1.ID = ds.Tables[0].Rows[i][1].ToString();
                b1.CommandArgument = b1.ID + "s" + ds.Tables[0].Rows[i][0].ToString();
                b1.Command += new CommandEventHandler(b1_Command);


                Panel2.Controls.Add(p);
                p.Controls.Add(l1);
                p.Controls.Add(b1);
                p.Controls.Add(l2);


            }
            check = 0;
            }

        ds.Clear();


    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        check = 1;
          
        

    }
    protected void b1_Command(object sender, CommandEventArgs e)
    {

       /* Panel5.Visible = false;
        Panel6.Visible = true;
        Panel7.Visible = true;*/

        string p1 = e.CommandArgument.ToString();
        string[] st = p1.Split('s');
        uid = Convert.ToInt32(st[0]);
        id = Convert.ToInt32(st[1]);

        Response.Redirect("~/Adminadman.aspx?ID=" + id);
    }
 



    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}