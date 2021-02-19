using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicDenoDB.Entity
{
    public class Appointment
    {

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public string Status { get; set; }
        public string MCId { get; set; }
        public string MRId { get; set; }
        public string MIId { get; set; }
        public string clinicName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string clinicType { get; set; }
        public int clinicId { get; set; }

        public Appointment()
        {
        }

        public Appointment(string id, DateTime date, string patientId, string status)
        {
            Id = id;
            Date = date;
            PatientId = patientId;
            Status = status;
        }

        public Appointment(string id, DateTime date, TimeSpan time, string doctorId, string patientId, string status)
        {
            Id = id;
            Date = date;
            Time = time;
            DoctorId = doctorId;
            PatientId = patientId;
            Status = status;

        }

        public Appointment(string id, DateTime date, TimeSpan time, string doctorId, string patientId, string status, string mcid, string mrid, string miid)
        {
            Id = id;
            Date = date;
            Time = time;
            DoctorId = doctorId;
            PatientId = patientId;
            Status = status;
            MCId = mcid;
            MRId = mrid;
            MIId = miid;

        }

        public Appointment(string id, DateTime date, TimeSpan time, string doctorId, string patientId, string status, string mcid, string mrid, string miid, string clinicname, string firstname, string lastname, string clinictype)
        {
            Id = id;
            Date = date;
            Time = time;
            DoctorId = doctorId;
            PatientId = patientId;
            Status = status;
            MCId = mcid;
            MRId = mrid;
            MIId = miid;
            clinicName = clinicname;
            firstName = firstname;
            lastName = lastname;
            clinicType = clinictype;
        }

        public List<Appointment> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Appointment> appointmentList = new List<Appointment>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string id = row["id"].ToString();
                DateTime date = Convert.ToDateTime(row["date"].ToString());
                string patientId = row["patientId"].ToString();
                string status = row["status"].ToString();
                
                Appointment obj = new Appointment(id, date, patientId, status);
                appointmentList.Add(obj);
            }
            return appointmentList;
        }
        public List<Appointment> GetAppointmentByPatientId(string patientId)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment Where patientId = @paraPatientId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraPatientId", patientId);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Appointment> appointmentList = new List<Appointment>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string id = row["id"].ToString();
                DateTime date = Convert.ToDateTime(row["date"].ToString());
                TimeSpan time = TimeSpan.Parse(row["time"].ToString());
                string doctorId = row["doctorId"].ToString();
                string status = row["status"].ToString();

                Appointment obj = new Appointment(id, date, time, doctorId, patientId, status);
                appointmentList.Add(obj);
            }
            return appointmentList;
        }

        public Appointment GetAppointmentById(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * FROM appointment INNER JOIN doctor ON doctor.id = appointment.doctorId INNER JOIN clinic on clinic.id = doctor.clientId WHERE appointment.id = @paraId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            Appointment appointment = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string ID = row["id"].ToString();
                DateTime date = Convert.ToDateTime(row["date"].ToString());
                TimeSpan time = TimeSpan.Parse(row["time"].ToString());
                string doctorid = row["doctorId"].ToString();
                string patientId = row["patientId"].ToString();
                string status = row["status"].ToString();
                string MCId = row["MCId"].ToString();
                string medicalRecordId = row["medicalRecordId"].ToString();
                string medicalInstructId = row["medicalInstructId"].ToString();
                string sclinicName = row["clinicName"].ToString();
                string doctorFN = row["firstName"].ToString();
                string doctorLN = row["lastName"].ToString();
                string sclinicType = row["clinicType"].ToString();

                appointment = new Appointment(ID, date, time, doctorid, patientId, status, MCId, medicalRecordId, medicalInstructId, sclinicName, doctorFN, doctorLN, sclinicType);
            }
            return appointment;
        }

        public void UpdateAppointmentStatus(string id, string newAppointmentStatus)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Update Appointment Set status=@paraAppStatus  Where id=@paraId";
            MySqlCommand sqlCmd = new MySqlCommand(sqlstmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraAppStatus", newAppointmentStatus);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            // Step 5 :Close connection
            myConn.Close();
        }

        public void AddMRId(string typeid, string id)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlstmt = "UPDATE appointment SET medicalRecordId = @typeid WHERE id = @id";
            MySqlCommand sqlCmd = new MySqlCommand(sqlstmt, myConn);
            sqlCmd.Parameters.AddWithValue("@typeid", typeid);
            sqlCmd.Parameters.AddWithValue("@id", id);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void AddMCId(string typeid, string id)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlstmt = "UPDATE appointment SET MCId = @typeid WHERE id = @id";
            MySqlCommand sqlCmd = new MySqlCommand(sqlstmt, myConn);
            sqlCmd.Parameters.AddWithValue("@typeid", typeid);
            sqlCmd.Parameters.AddWithValue("@id", id);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void AddMIId(string typeid, string id)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlstmt = "UPDATE appointment SET medicalInstructId = @typeid WHERE id = @id";
            MySqlCommand sqlCmd = new MySqlCommand(sqlstmt, myConn);
            sqlCmd.Parameters.AddWithValue("@typeid", typeid);
            sqlCmd.Parameters.AddWithValue("@id", id);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public List<Appointment> GetAppointmentByDoctorId(string doctorId)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment Where doctorId = @paraDoctorId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraDoctorId", doctorId);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Appointment> appointmentList = new List<Appointment>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string ID = row["id"].ToString();
                DateTime date = Convert.ToDateTime(row["date"].ToString());
                TimeSpan time = TimeSpan.Parse(row["time"].ToString());
                string doctorid = row["doctorId"].ToString();
                string patientId = row["patientId"].ToString();
                string status = row["status"].ToString();
                string MCId = row["MCId"].ToString();
                string medicalRecordId = row["medicalRecordId"].ToString();
                string medicalInstructId = row["medicalInstructId"].ToString();

                Appointment appointment = new Appointment(ID, date, time, doctorid, patientId, status, MCId, medicalRecordId, medicalInstructId);
                appointmentList.Add(appointment);
            }
            return appointmentList;
        }
    }
}
