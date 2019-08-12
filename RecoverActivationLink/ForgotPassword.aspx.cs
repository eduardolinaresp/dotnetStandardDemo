using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace RecoverActivationLink
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string uniqueCode = string.Empty;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // get the records matching the supplied username or email id.         
                cmd = new SqlCommand("select * from Tbl_Login where UserName COLLATE Latin1_general_CS_AS=@username or EmailId COLLATE Latin1_general_CS_AS=@emailId", con);

                cmd.Parameters.AddWithValue("@username", Convert.ToString(txtUserName.Text.Trim()));
                cmd.Parameters.AddWithValue("@emailId", Convert.ToString(txtEmailId.Text.Trim()));
                dr = cmd.ExecuteReader();
                cmd.Dispose();
                if (dr.HasRows)
                {
                    dr.Read();
                    //generate unique code
                    uniqueCode = Convert.ToString(System.Guid.NewGuid());
                    //Updating an unique random code in then UniquCode field of the database table
                    cmd = new SqlCommand("update Tbl_Login set UniqueCode=@uniqueCode where UserName=@username or EmailId=@emailid", con);
                    cmd.Parameters.AddWithValue("@uniqueCode", uniqueCode);
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@emailid", txtEmailId.Text.Trim());

                    StringBuilder strBody = new StringBuilder();
                    //Passing emailid,username and generated unique code via querystring. For testing pass your localhost number and while making online pass your domain name instead of localhost path.
                    //strBody.Append("<a href=http://localhost:2464/SampleApplication/ResetPassword.aspx?emailId=" + txtEmailId.Text + "&uName=" + txtUserName.Text + "&uCode=" + uniqueCode + ">Click here to change your password</a>");
                    strBody.Append("<a href=http://localhost:2464/SampleApplication/ResetPassword.aspx?emailId=" + txtEmailId.Text + "&uName=" + txtUserName.Text + "&uCode=" + uniqueCode + ">Click here to change your password</a>");
                    // sbody.Append("&uCode=" + uniqueCode + "&uName=" + txtUserName.Text + ">Click here to change your password</a>");

                    //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("SenderEmailIAddress@gmail.com", dr["EmailId"].ToString(), "Reset Your Password", strBody.ToString());
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("sistemas@example.cl", dr["EmailId"].ToString(), "Reset Your Password", strBody.ToString());
                    //pasing the Gmail credentials to send the email

                    //System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("SenderEmailIAddress@gmail.com", "SenderPassword");

                    System.Net.NetworkCredential mailAuthenticaion = new System.Net.NetworkCredential("sistemas@example.cl", "sistemas");

                    System.Net.Mail.SmtpClient mailclient = new System.Net.Mail.SmtpClient("127.0.0.1", 25);
                    //  mailclient.EnableSsl = true;
                    mailclient.EnableSsl = false;
                     mailclient.UseDefaultCredentials = false;
                    mailclient.Credentials = mailAuthenticaion;
                    mail.IsBodyHtml = true;
                    mailclient.Send(mail);
                    dr.Close();
                    dr.Dispose();
                    cmd.ExecuteReader();
                    cmd.Dispose();
                    con.Close();
                    lblStatus.Text = "Reset password link has been sent to your email address";
                    txtEmailId.Text = string.Empty;
                    txtUserName.Text = string.Empty;
                }
                else
                {
                    lblStatus.Text = "Please enter valid email address or username";
                    txtEmailId.Text = string.Empty;
                    txtUserName.Text = string.Empty;
                    con.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error Occured: " + ex.Message.ToString();
            }
            finally
            {
                cmd.Dispose();
            }
        }
    }
}