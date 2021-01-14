using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void doctorBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DoctorLogin.aspx");
        }

        protected void adminBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLogin.aspx");
        }

        protected void clinicBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ClinicRegistration.aspx");
        }
    }
}