using clinicDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class DoctorRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            List<Clinic> clinicList = client.GetAllClinic().ToList<Clinic>();

            string clinicNameList = "";
            for (int i = 0; i < clinicList.Count; i++)
            {
                string clinicName = clinicList[i].ClinicName + ",";

                clinicNameList += clinicName;

            }
            ExistingClinicNET.Text = clinicNameList;
        }

        protected void DoctorRegistrationBtn_Click(object sender, EventArgs e)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();


            string doctorFirstName = DoctorFirstName.Text.ToString();
            string doctorLastName = DoctorLastName.Text.ToString();
            DateTime doctorDob = DateTime.Parse(DoctorDOB.Text.ToString());
            string doctorGender = DoctorGenderNET.Text.ToString();
            string doctorClinicName = SelectedClinicNET.Text.ToString();
            string doctorPhoneNum = DoctorPhoneNum.Text.ToString();
            string doctorEmail = DoctorEmail.Text.ToString();
            string doctorPassword = DoctorPassword.Text.ToString();
            string doctorSignature = DoctorSignature.Text.ToString();

            Clinic workingClinic = client.GetClinicByName(doctorClinicName);
            string clinicId = workingClinic.Id;
            //string clinicEmail = workingClinic.Email;

            //string verificationId = Guid.NewGuid().ToString();

            client.CreateDoctor(doctorEmail, doctorPhoneNum, doctorFirstName, doctorLastName, doctorDob, doctorGender,doctorSignature, doctorPassword, clinicId);


            //var gmailAddress = Environment.GetEnvironmentVariable("GMAIL_ADDRESS");
            //var gmailPassword = Environment.GetEnvironmentVariable("GMAIL_PASSWORD");
            //AdminLastName.Text = gmailAddress;
            //AdminFirstName.Text = gmailPassword;
            //MailMessage mail = new MailMessage();
            //mail.To.Add(clinicEmail);
            //mail.From = new MailAddress(gmailAddress);
            //mail.Subject = "[ClinicDeno] Account Verification";
            //mail.Body = $"Dear {adminClinicName},\n\n{adminFirstName} {adminLastName} has registered an administrator account under your clinic. \n\nPlease click the link below to verify this account. Otherwise, kindly ignore this email. Thank you!\n\n✅https://localhost:44361/EmailVerification?verifyId=" + verificationId + " \n\n\nRegards,\nClinicDeno Team";
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new System.Net.NetworkCredential(gmailAddress, gmailPassword);
            //smtp.EnableSsl = true;
            //smtp.Send(mail);

            Response.Redirect("~/DoctorRegistrationSuccess.aspx");
        }
    }
}