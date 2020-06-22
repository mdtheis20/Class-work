using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;
using WorldDB.Models;

namespace WorldDB_itegration_test
{
    [TestClass]
    public class CityDAOTests
    {

        private string connectionString = @"Server = .\sqlexpress;database=world;trusted_connection=true;";
        private TransactionScope transaction;
        private void SetupDB()
        {
            // This is "Begin Tran"
             transaction = new TransactionScope();
            string sqlScript = File.ReadAllText("Setup.sql");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlScript, conn);

                cmd.ExecuteNonQuery();
            }
        }


        private void CleanupDB()
        {
            // Rollback transaction
            transaction.Dispose();
        }



        [TestMethod]
        public void GetCitiesByCountryCodeTest()
        {

            //Arrange
            //Setup fake data in a new transaction
            SetupDB();

            //Create a city sql DAO
            CitySqlDAO dao = new CitySqlDAO(connectionString);


            //Act - call the method under test
            IList<City> list = dao.GetCitiesByCountryCode("USA");

            //Assert
            Assert.AreEqual(2, list.Count);

            //Cleanup the transaction by rolling back
            CleanupDB();
        }
    }
}
