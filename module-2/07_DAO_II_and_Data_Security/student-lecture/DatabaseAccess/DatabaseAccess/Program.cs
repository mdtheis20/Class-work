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
            DataAccess data = new DataAccess();
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
            data.UpdateUSPresident("Donald J Trump");


            /*****************************************************************************/
            // Execute an Insert using ExecuteScalar
            City newCity = new City();

            // TODO 06: Fill in the data here

            data.AddCity(newCity);

            // TODO 07: Get the Id of the new city

            /*****************************************************************************/
            // Execute a Delete using ExecuteNonQuery
            data.DeleteUSCity("Richfield", "Ohio");

            return;
        }

    }
}
