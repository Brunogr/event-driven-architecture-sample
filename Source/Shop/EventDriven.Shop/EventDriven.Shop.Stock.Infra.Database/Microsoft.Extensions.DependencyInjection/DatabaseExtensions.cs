using EventDriven.Shop.Stock.Infra.Database;
using EventDriven.Shop.Stock.Infra.Database.Interfaces;
using EventDriven.Shop.Stock.Infra.Database.Seed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEstoqueRepository, EstoqueRepository>();
            serviceCollection.AddScoped<IProdutoRepository, ProdutoRepository>();

            return serviceCollection;
        }

        public static IServiceCollection SeedDatabase(this IServiceCollection serviceCollection)
        {
            SeedData.Seed(serviceCollection.BuildServiceProvider()).GetAwaiter().GetResult();
            return serviceCollection;
        }
    }
}
