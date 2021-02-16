using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicDenoDB.Entity
{
    public class Doctor
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Signature { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }

        public Doctor() { }

        public Doctor(string id, string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string signature, string password, string clientId)
        {
            Id = id;
            Email = email;
            PhoneNum = phoneNum;
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Gender = gender;
            Signature = signature;
            Password = password;
            ClientId = clientId;
        }

        public Doctor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Doctor SelectById(string id)
        {
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            string sqlStmt = "SELECT * FROM Doctor WHERE id = @id";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@id", id);

            DataSet ds = new DataSet();

            da.Fill(ds);

            Doctor doctor = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string email = row["email"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();
                DateTime dob = Convert.ToDateTime(row["dob"].ToString());
                string gender = row["gender"].ToString();
                string signature = row["signature"].ToString();
                string password = row["password"].ToString();
                string clientId = row["clientId"].ToString();

                doctor = new Doctor(id, email, phoneNum, firstName, lastName, dob, gender, signature, password, clientId);
            }
            return doctor;
        }




    }
}
