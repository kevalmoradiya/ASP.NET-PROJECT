using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;


public partial class Addetail : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    String s;

    
    string id,cnt,price="0",compare,compare1="0";
    
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
         id = Request.QueryString["id"];
        
        cnn.Open();
        cmd.Connection = cnn;
        cmd.CommandText = "select title,image,description,price,locations,locationc,date,idui from postad where idp=" + id + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
         int id2=Convert.ToInt32(ds.Tables[0].Rows[0][7].ToString());
        DataSet ds1 = new DataSet();
        cmd.Connection = cnn;
        cmd.CommandText = "select cname,email,phoneno,iam from userinfo where id=" + id2 + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds1);

        Label1.Text = ds.Tables[0].Rows[0][0].ToString();
        s = ds.Tables[0].Rows[0][1].ToString();
        Image2.ImageUrl = "~/img/" + s;
        TextBox5.Text = ds.Tables[0].Rows[0][2].ToString();
        compare = ds.Tables[0].Rows[0][3].ToString();
        if (compare == price)
        {
            Label8.Text = "Free";
        }
        else
        {
            Label8.Text="Rs." + ds.Tables[0].Rows[0][3].ToString();
        }
        Label4.Text = ds1.Tables[0].Rows[0][0].ToString();
        Label6.Text = ds1.Tables[0].Rows[0][2].ToString();
        int a=Int32.Parse(ds.Tables[0].Rows[0][4].ToString());
        int b=Int32.Parse(ds.Tables[0].Rows[0][5].ToString());
        Label7.Text = ds.Tables[0].Rows[0][6].ToString();
        

        if (compare1 == ds1.Tables[0].Rows[0][3].ToString())
        {
            Label3.Text = "An Individual ";
        }
        else
        {
            Label3.Text = "A Professional/Business ";

        }
        
       


        ds.Clear();
        ds=new DataSet();
        cmd.CommandText = "select state from state where id=" +a + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        string ss = ds.Tables[0].Rows[0][0].ToString();
        ds.Clear();
        ds = new DataSet();
        cmd.CommandText = "select city from city where id=" + b + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        string cc = ds.Tables[0].Rows[0][0].ToString();
        ds.Clear();
        Label5.Text=ss + "," + cc; 

        cmd.CommandText = "select idp from postad";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        cnt = ds.Tables[0].Rows.Count.ToString();
        ds.Clear();



    }

    
    
       

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        int echeck=0;

        if (TextBox1.Text == "" || TextBox1.Text == null)
        { Label2.Visible = true; echeck = 1; }
        else
        { Label2.Visible = false; }

        if (TextBox2.Text == "" || TextBox2.Text == null)
        { Label10.Visible = true; echeck = 1; }
        else
        { Label10.Visible = false; }

        if (TextBox3.Text == "" || TextBox3.Text == null)
        { Label11.Visible = true; echeck = 1; }
        else
        { Label11.Visible = false; }

        if (TextBox4.Text == "" || TextBox4.Text == null)
        { Label12.Visible = true; echeck = 1; }
        else
        { Label12.Visible = false; }

        if (echeck == 1)
        { return; }

       

       

      ds = new DataSet();
        cmd.CommandText = "select uid from userinfo where id in (select idui from postad where idp=" + id + ")";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int uu=Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        ds.Clear();

        cmd.CommandText = "insert into usermsg (uid,name,email,phonenumber,description,idp) values(" + uu + ",'" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "'," + id + ")";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        ds.Clear();
       
        
        cmd.CommandText = "select title from postad where idp="+id+"";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        string titl = ds.Tables[0].Rows[0][0].ToString();
        ds.Clear();
        ds = new DataSet();
        cmd.CommandText = "select email from userinfo where id in(select idui from postad where idp=" + id + ")";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);


        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            mail.To.Add(ds.Tables[0].Rows[0][0].ToString());
            mail.From = new MailAddress("jskserver.info@gmail.com");
            mail.Subject = titl;
            mail.Priority = MailPriority.High;

            string Body = "Hi..." + Environment.NewLine + "     My name is " + TextBox1.Text + " . " + TextBox4.Text + Environment.NewLine + ". " + "My Email Is :: " + TextBox2.Text + ". My Mobile No. Is :: " + TextBox3.Text;
            mail.Body = Body;

            mail.IsBodyHtml = true;

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
                 ("jskserver.info@gmail.com", "%hacker%");

            smtp.EnableSsl = true;
            smtp.Send(mail);
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            Label9.Text = "Send Successfully";
            Label9.Attributes.Add("ForeColor", "Green");
        
        }
        catch(Exception e1)
        {
           
            Label9.Text = "Send Failed";
            Label9.Attributes.Add("ForeColor", "Red");

        }
        Label2.Visible = false;
        Label10.Visible = false;
        Label11.Visible = false;
        Label12.Visible = false;
        
    }
}

   