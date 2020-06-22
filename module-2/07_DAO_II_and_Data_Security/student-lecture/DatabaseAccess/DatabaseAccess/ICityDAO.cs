using DatabaseAccess.Models;
using System.Collections.Generic;

namespace DatabaseAccess
{
    public interface ICityDAO
    {
        int AddCity(City city);
        void DeleteUSCity(string cityName, string stateName);
        IList<City> GetAllCities();
        IList<City> GetAllCitiesInState(string state);
        void UpdatePopulation(string cityName, int population);
    }
}