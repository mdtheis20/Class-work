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


            //Create a connection to the database with using
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "Select * from city";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    City city = RowToObject(rdr);

                    //Add it to the list

                    cities.Add(city);

                }
            }


            // TODO 02: Add code to list all cities

            return cities;
        }

        private static City RowToObject(SqlDataReader rdr)
        {
            //I am now pointing to one row of the result set. Create a new city and populate its properties.
            City city = new City();
            city.Id = Convert.ToInt32(rdr["id"]);
            city.CountryCode = Convert.ToString(rdr["CountryCode"]);
            city.Population = Convert.ToInt32(rdr["Population"]);
            city.District = Convert.ToString(rdr["District"]);
            city.Name = Convert.ToString(rdr["Name"]);
            return city;
        }

        public IList<City> GetAllCitiesInState(string state)
        {
            List<City> cities = new List<City>();

            using (SqlConnection conn = new SqlConnection(@"Server=.\SqlExpress; Database=World; Trusted_Connection=True;"))
            {
                conn.Open();
                string sql = "Select * from city where district = @stateName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@stateName", state);

                //Execute
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    City city = RowToObject(rdr);

                    cities.Add(city);
                }

            }

            return cities;
        }

        public void UpdatePopulation(string cityName, int population)
        {
            // TODO 04: Add code to update the population of a city
            string sql = @"Update city Set population = @pop where name = @city";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@pop", population);
                cmd.Parameters.AddWithValue("@city", cityName);

                //Execute the update

                int rowsAffected = cmd.ExecuteNonQuery();

                //Here I can test for rows affected


            }


            return;
        }

        public int AddCity(City city)
        {
            // TODO 05: Add code to add a new city


            string sql = "Insert into City (name, countrycode, district, population) Values (@name, @countrycode, @district, @population);Select @@ Identity";


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

                //cmd.ExecuteNonQuery();
            }


        }

        public void DeleteUSCity(string cityName, string stateName)
        {
            // TODO 08: Add code to Delete a US city based on parameters passed in

            string sql = "Delete from city where name = @cityName And district = @stateName";
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
