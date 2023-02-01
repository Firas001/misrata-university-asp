using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication1
{
    public partial class materials_management : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_seats_no, global_available_seats, global_reserved_seats;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)(Session["role"]) != "admin")
            {
                Response.Redirect("userlogin.aspx");
            }
            if (!IsPostBack)
            {
                fillInstructorDepartmentValues();
            }

            GridView1.DataBind();
        }

        // go button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            getBookByID();
        }


        // update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }
        // delete button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }
        // add button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('تمت إضافة المادة مسبقاً، جرب معرف آخر!');</script>");
            }
            else
            {

                addNewBook();
            }
        }



        // user defined functions

        void deleteBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from materials WHERE material_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('تم حذف المادة بنجاح');</script>");

                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('المعرف غير موجود');</script>");
            }
        }

        void updateBookByID()
        {

            if (checkIfBookExists())
            {
                try
                {

                    int seats_no = Convert.ToInt32(TextBox4.Text.Trim());
                    int available_seats = Convert.ToInt32(TextBox7.Text.Trim());

                    if (global_seats_no == seats_no)
                    {

                    }
                    else if (seats_no < global_seats_no)
                        {
                            Response.Write("<script>alert('لا يمكن اختيار عدد أقل من العدد الأصلي!');</script>");
                            return;


                        }
                        else
                        {
                            available_seats = seats_no - global_reserved_seats;
                            TextBox7.Text = "" + available_seats;
                        }
                    

           

                    string filepath = "~/img/books1";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("books/" + filename));
                        filepath = "~/books/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE materials set material_name = @material_name, instructor_id = @instructor_id, department_id = @department_id, seats_no = @seats_no, available_seats = @available_seats, material_info = @material_info, material_link = @material_link where material_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@material_name", TextBox2.Text.Trim()); // اسم المادة
                    cmd.Parameters.AddWithValue("@department_id", DropDownList3.SelectedItem.Value); // القسم
                    cmd.Parameters.AddWithValue("@instructor_id", DropDownList2.SelectedItem.Value); // مدرس المادة
                    cmd.Parameters.AddWithValue("@material_info", TextBox6.Text.Trim()); // معلومات إضافية
                    cmd.Parameters.AddWithValue("@seats_no", seats_no.ToString()); // عدد المقاعدة
                    cmd.Parameters.AddWithValue("@available_seats", available_seats.ToString()); // المقاعد المتوفرة
                    cmd.Parameters.AddWithValue("@material_link", filepath); // مسار الملف

                    global_seats_no = Convert.ToInt32(seats_no.ToString().Trim());
                    global_available_seats = global_seats_no - global_reserved_seats;


                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('تمت عملية التعديل بنجاح');</script>");


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('معرف المادة غير صحيح');</script>");
            }
        }


        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from materials WHERE material_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["material_name"].ToString(); // اسم المادة
                    TextBox4.Text = dt.Rows[0]["seats_no"].ToString().Trim(); // عدد المقاعد
                    TextBox5.Text = dt.Rows[0]["reserved_seats"].ToString().Trim(); // عدد المقاعد المحجوزة
                    TextBox6.Text = dt.Rows[0]["material_info"].ToString(); // معلومات إضافية
                    TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["seats_no"].ToString()) - Convert.ToInt32(dt.Rows[0]["reserved_seats"].ToString()));
                    DropDownList2.SelectedValue = dt.Rows[0]["instructor_id"].ToString().Trim(); // مدرس المادة
                    DropDownList3.SelectedValue = dt.Rows[0]["department_id"].ToString().Trim(); // القسم

                    global_seats_no = Convert.ToInt32(dt.Rows[0]["seats_no"].ToString().Trim());
                    global_reserved_seats = Convert.ToInt32(dt.Rows[0]["reserved_seats"].ToString().Trim());
                    global_available_seats = global_seats_no - global_reserved_seats;
                    global_filepath = dt.Rows[0]["material_link"].ToString();

                    

                }
                else
                {
                    Response.Write("<script>alert('معرف المادة غير صحيح');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }

        void fillInstructorDepartmentValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from instructors;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataTextField = "instructor_name";
                DropDownList2.DataValueField = "instructor_id";
                DropDownList2.DataBind();

                cmd = new SqlCommand("SELECT * from departments;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                DropDownList3.DataSource = dt;
                DropDownList3.DataTextField = "department_name";
                DropDownList3.DataValueField = "department_id";
                DropDownList3.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from materials where material_id='" + TextBox1.Text.Trim() + "' OR material_name='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else if (TextBox1.Text.Trim() == "")
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

        void addNewBook()
        {
            try
            {

                string filepath = "~/imgs/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);



                FileUpload1.SaveAs(Server.MapPath("books/" + filename));
                filepath = "~/books/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                SqlCommand cmd = new SqlCommand("INSERT INTO materials(material_id, material_name, instructor_id, department_id, seats_no, reserved_seats, available_seats, material_info, material_link) " +
                                                                    "values(@material_id, @material_name, @instructor_id, @department_id, @seats_no, @reserved_seats, @available_seats, @material_info, @material_link)", con);

                cmd.Parameters.AddWithValue("@material_id", TextBox1.Text.Trim()); // رمز المادة
                cmd.Parameters.AddWithValue("@material_name", TextBox2.Text.Trim()); // اسم المادة
                cmd.Parameters.AddWithValue("@department_id", DropDownList3.SelectedItem.Value); // القسم
                cmd.Parameters.AddWithValue("@instructor_id", DropDownList2.SelectedItem.Value); // مدرس المادة
                cmd.Parameters.AddWithValue("@material_info", TextBox6.Text.Trim()); // معلومات إضافية
                cmd.Parameters.AddWithValue("@seats_no", TextBox4.Text.Trim()); // عدد المقاعد
                cmd.Parameters.AddWithValue("@available_seats", TextBox4.Text.Trim()); // عدد المقاعد
                cmd.Parameters.AddWithValue("@reserved_seats", 0); // عدد المقاعد المحجوزة
                cmd.Parameters.AddWithValue("@material_link", filepath); // مسار الملف


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('تمت إضافة مقرر جديد بنجاح');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}