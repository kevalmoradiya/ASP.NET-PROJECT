using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;


public partial class Adminsendmessage : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    
    Panel[] pp;
    CheckBox[] ch1;
    static int id;
    static int no1;
    static int uid;
    protected void Page_Load(object sender, EventArgs e)
    {
        cnn.Open();
        cmd.Connection = cnn;
        printpanel();
        Label1.Visible = false;
    }

    protected void printpanel()
    {
        string s1 = TextBox2.Text;
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



        no1 = ds.Tables[0].Rows.Count;
        ch1 = new CheckBox[no1];
        
        for (int i = 0; i < no1; i++)
        {
            Panel p = new Panel();
            p.Attributes.CssStyle.Add("margin-top", "5px");
            p.BorderStyle = BorderStyle.Solid;
            p.BorderColor = System.Drawing.Color.Black;
            p.BorderWidth = Unit.Pixel(1);
            p.Height = Unit.Pixel(25);






            Label l1 = new Label();
            Label l2 = new Label();

            l1.Attributes.CssStyle.Add("Position", "Absolute");
            l2.Attributes.CssStyle.Add("Position", "Absolute");

            ch1[i] = new CheckBox();
            l1.Attributes.CssStyle.Add("margin-left", "100px");
            l2.Attributes.CssStyle.Add("margin-left", "250px");
            l2.Text = ds.Tables[0].Rows[i][3].ToString();
            l1.Text = ds.Tables[0].Rows[i][2].ToString();
            ch1[i].Attributes.CssStyle.Add("Position", "Absolute");
            ch1[i].Attributes.CssStyle.Add("margin-left", "20px");
            ch1[i].ID = ds.Tables[0].Rows[i][0].ToString();



            Panel2.Controls.Add(p);
            p.Controls.Add(ch1[i]);
            p.Controls.Add(l1);

            p.Controls.Add(l2);


        }


        ds.Clear();

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
       // printpanel();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < no1; i++)
        {
            ch1[i].Checked = true;        
        }
      
            ds.Clear();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string s1 = TextBox2.Text;
        string que;

        if (s1 != null || s1 != "")
        {
            que = "cname LIKE '%" + s1 + "%'";
        }
        else
        {
            que = "1=2";
        }
        cmd = new SqlCommand("select id,email from userinfo where " + que + " order by uid ", cnn);
        cmd.CommandType = CommandType.Text;
        da = new SqlDataAdapter();
        ds = new DataSet();

        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int nn = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());

        for (int i = 0; i < nn; i++)
        {
            if (ch1[i].Checked == true)
            {
              
                sendmail(ds.Tables[0].Rows[i][1].ToString());
            }
        }

        ds.Clear();
    }

    protected void sendmail(String address)
    {
        Label1.Visible = true;
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            mail.To.Add(address);
            mail.From = new MailAddress("jskserver.info@gmail.com");
            mail.Subject = "From JSK Server";
            mail.Priority = MailPriority.High;

            string Body = "Hi..." + TextBox1.Text;
            mail.Body = Body;

            mail.IsBodyHtml = true;

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
                 ("jskserver.info@gmail.com", "%hacker%");

            smtp.EnableSsl = true;
            smtp.Send(mail);
            
            Label1.Text = "Send Successfully";
            Label1.Attributes.Add("ForeColor", "Green");

        }
        catch (Exception e1)
        {

            Label1.Text = "Send Failed";
            Label1.Attributes.Add("ForeColor", "Red");

        }
     
    
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
     
        for (int i = 0; i < no1; i++)
        {
            ch1[i].Checked =false;
        }
    }

} 
