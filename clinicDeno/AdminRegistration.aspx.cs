using clinicDeno.MyDenoDBServiceReference;
using FluentEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Clinic> clinicList =  client.GetAllClinic().ToList<Clinic>();

            string clinicNameList = "";
            for(int i =0; i<clinicList.Count; i++)
            {
                string clinicName =  clinicList[i].ClinicName + ",";
                
                clinicNameList += clinicName;

            }
            ExistingClinicNET.Text = clinicNameList;


        }

        protected async void ClinicRegistrationBtn_Click(object sender, EventArgs e)
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
            string clinicId =  workingClinic.Id;

            client.CreateClinicAdmin(adminEmail, adminPhoneNum, adminFirstName, adminLastName, adminDob, adminGender, adminPassword, clinicId);

            //string email = await Email.From("we@hedeno.com").To("me@yxy.ninja", "XY").Subject("Hello").Body("Test").SendAsync();
        }
    }
}