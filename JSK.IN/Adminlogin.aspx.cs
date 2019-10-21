using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Adminlogin : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        cnn.Open();
        cmd.Connection = cnn;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        cmd.CommandText = "select username,password from adminlogin";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);

        if (ds.Tables[0].Rows[0][0].ToString() == TextBox1.Text && ds.Tables[0].Rows[0][1].ToString() == TextBox2.Text)
        {
            Response.Redirect("Adminhome.aspx");

        }
        else
        {
            Label3.Text = "Incorrect Username Or Password";
            
        }


    }
}