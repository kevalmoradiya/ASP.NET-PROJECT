using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class User : System.Web.UI.Page
{
    SqlConnection cnn;// = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
    SqlCommand cmd;// = new SqlCommand();
    SqlDataAdapter da;// = new SqlDataAdapter();
    DataSet ds;// = new DataSet();
    string id, price = "0", compare,filename,po;
    TextBox t1 = new TextBox();
    TextBox t2 = new TextBox();
    TextBox t4 = new TextBox();
    TextBox t5 = new TextBox();
    TextBox t6 = new TextBox();
 
    Label l4 = new Label();
    Label l5 = new Label();
    Label l6 = new Label();

    static string u;
    HttpCookie cookie;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["jskConnectionString"].ConnectionString);
        cmd = new SqlCommand();
        da = new SqlDataAdapter();
        ds = new DataSet();
        try
        {

            cookie = new HttpCookie(Session["Uname"].ToString(), "_Password");

            Response.Cookies.Add(cookie);

        }
        catch
        {
            
        }
        try
        {
            u = Session["Uname"].ToString();
            
        }
        catch
        {
            Response.Redirect("Timeout.aspx");
           
        }
        cnn.Open();
        cmd.Connection = cnn;
        id = Request.QueryString["id"];
        DropDownList1.Visible = false;
        DropDownList2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = true;
    
        
        
        HyperLink1.NavigateUrl = "~/User.aspx?id=" + 1;
        HyperLink2.NavigateUrl = "~/User.aspx?id=" + 2;
        HyperLink3.NavigateUrl = "~/User.aspx?id=" + 3;
        HyperLink4.NavigateUrl = "~/User.aspx?id=" + 4;

        if (id == "1")
        {
           
            DropDownList1.Visible = false;
            DropDownList2.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;
           
            cmd.CommandText = "select image,title,price,date,idp from postad where idui in(select id from userinfo where uid="+Convert.ToInt32(Session["Uname"])+") and ins="+DropDownList2.SelectedIndex+"";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
            int cnt = ds.Tables[0].Rows.Count;
            String s;


       


            for (int i = 0; i < cnt; i++)
            {

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
                
                Button b1 = new Button();
                
                Button b2 = new Button();
                Button b4 = new Button();



                Label l1 = new Label();
                Label l2 = new Label();
                HyperLink h1 = new HyperLink();
                
                h.Attributes.CssStyle.Add("Position", "Absolute");
                b1.Attributes.CssStyle.Add("Position", "Absolute");
                b1.Attributes.CssStyle.Add("Background-Color", "#333333");
                b1.Attributes.CssStyle.Add("Color", "#ffffff");
                b1.Attributes.CssStyle.Add("Width", "50px");
                b1.Attributes.CssStyle.Add("Height", "25px");
                b1.Text = "Edit";
                b1.Attributes.CssStyle.Add("margin-left", "10px");
                b1.Attributes.CssStyle.Add("margin-top", "70px");
                b1.Attributes.CssStyle.Add("text-align", "center");
                b1.ID = "s" + ds.Tables[0].Rows[i][4].ToString();
                b1.CommandArgument = b1.ID;
                b1.Command += new CommandEventHandler(b1_Command);
                
               

                



                


                b2.Attributes.CssStyle.Add("Position", "Absolute");
                b2.Attributes.CssStyle.Add("Background-Color", "#333333");
                b2.Attributes.CssStyle.Add("Color", "#ffffff");
                b2.Attributes.CssStyle.Add("Width", "100px");
                b2.Attributes.CssStyle.Add("Height", "25px");
                b2.Text = "Remove Ad";
                b2.Attributes.CssStyle.Add("margin-left", "100px");
                b2.Attributes.CssStyle.Add("margin-top", "70px");
                b2.Attributes.CssStyle.Add("text-align", "center");
                b2.ID = ds.Tables[0].Rows[i][4].ToString();
                b2.CommandArgument = b2.ID;
                b2.Command += new CommandEventHandler(b2_Command);


                b4.Attributes.CssStyle.Add("Position", "Absolute");
                b4.Attributes.CssStyle.Add("Background-Color", "#333333");
                b4.Attributes.CssStyle.Add("Color", "#ffffff");
                b4.Attributes.CssStyle.Add("Width", "100px");
                b4.Attributes.CssStyle.Add("Height", "25px");
                b4.Text = "Message";
                b4.Attributes.CssStyle.Add("margin-left", "220px");
                b4.Attributes.CssStyle.Add("margin-top", "70px");
                b4.Attributes.CssStyle.Add("text-align", "center");
                
                b4.ID = "j" + ds.Tables[0].Rows[i][4].ToString();
                b4.CommandArgument = b4.ID;
                b4.Command += new CommandEventHandler(b4_Command);
                


                l1.Attributes.CssStyle.Add("Position", "Absolute");
                l2.Attributes.CssStyle.Add("Position", "Absolute");
                h.Attributes.CssStyle.Add("margin-left", "10px");
                h.Attributes.CssStyle.Add("margin-top", "40px");
                l1.Attributes.CssStyle.Add("margin-top", "40px");
                l2.Attributes.CssStyle.Add("margin-top", "40px");
                l1.Attributes.CssStyle.Add("margin-left", "300px");
                l2.Attributes.CssStyle.Add("margin-left", "500px");

                Panel1.Controls.Add(p);
                p.Controls.Add(im);
                p.Controls.Add(h);
                p.Controls.Add(l1);
                p.Controls.Add(l2);
                p.Controls.Add(b1);
                p.Controls.Add(b2);
                p.Controls.Add(b4);




                s = ds.Tables[0].Rows[i][0].ToString();
                im.ImageUrl = "~/img/" + s;
                h.Text = ds.Tables[0].Rows[i][1].ToString();
                compare = ds.Tables[0].Rows[i][2].ToString();
                if (compare == price)
                {
                    l1.Text = "Free";
                }
                else
                {
                    l1.Text = "Rs." + ds.Tables[0].Rows[i][2].ToString();
                }
                l2.Text = ds.Tables[0].Rows[i][3].ToString();

                

            }
            ds.Clear();


            








        }
        else if (id == "2")
        {
            DropDownList2.Visible = false;
            DropDownList1.Visible = true;
            Panel3.Visible = false;
            Panel4.Visible = false;

            DataSet ds1 = new DataSet();
            Panel p = new Panel();
            p.Attributes.CssStyle.Add("margin-top", "10px");
            p.BorderStyle = BorderStyle.Solid;
            p.BorderColor = System.Drawing.Color.Black;
            p.BorderWidth = Unit.Pixel(1);

            Panel1.Controls.Add(p);




            cmd.CommandText = "select name,email,phonenumber,description from usermsg where uid=" + Convert.ToInt32(Session["Uname"]) + " and idp in(select idp from postad where ins=" + DropDownList1.SelectedIndex + ")";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
            cmd.CommandText = "select title,price,idp from postad where idui in(select id from userinfo where uid=" + Convert.ToInt32(Session["Uname"]) + ") and ins=" + DropDownList1.SelectedIndex + "";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds1);
            int cnt = ds.Tables[0].Rows.Count;

            int ip;
            for (ip = 0; ip < cnt; ip++)
            {
                TextBox t3 = new TextBox();
                Button b10 = new Button();


                t3.Attributes.CssStyle.Add("margin-left", "20px");
                t3.Attributes.CssStyle.Add("margin-top", "15px");
                t3.Attributes.CssStyle.Add("margin-bottom", "15px");
                t3.ReadOnly = true;
                t3.TextMode = TextBoxMode.MultiLine;
                t3.Rows = 8;
                t3.Columns = 50;

                t3.Text = "Name : " + ds.Tables[0].Rows[ip][0].ToString() + Environment.NewLine + Environment.NewLine + "Email : " + ds.Tables[0].Rows[ip][1].ToString() + Environment.NewLine + Environment.NewLine + "Phone Number : " + ds.Tables[0].Rows[ip][2].ToString() + Environment.NewLine + Environment.NewLine + "Description : " + ds.Tables[0].Rows[ip][3].ToString() + Environment.NewLine + Environment.NewLine + "Ad Title : " + ds1.Tables[0].Rows[ip][0].ToString() + Environment.NewLine + Environment.NewLine + "Price : " + ds1.Tables[0].Rows[ip][1].ToString();
                b10.Attributes.CssStyle.Add("Width", "80px");
                b10.Attributes.CssStyle.Add("Height", "35px");
                b10.Text = "Remove";
                b10.Attributes.CssStyle.Add("margin-left", "20px");



                b10.Attributes.CssStyle.Add("text-align", "center");
                b10.Font.Bold = true;

                b10.Attributes.Add("class", "buttonchange");

                b10.ID = ds1.Tables[0].Rows[ip][2].ToString();
                b10.CommandArgument = b10.ID;
                b10.Command += new CommandEventHandler(b10_Command);



                p.Controls.Add(t3);
                p.Controls.Add(b10);

            }

            ds.Clear();
            ds1.Clear();

           
            
        }
        else if (id == "3")
        {
           
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            Panel4.Visible = false;
            Panel3.Visible = false;
            Panel p = new Panel();
            p.Attributes.CssStyle.Add("margin-top", "10px");
            p.BorderStyle = BorderStyle.Solid;
            p.BorderColor = System.Drawing.Color.Black;
            p.BorderWidth = Unit.Pixel(1);
            p.Height = Unit.Pixel(200);
            Panel1.Controls.Add(p);
            Label l1 = new Label();
            Label l2 = new Label();
            
            Button b3 = new Button();

            l1.Attributes.CssStyle.Add("Position", "Absolute");
            l1.Attributes.CssStyle.Add("Background-Color", "#333333");
            l1.Attributes.CssStyle.Add("Color", "#ffffff");
            l1.Attributes.CssStyle.Add("Width", "150px");
            l1.Attributes.CssStyle.Add("Height", "30px");
            l1.Text = "Current Password :";
            l1.Attributes.CssStyle.Add("margin-left", "10px");
            l1.Attributes.CssStyle.Add("margin-top", "20px");
            l1.Attributes.CssStyle.Add("text-align", "center");

            l2.Attributes.CssStyle.Add("Position", "Absolute");
            l2.Attributes.CssStyle.Add("Background-Color", "#333333");
            l2.Attributes.CssStyle.Add("Color", "#ffffff");
            l2.Attributes.CssStyle.Add("Width", "150px");
            l2.Attributes.CssStyle.Add("Height", "30px");
            l2.Text = "New Password :";
            l2.Attributes.CssStyle.Add("margin-left", "10px");
            l2.Attributes.CssStyle.Add("margin-top", "100px");
            l2.Attributes.CssStyle.Add("text-align", "center");


            t1.Attributes.CssStyle.Add("Position", "Absolute");
            t1.Attributes.CssStyle.Add("Width", "200px");
            t1.Attributes.CssStyle.Add("Height", "25px");
            t1.Attributes.CssStyle.Add("margin-left", "180px");
            t1.Attributes.CssStyle.Add("margin-top", "20px");
            t1.Attributes.Add("type", "Password");

            t2.Attributes.CssStyle.Add("Position", "Absolute");
            t2.Attributes.CssStyle.Add("Width", "200px");
            t2.Attributes.CssStyle.Add("Height", "25px");
            t2.Attributes.CssStyle.Add("margin-left", "180px");
            t2.Attributes.CssStyle.Add("margin-top", "100px");
            t2.Attributes.Add("type", "Password");

            b3.Attributes.CssStyle.Add("Position", "Absolute");
           
           
            b3.Attributes.CssStyle.Add("Width", "80px");
            b3.Attributes.CssStyle.Add("Height", "35px");
            b3.Text = "OK";
            b3.Attributes.CssStyle.Add("margin-left", "180px");
            b3.Attributes.CssStyle.Add("margin-top", "160px");
            b3.Attributes.CssStyle.Add("text-align", "center");
            b3.Font.Bold = true;
            b3.Click += new EventHandler(b3_Click);
            b3.Attributes.Add("class", "buttonchange");




            p.Controls.Add(l1);
            p.Controls.Add(l2);
            p.Controls.Add(t1);
            p.Controls.Add(t2);
            p.Controls.Add(b3);

           

            

        }
        else if (id == "4")
        {
            DropDownList1.Visible = false;
            DropDownList2.Visible = false;
            Panel4.Visible = false;
            Panel3.Visible = false;
           
           Panel p = new Panel();
            p.Attributes.CssStyle.Add("margin-top", "10px");
            p.BorderStyle = BorderStyle.Solid;
            p.BorderColor = System.Drawing.Color.Black;
            p.BorderWidth = Unit.Pixel(1);
            p.Height = Unit.Pixel(500);
            Panel1.Controls.Add(p);

            
            Button b5 = new Button();
            p.Controls.Add(t4);
            p.Controls.Add(t5);
            p.Controls.Add(t6);
            
            p.Controls.Add(l4);
            p.Controls.Add(l5);
            p.Controls.Add(l6);
            
            p.Controls.Add(b5);

            t4.Attributes.CssStyle.Add("Position", "Absolute");
            t4.Attributes.CssStyle.Add("Width", "200px");
            t4.Attributes.CssStyle.Add("Height", "25px");
            t4.Attributes.CssStyle.Add("margin-left", "180px");
            t4.Attributes.CssStyle.Add("margin-top", "20px");
            

            t5.Attributes.CssStyle.Add("Position", "Absolute");
            t5.Attributes.CssStyle.Add("Width", "200px");
            t5.Attributes.CssStyle.Add("Height", "25px");
            t5.Attributes.CssStyle.Add("margin-left", "180px");
            t5.Attributes.CssStyle.Add("margin-top", "90px");
            

            t6.Attributes.CssStyle.Add("Position", "Absolute");
            t6.Attributes.CssStyle.Add("Width", "200px");
            t6.Attributes.CssStyle.Add("Height", "25px");
            t6.Attributes.CssStyle.Add("margin-left", "180px");
            t6.Attributes.CssStyle.Add("margin-top", "160px");
            

     

            l4.Attributes.CssStyle.Add("Position", "Absolute");
            l4.Attributes.CssStyle.Add("Background-Color", "#333333");
            l4.Attributes.CssStyle.Add("Color", "#ffffff");
            l4.Attributes.CssStyle.Add("Width", "150px");
            l4.Attributes.CssStyle.Add("Height", "30px");
            l4.Text = "Name :";
            l4.Attributes.CssStyle.Add("margin-left", "10px");
            l4.Attributes.CssStyle.Add("margin-top", "20px");
            l4.Attributes.CssStyle.Add("text-align", "center");

            l5.Attributes.CssStyle.Add("Position", "Absolute");
            l5.Attributes.CssStyle.Add("Background-Color", "#333333");
            l5.Attributes.CssStyle.Add("Color", "#ffffff");
            l5.Attributes.CssStyle.Add("Width", "150px");
            l5.Attributes.CssStyle.Add("Height", "30px");
            l5.Text = "Phonenumber :";
            l5.Attributes.CssStyle.Add("margin-left", "10px");
            l5.Attributes.CssStyle.Add("margin-top", "90px");
            l5.Attributes.CssStyle.Add("text-align", "center");

            l6.Attributes.CssStyle.Add("Position", "Absolute");
            l6.Attributes.CssStyle.Add("Background-Color", "#333333");
            l6.Attributes.CssStyle.Add("Color", "#ffffff");
            l6.Attributes.CssStyle.Add("Width", "150px");
            l6.Attributes.CssStyle.Add("Height", "30px");
            l6.Text = "Email :";
            l6.Attributes.CssStyle.Add("margin-left", "10px");
            l6.Attributes.CssStyle.Add("margin-top", "160px");
            l6.Attributes.CssStyle.Add("text-align", "center");

        

            b5.Attributes.CssStyle.Add("Width", "80px");
            b5.Attributes.CssStyle.Add("Height", "35px");
            b5.Text = "OK";
            b5.Attributes.CssStyle.Add("margin-left", "180px");
            b5.Attributes.CssStyle.Add("margin-top", "280px");
            b5.Attributes.CssStyle.Add("text-align", "center");
            b5.Font.Bold = true;
            b5.Click += new EventHandler(b5_Click);
            b5.Attributes.Add("class", "buttonchange");




            //cnn.Open();
            ds.Clear();
            ds = new DataSet();
            cmd.CommandText = "select cname,email,phoneno from userinfo where uid=" + Convert.ToInt32(Session["Uname"].ToString()) + "";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(ds);
           
          
            t4.Text = ds.Tables[0].Rows[0][0].ToString();
            t5.Text = ds.Tables[0].Rows[0][2].ToString();
            t6.Text = ds.Tables[0].Rows[0][1].ToString();
            
            ds.Clear();
           
           
           



        }


       



    }

    protected void b1_Command(object sender, CommandEventArgs e)
    {
        ds = new DataSet();
        Panel1.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
       // DropDownList2.Visible = false;
        string p1 = e.CommandArgument.ToString();
        po = p1.Remove(0, 1);
        Session["p1"]=po;
        int iu = Convert.ToInt32(po);
        cmd.CommandText = "select title,description,price from postad where idp=" + iu + " ";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        TextBox2.Text = ds.Tables[0].Rows[0][0].ToString();
        TextBox3.Text = ds.Tables[0].Rows[0][2].ToString();
        TextBox4.Text = ds.Tables[0].Rows[0][1].ToString();
        ds.Clear();
        
        
       
       
    }
    protected void b2_Command(object sender, CommandEventArgs e)
    {

        
        int y = Convert.ToInt32(e.CommandArgument.ToString());
        cmd.CommandText = "delete from postad where idp=" + y + " ";
        cmd.ExecuteNonQuery();
        
       
        Response.Redirect("User.aspx");
        
       

    }

    protected void b3_Click(object sender, EventArgs e)
    {

        cmd.CommandText = "select password from userprofile where uid=" + Convert.ToInt32(Session["Uname"]) + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        string tt=ds.Tables[0].Rows[0][0].ToString();
        ds.Clear();
        if (t1.Text == tt)
        {
            cmd.CommandText = "update userprofile set password='" + t2.Text + "' where uid=" + Convert.ToInt32(Session["Uname"]) + "";
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            
           
            t1.Text = "";
            t2.Text = "";

        }
        else
        {
         
        }
        ds.Clear();


    }


    protected void b4_Command(object sender, CommandEventArgs e)
    {
        DataSet ds = new DataSet();
        DropDownList1.Visible = false;
        DropDownList2.Visible = false;
        Panel3.Visible = false;
        Panel1.Visible = false;
        Panel4.Visible = true;

        
        string p1 = e.CommandArgument.ToString();
        int jk=Convert.ToInt32(p1.Remove(0, 1));
  

        Panel p = new Panel();
        p.Attributes.CssStyle.Add("margin-top", "10px");
        p.BorderStyle = BorderStyle.Solid;
        p.BorderColor = System.Drawing.Color.Black;
        p.BorderWidth = Unit.Pixel(1);
        
        Panel4.Controls.Add(p);
        cmd.CommandText = "select name,email,phonenumber,description from usermsg where uid=" + Convert.ToInt32(Session["Uname"]) + " and idp=" + jk + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        da.Fill(ds);
        
        int cnt = ds.Tables[0].Rows.Count;

        int ip;
        for (ip = 0; ip < cnt; ip++)
        {
            TextBox t3 = new TextBox();


            t3.Attributes.CssStyle.Add("margin-left", "20px");
            t3.Attributes.CssStyle.Add("margin-top", "15px");
            t3.Attributes.CssStyle.Add("margin-bottom", "15px");
            t3.TextMode = TextBoxMode.MultiLine;
            t3.Rows = 8;
            t3.Columns = 50;

            t3.Text = "Name : " + ds.Tables[0].Rows[ip][0].ToString() + Environment.NewLine + Environment.NewLine + "Email : " + ds.Tables[0].Rows[ip][1].ToString() + Environment.NewLine + Environment.NewLine + "Phone Number : " + ds.Tables[0].Rows[ip][2].ToString() + Environment.NewLine + Environment.NewLine + "Description : " + ds.Tables[0].Rows[ip][3].ToString() + Environment.NewLine + Environment.NewLine; ;
            p.Controls.Add(t3);
        }

        ds.Clear();
      
   

       


    }


    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        

      
    }
    
    protected void b5_Click(object sender, EventArgs e)
    {

        
        cmd.CommandText = "update userinfo set cname='" + t4.Text + "',email='" + t6.Text + "',phoneno=" + t5.Text + " where uid=" + Convert.ToInt32(Session["Uname"]) + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        cmd.CommandText = "update postad set title='" + TextBox2.Text + "' where idp=" + Convert.ToInt32(Session["p1"]) + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        TextBox2.Text = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        
        cmd.CommandText = "update postad set price='" + Convert.ToDecimal(TextBox3.Text) + "' where idp="+Convert.ToInt32(Session["p1"])+"";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        TextBox3.Text = "";
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (this.FileUpload1.HasFile)
        {
            try
            {

                filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/img/") + filename);
                Label5.Text = "Upload status: File uploaded!";

            }
            catch (Exception ex)
            {
                Label5.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
            }
        }
        cmd.CommandText = "update postad set image='" + filename + "' where idp=" + Convert.ToInt32(Session["p1"]) + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        
        
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        cmd.CommandText = "update postad set description='" + TextBox4.Text + "' where idp=" + Convert.ToInt32(Session["p1"]) + "";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;
        TextBox4.Text = "";
    }
  
   protected void b10_Command(object sender, CommandEventArgs e)
    {
        int pol = Convert.ToInt32(e.CommandArgument.ToString());
     
        cmd.CommandText = "delete from usermsg where idp="+pol+"";
        cmd.ExecuteNonQuery();
        da.SelectCommand = cmd;

        Response.Redirect("SignIn.aspx");
    }
  
}