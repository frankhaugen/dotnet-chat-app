using System;
using LinqToDB.Mapping;

namespace ChatApp.Entities
{
    [Table(Name = "Messages")]
    public class ChatMessage
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column] public DateTime Time { get; set; }
        [Column] public string From { get; set; }
        [Column] public string Message { get; set; }
    }
}
