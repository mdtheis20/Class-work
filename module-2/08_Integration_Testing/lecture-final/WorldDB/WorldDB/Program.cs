using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using WorldDB.DAL;
using WorldDB.Views;

namespace WorldDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // The following code sets up appsettings.json as the configuration file for this program.
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        IConfigurationRoot configuration = builder.Build();

            // Now read the connection string from the configuration
            string connectionString = configuration.GetConnectionString("World");

            // Our CLI will need to use (have a dependency on) the DAO's.  So create some 
            ICityDAO cityDAO = new CitySqlDAO(connectionString);
            ICountryDAO countryDAO = new CountrySqlDAO(connectionString);
            ILanguageDAO languageDAO = new LanguageSqlDAO(connectionString);

            // "Inject" these DAO dependencies into the constructor of the main menu
            WorldDBMenu menu = new WorldDBMenu(cityDAO, countryDAO, languageDAO);
            menu.Run();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Goodbye...");
            Thread.Sleep(1500);
        }
    }
}
