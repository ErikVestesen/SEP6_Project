using Microsoft.AspNetCore.Mvc;
using SEP6_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace SEP6_Project.Controllers
{
    public class TempController : Controller
    {
        public IActionResult TempIndex()
        {
            return View();
        }


        public double fahrenheitToCelcius(double fahrenheit)
        { 
            return (fahrenheit - 32) * (5.0 / 9.0); 
        }

        public JsonResult GetTempModel()
        {
            TempModel tm = new TempModel();
            tm = loadTempModel();
            return Json(tm);
        }

        public TempModel loadTempModel()
        {
            TempModel tm = new TempModel();

            //tm.daily_temp_JFK = getDailyTempFromOrigin("JFK");
            //tm.daily_temp_EWR = getDailyTempFromOrigin("EWR");
            //tm.daily_temp_LGA = getDailyTempFromOrigin("LGA");

            tm.temp_JFK = getTempFromOrigin("JFK");
            tm.temp_EWR = getTempFromOrigin("EWR");
            tm.temp_LGA = getTempFromOrigin("LGA");

            return tm;
        }

        public JsonResult loadTempJFK()
        {
            TempModel tm = new TempModel();

            tm.temp_JFK = getTempFromOrigin("JFK");

            return Json(tm);
        }

        public JsonResult loadTempEWR()
        {
            TempModel tm = new TempModel();

            tm.temp_EWR = getTempFromOrigin("EWR");

            return Json(tm);
        }

        public JsonResult loadTempLGA()
        {
            TempModel tm = new TempModel();

            tm.temp_LGA = getTempFromOrigin("LGA");

            return Json(tm);
        }

        public List<Temperature> getTempFromOrigin(string origin)
        {
            //Move me to db operations
            SqlConnection conn = new SqlConnection("Data Source=den1.mssql8.gear.host;Initial Catalog=sep6;User id=sep6;Password=Dr4uvX~_Nkx4;");
            List<Temperature> result = new List<Temperature>();

            conn.Open();

            string query = "SELECT TRY_CAST(temp as DECIMAL(10,2)) as temp, " +
                            "datepart(day, weather.time_hour) as dd, " +
                            "datepart(month, weather.time_hour) as mm, " +
                            "datepart(year, weather.time_hour) as yyyy " +
                            "FROM weather " +
                            "WHERE origin = '" + origin + "' " +
                            "GROUP BY datepart(day, weather.time_hour), datepart(month, weather.time_hour), datepart(year, weather.time_hour), weather.temp " +
                            "ORDER BY dd ASC, mm ASC, yyyy ASC ";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["temp"] != System.DBNull.Value)
                {
                    Temperature t = new Temperature(
                    origin,
                    fahrenheitToCelcius(Convert.ToDouble(reader["temp"])),
                    Convert.ToInt32(reader["dd"]),
                    Convert.ToInt32(reader["mm"]),
                    Convert.ToInt32(reader["yyyy"])
                    );
                    result.Add(t);
                }
            }
            reader.Close();

            conn.Close();
            return result;
        }
        
        public List<Temperature> getDailyTempFromOrigin(string origin)
        {
            //Move me to db operations
            SqlConnection conn = new SqlConnection("Data Source=den1.mssql8.gear.host;Initial Catalog=sep6;User id=sep6;Password=Dr4uvX~_Nkx4;");
            List<Temperature> result = new List<Temperature>();

            conn.Open();

            string query = "SELECT avg(TRY_CAST(temp as DECIMAL(10,2))) as dailytemp, " +
                            "datepart(day, weather.time_hour) as dd, " +
                            "datepart(month, weather.time_hour) as mm, " +
                            "datepart(year, weather.time_hour) as yyyy " +
                            "FROM weather " +
                            "WHERE origin = '"+origin+"' " +
                            "GROUP BY datepart(day, weather.time_hour), datepart(month, weather.time_hour), datepart(year, weather.time_hour) " +
                            "ORDER BY dd ASC, mm ASC, yyyy ASC ";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Temperature t = new Temperature(
                    origin,
                    fahrenheitToCelcius(Convert.ToDouble(reader["dailytemp"])),
                    Convert.ToInt32(reader["dd"]),
                    Convert.ToInt32(reader["mm"]),
                    Convert.ToInt32(reader["yyyy"])
                    );
                result.Add(t);
            }
            reader.Close();
            
           
            conn.Close();
            return result;
        }
    }
}
