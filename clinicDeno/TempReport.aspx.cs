using clinicDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class TempReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            MyDenoDBServiceReference.MedicalRecord medicalRecord = client.SelectOneMRById(id);
            Patient patient = client.GetPatientById(medicalRecord.PatientId);
            Appointment appointment = client.GetAppointmentById(medicalRecord.AppointmentId);
            MedicalCertificate medicalCertificate = new MedicalCertificate();
            MedicalInstruct medicalInstruct = new MedicalInstruct();
            if (appointment.MCId != "")
            {
                medicalCertificate = client.SelectOneMCById(appointment.MCId);
            }
            if (appointment.MIId != "")
            {
                medicalInstruct = client.SelectOneMIById(appointment.MIId);
            }

            RecordID.Text = medicalRecord.Id;
            RecordDate.Text = medicalRecord.Date.ToString("dd/MM/yy");

            Literal record = new Literal();

            record.Text = $"<span class='record-titlesnew IDTitle'>Patient ID:</span> <span class='records ID'>{patient.Id}</span> <span class='record-titles NRICTitle'>NRIC:</span> <span class='records NRIC'>{patient.Nric}</span> <span class='record-titles NameTitle'>Name:</span> <span class='records Name' >{patient.FirstName + " " + patient.LastName}</span> <span class='record-titles EmailTitle'>Email:</span> <span class='records Email'>{patient.Email}</span> <span class='record-titles GenderTitle'>Gender:</span> <span class='records Gender'>{patient.Gender}</span> <span class='record-titles ContactTitle'>Contact Number:</span> <span class='records Contact'>{patient.PhoneNum}</span>";

            PlaceHolder1.Controls.Add(record);

            string[] ASplit = medicalRecord.Allergies.Split('|');
            ASplit = ASplit.Take(ASplit.Count() - 1).ToArray();

            foreach (string A in ASplit)
            {
                Literal record2 = new Literal();
                record2.Text = $"<span class='record-titlesnew'>Allergy:</span> <span class='records ID'>{A}</span>";

                PlaceHolder2.Controls.Add(record2);
            }

            string[] FMHSplit = medicalRecord.FamilyMedicalHistory.Split('|');
            FMHSplit = FMHSplit.Take(FMHSplit.Count() - 1).ToArray();

            foreach (string FMH in FMHSplit)
            {
                Literal record3 = new Literal();
                record3.Text = $"<span class='record-titlesnew'>Condition:</span> <span class='records ID'>{FMH}</span>";

                PlaceHolder3.Controls.Add(record3);
            }

            string[] CMSplit = medicalRecord.CurrentMedications.Split('|');
            CMSplit = CMSplit.Take(CMSplit.Count() - 1).ToArray();

            foreach (string CM in CMSplit)
            {
                Literal record4 = new Literal();
                record4.Text = $"<span class='record-titlesnew'>Medication:</span> <span class='records ID'>{CM}</span>";

                PlaceHolder4.Controls.Add(record4);
            }

            Diagnosis.Text = medicalRecord.Diagnosis.ToString();

            string[] CSplit = medicalRecord.Comment.Split('|');
            CSplit = CSplit.Take(CSplit.Count() - 1).ToArray();

            foreach (string C in CSplit)
            {
                Literal record5 = new Literal();
                record5.Text = $"<span class='record-titlesnew'>Comment:</span> <span class='records ID'>{C}</span>";

                PlaceHolder5.Controls.Add(record5);
            }

            if (appointment.MIId != "")
            {
                string[] PSplit = medicalInstruct.Prescription.Split('|');
                PSplit = PSplit.Take(PSplit.Count() - 1).ToArray();
                string[] ISplit = medicalInstruct.Instruction.Split('|');
                ISplit = ISplit.Take(ISplit.Count() - 1).ToArray();
                string[] QSplit = medicalInstruct.Quantity.Split('|');
                QSplit = QSplit.Take(QSplit.Count() - 1).ToArray();
                string[] RSplit = medicalInstruct.Refills.Split('|');
                RSplit = RSplit.Take(RSplit.Count() - 1).ToArray();

                for (int i = 0; i < PSplit.Count(); i++)
                {
                    Literal record5 = new Literal();
                    record5.Text = $"<span class='record-titlesnew'>Prescription:</span> <span class='records ID'>{PSplit[i]}</span> <span class='record-titles'>Instruction:</span> <span class='records'>{ISplit[i]}</span><span class='record-titlesnew'>Quantity:</span> <span class='records ID'>{QSplit[i]}</span> <span class='record-titles'>Refills:</span> <span class='records'>{RSplit[i]}</span>";

                    PlaceHolder6.Controls.Add(record5);
                }
            }

            if (appointment.MCId != "")
            {
                SDate.Text = medicalCertificate.StartDate.ToString("dd/MM/yy");
                EDate.Text = medicalCertificate.EndDate.ToString("dd/MM/yy");
                Comments.Text = medicalCertificate.Comments.ToString();
            }

            //Literal record2 = new Literal();
            //record2.Text = $"<span class='record-titlesnew IDTitle'>Patient ID:</span> <span class='records ID'>{patient.Id}</span> <span class='record-titles NRICTitle'>NRIC:</span> <span class='records NRIC'>{patient.NRIC}</span> <span class='record-titles NameTitle'>Name:</span> <span class='records Name' >{patient.FirstName + " " + patient.LastName}</span> <span class='record-titles EmailTitle'>Email:</span> <span class='records Email'>{patient.Email}</span> <span class='record-titles GenderTitle'>Gender:</span> <span class='records Gender'>{patient.Gender}</span> <span class='record-titles ContactTitle'>Contact Number:</span> <span class='records Contact'>{patient.PhoneNum}</span>";


        }
    }
}