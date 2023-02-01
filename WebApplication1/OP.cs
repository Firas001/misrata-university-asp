using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace System
{
    public static class User
    {

        public static bool isLogin() /// ألتحقق هل المستخدم مسجل ام لا
        {
            if (System.Web.HttpContext.Current.Session["userID"] != null)
                return true;

            return false;

        }

        public static void Logout()
        {

            System.Web.HttpContext.Current.Session["userID"] = null;

        }

        public static string getUserData(string Column_name) /// جلب بيانات أي عمود
        {
            if (isLogin())
                {
                string userID = "", full_name = ""
                , dob = "", contact_no = ""
                , email = "", state = "", city = "", pincode = "",
                full_address = "", account_status = "", RoleID = "";

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from users where userID ='" + System.Web.HttpContext.Current.Session["userID"]+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        userID = dr.GetValue(0).ToString();
                        full_name = dr.GetValue(1).ToString();
                        dob = dr.GetValue(2).ToString();
                        contact_no = dr.GetValue(3).ToString();
                        email = dr.GetValue(4).ToString();
                        state = dr.GetValue(5).ToString();
                        city = dr.GetValue(6).ToString();
                        pincode = dr.GetValue(7).ToString();
                        full_address = dr.GetValue(8).ToString();
                        account_status = dr.GetValue(9).ToString();
                        RoleID = dr.GetValue(10).ToString();


                    }

                }

                con.Close();

                switch (Column_name)
                {

                    case "full_name":
                        return full_name;
                        break;

                    case "dob":
                        return dob;
                        break;

                    case "contact_no":
                        return contact_no;
                        break;

                    case "email":
                        return email;
                        break;

                    case "state":
                        return state;
                        break;

                    case "city":
                        return city;
                        break;

                    case "pincode":
                        return pincode;
                        break;

                    case "full_address":
                        return full_address;
                        break;

                    case "userID":
                        return userID;
                        break;

                    case "account_status":
                        return account_status;
                        break;

                    case "RoleID":
                        return RoleID;
                        break;
                }

            }
            return "Not Logged !!!!"; 
            
        }







    }


    public static class Admin
    {

        public static bool isLogin() /// ألتحقق هل المستخدم مسجل ام لا
        {
            if (HttpContext.Current.Session["userID"] != null)
                return true;

            return false;

        }


        public static void setAdmin(string userID)
        {

            if (isLogin())

            {

                string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                SqlConnection con = new SqlConnection(strcon);

                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE users SET RoleID = 111 WHERE userID = @userID", con);
                cmd.Parameters.AddWithValue("@userID", userID);

                cmd.ExecuteNonQuery();

                con.Close();

            }

        }


    }
}