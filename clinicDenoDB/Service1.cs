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

        public List<Appointment> GetAllAppointments()
        {
            Appointment appointment = new Appointment();
            return appointment.SelectAll();
        }
        public List<Appointment> GetAppointmentByPatientId(string patientId)
        {
            Appointment appointment = new Appointment();
            return appointment.GetAppointmentByPatientId(patientId);
        }

        

        public Patient GetPatientById(string id)
        {
            Patient patient = new Patient();
            return patient.GetById(id);
        }

        public string GetIdByNRIC(string nric)
        {
            Patient patient = new Patient();
            return patient.GetIdByNRIC(nric);
        }

        public Appointment GetAppointmentById(string id)
        {
            Appointment appointment = new Appointment();
            return appointment.GetAppointmentById(id);
        }

        public Doctor GetDoctorById(string id)
        {
            Doctor doctor = new Doctor();
            return doctor.SelectById(id);
        }

        public void UpdateAppointmentStatus(string id, string newAppId)
        {
            Appointment appointment = new Appointment();
            appointment.UpdateAppointmentStatus(id, newAppId);
        }

        public int CreateMR(DateTime date, string allergies, string familyMedicalHistory, string currentMedications, string diagnosis, string comment, string doctorId, string clinicId, string patientId, string appointmentId)
        {
            MedicalRecord medicalRecord = new MedicalRecord(date, allergies, familyMedicalHistory, currentMedications, diagnosis, comment, doctorId, clinicId, patientId, appointmentId);
            return medicalRecord.Insert();
        }
        public List<MedicalRecord> SelectMRById(string givenPatientId)
        {
            MedicalRecord medicalrecord = new MedicalRecord();
            return medicalrecord.SelectMRById(givenPatientId);
        }

        public MedicalRecord SelectOneMRById(string givenMRId)
        {
            MedicalRecord medicalrecord = new MedicalRecord();
            return medicalrecord.SelectOneMRById(givenMRId);
        }

        public int CreateMI(DateTime date, string prescription, string instruction, string quantity, string refills, string doctorId, string patientId, string appointmentId)
        {
            MedicalInstruct medicalInstruct = new MedicalInstruct(date, prescription, instruction, quantity, refills, doctorId, patientId, appointmentId);
            return medicalInstruct.Insert();
        }
        public List<MedicalInstruct> SelectMIById(string givenPatientId)
        {
            MedicalInstruct medicalInstruct = new MedicalInstruct();
            return medicalInstruct.SelectMIById(givenPatientId);
        }

        public MedicalInstruct SelectOneMIById(string givenMIId)
        {
            MedicalInstruct medicalInstruct = new MedicalInstruct();
            return medicalInstruct.SelectOneMIById(givenMIId);
        }
        public int CreateMC(DateTime startDate, DateTime endDate, string comments, string doctorId, string doctorSignature, string patientId, string appointmentId)
        {
            MedicalCertificate medicalCertificate = new MedicalCertificate(startDate, endDate, comments, doctorId, doctorSignature, patientId, appointmentId);
            return medicalCertificate.Insert();
        }
        public List<MedicalCertificate> SelectMCById(string givenPatientId)
        {
            MedicalCertificate medicalCertificate = new MedicalCertificate();
            return medicalCertificate.SelectMCById(givenPatientId);
        }

        public MedicalCertificate SelectOneMCById(string givenMCId)
        {
            MedicalCertificate medicalCertificate = new MedicalCertificate();
            return medicalCertificate.SelectOneMCById(givenMCId);
        }

        public int CreateDoctor(string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string signature, string password, string clinicId)
        {
            Doctor doctor = new Doctor(email, phoneNum, firstName, lastName, dob, gender, signature, password, clinicId);
            return doctor.Insert();

        }

        public List<string> DoctorLoginVerify(string email, string password)
        {
            Doctor doctor = new Doctor();
            return doctor.DoctorLoginVerify(email, password);
        }

        public List<Patient> GetPatientByName(string name)
        {
            Patient patient = new Patient();
            return patient.GetPatientByName(name);
        }

        public void AppointAddMRId(string typeid, string id)
        {
            Appointment appointment = new Appointment();
            appointment.AddMRId(typeid, id);
        }
        public void AppointAddMCId(string typeid, string id)
        {
            Appointment appointment = new Appointment();
            appointment.AddMCId(typeid, id);
        }
        public void AppointAddMIId(string typeid, string id)
        {
            Appointment appointment = new Appointment();
            appointment.AddMIId(typeid, id);
        }
        public Clinic SelectClinicByID(string givenClinicID)
        {
            Clinic clinic = new Clinic();
            return clinic.SelectClinicByID(givenClinicID);
        }
        public List<Appointment> GetAppointmentByDoctorId(string doctorId)
        {
            Appointment appointment = new Appointment();
            return appointment.GetAppointmentByDoctorId(doctorId);
        }
    }
}
