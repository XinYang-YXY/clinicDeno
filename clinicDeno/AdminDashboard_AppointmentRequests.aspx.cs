using clinicDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class AdminDashboard_AppointmentRequests : System.Web.UI.Page
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
                    PopulateAllAppointments();
                }
            }
            else
            {
                Response.Redirect("AdminLogin.aspx", false);
            }

        }

        private void PopulateAllAppointments()
        {
            List<Appointment> eList = new List<Appointment>();
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();

            eList = client.GetAllAppointments().ToList<Appointment>();
            string jsonString = "";

            for (int i = 0; i < eList.Count; i++)
            {
                string patientId = eList[i].PatientId;
                Patient patient = client.GetPatientById(patientId);
                string patientName = patient.FirstName + " " + patient.LastName;

                string entryInfo = "";

                if (eList[i].Status == "0")
                {


                    if (i == eList.Count - 1)
                    {
                        entryInfo = eList[i].Id + "," + patientName + "," + eList[i].Date.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        entryInfo = eList[i].Id + "," + patientName + "," + eList[i].Date.ToString("dd/MM/yyyy") + "|";

                    }
                    jsonString += entryInfo;
                }


            }

            JSONString.Text = jsonString;
        }

        protected void appointmentRequestSearchBtn_Click(object sender, EventArgs e)
        {
            List<Appointment> eList = new List<Appointment>();
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();

            string patientNric = searchPatientNric.Text.Trim();

            string patientId = client.GetIdByNRIC(patientNric);

            if (patientId == "")
            {
                JSONString.Text = "";
            }
            else
            {
                eList = client.GetAppointmentByPatientId(patientId).ToList<Appointment>();
                string jsonString = "";

                for (int i = 0; i < eList.Count; i++)
                {
                    Patient patient = client.GetPatientById(patientId);
                    string patientName = patient.FirstName + " " + patient.LastName;

                    string entryInfo = "";

                    if (i == eList.Count - 1)
                    {
                        entryInfo = eList[i].Id + "," + patientName + "," + eList[i].Date.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        entryInfo = eList[i].Id + "," + patientName + "," + eList[i].Date.ToString("dd/MM/yyyy") + "|";

                    }
                    jsonString += entryInfo;


                }

                JSONString.Text = jsonString;

            }


        }
    }

}