using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DatabaseAccess
{
    /// <summary>
    /// This class is responsible for access the SQL Server database, and converting row data to objects and vice-versa
    /// </summary>
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        public CitySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<City> GetAllCities()
        {
            List<City> cities = new List<City>();

            try
            {
                // Create a connection to the database with using
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "Select * from city";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        // I am now pointing to one row of the result set. Create a new city and populate its properties
                        City city = RowToObject(rdr);

                        // Add it to the list
                        cities.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                // To do: Log this error somewhere
                return null;
            }
            return cities;
        }

        private static City RowToObject(SqlDataReader rdr)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(rdr["ID"]);
            city.Population = Convert.ToInt32(rdr["population"]);
            city.CountryCode = Convert.ToString(rdr["CountryCode"]);
            city.District = Convert.ToString(rdr["district"]);
            city.Name = Convert.ToString(rdr["name"]);
            return city;
        }

        public IList<City> GetAllCitiesInState(string state)
        {
            List<City> cities = new List<City>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "Select * from city where district = @stateName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@stateName", state);

                // Execute
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    // I am now pointing to one row of the result set. Create a new city and populate its properties

                    // Add it to the list
                    cities.Add(RowToObject(rdr));
                }
            }

            return cities;
        }

        public void UpdatePopulation(string cityName, int population)
        {
            // Add code to update the population of a city
            string sql = @"
Update city 
	Set population = @pop
	where name = @city";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@city", cityName);
                cmd.Parameters.AddWithValue("@pop", population);

                // Execute the Update
                int rowsAffected = cmd.ExecuteNonQuery();

                // Here I can test for rows affected 
            }

            return;

        }

        public int AddCity(City city)
        {
            string sql =
               @"Insert into City (name, countrycode, district, population) 
                    Values (@name, @countrycode, @district, @population);
                    Select @@Identity";

            // Add code to add a new city
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", city.Name);
                cmd.Parameters.AddWithValue("@Population", city.Population);
                cmd.Parameters.AddWithValue("@District", city.District);
                cmd.Parameters.AddWithValue("@CountryCode", city.CountryCode);

                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                return newId;
            }
        }

        public void DeleteUSCity(string cityName, string stateName)
        {
            // Add code to Delete a US city based on parameters passed in
            string sql = "Delete From city Where name = @cityName And district = @stateName";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cityName", cityName);
                cmd.Parameters.AddWithValue("@stateName", stateName);

                cmd.ExecuteNonQuery();
            }
            return;
        }

    }
}
