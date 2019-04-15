using Commander.Abstractions;
using Commander.MessageBus.Abstractions;
using Microsoft.Azure;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Management;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commander.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IMessageBusConfiguration configuration;
        private readonly QueueClient client;
        private readonly IHandler handler;

        public MessageBus(IHandler handler, IMessageBusConfiguration configuration)
        {
            this.configuration = configuration;
            this.handler = handler;
        }

        private Task<QueueClient> GetQueueAsync<TMessage>(TMessage @event) where TMessage : IMessage
        {
            return Task.FromResult(new QueueClient(configuration.ConnectionString, @event.MessageType));
        }

        public async Task PublishAsync<TMessage>(TMessage message) where TMessage : Commander.Abstractions.IMessage
        {
            var queue = await GetQueueAsync(message);

            var body = JsonConvert.SerializeObject(message);

            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(body));

            await queue.SendAsync(serviceBusMessage);
        }

        public Task<TMessage> ReceiveAsync<TMessage>(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SubscribeAsync<TMessage>() where TMessage : Commander.Abstractions.IMessage
        {
            return Task.Factory.StartNew(async () =>
            {
                var @event = Activator.CreateInstance(typeof(TMessage), true);
                var queue = await GetQueueAsync((IMessage)@event);

                var options = new MessageHandlerOptions(ExceptionHandler) { AutoComplete = false, MaxConcurrentCalls = 5, MaxAutoRenewDuration = new TimeSpan(0, 0, 1) };

                //Registra o subscribe na mensagem baseado no nome
                queue.RegisterMessageHandler(
                    async (Message message, CancellationToken cancellationToken) =>
                    {
                        try
                        {
                            var body = JsonConvert.DeserializeObject<TMessage>(Encoding.UTF8.GetString(message.Body));
                            
                            bool isEvent = (body is IEvent);
                            if (isEvent)
                            {
                                IEvent currentEvent = ((IEvent)body);

                                await handler.RaiseEvent(currentEvent);
                            }
                            else
                                await handler.Send((ICommand<CommandResult>)body);

                            await queue.CompleteAsync(message.SystemProperties.LockToken);
                            
                        }
                        catch (ServiceBusTimeoutException)
                        {
                            Console.WriteLine("Timeout na execução da mensagem.");
                            throw;
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex);
                            await queue.DeadLetterAsync(message.SystemProperties.LockToken);
                            throw;
                        }
                    }, options);
            });
        }

        private async Task ExceptionHandler(ExceptionReceivedEventArgs ex)
        {
            await Task.Delay(0);
            Console.WriteLine("Error on message bus.");
            Console.WriteLine(ex.Exception.Message);
        }        
    }
}
