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
    public partial class instructors_management : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)(Session["role"]) != "admin")
            {
                Response.Redirect("userlogin.aspx");
            }
            if (!IsPostBack)
            {
                fillDepartmentValues();
            }
            GridView1.DataBind();
        }

        // add publisher
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                Response.Write("<script>alert('الأستاذ الذي ترغب بإضافته موجود بالفعل');</script>");
            }
            else
            {
                addNewPublisher();
            }
        }
        // update publisher
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                updatePublisherByID();
            }
            else
            {
                Response.Write("<script>alert('لا يوجد أستاذ بهذا المعرف');</script>");
            }
        }
        // delete publisher
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                deletePublisherByID();
            }
            else
            {
                Response.Write("<script>alert('لا يوجد أستاذ بهذا المعرف');</script>");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherByID();
        }




        // user defined functions

        void getPublisherByID()
        {
            fillDepartmentValues();
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from instructors where instructor_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('لا يوجد أستاذ بنفس هذا المعرف');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        bool checkPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from instructors where instructor_id='" + TextBox1.Text.Trim() + "';", con);
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

        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO instructors(instructor_id,instructor_name, department_id) values(@instructor_id,@instructor_name, @department_id)", con);

                cmd.Parameters.AddWithValue("@instructor_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@instructor_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@department_id", DropDownList1.SelectedItem.Value);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('تمت إضافة أستاذ');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void updatePublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update instructors set instructor_name=@instructor_name, department_id=@department_id WHERE instructor_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@instructor_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@department_id", DropDownList1.SelectedItem.Value);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('تمت عملية التعديل بنجاح');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('لا يوجد أستاذ بنفس هذا المعرف');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void deletePublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from instructors WHERE instructor_id='" + TextBox1.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('تم حذف أستاذ');</script>");
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('لا يوجد أستاذ بنفس هذا المعرف');</script>");
                }

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
                SqlCommand cmd = new SqlCommand("SELECT * from departments;", con);
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