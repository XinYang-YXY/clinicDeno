using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace clinicDeno
{
    public partial class MedicalRecordsSearch : System.Web.UI.Page
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

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string name = Name.Text.ToString();
            string nric = NRIC.Text.ToString();
            Response.Redirect($"~/MedicalRecordsResults.aspx?name={name}&nric={nric}");
        }
    }
}