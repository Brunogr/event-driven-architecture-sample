using Commander.MessageBus;
using Commander.MessageBus.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MessageBusExtensions
    {
        public static IServiceCollection AddMessageBusServiceBus(this IServiceCollection serviceCollection, Action<MessageBusConfigurationLambda> configuration, 
            params Assembly[] assemblies)
        {

            var configLambda = new MessageBusConfigurationLambda(serviceCollection);

            configuration.Invoke(configLambda);

            serviceCollection.AddCommander(assemblies);

            serviceCollection.AddScoped<IMessageBus, MessageBus>();

            return serviceCollection;
        }
    }
}
