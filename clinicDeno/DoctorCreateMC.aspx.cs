using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class DoctorCreateMC : System.Web.UI.Page
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
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            string aid = Request.QueryString["aid"];
            string pid = Request.QueryString["pid"];

            int Days = int.Parse(Duration.Text.ToString());
            string Comments = Comment.Text.ToString();

            var id = client.CreateMC(DateTime.Now.Date, DateTime.Now.AddDays(Days).Date, Comments, Session["ID"].ToString() ,Session["Signature"].ToString() , pid, aid);

            client.AppointAddMCId(id.ToString(), aid);

            Response.Redirect($"~/DAppointment.aspx?aid={aid}");
        }
    }
}