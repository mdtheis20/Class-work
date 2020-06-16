using DatabaseAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess
{
    /// <summary>
    /// This class is responsible for access the SQL Server database, and converting row data to objects and vice-versa
    /// </summary>
    public class DataAccess
    {
        public IList<City> GetAllCities()
        {
            List<City> cities = new List<City>();

            // TODO 02: Add code to list all cities

            return cities;
        }

        public IList<City> GetAllCitiesInState(string state)
        {
            List<City> cities = new List<City>();

            // TODO03: Add code to list all cities in the given district of the USA

            return cities;
        }

        public void UpdateUSPresident(string president)
        {
            // TODO 04: Add code to update the US President to what was passed into this method
            return;
        }

        public int AddCity(City city)
        {
            // TODO 05: Add code to add a new city
            return 0;
        }

        public void DeleteUSCity(string cityName, string stateName)
        {
            // TODO 08: Add code to Delete a US city based on parameters passed in
            return;
        }

    }
}
