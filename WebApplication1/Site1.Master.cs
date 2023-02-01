using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //// حفظ بيانات الدخول
            {
                if (Request.Cookies["userID"] != null && Request.Cookies["Password"] != null)
                {
                    TextBox1.Text = Request.Cookies["userID"].Value;
                    TextBox2.Attributes["value"] = Request.Cookies["Password"].Value;
                    loginRemember.Checked = true;
                }
            }



            try
            {
                if (Session["role"] == null) { }

                else if (Session["role"].Equals("user"))
                {

                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "مرحبا " + Session["full_name"].ToString();

                    LOGIN.Visible = false;
                    LOGOUT.Visible = true;

                }
                else if (Session["role"].Equals("admin"))
                {

                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "حساب مدير النظام";


                    instructorsmanagement.Visible = true;
                    departmentmanagement.Visible = true;
                    materialsmanagement.Visible = true;
                    bookmaterial.Visible = true;
                    studentmanagement.Visible = true;

                    LOGIN.Visible = false;
                    LOGOUT.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

       

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("instructors-management.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("department-management.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("materials-management.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("book-material.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("student-management.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

    
        // view profile
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }



        // user login
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("select * from users, roles where (userID=@userID AND password=@password) and (users.RoleID = roles.RoleID)", con);
                cmd.Parameters.AddWithValue("@userID",TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());



                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    { 
                        Session["userID"] = dr["userID"].ToString();
                        Session["full_name"] = dr["full_name"].ToString();
                        Session["role"] = dr["RoleName"].ToString();
                        Session["status"] = dr["account_status"].ToString();
                    }

                    if(loginRemember.Checked)
                    {
                        Response.Cookies["userID"].Value = TextBox1.Text.Trim();
                        Response.Cookies["Password"].Value = TextBox2.Text.Trim();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('البيانات المدخلة غير صحيحة');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }


        //logout button
        protected void Button3_Click(object sender, EventArgs e)
        {
           
            Session["fullname"] = null;
            Session["role"] = null;
            Session["status"] = null;
            Session["userID"] = null;

            Response.Redirect("homepage.aspx");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}