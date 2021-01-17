using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace clinicDenoDB.Entity
{
    public class Clinic
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string ClinicName { get; set; }

        public string ClinicType { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Clinic()
        {

        }
        // Define a constructor to initialize all the properties
        public Clinic(string id, string address, string phoneNum, string email, string clinicName, string clinicType, string startTime, string endTime)
        {
            Id = id;
            Address = address;
            PhoneNum = phoneNum;
            Email = email;
            ClinicName = clinicName;
            ClinicType = clinicType;
            StartTime = startTime;
            EndTime = endTime;
        }
        public Clinic SelectById(string id)
        {
            //Customer cust = new Customer("111", "Phoon LK", "Nanyang Polytechnic", "560860", "61234567", "91234567");
            //return cust;

            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * from Clinic where id = @paraId";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            int rec_cnt = ds.Tables[0].Rows.Count;
            Clinic obj = null;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string clinicId = row["id"].ToString();
                string address = row["address"].ToString();
                string phoneNum = row["phoneNum"].ToString();
                string email = row["email"].ToString();
                string clinicName = row["clinicName"].ToString();
                string clinicType = row["clinicType"].ToString();
                string startTime = row["startTime"].ToString();
                string endTime = row["endTime"].ToString();

                obj = new Clinic(clinicId, address, phoneNum, email, clinicName, clinicType, startTime, endTime);
            }
            return obj;
        }
    }
}
