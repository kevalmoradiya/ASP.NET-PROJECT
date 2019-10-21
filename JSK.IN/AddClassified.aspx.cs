using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Configuration;




public partial class AddClassified : System.Web.UI.Page
{
    string filename;
    int freeid = 0,radio;
    
    SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    SqlDataAdapter da1 = new SqlDataAdapter();
    SqlCommand cmd1 = new SqlCommand();
    int echeck = 0;




    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox1.Visible = false;
        cnn.Open();
        cmd.Connection = cnn;
        cmd1.Connection = cnn;

        try
        {
            int sid = Convert.ToInt32(Session["Uname"]);
            if(!IsPostBack)
            userData_AutoFill(sender, e);
        }
        catch { }

        
    }
    protected void userData_AutoFill(object sender, EventArgs e)
    {
        ds = new DataSet();
        da = new SqlDataAdapter();
        cmd.CommandText = "select iam,cname,phoneno,email from userinfo where uid="+Convert.ToInt32(Session["Uname"])+"";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        
        

            if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
            {
                RadioButton1.Checked = true;
                RadioButton2.Checked = false;
            }
            else
            {
                RadioButton2.Checked = true;
                RadioButton1.Checked = false;
            }
            TextBox7.Text = ds.Tables[0].Rows[0][1].ToString();
            TextBox9.Text = ds.Tables[0].Rows[0][2].ToString();
            TextBox8.Text = ds.Tables[0].Rows[0][3].ToString();



        
        
    }


    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (freeid == 0)
        {
            freeid = 1;
        }
        else if (freeid == 1)
        {
            freeid = 0;
        }

    }
 
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
      

        


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        filename = "noimage.jpg";
        if (this.FileUpload1.HasFile)
        {
            try
            {

                filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/img/") + filename);
                Label13.Text = "Upload status: File uploaded!";

            }
            catch (Exception ex)
            {
                Label13.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
        else
        {
            filename = "noimage.jpg";
        }
        if (freeid == 1)
        {
            TextBox10.Text = "0";
        }

        if (RadioButton1.Checked)
        {
            radio = 0;
        }
        else
        {
            radio = 1;
        }

      

        int q = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
        

        cmd.CommandText="select id from city where city='" + DropDownList2.SelectedItem.ToString() + "'";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int j = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
        ds.Clear();

        cmd.CommandText = "select id from subselection where name='" + DropDownList4.SelectedItem.ToString() + "'";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int k = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
        ds.Clear();

      
        //Check Wether session is created or not..
        int idc=0;
        try
        {
            idc = Convert.ToInt32(Session["Uname"]);
        }
        catch
        {
        }

        if (idc == 0)
        {
            ds = new DataSet();
            cmd.CommandText = "select uid from userprofile where username='jskserver'";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
            idc = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            ds.Clear();
        }
        

                try
        {
            string temp = Session["Uname"].ToString();
            ds.Clear();
            ds = new DataSet();
            cmd.CommandText = "select id from userinfo where uid=" + Convert.ToInt32(temp) + "";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
        }
        catch
        {
            echeck = checkEmail(TextBox8.Text);
            if (echeck == 0)
            {
                cmd.CommandText = "insert into userinfo values('" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "'," + radio + "," + idc + ")";


                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
            }

            ds.Clear();
            ds = new DataSet();
           
                //cmd.CommandText = "select max(id) from userinfo";
            
                cmd.CommandText="select id from userinfo where email='"+TextBox8.Text+"'";
           
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
        }

        
        int id1=Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
        ds.Clear();
        decimal price1;
        if(CheckBox1.Checked)
        {
        price1=0;
        }
        else
        {
        price1=Convert.ToDecimal(TextBox10.Text);
        }

    cmd.CommandText = "insert into postad values('" + TextBox2.Text + "','" + filename + "','" + TextBox11.Text + "',"+price1+"," + q + "," + j + ",'" + System.DateTime.Now.ToString() + "'," + DropDownList3.SelectedValue.ToString() + "," + k + "," + id1 + ")";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;

        ds.Clear();

        cnn.Close();
        Response.Redirect("AddClassified.aspx");
        
         

    }

    int checkEmail(string x)
    {
        ds = new DataSet();
        cmd.CommandText = "select email from userinfo where email='"+x+"'";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        return ds.Tables[0].Rows.Count;
        //idc = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        //ds.Clear();
        //return 0;
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
       

    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
     
    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("---Select---");
        ds = new DataSet();
        da = new SqlDataAdapter();
        cmd.CommandText = "select city from city where idc in(select id from state where state='"+DropDownList1.SelectedItem.ToString()+"')";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int cnt = ds.Tables[0].Rows.Count;
        int i = 0;
        while (i < cnt)
        {

            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());


            i = i + 1;
        }

        

    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList3_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList4.Items.Clear();
        DropDownList4.Items.Add("---Select---");
        ds = new DataSet();
        da = new SqlDataAdapter();
        cmd.CommandText = "select name from subselection where idf in(select id from selection where name='" + DropDownList3.SelectedItem.ToString() + "')";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        int cn = ds.Tables[0].Rows.Count;
        int ii = 0;
        while (ii < cn)
        {

            DropDownList4.Items.Add(ds.Tables[0].Rows[ii][0].ToString());


            ii = ii + 1;
        }
    }
        protected void Textchanged_Fill(object sender,EventArgs e)
        {
            
        }
        protected void TextBox8_OnTextChanged(object sender, EventArgs e)
        {
            ds = new DataSet();
            da = new SqlDataAdapter();
            cmd.CommandText = "select iam,cname,phoneno from userinfo where lower(email)='" + TextBox8.Text + "'";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
            int cnt = ds.Tables[0].Rows.Count;

            if (cnt > 0)
            {
                
                if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
                {
                    RadioButton1.Checked = true;
                    RadioButton2.Checked = false;
                }
                else
                {
                    RadioButton2.Checked = true;
                    RadioButton1.Checked = false;
                }
                TextBox7.Text = ds.Tables[0].Rows[0][1].ToString();
                TextBox9.Text = ds.Tables[0].Rows[0][2].ToString();
                



            }
            else
            {
                RadioButton2.Checked = false;
                RadioButton1.Checked = true;
                TextBox7.Text = TextBox9.Text = "";
                               
            }
            
        }
        protected void TextBox9_OnTextChanged(object sender, EventArgs e)
        {

        }


        protected void Upload_Image(object sender, EventArgs e)
        {
            Label3.Text = "Updated";
        }
     
}
