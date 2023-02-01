using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class book_material : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["role"].Equals("admin"))
            {
                Response.Redirect("userlogin.aspx");
            }

            GridView1.DataBind();
        }

        // issue book
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {


                if (checkIfIssueEntryExist())
                {
                    Response.Write("<script>alert('تم تنزيل هذه المادة مسبقاً');</script>");
                }
                else
                {
                    issueBook();
                }

            }
            else
            {
                Response.Write("<script>alert('خطأ في معرف الطالب أو معرف المادة');</script>");
            }
        }
        // return book
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {

                if (checkIfIssueEntryExist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('المقرر الدراسي غير موجود');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('خطأ في معرف الطالب أو معرف المادة');</script>");
            }
        }

        // go button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }




        // user defined function

        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from book_material WHERE material_id='" + TextBox1.Text.Trim() + "' AND userID='" + TextBox2.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                    cmd = new SqlCommand("update materials set reserved_seats-=1,  available_seats+=1 WHERE material_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('تم حذف مادة بنجاح');</script>");
                    GridView1.DataBind();

                    con.Close();

                }
                else
                {
                    Response.Write("<script>alert('خطأ في المعلومات');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_material(userID,material_id,book_date) values(@userID,@material_id,@book_date)", con);
                cmd.Parameters.AddWithValue("@userID", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@material_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_date", DateTime.Now.ToString("yyyy-MM-dd"));

                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update materials set reserved_seats+=1,  available_seats-=1 WHERE material_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();

                con.Close();

                Response.Write("<script>alert('تم تنزيل مقرر دراسي بنجاح');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfBookExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from materials WHERE material_id='" + TextBox1.Text.Trim() + "' AND available_seats > 0", con);
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
                return false;
            }

        }

        bool checkIfMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from users WHERE userID='" + TextBox2.Text.Trim() + "'", con);
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
                return false;
            }

        }

        bool checkIfIssueEntryExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_material WHERE userID='" + TextBox2.Text.Trim() + "' AND material_id='" + TextBox1.Text.Trim() + "'", con);
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
                return false;
            }

        }



        void getNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from materials WHERE material_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["material_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('خطأ في رمز المادة');</script>");
                }

                cmd = new SqlCommand("select * from users WHERE RoleID='222' and userID='" + TextBox2.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('خطأ في رقم القيد');</script>");
                }


            }
            catch (Exception ex)
            {

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