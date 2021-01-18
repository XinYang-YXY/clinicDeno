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

        public Clinic GetClinicById(string id)
        {
            Clinic clinic = new Clinic();
            return clinic.SelectById(id);
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
