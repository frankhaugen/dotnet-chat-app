using ChatApp.Entities;
using ChatApp.Repositories;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private List<ChatMessage> messages = new List<ChatMessage>();
        
        public AppRunner(IChatMessageRepository chatMessageRepository, IDatabaseRepository databaseRepository)
        {
            _chatMessageRepository = chatMessageRepository;
            _databaseRepository = databaseRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var name = GetInput("What is your name?");

            messages.AddRange(await _chatMessageRepository.GetAllMessages());

            PrintTable();

            while (!stoppingToken.IsCancellationRequested)
            {
                var newMessage = GetInput("Write your message:");

                if (!newMessage.IsNullOrEmpty())
                {
                    await _chatMessageRepository.AddNewMessage(new ChatMessage()
                    {
                        From = name,
                        Message = newMessage,
                        Time = DateTime.UtcNow
                    });
                }

                if (messages.IsNullOrEmpty())
                {
                    messages.AddRange(await _chatMessageRepository.GetAllMessages());
                }
                else
                {
                    messages.AddRange(await _chatMessageRepository.GetAllMessagesSince(messages.LastOrDefault().Time));
                }

                PrintTable();
            }
        }

        private string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private void PrintTable()
        {
            Console.Clear();

            try
            {
                ConsoleTableBuilder.From(messages).WithFormat(ConsoleTableBuilderFormat.Minimal).ExportAndWriteLine();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }
    }
}
