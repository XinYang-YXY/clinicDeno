using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class AdminDashboard_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("AdminLogin.aspx", false);
                }
                else
                {
                                    }
            }
            else
            {
                Response.Redirect("AdminLogin.aspx", false);
            }
        }

        protected void appReqBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminDashboard_AppointmentRequests.aspx");
        }

        protected void appUpBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminDashboard_UpcomingAppointment.aspx");
        }

        protected void appReminderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminDashboard_AppointmentReminder.aspx");
        }

        protected void patientRecordBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminDashboard_PatientRecord.aspx");
        }

        protected void medicalInsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminDashboard_MedicalInstruction.aspx");
        }
    }
}