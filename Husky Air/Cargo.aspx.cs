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
    public partial class Cargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString"].ConnectionString);
                conn.Open();
                string query1 = "Select count(*) from Cargo where id='"+TextBox1.Text+"'";
                SqlCommand comm = new SqlCommand(query1,conn);
                int temp = Convert.ToInt32(comm.ExecuteScalar().ToString());
                if(temp==1)
                {
                    Response.Write("Data already stored ");
                }
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString"].ConnectionString);
            con.Open();
            string query = "Insert into Cargo(id,Weight)values(@id,@Weight)";
            string query1 = "Select count(*) from Cargo where id='" + TextBox1.Text + "'";
            SqlCommand com = new SqlCommand(query,con);
            SqlCommand com1 = new SqlCommand(query1, con);
            com.Parameters.AddWithValue("@id",TextBox1.Text);
            com.Parameters.AddWithValue("@Weight",TextBox2.Text);
           
            int temp = Convert.ToInt32(com1.ExecuteScalar().ToString());
            if (temp == 0)
            {
                com.ExecuteNonQuery();
                Response.Write("Data stored successfully");
               
            }
           
            con.Close();
        }
    }
}