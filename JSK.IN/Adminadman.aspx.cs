using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Adminadman : System.Web.UI.Page
{
    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    int id;
    static int no;
    Panel[] pp;
    CheckBox[] ch1;
    protected void Page_Load(object sender, EventArgs e)
    {
        cnn.Open();
        cmd.Connection = cnn;
        id=Convert.ToInt32(Request.QueryString["ID"]);
        panel2Print(id);

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int[] idarray;

        cmd = new SqlCommand("Select idp from postad where idui=" + id + "", cnn);
        cmd.CommandType = CommandType.Text;
        da = new SqlDataAdapter();
        ds = new DataSet();

        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int nn = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());
        idarray = new int[nn];
        for (int i = 0; i < nn; i++)
        {

            idarray[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
        }


        for (int i = 0; i < no; i++)
        {


            int chkid = Convert.ToInt32(ch1[i].ID);
            for (int j = 0; j < nn; j++)
            {
                if (chkid == idarray[j])
                {

                    ch1[i].Checked = false;


                }
            }

        }
        ds.Clear();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int[] idarray;

        cmd = new SqlCommand("Select idp from postad where idui=" + id + "", cnn);
        cmd.CommandType = CommandType.Text;
        da = new SqlDataAdapter();
        ds = new DataSet();

        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int nn = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());
        idarray = new int[nn];
        for (int i = 0; i < nn; i++)
        {

            idarray[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
        }


        for (int i = 0; i < no; i++)
        {


            int chkid = Convert.ToInt32(ch1[i].ID);
            for (int j = 0; j < nn; j++)
            {
                if (chkid == idarray[j])
                {

                    ch1[i].Checked = true;


                }
            }

        }
        ds.Clear();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int[] idarray;


        cmd = new SqlCommand("Select idp from postad where idui=" + id + "", cnn);
        cmd.CommandType = CommandType.Text;
        da = new SqlDataAdapter();
        ds = new DataSet();

        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int nn = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());
        idarray = new int[nn];
        //System.Windows.Forms.MessageBox.Show(" nn :: " + nn);
        for (int i = 0; i < nn; i++)
        {
            idarray[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());

        }

        //System.Windows.Forms.MessageBox.Show(" no :: " + no);
        for (int i = 0; i < no; i++)
        {
            int chkid = Convert.ToInt32(ch1[i].ID);
            for (int j = 0; j < nn; j++)
            {
                if (chkid == idarray[j])
                {
                    //System.Windows.Forms.MessageBox.Show(" sds " + ch1[i].Checked);
                    if (ch1[i].Checked == true)
                    {
                        //System.Windows.Forms.MessageBox.Show(" idarray[" + j + "] :: " + idarray[j]);
                        deleteIt(idarray[j]);
                        Panel2.Controls.Remove(pp[i]);

                    }

                }
            }

        }

    }

    protected void deleteIt(int idToDelete)
    {
        cmd = new SqlCommand("delete from usermsg where idp=" + idToDelete + "", cnn);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
        //System.Windows.Forms.MessageBox.Show(" ID :: " + idToDelete);
        cmd = new SqlCommand("delete from postad where idp=" + idToDelete + "", cnn);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
    }

    protected void panel2Print(int id)
    {
        ds = new DataSet();
        cmd.CommandText = "select idp,title,image,description from postad where idui=" + id + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        no = ds.Tables[0].Rows.Count;

        pp = new Panel[no];
        ch1 = new CheckBox[no];



        for (int i = 0; i < no; i++)
        {
            pp[i] = new Panel();

            pp[i].Attributes.CssStyle.Add("margin-top", "10px");
            pp[i].BorderStyle = BorderStyle.Solid;
            pp[i].BorderColor = System.Drawing.Color.Black;
            pp[i].BorderWidth = Unit.Pixel(1);
            pp[i].Height = Unit.Pixel(100);
            ch1[i] = new CheckBox();

            //ch1[i]. = b1.ID + "s" + ds.Tables[0].Rows[i][0].ToString();
            //ch1[i].AutoPostBack = true;

            //ch1[i].CheckedChanged += new EventHandler(CheckedChanged);



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
            ch1[i].Attributes.CssStyle.Add("Position", "Absolute");
            im.Attributes.CssStyle.Add("margin-left", "100px");

            ch1[i].ID = ds.Tables[0].Rows[i][0].ToString();
            ch1[i].Attributes.CssStyle.Add("margin-top", "40px");

            Panel2.Controls.Add(pp[i]);
            pp[i].Controls.Add(ch1[i]);
            pp[i].Controls.Add(im);
            pp[i].Controls.Add(h);
            pp[i].Controls.Add(l1);
            pp[i].Controls.Add(l2);





            string s = ds.Tables[0].Rows[i][2].ToString();
            im.ImageUrl = "~/img/" + s;
            h.Text = ds.Tables[0].Rows[i][1].ToString();
            l1.Text = ds.Tables[0].Rows[i][3].ToString();

        }






        ds.Clear();
    }
    
}