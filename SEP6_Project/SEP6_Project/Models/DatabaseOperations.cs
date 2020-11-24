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
        public Weather getWeather()
        {
            Weather weather = new Weather();
            connect();
            string query = "select origin, year, month, day FROM WEATHER where wind_speed = '8.05546' and time_hour ='2013-05-09T03:00:00Z'";
            SqlCommand test = new SqlCommand(query, conn);
            SqlDataReader reader = test.ExecuteReader();
            while (reader.Read())
            {
                weather.Origin = reader["origin"].ToString();
                weather.Year = Convert.ToInt32(reader["year"].ToString());
                weather.Month = Convert.ToInt32(reader["month"].ToString());
                weather.Day = Convert.ToInt32(reader["day"].ToString());
            }
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
