using clinicDeno.MyDenoDBServiceReference;
using FluentEmail.Core;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class AdminRegistration : System.Web.UI.Page
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

        protected  void ClinicRegistrationBtn_Click(object sender, EventArgs e)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();


            string adminFirstName = AdminFirstName.Text.ToString();
            string adminLastName = AdminLastName.Text.ToString();
            DateTime adminDob = DateTime.Parse(AdminDOB.Text.ToString());
            string adminGender = AdminGenderNET.Text.ToString();
            string adminClinicName = SelectedClinicNET.Text.ToString();
            string adminPhoneNum = AdminPhoneNum.Text.ToString();
            string adminEmail = AdminEmail.Text.ToString();
            string adminPassword = AdminPassword.Text.ToString();

            Clinic workingClinic = client.GetClinicByName(adminClinicName);
            string clinicId = workingClinic.Id;
            string clinicEmail = workingClinic.Email;

            string verificationId = Guid.NewGuid().ToString();

            client.CreateClinicAdmin(adminEmail, adminPhoneNum, adminFirstName, adminLastName, adminDob, adminGender, adminPassword, clinicId, verificationId);


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

           Response.Redirect("~/AdminRegistrationSuccess.aspx");



        }
    }
}