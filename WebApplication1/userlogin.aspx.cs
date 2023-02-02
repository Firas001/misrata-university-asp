using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{

    public partial class userlogin : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                cmd.Parameters.AddWithValue("@userID", TextBox1.Text.Trim());
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
    }
}