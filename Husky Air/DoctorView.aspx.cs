using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Husky_Air
{
    public partial class DoctorView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString2"].ConnectionString);
                con.Open();
                string query = "Select Count(*) from Doctor where status=1";
                SqlCommand com = new SqlCommand(query, con);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                con.Close();

                if (temp != 0)
                {
                    GridView2.Visible = true;

                    Label1.Visible = true;
                }
                else
                {
                    Label1.Visible = false;
                }
            }
            else
            {
                GridView2.Visible = false;
                Label1.Visible = false;
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            TextBox2.Text = gr.Cells[3].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int temp = 1;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString"].ConnectionString);
            con.Open();
            string query = "update Doctor set status='" + temp + "' where Emailid='" + TextBox2.Text + "'";
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            Response.Write("Doctor account has been suspended Doctor cant login");
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            int temp = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString"].ConnectionString);
            con.Open();
            string query = "Update Doctor set status='" + temp + "' where Emailid='" + TextBox2.Text + "'";
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            Response.Write("Account has been Reactivated User can Login ");

            con.Close();
        }
    }
}