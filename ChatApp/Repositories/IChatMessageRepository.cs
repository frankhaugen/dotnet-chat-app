using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApp.Entities;

namespace ChatApp.Repositories
{
    public interface IChatMessageRepository
    {
        Task<List<ChatMessage>> GetAllMessages();
        Task<List<ChatMessage>> GetAllMessagesSince(DateTime dateTime);
        Task<int> AddNewMessage(ChatMessage message);
    }
}