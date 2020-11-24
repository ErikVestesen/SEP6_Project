using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_Project.Models
{
    public class DatabaseOperations
    {
        SqlConnection conn = new SqlConnection();
        public string getWeather()
        {
            connect();
            string weather = "";
            string query = "select * FROM WEATHER where wind_speed = '8.05546' and time_hour ='2013-05-09T03:00:00Z'";
            SqlCommand test = new SqlCommand(query, conn);
            SqlDataReader reader = test.ExecuteReader();
            while (reader.Read())
            {

            }
            test.ExecuteNonQuery();
            return weather;
        }

        public void connect()
        {
            conn.ConnectionString =
            "Data Source=den1.mssql8.gear.host;" +
            "Initial Catalog=sep6;" +
            "User id=sep6;" +
            "Password=Dr4uvX~_Nkx4;";
            conn.Open();
        }
    }
}
