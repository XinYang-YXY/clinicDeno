using clinicDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class MedicalRecordsRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            List<MyDenoDBServiceReference.MedicalRecord> recordList = client.SelectMRById(id).ToList<MyDenoDBServiceReference.MedicalRecord>();
            Patient patient = client.GetPatientById(id);
            for (int i = 0; i < recordList.Count; i++)
            {
                Clinic clinic = client.SelectClinicByID(recordList[i].ClinicId);
                Doctor doctor = client.GetDoctorById(recordList[i].DoctorId);
                Literal record = new Literal();

                var div = new HtmlGenericControl("div");
                div.Attributes["class"] = "layout-records";


                var button = new Button
                {
                    ID = recordList[i].Id,
                    Text = "View record",
                    CssClass = "montserrat rounded-full standard-btn btn-standard-width y-gap record-btn"
                };
                button.Command += ViewBtnClick;


                record.Text = $"<span class='record-titles RecordTitle'>Medical Record ID:</span> <span class='records Record'>{recordList[i].Id}</span> <span class='record-titles PNameTitle'>Patient Name:</span> <span class='records PName'>{patient.FirstName + " " + patient.LastName}</span> <span class='record-titles DateTitle'>Date:</span> <span class='records Name' >{recordList[i].Date}</span> <span class='record-titles DoctorTitle'>Doctor Name:</span> <span class='records Doctor'>{doctor.FirstName + " " + doctor.LastName}</span> <span class='record-titles ClinicTitle'>Clinic Name:</span> <span class='records Clinic'>{clinic.ClinicName}</span>";

                div.Controls.Add(record);
                div.Controls.Add(button);
                allRecords.Controls.Add(div);
            }
        }

        protected void ViewBtnClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Response.Redirect($"~/TempReport.aspx?id={clickedButton.ID}");
        }

    }
}