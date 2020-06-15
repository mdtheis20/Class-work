using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class LanguageSqlDAO : ILanguageDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a sql based language dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public LanguageSqlDAO(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public IList<Language> GetLanguages(string countryCode)
        {
            throw new NotImplementedException();
        }

        public bool AddNewLanguage(Language newLanguage)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLanguage(Language deadLanguage)
        {
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("Delete From countrylanguage where countryCode = @countryCode And language = @language", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@countryCode", deadLanguage.CountryCode);
                    sqlCommand.Parameters.AddWithValue("@language", deadLanguage.Name);

                    sqlCommand.ExecuteNonQuery();

                }

            }
            catch(SqlException ex)
            {
                Console.WriteLine("An error occured whole removing a language.");
                Console.WriteLine(ex.Message);
                throw;
            }
            return true;
        }
    }
}
