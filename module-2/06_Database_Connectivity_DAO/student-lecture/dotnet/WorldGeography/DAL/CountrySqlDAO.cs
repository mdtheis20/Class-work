using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based country dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CountrySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }        

        public IList<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    const string QUERY = "SELECT * FROM country;";
                    SqlCommand sqlCommand = new SqlCommand(QUERY, sqlConnection);
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while(reader.Read())
                    {
                        Country country = ParseRow(reader);
                        //Parse one row of data
                        countries.Add(country);

                    }
                }
            
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Something went Wrong");
                Console.WriteLine(ex.Message);
                throw;
            }
            return countries;
            
        }

        private Country ParseRow(SqlDataReader reader)
        {
            Country country = new Country();

            country.Code = Convert.ToString(reader["code"]);
            country.Name = Convert.ToString(reader["name"]);
            country.Continent = Convert.ToString(reader["continent"]);
            country.Region = Convert.ToString(reader["region"]);
            country.SurfaceArea = Convert.ToDouble(reader["surfacearea"]);
            country.Population = Convert.ToInt32(reader["population"]);
            country.GovernmentForm = Convert.ToString(reader["governmentform"]);

            return country;
        }

        public IList<Country> GetCountries(string continent)
        {
            List<Country> countries = new List<Country>();

            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    const string QUERY = "SELECT * FROM country WHERE continent = @continent;";

                    SqlCommand sqlCommand = new SqlCommand(QUERY, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("@continent", continent);

                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Country country = ParseRow(reader);

                        countries.Add(country);
                    }


                }


            }
            catch(SqlException ex)
            {

                Console.WriteLine("Something went wrong");
                Console.WriteLine(ex.Message);
                throw;
            }


            return countries;
        }
    }
}
