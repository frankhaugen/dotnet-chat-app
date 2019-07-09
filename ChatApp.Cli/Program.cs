using ChatApp.Repositories;
using ChatApp.Repositories.Sqlite;
using LinqToDB.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChatApp.Cli
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                    {
                        DataConnection.DefaultSettings = new DatabaseSettings();

                        services.AddTransient<IChatMessageRepository, ChatMessageRepository>();
                        services.AddTransient<IDatabaseRepository, DatabaseRepository>();

                        services.AddHostedService<AppRunner>();
                    });
    }
}
