using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Removeaccount : System.Web.UI.Page
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

    }

    protected void printpanel()
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
        cmd.CommandText = "select uid,cname,email,id from userinfo where " + que + " order by uid ";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        DataSet ds1;
       


        no1 = ds.Tables[0].Rows.Count;
        ch1 = new CheckBox[no1];

        for (int i = 0; i < no1; i++)
        {
            ds1 = new DataSet();
            cmd.CommandText = "select username from userprofile where uid=" + Convert.ToInt32(ds.Tables[0].Rows[i][0]) + "";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds1);
            Panel p = new Panel();
            p.Attributes.CssStyle.Add("margin-top", "5px");
            p.BorderStyle = BorderStyle.Solid;
            p.BorderColor = System.Drawing.Color.Black;
            p.BorderWidth = Unit.Pixel(1);
            p.Height = Unit.Pixel(25);






            Label l1 = new Label();
            Label l2 = new Label();
            Label l3 = new Label();

            l1.Attributes.CssStyle.Add("Position", "Absolute");
            l2.Attributes.CssStyle.Add("Position", "Absolute");
            l3.Attributes.CssStyle.Add("Position", "Absolute");

            ch1[i] = new CheckBox();
            l1.Attributes.CssStyle.Add("margin-left", "100px");
            l2.Attributes.CssStyle.Add("margin-left", "450px");
            l3.Attributes.CssStyle.Add("margin-left", "250px");
            l1.Text = ds.Tables[0].Rows[i][1].ToString();
            l2.Text = ds.Tables[0].Rows[i][2].ToString();
            l3.Text = ds1.Tables[0].Rows[0][0].ToString();

            ch1[i].Attributes.CssStyle.Add("Position", "Absolute");
            ch1[i].Attributes.CssStyle.Add("margin-left", "20px");
            ch1[i].ID = ds.Tables[0].Rows[i][3].ToString();



            Panel2.Controls.Add(p);
            p.Controls.Add(ch1[i]);
            p.Controls.Add(l1);

            p.Controls.Add(l2);
            p.Controls.Add(l3);


        }


        ds.Clear();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        for (int i = 0; i < no1; i++)
        {
            ch1[i].Checked = false;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < no1; i++)
        {
            if (ch1[i].Checked)
            {
                deleteIt(Convert.ToInt32(ch1[i].ID));
            }
        }
     
    }


    protected void deleteIt(int idToDelete)
    {
      
        cmd = new SqlCommand("select uid from userinfo where id="+idToDelete+"", cnn);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        ds = new DataSet();
        da.SelectCommand = cmd;
        da.Fill(ds);

        int chk = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

        cmd = new SqlCommand("delete from usermsg where idp in (select idp from postad where idui=" + idToDelete + ")",cnn);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();

        cmd = new SqlCommand("delete from postad where idui=" + idToDelete + "", cnn);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();

        cmd = new SqlCommand("delete from userinfo where id=" + idToDelete + "", cnn);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();



        if (chk != 4)
        {
            cmd = new SqlCommand("delete from userprofile where uid="+chk+"", cnn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < no1; i++)
        {
            ch1[i].Checked = true;
        }

        ds.Clear();
    }
}