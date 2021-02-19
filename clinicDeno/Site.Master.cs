using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value) & Session["ID"] != null)
                {
                    homeMenuBtn.Visible = false;
                    clinicMenuBtn.Visible = false;
                    doctorMenuBtn.Visible = false;
                    adminMenuBtn.Visible = false;

                    logoutMenuBtn.Visible = true;
                    homeDoctorDashboardMenuBtn.Visible = true;
                    upcomingDoctorAppointmentMenuBtn.Visible = true;
                    medicalRecordsBtn.Visible = true;

                }
                else if (Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    homeMenuBtn.Visible = false;
                    clinicMenuBtn.Visible = false;
                    doctorMenuBtn.Visible = false;
                    adminMenuBtn.Visible = false;
                    siteLogoPublic.Visible = false;

                    logoutMenuBtn.Visible = true;
                    homeAdminDashboardMenuBtn.Visible = true;
                    appointmentRequestMenuBtn.Visible = true;
                    upcomingAppointmentMenuBtn.Visible = true;
                    ReminderMenuBtn.Visible = true;
                    PatientRecordMenuBtn.Visible = true;
                    MedInsMenuBtn.Visible = true;
                    siteLogoPrivate.Visible = true;
                }
            }
            else
            {
            }

        }

        protected void logoutMenuBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }
            Response.Redirect("AdminLogin.aspx");
        }
    }
}