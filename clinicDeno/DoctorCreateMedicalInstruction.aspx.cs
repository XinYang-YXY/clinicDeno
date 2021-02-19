using clinicDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class DoctorCreateMedicalInstruction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value) & Session["ID"] != null) { }
                else
                {
                    Response.Redirect($"~/AdminLogin.aspx");
                }
            }
            else
            {
                Response.Redirect($"~/AdminLogin.aspx");
            }
            date.Text = "Date: " + DateTime.Now.Date.ToString("dd/MM/yy");
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();

            string pid = Request.QueryString["pid"];
            Patient patient = client.GetPatientById(pid);

            Name.Text = patient.FirstName + " " + patient.LastName;
            NRIC.Text = patient.Nric;
            Gender.Text = patient.Gender;
            PNum.Text = patient.PhoneNum.ToString();
            Email.Text = patient.Email;
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();

            string PString = "";
            string IString = "";
            string QString = "";
            string RString = "";

            string PCommaSeparatedString = Request.Form["Pinput"];
            if (PCommaSeparatedString != null)
            {
                string[] PValues = PCommaSeparatedString.Split(',');
                foreach (string P in PValues)
                {
                    if (P != "")
                    {
                        PString += P + "|";
                    }
                }
            }

            string ICommaSeparatedString = Request.Form["Iinput"];
            if (ICommaSeparatedString != null)
            {
                string[] IValues = ICommaSeparatedString.Split(',');
                foreach (string I in IValues)
                {
                    if (I != "")
                    {
                        IString += I + "|";
                    }
                }
            }

            string QCommaSeparatedString = Request.Form["Qinput"];
            if (QCommaSeparatedString != null)
            {
                string[] QValues = QCommaSeparatedString.Split(',');
                foreach (string Q in QValues)
                {
                    if (Q != "")
                    {
                        QString += Q + "|";
                    }
                }
            }

            string RCommaSeparatedString = Request.Form["Rinput"];
            if (RCommaSeparatedString != null)
            {
                string[] RValues = RCommaSeparatedString.Split(',');
                foreach (string R in RValues)
                {
                    if (R != "")
                    {
                        RString += R + "|";
                    }
                }
            }

            string defaultP = Prescription.Text.ToString() + "|";
            string defaultI = Instructions.Text.ToString() + "|";
            string defaultQ = Quantity.Text.ToString() + "|";
            string defaultR = Refills.Text.ToString() + "|";

            string finalP = defaultP + PString;
            string finalI = defaultI + IString;
            string finalQ = defaultQ + QString;
            string finalR = defaultR + RString;

            string aid = Request.QueryString["aid"];
            string pid = Request.QueryString["pid"];

            var id = client.CreateMI(DateTime.Now.Date, finalP, finalI, finalQ, finalR, Session["ID"].ToString(), pid, aid);

            client.AppointAddMIId(id.ToString(), aid);

            Response.Redirect($"~/DAppointment.aspx?aid={aid}");
        }
    }
}