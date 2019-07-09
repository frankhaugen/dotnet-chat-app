using System;
using ChatApp.Repositories.Tsv;
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
                        services.AddTransient<ITsvRepository, TsvRepository>();
                        services.AddTransient<ITsvStringGenerator, TsvStringGenerator>();
                    });
    }
}
