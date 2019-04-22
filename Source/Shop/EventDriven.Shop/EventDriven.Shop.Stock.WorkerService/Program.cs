using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Commander.MessageBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EventDriven.Shop.Stock.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseDefaultServiceProvider(s => s.ValidateScopes = false)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                    Assembly.Load("EventDriven.Shop.Stock.Application");
                    services
                    .AddMessageBusServiceBus(a => 
                        a.Configure(
                            new MessageBusConfiguration("Endpoint=sb://event-driven-sample.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=/evMRy4ApKPmiRRd7fxNUTGKR4qcgWU42XdIAlm/Rl0=;TransportType=Amqp")
                            )
                        )
                    .AddDatabase()
                    .AddLogging();
                });
    }
}
