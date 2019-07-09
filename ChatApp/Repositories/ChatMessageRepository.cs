using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Entities;
using ChatApp.Repositories.Sqlite;
using LinqToDB;

namespace ChatApp.Repositories
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        public async Task<List<ChatMessage>> GetAllMessages()
        {
            using (var database = new Database())
            {
                return await database.GetTable<ChatMessage>().ToListAsync();
            }
        }
        public async Task<List<ChatMessage>> GetAllMessagesSince(DateTime dateTime)
        {
            using (var database = new Database())
            {
                return await database.Messages.Where(msg => msg.Time > dateTime).ToListAsync();
            }
        }
        public async Task<int> AddNewMessage(ChatMessage message)
        {
            using (var database = new Database())
            {
                return await database.InsertAsync(message);
            }
        }
    }
}
