using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    static int check = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if(check==1)
        {
              
        string s1 = TextBox1.Text;
       
        cnn.Open();
        cmd.Connection = cnn;
        cmd.CommandText = "select id,uid,cname,email from userinfo where cname LIKE '%"+s1+"%' order by uid ";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);

        

        int no=ds.Tables[0].Rows.Count;
        System.Windows.Forms.MessageBox.Show(no.ToString());

        for (int i = 0; i < no; i++)
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


            Panel5.Controls.Add(p);
            p.Controls.Add(l1);
            p.Controls.Add(b1);
            p.Controls.Add(l2);

        
        }
        ds.Clear();




        }
       

       
    }

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        Panel3.Visible = true;

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel4.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        check = 1;
        Panel5.Visible = true;
    }
  
    protected void b1_Command(object sender, CommandEventArgs e)
    {
        
        Panel5.Visible = false;
        Panel6.Visible = true;


        string p1 = e.CommandArgument.ToString();
        string[] st = p1.Split('s');
        int uid = Convert.ToInt32(st[0]);
        int id = Convert.ToInt32(st[1]);
        System.Windows.Forms.MessageBox.Show(id.ToString() + "  " + uid.ToString());
        ds = new DataSet();
        cmd.CommandText="select idp,title,image,description from postad where idui="+id+"";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int no = ds.Tables[0].Rows.Count;
     


       for (int i = 0; i < no; i++)
        {
            Panel p = new Panel();
            p.Attributes.CssStyle.Add("margin-top", "10px");
            p.BorderStyle = BorderStyle.Solid;
            p.BorderColor = System.Drawing.Color.Black;
            p.BorderWidth = Unit.Pixel(1);
            p.Height = Unit.Pixel(100);
            CheckBox ch1 = new CheckBox();


            Image im = new Image();
            im.Height = Unit.Pixel(100);
            im.Width = Unit.Pixel(100);

            HyperLink h = new HyperLink();



            Label l1 = new Label();
            Label l2 = new Label();
            h.Attributes.CssStyle.Add("Position", "Absolute");
            l1.Attributes.CssStyle.Add("Position", "Absolute");
            l2.Attributes.CssStyle.Add("Position", "Absolute");
            h.Attributes.CssStyle.Add("margin-left", "10px");
            h.Attributes.CssStyle.Add("margin-top", "40px");
            l1.Attributes.CssStyle.Add("margin-top", "40px");
            l2.Attributes.CssStyle.Add("margin-top", "40px");
            l1.Attributes.CssStyle.Add("margin-left", "300px");
            l2.Attributes.CssStyle.Add("margin-left", "400px");
            ch1.Attributes.CssStyle.Add("Position", "Absolute");
           ch1.Attributes.CssStyle.Add("margin-left", "600px");
            ch1.ID = ds.Tables[0].Rows[i][0].ToString();
            ch1.Attributes.CssStyle.Add("margin-top", "40px");

            Panel6.Controls.Add(p);
            p.Controls.Add(im);
            p.Controls.Add(h);
            p.Controls.Add(l1);
            p.Controls.Add(l2);
            p.Controls.Add(ch1);




           string s = ds.Tables[0].Rows[i][2].ToString();
            im.ImageUrl = "~/img/" + s;
            h.Text = ds.Tables[0].Rows[i][1].ToString();
            l1.Text = ds.Tables[0].Rows[i][3].ToString();
           
        }






       ds.Clear();
    }
   
   
   }
