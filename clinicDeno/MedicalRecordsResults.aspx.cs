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
    public partial class MedicalRecordsResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Name = Request.QueryString["name"];
            string NRIC = Request.QueryString["nric"];
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            if (NRIC != "")
            {
                string ID = client.GetIdByNRIC(NRIC);
                Patient patient = client.GetPatientById(ID);
                Literal record = new Literal();

                var div = new HtmlGenericControl("div");
                div.Attributes["class"] = "layout-records";


                var button = new Button
                {
                    ID = patient.Id,
                    Text = "View records",
                    CssClass = "montserrat rounded-full standard-btn btn-standard-width y-gap record-btn"
                };
                button.Command += ViewBtnClick;

                record.Text = $"<span class='record-titles IDTitle'>Patient ID:</span> <span class='records ID'>{patient.Id}</span> <span class='record-titles NRICTitle'>NRIC:</span> <span class='records NRIC'>{patient.Nric}</span> <span class='record-titles NameTitle'>Name:</span> <span class='records Name' >{patient.FirstName + " " + patient.LastName}</span> <span class='record-titles EmailTitle'>Email:</span> <span class='records Email'>{patient.Email}</span> <span class='record-titles GenderTitle'>Gender:</span> <span class='records Gender'>{patient.Gender}</span> <span class='record-titles ContactTitle'>Contact Number:</span> <span class='records Contact'>{patient.PhoneNum}</span>";

                div.Controls.Add(record);
                div.Controls.Add(button);
                allPatients.Controls.Add(div);
            }
            else
            {
                List<Patient> patientList = client.GetPatientByName(Name).ToList<Patient>();
                for (int i = 0; i < patientList.Count; i++)
                {
                    Literal record = new Literal();

                    var div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "layout-records";


                    var button = new Button
                    {
                        ID = patientList[i].Id,
                        Text = "View records",
                        CssClass = "montserrat rounded-full standard-btn btn-standard-width y-gap record-btn"
                    };
                    button.Command += ViewBtnClick;

                    record.Text = $"<span class='record-titles IDTitle'>Patient ID:</span> <span class='records ID'>{patientList[i].Id}</span> <span class='record-titles NRICTitle'>NRIC:</span> <span class='records NRIC'>{patientList[i].Nric}</span> <span class='record-titles NameTitle'>Name:</span> <span class='records Name' >{patientList[i].FirstName + " " + patientList[i].LastName}</span> <span class='record-titles EmailTitle'>Email:</span> <span class='records Email'>{patientList[i].Email}</span> <span class='record-titles GenderTitle'>Gender:</span> <span class='records Gender'>{patientList[i].Gender}</span> <span class='record-titles ContactTitle'>Contact Number:</span> <span class='records Contact'>{patientList[i].PhoneNum}</span>";

                    div.Controls.Add(record);
                    div.Controls.Add(button);
                    allPatients.Controls.Add(div);
                }
            }

        }
        protected void ViewBtnClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            System.Diagnostics.Debug.WriteLine(clickedButton.ID);
            Response.Redirect($"~/MedicalRecordsRecords.aspx?id={clickedButton.ID}");
        }
    }
}