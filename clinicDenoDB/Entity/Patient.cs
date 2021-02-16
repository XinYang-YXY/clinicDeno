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

    }
}
