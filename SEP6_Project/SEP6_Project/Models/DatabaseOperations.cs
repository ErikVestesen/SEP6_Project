using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_Project.Models
{
    public class DatabaseOperations
    {
        SqlConnection conn = new SqlConnection("Data Source=den1.mssql8.gear.host;Initial Catalog=sep6;User id=sep6;Password=Dr4uvX~_Nkx4;");

        public Weather getWeather()
        {
            conn.Open();
            Weather weather = new Weather();
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
            reader.Close();
            conn.Close();
            
            return weather;
        }

        public IDictionary<int, int> TotalFlightsMonth()
        {
            IDictionary<int, int> flights = new Dictionary<int, int>();

            conn.Open();
            for (int j = 1; j < 13; j++)
            {
                //int total = 0;
                string query = "SELECT COUNT(month) as 'month' FROM flights WHERE month = " + j;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(j, Convert.ToInt32(reader["month"]));
                }
                reader.Close();
            }
            conn.Close();
            return flights;
        }
        public List<int> FlightsOriginJFK()
        {
            //IDictionary<int, int> flights = new Dictionary<int, int>();
            List<int> flights = new List<int>();
            conn.Open();
            for (int j = 1; j < 13; j++)
            {
                //int total = 0;
                string query = "SELECT COUNT(month) as 'month' FROM flights WHERE month = " + j + "AND origin = 'JFK'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(Convert.ToInt32(reader["month"]));
                }
                reader.Close();
            }
            conn.Close();
            return flights;
        }

        public List<int> FlightsOriginEWR()
        {
            //IDictionary<int, int> flights = new Dictionary<int, int>();
            List<int> flights = new List<int>();
            conn.Open();
            for (int j = 1; j < 13; j++)
            {
                //int total = 0;
                string query = "SELECT COUNT(month) as 'month' FROM flights WHERE month = " + j + "AND origin = 'EWR'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(Convert.ToInt32(reader["month"]));
                }
                reader.Close();
            }
            conn.Close();
            return flights;
        }

        public List<int> FlightsOriginLGA()
        {
            //IDictionary<int, int> flights = new Dictionary<int, int>();
            List<int> flights = new List<int>();
            conn.Open();
            for (int j = 1; j < 13; j++)
            {
                //int total = 0;
                string query = "SELECT COUNT(month) as 'month' FROM flights WHERE month = " + j + "AND origin = 'LGA'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flights.Add(Convert.ToInt32(reader["month"]));
                }
                reader.Close();
            }
            conn.Close();
            return flights;
        }


        public IDictionary<string, int> Top10Flights()
        {
            IDictionary<string, int> flights = new Dictionary<string, int>();

            conn.Open();
            string query = "SELECT TOP(10) dest, Count(*) as flights FROM flights GROUP BY dest ORDER BY Count(*) DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                flights.Add(reader["dest"].ToString(), Convert.ToInt32(reader["flights"]));
            }
            reader.Close();
            conn.Close();
            return flights;
        }

        public List<int> Top10FlightsForOrigin(IDictionary<string, int> flights, string origin)
        {

            List<int> flightTotal = new List<int>(); 

            conn.Open();
            //string query = "SELECT TOP(10) dest, Count(*) as flights FROM flights WHERE dest = "+origin+" GROUP BY dest ORDER BY Count(*) DESC";
            string query = "";
            foreach(var dest in flights)
            {
                query = "SELECT TOP(10) dest, Count(*) as flights FROM flights WHERE origin = '"+origin+"' AND dest = '" + dest.Key + "' GROUP BY dest ORDER BY dest DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    flightTotal.Add(Convert.ToInt32(reader["flights"]));
                }
                reader.Close();
            }
            conn.Close();
            return flightTotal;
        }


        //The mean AirTime of each of the origins in a table
        public List<string> MeanAirtime()
        {
            List<string> meanAirtime = new List<string>();

            conn.Open();
            string query = "";

            query = "SELECT AVG(CAST(air_time as bigint)) AS mean_air_time, origin FROM flights WHERE air_time  <> 'NA' GROUP BY origin";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                meanAirtime.Add(reader["origin"].ToString());
                meanAirtime.Add(reader["mean_air_time"].ToString());
            }
            reader.Close();

            conn.Close();
            return meanAirtime;
        }

        //All weather observations from origin
        public List<string> WeatherObservations()
        {
            List<string> weatherOb = new List<string>();

            conn.Open();
            string query = "";

            query = "SELECT COUNT(*) AS Weather_Observations, origin FROM weather GROUP BY origin";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                weatherOb.Add(reader["origin"].ToString());
                weatherOb.Add(reader["Weather_Observations"].ToString());
            }
            reader.Close();

            conn.Close();
            return weatherOb;
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
                            "WHERE origin = '" + origin + "' " +
                            "GROUP BY datepart(day, weather.time_hour), datepart(month, weather.time_hour), datepart(year, weather.time_hour) " +
                            "ORDER BY mm ASC, dd ASC, yyyy ASC ";

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
        public double fahrenheitToCelcius(double fahrenheit)
        {
            return (fahrenheit - 32) * (5.0 / 9.0);
        }


        public double[] getMeanDepArr(string origin)
        {
            SqlConnection conn = new SqlConnection("Data Source=den1.mssql8.gear.host;Initial Catalog=sep6;User id=sep6;Password=Dr4uvX~_Nkx4;");
            double[] result = new double[2];

            conn.Open(); 

            string query = "select avg(TRY_CAST(f.dep_delay as DECIMAL(10,2))) as dep_delay,avg(TRY_CAST(f.arr_delay as DECIMAL(10,2))) as arr_delay, "+
                            "origin "+
                            "from flights f "+
                            "where origin = '"+origin+"' "+
                            "GROUP BY origin";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result[0] = Convert.ToDouble(reader["dep_delay"]);
                result[1] = Convert.ToDouble(reader["arr_delay"]);
            }
            reader.Close();


            conn.Close();
            return result;
        }

        public List<Manufacturer> getBigManufacturers()
        {
            SqlConnection conn = new SqlConnection("Data Source=den1.mssql8.gear.host;Initial Catalog=sep6;User id=sep6;Password=Dr4uvX~_Nkx4;");
            List<Manufacturer> result = new List<Manufacturer>();


            conn.Open(); 
            string query =  "SELECT manufacturer,COUNT(manufacturer) AS planes  " +
                            "FROM planes "+
                            "GROUP BY manufacturer "+
                            "HAVING COUNT(manufacturer) >= 200";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Manufacturer m = new Manufacturer();
                m.name = reader["manufacturer"].ToString();
                m.plane_count = Convert.ToInt32(reader["planes"]);
                result.Add(m);
            }
            reader.Close();


            conn.Close();
            return result;
        }

        public List<Manufacturer> getManufacturersFlight()
        {
            SqlConnection conn = new SqlConnection("Data Source=den1.mssql8.gear.host;Initial Catalog=sep6;User id=sep6;Password=Dr4uvX~_Nkx4;");
            List<Manufacturer> result = new List<Manufacturer>();


            conn.Open(); 
            string query = "SELECT COUNT(*) AS flight_count, p.manufacturer " +
                            "FROM flights " +
                            "OUTER APPLY " +
                                "(SELECT tailnum, manufacturer " +
                                "FROM planes " +
                                "WHERE manufacturer in " +
                                "(" +
                                    "SELECT manufacturer " + 
                                    "FROM planes " +
                                    "GROUP BY manufacturer " + 
                                "HAVING COUNT(manufacturer) >= 200 " +
                                ")) " + 
                            "AS p " +
                            "WHERE p.tailnum = flights.tailnum " +
                            "GROUP BY p.manufacturer";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Manufacturer m = new Manufacturer();
                m.name = reader["manufacturer"].ToString();
                m.flight_count = Convert.ToInt32(reader["flight_count"]);
                result.Add(m);
            }
            reader.Close();


            conn.Close();
            return result;
        }


        public List<(string, int)> getAirbusModels()
        {
            SqlConnection conn = new SqlConnection("Data Source=den1.mssql8.gear.host;Initial Catalog=sep6;User id=sep6;Password=Dr4uvX~_Nkx4;");
            List<(string, int)> result = new List<(string, int)>();


            conn.Open();
            string query = "SELECT model, count(model) AS model_count " +
                           "FROM planes "+
                           "WHERE manufacturer = 'AIRBUS' "+
                           "GROUP BY model";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add((reader["model"].ToString(), Convert.ToInt32(reader["model_count"])));
            }
            reader.Close();


            conn.Close();
            return result;
        }
    }
}
