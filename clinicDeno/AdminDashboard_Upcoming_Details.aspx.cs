using clinicDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class AdminDashboard_Upcoming_Details : System.Web.UI.Page
    {
        string appointmentId = "";
        string patientId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["appointmentId"]))
            {
                //Label1.Text = Request.QueryString["patientId"];
                appointmentId = Request.QueryString["appointmentId"];

                MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();

                Appointment appointment = client.GetAppointmentById(appointmentId);

                string doctorId = appointment.DoctorId;
                patientId = appointment.PatientId;
                Doctor doctor = client.GetDoctorById(doctorId);
                Patient patient = client.GetPatientById(patientId);

                string appointmentDate = appointment.Date.ToString("dd/MM/yyyy");
                string appointmentTime = appointment.Time.ToString();
                //string patientName = 


                appointmentRequestDoctor.Text = "DR " + doctor.FirstName + " " + doctor.LastName;
                appointmentRequestDateTime.Text = appointmentDate + ", " + appointmentTime;

                appointmentRequestPatientName.Text = patient.FirstName + " " + patient.LastName;
                appointmentRequestPatientnric.Text = patient.Nric;
                appointmentRequestPatientGender.Text = patient.Gender;
                appointmentRequestPatientEmail.Text = patient.Email;
                appointmentRequestPatientContactNum.Text = patient.PhoneNum;





            }
        }

        protected void detailGoBackBtn_Click(object sender, EventArgs e)
        {
            string detailType = detailHeader.Text.Trim();
            if (detailType == "request")
            {
                Response.Redirect("AdminDashboard_UpcomingAppointment.aspx");
            }
        }

        protected void upcomingAppointmentSendReminder_Click(object sender, EventArgs e)
        {
            var gmailAddress = Environment.GetEnvironmentVariable("GMAIL_ADDRESS");
            var gmailPassword = Environment.GetEnvironmentVariable("GMAIL_PASSWORD");
            MailMessage mail = new MailMessage();
            mail.To.Add(appointmentRequestPatientEmail.Text.Trim());
            mail.From = new MailAddress(gmailAddress);
            mail.Subject = "[ClinicDeno] Appointment Reminder.";
            mail.Body = $"Dear Mr {appointmentRequestPatientName.Text.Trim()},\n\nYou have an upcoming appointment on {appointmentRequestDateTime.Text.Trim()}.\n\nThank you!" + "\n\n\nRegards,\nClinicDeno Team";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(gmailAddress, gmailPassword);
            smtp.EnableSsl = true;
            smtp.Send(mail);

            Response.Redirect("AdminDashboard_UpcomingAppointment.aspx?alert=on");

        }
    }
}