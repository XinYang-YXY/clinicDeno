using clinicDenoDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace clinicDenoDB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        public int CreateClinic(string address, string phoneNum, string email, string clinicName, string clinicType, TimeSpan startTime, TimeSpan endTime)
        {
            Clinic clinic = new Clinic(address, phoneNum, email, clinicName, clinicType, startTime, endTime);
            return clinic.Insert();
        }

        public int CreateClinicAdmin(string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string password, string clinicId, string verificationId)
        {
            ClinicAdmin clinicAdmin = new ClinicAdmin(email, phoneNum, firstName, lastName, dob, gender, password, clinicId, verificationId);
            return clinicAdmin.Insert();
        }
        public void UpdateAdminVerifyStatus(string verificationId)
        {
            ClinicAdmin clinicAdmin = new ClinicAdmin();
            clinicAdmin.UpdateVerificationStatus(verificationId);
        }
        public string AdminLoginVerify(string email, string password)
        {
            ClinicAdmin clinicAdmin = new ClinicAdmin();
            return clinicAdmin.AdminLoginVerify(email, password);
        }


        public List<Clinic> GetAllClinic()
        {
            Clinic clinic = new Clinic();
            return clinic.SelectAll();
        }

        public Clinic GetClinicByName(string givenClinicName)
        {
            Clinic clinic = new Clinic();
            return clinic.SelectByName(givenClinicName);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

    }
}
