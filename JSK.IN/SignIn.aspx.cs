using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Net.Mail;


public partial class SignIn : System.Web.UI.Page
{
    
    SqlConnection con;
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label11.Text = null;
            Label12.Text = null;

        }
        
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
        HttpCookieCollection cookie = Request.Cookies;
    

        if (cookie.Count > 0)
        {
            for (int i = 0; i < cookie.Count; i++)
            {
                
                string[] st = cookie[i].Name.Split('_');
                con.Open();
                cmd = new SqlCommand("select uid from userprofile where uid='" + st[0] + "'", con);

                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                try
                {
                    if (dr.Read())
                    {
                        Session["Uname"] = st[0];
                        Response.Redirect("User.aspx");

                    }
                    else
                    {
                        //Label3.Text = "Invalid Username or Password";
                    }
                }
                catch
                {
                    //Response.Write(ee);
                }

                dr.Close();
                con.Close();

            }
        }
       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox5.Text != "jskserver")
        {
            con.Open();
            SqlDataReader dr;

            cmd = new SqlCommand("select uid from userprofile where username='" + TextBox5.Text + "' and password='" + TextBox6.Text + "'", con);

            cmd.CommandType = CommandType.Text;

            dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                Session["Uname"] = dr["uid"].ToString();

                Response.Redirect("User.aspx");
            }
            else
            {
                Label11.Text = "Invalid Username Or Password";
            }
            dr.Close();
            con.Close();
        }
        else
        {
            Label11.Text = "Invalid Username Or Password";

        }
    }

    protected void sendemail()
    {
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        cmd.Connection = con;

        cmd.CommandText = "select email from userinfo where uid in(select uid from userprofile where username='" + TextBox5.Text + "')";

        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);

        if (ds.Tables[0].Rows.Count == 0)
        {
            Label11.Text = "Enter Valid UserName";
            return;
        }
        string emaail = ds.Tables[0].Rows[0][0].ToString();

        cmd.CommandText = "select password from userprofile where username='" + TextBox5.Text + "'";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            mail.To.Add(ds.Tables[0].Rows[0][0].ToString());
            mail.From = new MailAddress("jskserver.info@gmail.com");
            mail.Subject = "UserID and Password for JSK Account";
            mail.Priority = MailPriority.High;

            string Body = "Username:: " + TextBox5.Text + "  Password:: " + ds.Tables[0].Rows[0][0].ToString();
            mail.Body = Body;

            mail.IsBodyHtml = true;

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
                 ("jskserver.info@gmail.com", "%hacker%");

            smtp.EnableSsl = true;
            smtp.Send(mail);
            Label11.Text = "Password sent...";
        }
        catch
        {

            Label11.Text = "Network Error";
        }

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Random rm = new Random();
        int i, no;
        char[] st1 = new char[10];
        string st2 = "";
        for (i = 0; i < 10; i++)
        {
            no = rm.Next(10);
            st1[i] = Convert.ToChar(no);
            if (i % 3 == 0)
            {
                st1[i] = Convert.ToChar(no + 65);
                st2 += st1[i];
            }
            else
            {
                st2 = st2 + no.ToString();
            }
            // Response.Write(st1[i]+":");

        }

        // System.Windows.Forms.MessageBox.Show(st2);
        ds.Clear();
        con.Open();
        cmd = new SqlCommand("select uid from userinfo where email='" + TextBox7.Text + "' ", con);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int no1;
        if (ds.Tables[0].Rows.Count == 0)
        {
            Label12.Text = "Invalid EmailID";
            return;
        }
       
        DataSet ds1=new DataSet();

        cmd = new SqlCommand("select username,password from userprofile where uid="+Convert.ToInt32(ds.Tables[0].Rows[0][0])+" and username<>'jskserver'  ", con);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds1);
        int n1 = ds1.Tables[0].Rows.Count;
        string uname;
        uname = TextBox7.Text;
        if (n1 != 0)
        {
            uname = ds1.Tables[0].Rows[0][0].ToString();
            st2 = ds1.Tables[0].Rows[0][1].ToString();
        }
       

        try
        {
            

                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                mail.To.Add(TextBox7.Text);
                mail.From = new MailAddress("jskserver.info@gmail.com");
                mail.Subject = "JSk Regestration";
                mail.Priority = MailPriority.High;

                string Body = "Hi..." + Environment.NewLine + " Thank you for regestration... " + Environment.NewLine + " your username:" + uname + "" + Environment.NewLine + "Your Password:" + st2 + " ";
                mail.Body = Body;

                mail.IsBodyHtml = true;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                     ("jskserver.info@gmail.com", "%hacker%");

                smtp.EnableSsl = true;
                smtp.Send(mail);

                //cmd.Connection = con;
                if (n1 != 0)
                {
                    Label12.Text = "Password Sent...";
                    return;
                }
                cmd = new SqlCommand("insert into userprofile values('" + TextBox7.Text + "','" + st2 + "')", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ds.Clear();
                cmd = new SqlCommand("select uid from userprofile where username='" + TextBox7.Text + "' ", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);

                int uid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                cmd = new SqlCommand("update userinfo set uid=" + uid + " where email='" + TextBox7.Text + "' ", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                ds.Clear();
                ds = new DataSet();
                cmd = new SqlCommand("select id from userinfo where uid=" + uid + "", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);

                int idui = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

                cmd = new SqlCommand("update usermsg set uid=" + uid + " where idp in(select idp from postad where idui=" + idui + ") ", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                
                Label12.Text = "Password Sent...";
        }
        catch
        {
            Label12.Text = "Network Error";
            // System.Windows.Forms.MessageBox.Show(e.Message);

        }

        con.Close();


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        sendemail();
    }
}