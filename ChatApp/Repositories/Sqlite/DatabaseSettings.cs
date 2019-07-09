using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToDB.Configuration;

namespace ChatApp.Repositories.Sqlite
{
    public class DatabaseSettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "Database";
        public string DefaultDataProvider => "SQLite";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new DatabaseConnectionString()
                    {
                        Name = "Database",
                        ProviderName = "SQLite",
                        ConnectionString = @"Data Source=Database.sqlite"
                    };
            }
        }
    }
}
