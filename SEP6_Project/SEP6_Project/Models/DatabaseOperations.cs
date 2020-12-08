﻿using System;
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
    }
}
