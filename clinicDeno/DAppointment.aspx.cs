using clinicDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class DAppointment : System.Web.UI.Page
    {
        string name = null;
        string nric = null;
        string patientid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string aid = Request.QueryString["aid"];
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            Appointment appoint = client.GetAppointmentById(aid);
            patientid = appoint.PatientId.ToString();
            if (appoint.DoctorId.ToString() != Session["ID"].ToString())
            {
                Response.Redirect("~/DoctorDashboard_Home", false);
            }
            Patient patient = client.GetPatientById(appoint.PatientId.ToString());
            name = patient.FirstName + " " + patient.LastName;
            nric = patient.Nric;

            Literal record = new Literal();

            record.Text = $"<span class='record-titlesnew IDTitle'>Patient ID:</span> <span class='records ID'>{patient.Id}</span> <span class='record-titles NRICTitle'>NRIC:</span> <span class='records NRIC'>{patient.Nric}</span> <span class='record-titles NameTitle'>Name:</span> <span class='records Name' >{patient.FirstName + " " + patient.LastName}</span> <span class='record-titles EmailTitle'>Email:</span> <span class='records Email'>{patient.Email}</span> <span class='record-titles GenderTitle'>Gender:</span> <span class='records Gender'>{patient.Gender}</span> <span class='record-titles ContactTitle'>Contact Number:</span> <span class='records Contact'>{patient.PhoneNum}</span>";

            AppPatient.Controls.Add(record);

            Literal record2 = new Literal();

            record2.Text = $"<span class='record-titlesnew'>Clinic:</span> <span class='records'>{appoint.clinicName}</span> <span class='record-titles'>Preferred Doctor:</span> <span class='records'>{appoint.firstName+" "+appoint.lastName}</span> <span class='record-titles'>Preferred Date/Time:</span> <span class='records' >{appoint.Date.ToString("dd/MM/yy")}, {appoint.Time}</span>";

            AppDetails.Controls.Add(record2);

            if (appoint.MCId != "") 
            {
                MCBtn.Enabled = false;
                MCBtn.CssClass = "montserrat rounded-full orange-btn-disabled btn-standard-width y-gap";
            };
            if (appoint.MRId != "")
            {
                createRecordBtn.Enabled = false;
                createRecordBtn.CssClass = "montserrat rounded-full orange-btn-disabled btn-standard-width y-gap";
            };
            if (appoint.MIId != "")
            {
                instructBtn.Enabled = false;
                instructBtn.CssClass = "montserrat rounded-full orange-btn-disabled btn-standard-width y-gap";
            };
        }

        protected void RecordsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/MedicalRecordsResults.aspx?name={name}&nric={nric}");
        }

        //Temporary only 1 for now
        protected void createRecordBtn_Click(object sender, EventArgs e)
        {
            string aid = Request.QueryString["aid"];
            Response.Redirect($"~/MedicalRecordsCreate.aspx?aid={aid}&pid={patientid}");
        }

        protected void instructBtn_Click(object sender, EventArgs e)
        {
            string aid = Request.QueryString["aid"];
            Response.Redirect($"~/DoctorCreateMedicalInstruction.aspx?aid={aid}&pid={patientid}");
        }

        protected void MCBtn_Click(object sender, EventArgs e)
        {
            string aid = Request.QueryString["aid"];
            Response.Redirect($"~/DoctorCreateMC.aspx?aid={aid}&pid={patientid}");
        }
    }
}