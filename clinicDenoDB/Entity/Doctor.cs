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

        public Doctor(string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string signature, string password, string clientId)
        {
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

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Doctor (email, phoneNum, firstName, lastName, dob, gender, signature, password, clientId) " +
                "VALUES ( @paraEmail,@paraPhoneNum, @paraFirstName, @paraLastName, @paraDob, @paraGender, @paraSignature, @paraPassword, @paraClinicId); select last_insert_id();";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            // sqlCmd.Parameters.AddWithValue("@paraId", Id);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraPhoneNum", PhoneNum);
            sqlCmd.Parameters.AddWithValue("@paraFirstName", FirstName);
            sqlCmd.Parameters.AddWithValue("@paraLastName", LastName);
            sqlCmd.Parameters.AddWithValue("@paraDob", DOB);
            sqlCmd.Parameters.AddWithValue("@paraGender", Gender);
            sqlCmd.Parameters.AddWithValue("@paraSignature", Signature);
            sqlCmd.Parameters.AddWithValue("@paraPassword", Password);
            sqlCmd.Parameters.AddWithValue("@paraClinicId", ClientId);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public List<string> DoctorLoginVerify(string email, string password)
        {
            List<string> list = new List<string>(new string[] { "", "", "", " " });
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from Doctor where email=@paraEmail";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            // =======

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            int rec_cnt = ds.Tables[0].Rows.Count;
            string doctorPassword = "";
            string doctorId = "";
            string clinicId = "";
            string doctorSignature = "";
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                doctorPassword = row["password"].ToString();
                doctorId = row["id"].ToString();
                clinicId = row["clientId"].ToString();
                doctorSignature = row["signature"].ToString();
            }

            if (doctorPassword == password)
            {

                list[0] = "loginPass";
                list[1] = doctorId;
                list[2] = clinicId;
                list[3] = doctorSignature;
            }
            else
            {
                list[0] = "invalidPassword";
            }

            return list;

        }

    }
}
