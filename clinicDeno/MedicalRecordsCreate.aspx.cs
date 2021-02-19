using clinicDeno.MyDenoDBServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class MedicalRecordsCreate : System.Web.UI.Page
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
            } else
            {
                Response.Redirect($"~/AdminLogin.aspx");
            }
            date.Text = "Date: "+DateTime.Now.Date.ToString("dd/MM/yy");
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

            string AString = "";
            string FMHString = "";
            string CMString = "";
            string CString = "";

            string ACommaSeparatedString = Request.Form["A"];
            if (ACommaSeparatedString != null)
            {
                string[] AValues = ACommaSeparatedString.Split(',');
                foreach (string A in AValues)
                {
                    if (A != "")
                    {
                        AString += A + "|";
                    }
                }
            }

            string FMHCommaSeparatedString = Request.Form["FMH"];
            if (FMHCommaSeparatedString != null)
            {
                string[] FMHValues = FMHCommaSeparatedString.Split(',');
                foreach (string FMH in FMHValues)
                {
                    if (FMH != "")
                    {
                        FMHString += FMH + "|";
                    }
                }
            }

            string CMCommaSeparatedString = Request.Form["CM"];
            if (CMCommaSeparatedString != null)
            {
                string[] CMValues = CMCommaSeparatedString.Split(',');
                foreach (string CM in CMValues)
                {
                    if (CM != "")
                    {
                        CMString += CM + "|";
                    }
                }
            }

            string CCommaSeparatedString = Request.Form["C"];
            if (CCommaSeparatedString != null)
            {
                string[] CValues = CCommaSeparatedString.Split(',');
                foreach (string C in CValues)
                {
                    if (C != "")
                    {
                        CString += C + "|";
                    }
                }
            }

            string aid = Request.QueryString["aid"];
            string pid = Request.QueryString["pid"];

            var id = client.CreateMR(DateTime.Now.Date,AString,FMHString,CMString,Diagnosis.Text.ToString(),CString,Session["ID"].ToString(),Session["ClinicID"].ToString(), pid, aid);

            client.AppointAddMRId(id.ToString(), aid);

            Response.Redirect($"~/DAppointment.aspx?aid={aid}");

        }
    }
}