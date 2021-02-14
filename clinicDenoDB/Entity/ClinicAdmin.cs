using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        public string VerificationId { get; set; }
        public ClinicAdmin()
        {

        }
        // Define a constructor to initialize all the properties
        public ClinicAdmin(string email, string phoneNum, string firstName, string lastName, DateTime dob, string gender, string password, string clinicId, string verficationId)
        {
            Email = email;
            PhoneNum = phoneNum;
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Gender = gender;
            Password = password;
            ClinicId = clinicId;
            VerificationId = verficationId;


        }
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO ClinicAdmin (email, phoneNum, firstName, lastName, dob, gender, password, clinicId, verificationId ) " +
                "VALUES ( @paraEmail,@paraPhoneNum, @paraFirstName, @paraLastName, @paraDob, @paraGender, @paraPassword, @paraClinicId, @paraVerificationId)";
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
            sqlCmd.Parameters.AddWithValue("@paraVerificationId", VerificationId);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            // Step 5 :Close connection
            myConn.Close();

            return result;
        }

        public void UpdateVerificationStatus(string verificationId)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Update ClinicAdmin Set verified=1 Where verificationId= @paraVerificationId";
            MySqlCommand sqlCmd = new MySqlCommand(sqlstmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraVerificationId", verificationId);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            // Step 5 :Close connection
            myConn.Close();
        }

        public string AdminLoginVerify(string email, string password)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from ClinicAdmin where email=@paraEmail";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            // =======

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            int rec_cnt = ds.Tables[0].Rows.Count;
            string adminPassword = "";
            string verifiedId = "0";
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                adminPassword = row["password"].ToString();
                verifiedId = row["verified"].ToString();
            }
            if (verifiedId == "1")
            {
                if (adminPassword == password)
                {

                    return "loginPass";
                }
                else
                {
                    return "invalidPassword";
                }

            }
            else
            {
                return "emailVerifyFail";
            }
        }
    }
}

