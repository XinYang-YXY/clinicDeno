using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class DoctorLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clinicDoctorLoginBtn_Click(object sender, EventArgs e)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();

            string[] loginVerificationResult = client.DoctorLoginVerify(ClinicDoctorLoginEmail.Text.Trim(), ClinicDoctorLoginPassword.Text.Trim());

            switch (loginVerificationResult[0])
            {
                case "invalidPassword":
                    loginMsg.Text = "Incorrect credentials";
                    loginMsg.Visible = true;
                    loginMsg.Attributes.Add("class", "alert alert-warn");
                    break;
                case "loginPass":
                    Session["ID"] = loginVerificationResult[1];
                    Session["ClinicID"] = loginVerificationResult[2];
                    Session["Signature"] = loginVerificationResult[3];
                    Session["LoggedIn"] = ClinicDoctorLoginEmail.Text.Trim();
                    string guid = Guid.NewGuid().ToString();
                    Session["AuthToken"] = guid;
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));


                    Response.Redirect("DoctorDashboard_Home", false);
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