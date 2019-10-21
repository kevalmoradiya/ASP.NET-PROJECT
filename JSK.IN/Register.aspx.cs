using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;

public partial class Register : System.Web.UI.Page
{
    SqlConnection cnn;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataSet ds;
    HttpCookie cookie;

    protected void Page_Load(object sender, EventArgs e)
    {
       cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
       cmd = new SqlCommand();
       da = new SqlDataAdapter();
       ds = new DataSet();

        TextBox4.Attributes.Add("type", "password");
        TextBox6.Attributes.Add("type", "password");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int echeck = 0;

        if (TextBox1.Text == "" || TextBox1.Text == null)
        { Label7.Visible = true; echeck = 1; }
        else
        { Label7.Visible = false; }

        if (TextBox3.Text == "" || TextBox3.Text == null)
        { Label11.Visible = true; echeck = 1; }
        else
        { Label11.Visible = false; }

        if (TextBox5.Text == "" || TextBox5.Text == null)
        { Label12.Visible = true; echeck = 1; }
        else
        { Label12.Visible = false; }

        if (TextBox8.Text == "" || TextBox8.Text == null)
        { Label13.Visible = true; echeck = 1; }
        else
        { Label13.Visible = false; }

        if (TextBox4.Text == "" || TextBox4.Text == null)
        { Label14.Visible = true; echeck = 1; }
        else
        { Label14.Visible = false; }

        if (TextBox6.Text == "" || TextBox6.Text == null)
        { Label15.Visible = true; echeck = 1; }
        else
        { Label15.Visible = false; }

        if (echeck == 1)
        { return; }
        if (User_Validation.Text == "" || User_Validation.Text == null)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = "insert into userprofile values('" + TextBox8.Text + "','" + TextBox4.Text + "')";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;



            ds = new DataSet();
            cmd.CommandText = "select uid from userprofile where username='" + TextBox8.Text + "'";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
            int idc = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            int radio;
            if (RadioButton1.Checked)
               radio = 0;
            else
               radio = 1;
          

            cmd.CommandText = "insert into userinfo values('" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "'," + radio + "," + idc + ")";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            cnn.Close();

            Label7.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
            Label13.Visible = false;
            Label14.Visible = false;
            Label15.Visible = false;

            Session["Uname"] = idc.ToString();
            cookie = new HttpCookie(Session["Uname"].ToString(),"_Password");
            Response.Cookies.Add(cookie);
            Response.Redirect("SignIn.aspx");
        }
    }

    protected void TextBox8_OnTextChanged(object sender, EventArgs e)
    {
        
        cnn.Open();
        cmd.Connection = cnn;
        

        ds.Clear();
        ds = new DataSet();
        cmd.CommandText = "select uid from userprofile where username='" + TextBox8.Text + "'";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int cnt = ds.Tables[0].Rows.Count;
         if (cnt != 0)
         {
             User_Validation.Text = "Username already Exists!!!";
    
         }
         else
         {
             User_Validation.Text = "";
         }
         cnn.Close();
     
    }
}