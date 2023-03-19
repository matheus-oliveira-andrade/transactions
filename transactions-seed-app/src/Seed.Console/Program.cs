using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Seed.Application;
using Seed.Infrastructure;
using Serilog;

namespace Seed.Console
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        private static IHost BuildHost(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices((ctx, services) =>
            {
                services.AddHostedService<PublishTransactionsHostedService>();
                
                services.AddApplication();
                services.AddInfrastructure(ctx.Configuration);
            })
            .UseSerilog((_, _, loggerConfiguration) => loggerConfiguration
                .Enrich.FromLogContext()
                .WriteTo.Console())
            .Build();

        public static int Main(string[] args)
        {
            BuildHost(args).Run();
            return 0;
        }
    }
}