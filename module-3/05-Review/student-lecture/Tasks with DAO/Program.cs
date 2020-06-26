using CLI;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.DAL;
using Tasks.Models;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Task List!\r\n");
            System.Threading.Thread.Sleep(500);

            ITaskDAO taskDAO = null;
            # region Read the config file to determine data source
            Config config = new Config("appsettings.json");

            switch (config.DataSource)
            {
                case DataSourceType.Database:
                    taskDAO = new TaskSqlDAO(config.ConnectionString);
                    break;
                case DataSourceType.File:
                    taskDAO = new TaskFileDAO(config.ConnectionString);
                    break;
            }
            #endregion

            MainMenu menu = new MainMenu(taskDAO);
            menu.Run();
        }
    }
}
