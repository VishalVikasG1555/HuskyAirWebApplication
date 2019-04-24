using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace Husky_Air
{
    public partial class Hospital : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString"].ConnectionString);
                conn.Open();
                string query1 = "Select count(*) from Hospital where ccn ='"+TextBox1.Text+"'";
                SqlCommand comm = new SqlCommand(query1,conn);
                int temp = Convert.ToInt32(comm.ExecuteScalar().ToString());
                if(temp==1)
                {
                    Response.Write("This data already exist");
                }
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString"].ConnectionString);
            con.Open();
            string query = "Insert into Hospital(ccn,Name,Address,Phoneno,Emailid)values(@ccn,@Name,@Address,@Phoneno,@Emailid)";
            SqlCommand com = new SqlCommand(query,con);
            com.Parameters.AddWithValue("@ccn", TextBox1.Text);
            com.Parameters.AddWithValue("@Name",TextBox2.Text);
            com.Parameters.AddWithValue("@Address",TextBox3.Text);
            com.Parameters.AddWithValue("@Phoneno",TextBox4.Text);
            com.Parameters.AddWithValue("@Emailid",TextBox5.Text);
            com.ExecuteNonQuery();
            Response.Write("Registered Successfully");
            con.Close();

        }
    }
}