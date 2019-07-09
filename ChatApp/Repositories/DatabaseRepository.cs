using ChatApp.Entities;
using ChatApp.Repositories.Sqlite;
using LinqToDB;
using System;
using System.Diagnostics;
using System.IO;

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

        public void CreateDatabase()
        {
            using (var database = new Database())
            {
                try
                {
                    database.CreateTable<ChatMessage>();
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e);
                }
            }
        }
    }
}
