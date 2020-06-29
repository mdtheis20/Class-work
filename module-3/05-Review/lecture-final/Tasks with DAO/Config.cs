using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Tasks
{
    public enum DataSourceType : int
    {
        File,
        Database,
        InMemory
    }

    public class Config
    {
        public DataSourceType DataSource { get; set; }
        public string ConnectionString { get; set; }
        public Config(string configFile)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configFile, optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            // Find the data source 
            string ds = configuration.GetSection("DataSource").Value;

            switch (ds.ToLower())
            {
                case "file":
                    DataSource = DataSourceType.File;
                    ConnectionString = configuration.GetSection("File")["Tasks"];
                    break;
                case "database":
                    DataSource = DataSourceType.Database;
                    ConnectionString = configuration.GetConnectionString("Tasks");
                    break;
            }
        }
    }
}
