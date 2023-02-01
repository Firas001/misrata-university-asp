using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace WebApplication1
{

    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDepartmentValues();
            }

            generatID();
        }

        // generat id

        void generatID()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT top 1 userID FROM users where RoleID = '222' ORDER BY userID DESC", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                TextBox8.Text = 91001.ToString();
            }
            else
            {
                TextBox8.Text = (Convert.ToInt32(dt.Rows[0][0]) + 1).ToString();
            }
        }




        // sign up button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {

                Response.Write("<script>alert('هذا الاسم موجود سابقاً، جرب اسماً آخر');</script>");
            }

            else
            {
                signUpNewMember();

            }

        }

        // user defined method
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from users where full_name='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }


        void signUpNewMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO users(userID, full_name, BirthDate, contact_no, email, department_id, GPA, student_info, account_status, password) values(@userID, @full_name, @BirthDate, @contact_no, @email, @department_id, @GPA, @student_info, @account_status, @password)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@BirthDate", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@department_id", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@GPA", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@student_info", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@userID", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "انتظار");
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("select * from users, roles where (userID='" + TextBox8.Text.Trim() + "' AND password='" + TextBox9.Text.Trim() + "') and (users.RoleID = roles.RoleID)", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Session["userID"] = dr["userID"].ToString();
                    Session["full_name"] = dr["full_name"].ToString();
                    Session["role"] = dr["RoleName"].ToString();
                    Session["status"] = dr["account_status"].ToString();
                }

                con.Close();

                Response.Redirect("homepage.aspx");

                Response.Write("<script>alert('تمت عملية تسحيل مستخدم جديد بنجاح!');</script>");

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }

        void fillDepartmentValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT department_id, department_name from departments;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;

                DropDownList1.DataTextField = "department_name";
                DropDownList1.DataValueField = "department_id";

                DropDownList1.DataBind();

            }
            catch (Exception ex)
            {

            }
        }




    }
}