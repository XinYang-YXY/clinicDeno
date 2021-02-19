using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinicDenoDB.Entity
{
    public class Specialty
    {
        public string specialtyName { get; set; }

        public Specialty()
        {

        }

        public Specialty(string specialtyName)
        {
            this.specialtyName = specialtyName;
        }

        public List<Specialty> SelectAllSpecialty()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = Environment.GetEnvironmentVariable("MyDenoDB").ToString();
            MySqlConnection myConn = new MySqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlstmt = "Select * FROM specialty";
            MySqlDataAdapter da = new MySqlDataAdapter(sqlstmt, myConn);

            DataSet ds = new DataSet();

            da.Fill(ds);

            //Step 5 -  Read data from DataSet to list.
            int rec_cnt = ds.Tables[0].Rows.Count;
            List<Specialty> specialtyList = new List<Specialty>();
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string specialtyName = row["specialtyName"].ToString();

                Specialty obj = new Specialty(specialtyName);
                specialtyList.Add(obj);
            }
            return specialtyList;
        }
    }
}
