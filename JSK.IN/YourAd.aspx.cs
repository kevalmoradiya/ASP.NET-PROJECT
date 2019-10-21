using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class YourAd : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    string id, price = "0", compare;
    static int pl;
   static int noofpanel,curpanelno;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        

        id = Request.QueryString["id"];
        string s1 = id.Substring(0, 1);
        id = id.Substring(1, id.Length - 1);
        int check = Convert.ToInt32(s1);
        string que1 = "1=1", que2 = "1=1",que3="1=1";

        if (check == 0)
        {
            que1 = "ins=" + id + "";
        }
        else if (check == 1)
        {
            que1 = "title LIKE '%" + id + "%'";
        }
        else if (check == 2)
        {
            que1 = "insu=" + id + "";
        }


        if (DropDownList1.SelectedIndex == -1 || DropDownList1.SelectedIndex == 0)
        {
            que2 = "1=1";

             
        }
        
        else if (DropDownList2.SelectedIndex == 0 || DropDownList1.SelectedIndex!=pl || DropDownList2.SelectedIndex == -1)
        {
            que2 = "locations=" + DropDownList1.SelectedValue + "";
           pl=DropDownList1.SelectedIndex;

        }
        else 
        {
            que2 = "locations=" + DropDownList1.SelectedValue + " and locationc=" + DropDownList2.SelectedValue + "";
           
        }
        if (CheckBox1.Checked)
        {
            que3 = "price >= " + Convert.ToDecimal(TextBox2.Text) + " and price <=" + Convert.ToDecimal(TextBox3.Text) + "";
        }
        else
        {
            que3="1=1";
        }
       
   
       
        cnn.Open();
        cmd.Connection = cnn;
        cmd.CommandText = "select image,title,price,date,idp from postad where " + que1 + " and " + que3 + " and " + que2 + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        noofpanel= ds.Tables[0].Rows.Count;
        if(!IsPostBack)
        curpanelno = 0;

        Button1.Visible = false;
        if (noofpanel <= 10)
        {
            Button2.Visible = false;
        }

        if(!IsPostBack)
        addtopanel(ds);


        cnn.Close();

    }


    protected void addtopanel(DataSet ds1)
    {
        String s;
        int no = curpanelno;
        Label3.Text="("+((curpanelno+1)/10+1).ToString()+")";
        for (int i = no; i < no+10 && i<noofpanel; i++)
        {
            curpanelno++;
            Panel p = new Panel();
            p.Attributes.CssStyle.Add("margin-top", "10px");
            p.BorderStyle = BorderStyle.Solid;
            p.BorderColor = System.Drawing.Color.Black;
            p.BorderWidth = Unit.Pixel(1);
            p.Height = Unit.Pixel(100);


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
            l2.Attributes.CssStyle.Add("margin-left", "500px");

            Panel6.Controls.Add(p);
            p.Controls.Add(im);
            p.Controls.Add(h);
            p.Controls.Add(l1);
            p.Controls.Add(l2);




            s = ds1.Tables[0].Rows[i][0].ToString();
            im.ImageUrl = "~/img/" + s;
            h.Text = ds1.Tables[0].Rows[i][1].ToString();
            compare = ds1.Tables[0].Rows[i][2].ToString();
            if (compare == price)
            {
                l1.Text = "Free";
            }
            else
            {
                l1.Text = "Rs." + ds1.Tables[0].Rows[i][2].ToString();
            }
            l2.Text = ds1.Tables[0].Rows[i][3].ToString();

            h.NavigateUrl = "~/Addetail.aspx/?id=" + ds1.Tables[0].Rows[i][4].ToString();

        }
       
 
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        curpanelno = 0;
        addtopanel(ds);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        curpanelno = 0;
        addtopanel(ds);
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        curpanelno = 0;
        addtopanel(ds);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel6.Controls.Clear();
        
        curpanelno=curpanelno-10;
        
        if (curpanelno % 10 == 0)
            curpanelno = curpanelno - 10;
        else
            curpanelno = curpanelno - curpanelno % 10;

        if (curpanelno == 0)
        {
            Button1.Visible = false;
        }
        else
        {
            Button1.Visible = true;
        }
        Button2.Visible = true;

        addtopanel(ds);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel6.Controls.Clear();
        
        if (curpanelno + 10 > noofpanel)
        {
            Button2.Visible = false;
        }
        else
        {
            Button2.Visible = true;
        }
        Button1.Visible = true; 
        addtopanel(ds);
    }
}