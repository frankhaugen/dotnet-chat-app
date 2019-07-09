using ChatApp.Entities;
using ChatApp.Repositories.Sqlite;
using LinqToDB;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public DatabaseRepository()
        {
            if (!File.Exists("Database.sqlite"))
            {
                File.Create("Database.sqlite");
            }

            CreateDatabase();
        }

        public async Task<bool> CreateDatabase()
        {
            using (var database = new Database())
            {
                var schema = database.DataProvider.GetSchemaProvider().GetSchema(database);
                var tableNames = schema.Tables.Select(tbl => tbl.TableName);
                
                try
                {
                    database.CreateTable<ChatMessage>();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
