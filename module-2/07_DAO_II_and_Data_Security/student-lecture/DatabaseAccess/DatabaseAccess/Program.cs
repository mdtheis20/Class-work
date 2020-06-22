using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using DatabaseAccess.Models;
using System.Data.SqlClient;

namespace DatabaseAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            CitySqlDAO data = new CitySqlDAO(@"Server=.\SqlExpress; Database=World; Trusted_Connection=True");

            // Execute a Select using a SQL Connection, Command and ExecuteReader.

            /*****************************************************************************/
            // Get the list of all cities in the world
            IList<City> cities = data.GetAllCities();

            // Print the list 
            Console.WriteLine(City.GetHeader());
            foreach (City city in cities)
            {
                Console.WriteLine(city);
            }
            Console.ReadLine();
            Console.Clear();
            /*****************************************************************************/

            /*****************************************************************************/
            // Get the list of all cities in Ohio
            // Execute a Select with parameters
            cities = data.GetAllCitiesInState("Ohio");
            Console.WriteLine(City.GetHeader());
            foreach (City city in cities)
            {
                Console.WriteLine(city);
            }
            Console.ReadLine();

            /*****************************************************************************/
            // Execute an Update using ExecuteNonQuery
            data.UpdatePopulation("Cleveland", 100);


            /*****************************************************************************/
            // Execute an Insert using ExecuteScalar
            City newCity = new City()
            {
                Name = "Joe City",
                CountryCode = "USA",
                District = "Ohio",
                Population = 1
            };

            // TODO 06: Fill in the data here

            int newCityId = data.AddCity(newCity);

            Console.WriteLine($"{newCity.Name} was added as city id {newCityId}!");

            // TODO 07: Get the Id of the new city

            /*****************************************************************************/
            // Execute a Delete using ExecuteNonQuery
            data.DeleteUSCity("Richfield", "Ohio");

            return;
        }

    }
}
