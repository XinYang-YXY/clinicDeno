using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clinicAdminLoginBtn_Click(object sender, EventArgs e)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();

            string loginVerificationResult = client.AdminLoginVerify(ClinicAdminLoginEmail.Text.Trim(), ClinicAdminLoginPassword.Text.Trim());

            switch (loginVerificationResult)
            {
                case "emailVerifyFail":
                    loginMsg.Text = "Please verify your email before login";
                    loginMsg.Visible = true;
                    loginMsg.Attributes.Add("class", "alert alert-warn");
                    break;
                case "invalidPassword":
                    loginMsg.Text = "Incorrect credentials";
                    loginMsg.Visible = true;
                    loginMsg.Attributes.Add("class", "alert alert-warn"); 
                    break;
                case "loginPass":
                    Session["LoggedIn"] = ClinicAdminLoginEmail.Text.Trim();
                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                    
                    Response.Redirect("~/AdminDashboard_Home.aspx");
                    break;
                default:
                    loginMsg.Text = "Something went wrong";
                    loginMsg.Visible = true;
                    loginMsg.Attributes.Add("class", "alert alert-warn");
                    break;
            }


        }
    }
}