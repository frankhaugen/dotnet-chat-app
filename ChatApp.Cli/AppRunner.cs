using ChatApp.Entities;
using ChatApp.Repositories;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConsoleTableExt;
using LinqToDB.Common;

namespace ChatApp.Cli
{
    public class AppRunner : BackgroundService
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IDatabaseRepository _databaseRepository;

        public AppRunner(IChatMessageRepository chatMessageRepository, IDatabaseRepository databaseRepository)
        {
            _chatMessageRepository = chatMessageRepository;
            _databaseRepository = databaseRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();

            var messages = await _chatMessageRepository.GetAllMessages();
            ConsoleTableBuilder.From(messages).WithFormat(ConsoleTableBuilderFormat.Minimal).ExportAndWriteLine();

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Write your message:");
                var newMessage = Console.ReadLine();

                if (!newMessage.IsNullOrEmpty())
                {
                    await _chatMessageRepository.AddNewMessage(new ChatMessage()
                    {
                        From = name,
                        Message = newMessage,
                        Time = DateTime.UtcNow
                    });
                }

                var newMessages = await _chatMessageRepository.GetAllMessagesSince(messages.OrderBy(msg => msg.Time).LastOrDefault().Time);
                messages.AddRange(newMessages);

                Console.Clear();
                ConsoleTableBuilder.From(messages).WithFormat(ConsoleTableBuilderFormat.Minimal).ExportAndWriteLine();
            }

            Console.WriteLine(messages.Count);
        }
    }
}
