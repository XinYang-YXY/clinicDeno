using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicDenoDB.Entity
{
    class ClinicAdmin
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

        public string ClinicId { get; set; }
        public ClinicAdmin()
        {

        }
        // Define a constructor to initialize all the properties
        public ClinicAdmin(string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string password, string clinicId)
        {
            Email = email;
            PhoneNum = phoneNum;
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Gender = gender;
            Password = password;
            ClinicId = clinicId;

        }
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO ClinicAdmin (email, phoneNum, firstName, lastName, dob, gender, password, clinicId ) " +
                "VALUES ( @paraEmail,@paraPhoneNum, @paraFirstName, @paraLastName, @paraDob, @paraGender, @paraPassword, @paraClinicId)";
            MySqlCommand sqlCmd = new MySqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            // sqlCmd.Parameters.AddWithValue("@paraId", Id);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraPhoneNum", PhoneNum);
            sqlCmd.Parameters.AddWithValue("@paraFirstName", FirstName);
            sqlCmd.Parameters.AddWithValue("@paraLastName", LastName);
            sqlCmd.Parameters.AddWithValue("@paraDob", DOB);
            sqlCmd.Parameters.AddWithValue("@paraGender", Gender);
            sqlCmd.Parameters.AddWithValue("@paraPassword", Password);
            sqlCmd.Parameters.AddWithValue("@paraClinicId", ClinicId);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
    }
}
