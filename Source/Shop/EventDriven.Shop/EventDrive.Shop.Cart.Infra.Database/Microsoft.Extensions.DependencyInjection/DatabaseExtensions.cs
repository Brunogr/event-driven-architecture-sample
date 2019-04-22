using EventDrive.Shop.Cart.Infra.Database;
using EventDrive.Shop.Cart.Infra.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddCartDatabase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICarrinhoRepository, CarrinhoRepository>();

            return serviceCollection;
        }
    }
}
