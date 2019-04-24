using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Husky_Air
{
    public partial class PatientForget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Label3.Visible = true;
                TextBox2.Visible = true;
                Button2.Visible = true;
            }
            else
            {
                Label3.Visible = false;
                TextBox2.Visible = false;
                Button2.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                TextBox4.Visible = false;
                TextBox5.Visible = false;
                Button3.Visible = false;
                RequiredFieldValidator2.Visible = false;
                RequiredFieldValidator3.Visible = false;
            }

        }

        public static class Random1
        {
            public static int num;
            public static int Random11()
            {

                int min = 1000;
                int max = 9999;
                Random random = new Random();
                num = random.Next(min, max);
                return num;

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            TextBox3.Text = Random1.Random11().ToString();


            MailMessage mail = new MailMessage(Label1.Text, TextBox1.Text);
            mail.Subject = "Verification Code";
            mail.Body = "Your Verification Code is " + TextBox3.Text;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            NetworkCredential networkcred = new NetworkCredential(Label1.Text, Label2.Text);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = networkcred;
            smtp.Port = 587;
            smtp.Send(mail);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string input = TextBox4.Text;

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
            string query = "Update Patient set Password='" + result + "' where Emailid='" + TextBox1.Text + "'";
            SqlCommand com = new SqlCommand(query, con);
            com.ExecuteNonQuery();
            Response.Write("Your Password has been changed");
            con.Close();
            Label3.Visible = false;
            Button2.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            Button3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            TextBox2.Visible = false;
            RequiredFieldValidator4.Visible = false;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == TextBox3.Text)
            {
                Label4.Visible = true;
                Label5.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                Button3.Visible = true;
                RequiredFieldValidator2.Visible = false;
                RequiredFieldValidator3.Visible = false;
                TextBox2.Visible = false;
                RequiredFieldValidator2.Visible = false;
                Label3.Visible = false;
                Button2.Visible = false;
            }
            else
            {
                Response.Write("Your Entered Incorrect Verification Code");
            }
        }
    }
}