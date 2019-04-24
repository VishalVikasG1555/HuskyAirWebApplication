using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Husky_Air
{
    public partial class Aircraft : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HuConnectionString"].ConnectionString);
                conn.Open();
                string query = "Select count(*) from Aircraft1 where id='"+ TextBox3.Text+"'";
                SqlCommand comm = new SqlCommand(query,conn);
                int temp = Convert.ToInt32(comm.ExecuteScalar().ToString());
                if(temp==1)
                {
                    Response.Write("Aircraft Already registered");

                }

                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string engine = string.Empty;
            if(CheckBox1.Checked)
            {
                engine = "Single";
            }
            else if(CheckBox2.Checked)
            {
                engine = "Multi";
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuConnectionString"].ConnectionString);
            con.Open();
            string query = "Insert into Aircraft1(id,Name,Type,Engine)values(@id,@Name,@Type,@Engine)";
            SqlCommand com = new SqlCommand(query,con);
            com.Parameters.AddWithValue("@id",TextBox3.Text );
            com.Parameters.AddWithValue("@Name",TextBox1.Text);
            com.Parameters.AddWithValue("@Type",TextBox2.Text);
            com.Parameters.AddWithValue("@Engine",engine);
            com.ExecuteNonQuery();
            Response.Write("Aircraft Registered");
            con.Close();

        }
    }
}