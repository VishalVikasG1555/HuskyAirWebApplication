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
    public partial class JourneyDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString"].ConnectionString);
            con.Open();
            string query = "Insert into JourneyDetails(Orderid,Duration,Distance,Fuel)values(@Orderid,@Duration,@Distance,@Fuel)";
            SqlCommand com = new SqlCommand(query,con);
            com.Parameters.AddWithValue("@Orderid",DropDownList1.SelectedValue);
            com.Parameters.AddWithValue("@Duration",TextBox1.Text);
            com.Parameters.AddWithValue("@Distance",TextBox2.Text);
            com.Parameters.AddWithValue("@Fuel",TextBox3.Text);
            com.ExecuteNonQuery();
            Response.Write("Data Stored Successfully");
            con.Close();
        }
    }
}