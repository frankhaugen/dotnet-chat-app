using ChatApp.Entities;
using LinqToDB;
using LinqToDB.Data;

namespace ChatApp.Repositories.Sqlite
{
    public class Database : DataConnection
    {
        public Database() : base("Database") { }

        public ITable<ChatMessage> Messages => GetTable<ChatMessage>();
    }
}
