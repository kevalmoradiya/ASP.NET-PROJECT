using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Adminpage : System.Web.UI.Page
{

    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    static int check = 0;
    Panel[] pp;
   static CheckBox[] ch1;
    static int id;
    static int no;
    static int uid;
    
   

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (check == 1)
            {

                string s1 = Texttext;

                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = "select id,uid,cname,email from userinfo where cname LIKE '%" + s1 + "%' order by uid ";
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
        Panel6.Visible = false;
        Panel5.Visible = false;
        Panel7.Visible = false;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        Panel4.Visible = true;
        Panel6.Visible = false;
        Panel5.Visible = false;
        Panel7.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        check = 1;
        Panel5.Visible = true;
        Panel6.Visible = false;
        Panel7.Visible = false;
    }

    protected void b1_Command(object sender, CommandEventArgs e)
    {

        Panel5.Visible = false;
        Panel6.Visible = true;
        Panel7.Visible = true;

        string p1 = e.CommandArgument.ToString();
        string[] st = p1.Split('s');
        uid = Convert.ToInt32(st[0]);
        id = Convert.ToInt32(st[1]);

        panel2Print(uid, id);
       
    }


    protected void panel2Print(int uid, int id)
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

            Panel6.Controls.Add(pp[i]);
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
    

    public void CheckedChanged(object sender, EventArgs e)
    {
        
        System.Windows.Forms.MessageBox.Show("dsvfjdvhdfkjvhdv");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
     
        //panel2Print(uid, id);
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
        System.Windows.Forms.MessageBox.Show(" nn :: " + nn);
        for (int i = 0; i < nn; i++)
        {
            idarray[i] = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());

        }

        System.Windows.Forms.MessageBox.Show(" no :: " + no);
        for (int i = 0; i < no; i++)
        {
            int chkid = Convert.ToInt32(ch1[i].ID);
            for (int j = 0; j < nn; j++)
            {
                if (chkid == idarray[j])
                {
                    System.Windows.Forms.MessageBox.Show(" sds " + ch1[i].Checked);
                    if (ch1[i].Checked == true)
                    {
                        System.Windows.Forms.MessageBox.Show(" idarray[" + j + "] :: " + idarray[j]);
                        deleteIt(idarray[j]);
                        Panel1.Controls.Remove(pp[i]);
                       
                    }

                }
            }

        }

    }

    protected void deleteIt(int idToDelete)
    {
        System.Windows.Forms.MessageBox.Show(" ID :: " + idToDelete);
        cmd = new SqlCommand("delete from postad where idp=" + idToDelete + "", cnn);
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        panel2Print(uid,id);
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
    protected void Button6_Click(object sender, EventArgs e)
    {
        panel2Print(uid, id);
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
}