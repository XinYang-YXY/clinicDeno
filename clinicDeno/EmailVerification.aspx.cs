using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class EmailVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            if (!string.IsNullOrEmpty(Request.QueryString["verifyId"]))
            {

                client.UpdateAdminVerifyStatus(Request.QueryString["verifyId"]);
                EmailVerificationMsg.Text = "Email has been verified successfully.\nPlease proceed to login.";

            } else
            {
                EmailVerificationMsg.Text = "Invalid email verification link!";

            }

        }
    }
}