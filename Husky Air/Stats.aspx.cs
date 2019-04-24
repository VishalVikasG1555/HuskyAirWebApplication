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
    public partial class Stats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString1"].ConnectionString);
            con.Open();
            string query1 = "Delete from Services where id='" + Label1.Text + "' ";
            string query = "Insert into Aircraft1(id,Name,Type,Engine)values(@id,@Name,@Type,@Engine) Delete from Stats where id='"+TextBox2.Text+"'";
            SqlCommand com = new SqlCommand(query,con);
            SqlCommand com1 = new SqlCommand(query1, con);
            com.Parameters.AddWithValue("@id",TextBox2.Text);
            com.Parameters.AddWithValue("@Name",TextBox1.Text);
            com.Parameters.AddWithValue("@Type",TextBox4.Text);
            com.Parameters.AddWithValue("@Engine",TextBox3.Text);
            com.ExecuteNonQuery();
            com1.ExecuteNonQuery();
            Response.Redirect("AircraftView.aspx");
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            TextBox1.Text = gr.Cells[6].Text;
            TextBox2.Text = gr.Cells[7].Text;
            TextBox3.Text = gr.Cells[8].Text;
            TextBox4.Text = gr.Cells[9].Text;
            TextBox5.Text=gr.Cells[10].Text;
            Label1.Text = gr.Cells[11].Text;
        }
    }
}