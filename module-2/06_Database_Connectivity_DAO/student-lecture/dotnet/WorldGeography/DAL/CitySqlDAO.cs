using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseconnectionString"></param>
        public CitySqlDAO(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }

        public void AddCity(City city)
        {
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    const string QUERY = "Insert Into city (name, countrycode, district, population) Values (@name, @countrycode, @district, @population)";
                    SqlCommand sqlCommand = new SqlCommand(QUERY, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@name", city.Name);
                    sqlCommand.Parameters.AddWithValue("@countrycode", city.CountryCode);
                    sqlCommand.Parameters.AddWithValue("@district", city.District);
                    sqlCommand.Parameters.AddWithValue("@population", city.Population);

                    sqlCommand.ExecuteNonQuery();

                     sqlCommand = new SqlCommand("SELECT MAX(id) FROM city;", sqlConnection);
                    int idOfInsertedRow = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    Console.WriteLine("My new id is: " + idOfInsertedRow);

                    city.CityId = idOfInsertedRow;


                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error saving new city. " + ex.Message);
                throw;
            }
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            List<City> cities = new List<City>();

            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    const string QUERY = "SELECT * From city WHERE countryCode = @countryCode ORDER BY district, name";
                    SqlCommand sqlCommand = new SqlCommand(QUERY, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@countryCode", countryCode);


                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while(reader.Read())
                    {
                        City city = ParseRow(reader);

                        cities.Add(city);
                    }
                }
            }
            catch(SqlException ex)
            {

            }
            return cities;
        }

        private City ParseRow(SqlDataReader reader)
        {

            City city = new City();

            city.CityId = Convert.ToInt32(reader["id"]);
            city.Name = Convert.ToString(reader["name"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.District = Convert.ToString(reader["district"]);
            city.Population = Convert.ToInt32(reader["population"]);

            return city;
        }

    }
}
