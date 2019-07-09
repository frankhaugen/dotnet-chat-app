using LinqToDB.Configuration;

namespace ChatApp.Repositories.Sqlite
{
    class DatabaseConnectionString : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }
}
