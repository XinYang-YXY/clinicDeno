using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicDenoDB.Entity
{
    public class Patient
    {

        public string Id { get; set; }
        public string SecretId { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Nric { get; set; }

        public Patient() { }
        public Patient(string id, string secretId, string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string password, string nric)
        {
            Id = id;
            SecretId = secretId;
            Email = email;
            PhoneNum = phoneNum;
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Gender = gender;
            Password = password;
            Nric = nric;

        }
        public Patient GetById(string id)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Patient WHERE id = @id";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@id", id);

            DataSet ds = new DataSet();

            da.Fill(ds);

            Patient patient = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string patientId = row["id"].ToString();
                string secretId = row["secretId"].ToString();
                string dataEmail = row["email"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();
                string password = row["password"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gender = row["gender"].ToString();
                string nric = row["nric"].ToString();

                patient = new Patient(patientId, secretId, dataEmail, phoneNum, firstName, lastName, dob, gender, password, nric);
            }
            return patient;
        }

        public string  GetIdByNRIC(string nric)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Patient WHERE NRIC = @nric";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@nric", nric);

            DataSet ds = new DataSet();

            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            string obtainedId = "";
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                obtainedId = row["id"].ToString();
            }
            return obtainedId;

        }

        public List<Patient> GetPatientByName(string name)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from patient where concat(firstName,' ',lastName) like @paraName";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraName", "%"+ name + "%");

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            List<Patient> PatientList = new List<Patient>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string patientId = row["id"].ToString();
                string secretId = row["secretId"].ToString();
                string dataEmail = row["email"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();
                string password = row["password"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gender = row["gender"].ToString();
                string nric = row["nric"].ToString();

                Patient patient = new Patient(patientId, secretId, dataEmail, phoneNum, firstName, lastName, dob, gender, password, nric);
                PatientList.Add(patient);
            }
            return PatientList;
        }

    }
}
