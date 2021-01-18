using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class ClinicRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ClinicRegistrationBtn_Click(object sender, EventArgs e)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();

            string clinicName = ClinicName.Text.ToString();
            string clinicType = ClinicTypeNET.Text.ToString();
            string clinicEmail = ClinicEmail.Text.ToString();
            string clinicPhoneNum = ClinicNum.Text.ToString();
            TimeSpan clinicStartTime =  TimeSpan.Parse(ClinicStartTime.Text.ToString());
            TimeSpan clinicEndTime = TimeSpan.Parse(ClinicEndTime.Text.ToString());
            String clinicAddress = ClinicAddressNET.Text.ToString();

            client.CreateClinic(clinicAddress, clinicPhoneNum, clinicEmail, clinicName, clinicType, clinicStartTime, clinicEndTime);

            Response.Redirect("~/ClinicRegistrationSuccess.aspx");

        }
    }
}