using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class student_management : System.Web.UI.Page
    {

        //connection string con
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)(Session["role"]) != "admin")
            {
                Response.Redirect("userlogin.aspx");
            }
            //show gridview on pagelode
            showCurrentData();
        }

        //go btn event
        protected void Button4_Click(object sender, EventArgs e)
        {
            goMember();
        }

        //active linkbtn event
        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            if (TextBox3.Text != "")
            {
                updateMemberStatus("نشط");
            }
            else
            {
                Response.Write("<script>alert('لا يوجد طالب بنفس رقم القيد');</script>");
                TextBox3.Focus();
            }
        }

        //pendind linkbtn event
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text != "")
            {
                updateMemberStatus("انتظار");
            }
            else
            {
                Response.Write("<script>alert('لا يوجد طالب بنفس رقم القيد');</script>");
                TextBox3.Focus();
            }

        }
        //deactive linkbtn event
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text != "")
            {
                updateMemberStatus("محظور");
            }
            else
            {
                Response.Write("<script>alert('لا يوجد طالب بنفس رقم القيد');</script>");
                TextBox3.Focus();
            }

        }

        //delete member data btn event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMember())
            {
                deleteMember();
                clearForm();
            }
            else
            {
                Response.Write("<script>alert('لا يوجد طالب بنفس رقم القيد')</script>");
            }
        }






        //user defiened methods

        //check Member esists
        bool checkMember()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //establishing connection 
                con.Close();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string checkId = "select * from users where RoleID='222' and userID='" + TextBox3.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(checkId, con);
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
        //gridview show data
        protected void showCurrentData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //establishing connection 
                con.Close();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string viewQuery = "select * from users, departments where RoleID='222' and users.department_id = departments.department_id";

                SqlDataAdapter da = new SqlDataAdapter(viewQuery, con);

                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        //go btn member id
        protected void goMember()
        {
            if (TextBox3.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('رقم القيد فارغ');</script>");

            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    //establishing connection 
                    con.Close();
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    
                    string query1 = "select * from users, departments where RoleID='222' and users.department_id = departments.department_id and userID='" + TextBox3.Text.Trim() + "'";

                    SqlCommand cmd = new SqlCommand(query1, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                    
                    if (dt.Rows.Count >= 1)
                    { 
                        TextBox4.Text = dt.Rows[0]["full_name"].ToString(); // الاسسم الكامل
                        TextBox7.Text = dt.Rows[0]["account_status"].ToString(); //حالة الحساب
                        TextBox1.Text = Convert.ToDateTime(dt.Rows[0]["BirthDate"]).ToString("d/M/yyyy"); // تاريخ الميلاد
                        TextBox2.Text = dt.Rows[0]["contact_no"].ToString(); // رقم الهاتف
                        TextBox8.Text = dt.Rows[0]["email"].ToString(); // البريد الإلكتروني
                        TextBox5.Text = dt.Rows[0]["department_name"].ToString(); // القسم
                        TextBox6.Text = dt.Rows[0]["GPA"].ToString(); //المعدل التراكمي
                        TextBox10.Text = dt.Rows[0]["student_info"].ToString(); // معلومات عامة
                    }
                    else
                    {
                        Response.Write("<script>alert('الطالب الذي رقم قيده<" + TextBox3.Text + "> غير موجود');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }


        }
        //update member status 
        protected void updateMemberStatus(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //establishing connection 
                con.Close();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string query1 = "update users set account_status=N'" + status + "' where userID='" + TextBox3.Text.Trim() + "'";

                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('الطالب رقم قيده <" + TextBox3.Text + "> تم تعديل حالته');</script>");
                showCurrentData();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        //delete member permanently 
        protected void deleteMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //establishing connection 
                con.Close();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string query1 = "delete users where userID='" + TextBox3.Text.Trim() + "'";

                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('الطالب رقم قيده <" + TextBox3.Text + "> تم حذفه');</script>");
                showCurrentData();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        //clear data
        protected void clearForm()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox7.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox8.Text = "";
            TextBox5.Text = "";
            TextBox10.Text = "";
        }

    }
}