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
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Session["role"].Equals("user"))
                {
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    getUserBookData();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Redirect("userlogin.aspx");
            }

     
        }

        // update button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["userID"].ToString() == "" || Session["userID"] == null)
            {
                Response.Redirect("userlogin.aspx");
            }
            else if (Session["status"].Equals("محظور"))
            {
                Response.Write("<script>alert('لا يمكن تعديل بيانات حساب محظور');</script>");

            }
            else
            {
                updateUserPersonalDetails();

            }
        }



        // user defined function


        void updateUserPersonalDetails()
        {
            string password = "";
            if (TextBox10.Text.Trim() == TextBox9.Text.Trim())
            {
                Response.Write("<script>alert('لا يمكن إعادة نفس كلمة السر القديمة');</script>");
            }
            else
            {
                if (TextBox10.Text.Trim() == "")
                {
                    password = TextBox9.Text.Trim(); // القديمة
                }
                else
                {
                    password = TextBox10.Text.Trim(); // الجديدة
                }
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }


                    SqlCommand cmd = new SqlCommand("update users set full_name = @full_name, BirthDate = @BirthDate, contact_no = @contact_no, email = @email,GPA = @GPA, student_info = @student_info, account_status = @account_status, password = @password WHERE userID='" + Session["userID"].ToString().Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@BirthDate", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@GPA", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@student_info", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@account_status", "pending");

                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result > 0)
                    {

                        Response.Write("<script>alert('تم تعديل بياناتك بنجاح');</script>");
                        getUserPersonalDetails();
                        getUserBookData();
                    }
                    else
                    {
                        Response.Write("<script>alert('خطأ في الادخال');</script>");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }


        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from users, departments where userID='" + Session["userID"].ToString() + "' and users.department_id = departments.department_id;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                TextBox2.Text = dt.Rows[0]["BirthDate"].ToString();
                TextBox3.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox4.Text = dt.Rows[0]["email"].ToString();
                TextBox6.Text = dt.Rows[0]["department_name"].ToString();
                TextBox7.Text = dt.Rows[0]["GPA"].ToString();
                TextBox5.Text = dt.Rows[0]["student_info"].ToString();
                TextBox8.Text = dt.Rows[0]["userID"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "نشط")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "انتظار")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "محظور")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from book_material, users, materials WHERE users.userID = book_material.userID and materials.material_id = book_material.material_id and book_material.userID ='" + Session["userID"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}