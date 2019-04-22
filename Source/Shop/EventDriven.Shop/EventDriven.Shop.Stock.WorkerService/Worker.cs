using System;
using System.Threading;
using System.Threading.Tasks;
using Commander.MessageBus.Abstractions;
using EventDriven.Shop.Shared.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EventDriven.Shop.Stock.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IMessageBus messageBus;

        public Worker(ILogger<Worker> logger, IMessageBus messageBus)
        {
            this.logger = logger;
            this.messageBus = messageBus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation($"Worker running at: {DateTime.Now}");
            await messageBus.SubscribeAsync<AtualizarEstoqueEvent>();

        }
    }
}
