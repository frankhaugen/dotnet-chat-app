using System;

namespace ChatApp.Entities
{
    public class ChatMessage
    {
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
    }
}
