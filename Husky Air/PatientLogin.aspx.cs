using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Husky_Air
{
    public partial class PatientLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string input = TextBox2.Text;

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("x2"));

            }
            string result = sb.ToString();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString"].ConnectionString);
            con.Open();
            string query = "Select count(*) from Patient where Emailid='" + TextBox1.Text + "'";
            SqlCommand com = new SqlCommand(query, con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();
            if (temp == 1)
            {
                con.Open();
                string checkpassword = "select Password from Patient where Emailid='" + TextBox1.Text + "'";
                string status = "select status from Patient where Emailid='" + TextBox1.Text + "'";
                SqlCommand com1 = new SqlCommand(checkpassword, con);
                SqlCommand com2 = new SqlCommand(status, con);
                int check = Convert.ToInt32(com2.ExecuteScalar().ToString());
                string password = com1.ExecuteScalar().ToString().Replace(" ", "");
                if (password == result && check!=1)
                {
                    Session["New"] = TextBox1.Text;

                    Response.Redirect("Index.aspx") ;

                }
                else if (password == result && check == 1)
                {
                    Response.Write("Your Account has been suspended contact the administrator to reactivate");
                }
                else
                {
                    Response.Write("password is wrong");
                }
            }
            else
            {
                Response.Write("user is not registered ");

            }

        }
    }
}