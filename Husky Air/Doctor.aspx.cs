using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;

using System.Net;
using System.Net.Mail;

namespace Husky_Air
{
    public partial class Doctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadMonths();
                LoadYears();
            }
        }

        private void LoadYears()
        {
            DataSet DsYears = new DataSet();
            DsYears.ReadXml(Server.MapPath("~/Data/Years.xml"));
            DropDownList2.DataSource = DsYears;
            DropDownList2.DataTextField = "Number";
            DropDownList2.DataValueField = "Number";
            DropDownList2.DataBind();
        }

        private void LoadMonths()
        {
            DataSet DsMonths = new DataSet();
            DsMonths.ReadXml(Server.MapPath("~/Data/Months.xml"));
            DropDownList1.DataSource = DsMonths;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Number";
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Gender = string.Empty;
            if(RadioButton1.Checked)
            {
                Gender = "Male";
            }
            else if(RadioButton2.Checked)
            {
                Gender = "Female";
            }
            else if(RadioButton3.Checked)
            {
                Gender = "Other";
            }
            string input = TextBox8.Text;

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("x2"));

            }
            string Address = TextBox5.Text + " " + TextBox6.Text + " " + DropDownList3.SelectedValue + " " + DropDownList4.SelectedValue + " " + TextBox9.Text;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HuskyAirConnectionString"].ConnectionString);
            con.Open();
            string query1 = "select count(*) from Doctor where Emailid='"+ TextBox2.Text+"'";
            SqlCommand com1 = new SqlCommand(query1,con);
            int temp = Convert.ToInt32(com1.ExecuteScalar().ToString());
            if (temp == 1)
            {
                Response.Write("User already Registered");
            }
            else
            {
                int status = 0;
                string query = "Insert into Doctor(Name,Gender,Emailid,Dob,Speciality,Address,Phoneno,Password,status)values(@Name,@Gender,@Emailid,@Dob,@Speciality,@Address,@Phoneno,@Password,@status)";
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@Name", TextBox1.Text);
                com.Parameters.AddWithValue("@Gender", Gender);
                com.Parameters.AddWithValue("@Emailid", TextBox2.Text);
                com.Parameters.AddWithValue("@Dob", TextBox3.Text);
                com.Parameters.AddWithValue("@Speciality", TextBox4.Text);
                com.Parameters.AddWithValue("@Address", Address);
                com.Parameters.AddWithValue("@Phoneno", TextBox7.Text);
                com.Parameters.AddWithValue("@Password", sb.ToString());
                com.Parameters.AddWithValue("@status",status);
                com.ExecuteNonQuery();

                MailMessage mail = new MailMessage(Label1.Text, TextBox2.Text);
                mail.Subject = "Doctor Registration";
                mail.Body = "Username" + TextBox2.Text + "\nPassword" + TextBox8.Text;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                NetworkCredential networkcred = new NetworkCredential(Label1.Text, Label2.Text);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkcred;
                smtp.Port = 587;
                smtp.Send(mail);
                Response.Write("Registered");
                Response.Write("Data Storted Successfully");



                
                con.Close();
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(DropDownList1.SelectedValue);
            int year = Convert.ToInt32(DropDownList2.SelectedValue);
            Calendar1.VisibleDate = new DateTime(year,month,1);
            Calendar1.SelectedDate = new DateTime(year,month,1);

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(DropDownList1.SelectedValue);
            int year = Convert.ToInt32(DropDownList2.SelectedValue);
            Calendar1.VisibleDate = new DateTime(year, month, 1);
            Calendar1.SelectedDate = new DateTime(year, month, 1);

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox3.Text = Calendar1.SelectedDate.ToString("d");
            Calendar1.Visible = false;
        }
    }
}