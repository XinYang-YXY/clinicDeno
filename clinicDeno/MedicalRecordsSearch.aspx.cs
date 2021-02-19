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

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string name = Name.Text.ToString();
            string nric = NRIC.Text.ToString();
            Response.Redirect($"~/MedicalRecordsResults.aspx?name={name}&nric={nric}");
        }
    }
}