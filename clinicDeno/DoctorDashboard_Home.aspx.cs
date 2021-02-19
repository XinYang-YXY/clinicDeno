using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class DoctorDashboard_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("DoctorLogin.aspx", false);
                }
                else
                {
                }
            }
            else
            {
                Response.Redirect("DoctorLogin.aspx", false);
            }
        }

        protected void AppBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoctorUpcomingAppointments.aspx", false);
        }

        protected void MRBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MedicalRecordsSearch.aspx", false);
        }
    }
}