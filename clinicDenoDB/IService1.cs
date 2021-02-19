using clinicDenoDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace clinicDenoDB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        Clinic GetClinicByName(string givenClinicName);
        [OperationContract]
        int CreateClinic( string address, string phoneNum, string email, string clinicName, string clinicType, TimeSpan startTime, TimeSpan endTime);
        [OperationContract]
        List<Clinic> GetAllClinic();
        [OperationContract]
        int CreateClinicAdmin(string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string password, string clinicId, string verificationId);
        [OperationContract]
        void UpdateAdminVerifyStatus(string verificationId);
        [OperationContract]
        string AdminLoginVerify(string email, string password);

        [OperationContract]
        List<Appointment> GetAllAppointments();
        [OperationContract]
        List<Appointment> GetAppointmentByPatientId(string patientId);
        [OperationContract]
        Appointment GetAppointmentById(string id);
        [OperationContract]
        void UpdateAppointmentStatus(string id, string newAppId);
        

        [OperationContract]
        Patient GetPatientById(string id);
        [OperationContract]
        string GetIdByNRIC(string nric);

        [OperationContract]
        Doctor GetDoctorById(string id);

        [OperationContract]
        int CreateMR(DateTime date, string allergies, string familyMedicalHistory, string currentMedications, string diagnosis, string comment, string doctorId, string clinicId, string patientId, string appointmentId);
        [OperationContract]
        List<MedicalRecord> SelectMRById(string givenPatientId);
        [OperationContract]
        MedicalRecord SelectOneMRById(string givenMRId);

        [OperationContract]
        List<MedicalInstruct> SelectMIById(string givenPatientId);
        [OperationContract]
        MedicalInstruct SelectOneMIById(string givenMIId);
        [OperationContract]
        int CreateMI(DateTime date, string prescription, string instruction, string quantity, string refills, string doctorId, string patientId, string appointmentId);

        [OperationContract]
        int CreateMC(DateTime startDate, DateTime endDate, string comments, string doctorId, string doctorSignature, string patientId, string appointmentId);
        [OperationContract]
        List<MedicalCertificate> SelectMCById(string givenPatientId);
        [OperationContract]
        MedicalCertificate SelectOneMCById(string givenMCId);

        [OperationContract]
        int CreateDoctor(string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string signature, string password, string clinicId);
        [OperationContract]
        List<string> DoctorLoginVerify(string email, string password);

        [OperationContract]
        List<Patient> GetPatientByName(string name);

        [OperationContract]
        void AppointAddMRId(string typeid, string id);
        [OperationContract]
        void AppointAddMCId(string typeid, string id);
        [OperationContract]
        void AppointAddMIId(string typeid, string id);

        [OperationContract]
        Clinic SelectClinicByID(string givenClinicID);
        [OperationContract]
        List<Appointment> GetAppointmentByDoctorId(string doctorId);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "clinicDenoDB.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
