using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;
using WorldDB.DAL;
using WorldDB.Models;

namespace WorldDB.IntegrationTests
{
    [TestClass]
    public class CityDAOTests
    {
        private string connectionString = @"Server=.\sqlexpress;database=world; trusted_connection=true;";
        private TransactionScope transaction;

        // A place to hold the id's that were added to the database
        private int candylandId;
        private int utopiaId;

        [TestInitialize]
        public void SetupDB()
        {
            // This is "Begin Tran"
            transaction = new TransactionScope();

            string sqlScript = File.ReadAllText("Setup.sql");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlScript, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    candylandId = Convert.ToInt32(rdr["CandyLandId"]);
                    utopiaId = Convert.ToInt32(rdr["UtopiaId"]);
                }
            }
        }

        [TestCleanup]
        public void CleanupDB()
        {
            // Roll back the transaction
            transaction.Dispose();
        }

        [TestMethod]
        public void GetCitiesByCountryCodeTest()
        {
            // Arrange

            // Setup the fake data in a new transaction
            //SetupDB();

            // Create a city sql dao
            CitySqlDAO dao = new CitySqlDAO(connectionString);

            // Act - call the method under test
            IList<City> list = dao.GetCitiesByCountryCode("USA");


            // Assert
            Assert.AreEqual(2, list.Count);


            // Cleanup the transaction by rolling back
            //CleanupDB();

        }

        [TestMethod]
        public void GetCityByIdTest()
        {
            // Arrange - create the city dao
            CitySqlDAO dao = new CitySqlDAO(connectionString);

            // Act - call the method under test
            City city = dao.GetCityById(this.candylandId);

            // Assert
            Assert.IsNotNull(city);
            Assert.AreEqual("Candyland", city.Name);

        }
    }
}
