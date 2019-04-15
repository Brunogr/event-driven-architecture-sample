using System;
using System.Threading;
using System.Threading.Tasks;
using Commander.MessageBus.Abstractions;
using EventDriven.Shop.Cart.Domain.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EventDriven.Shop.Cart.Application.CommandHandlers;

namespace EventDriven.Shop.Cart.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IMessageBus messageBus;

        public Worker(ILogger<Worker> logger,
            IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.messageBus = serviceProvider.GetRequiredService<IMessageBus>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation($"Worker running at: {DateTime.Now}");
            await messageBus.SubscribeAsync<AdicionarProdutoAoCarrinhoCommand>();

            Console.ReadKey();
        }
    }
}
