using EventDriven.Shop.Stock.Infra.Data.Seeds;
using EventDriven.Shop.Stock.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StockContext>(options =>
                options.UseSqlServer(connectionString));

            //using (var scope = services.BuildServiceProvider().CreateScope())
            //{
            //    var serv = scope.ServiceProvider;
            //    try
            //    {
            //        var context = serv.GetRequiredService<StockContext>();
            //        DataSeed.Initialize(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        //var logger = serv.GetRequiredService<ILogger<DataExtensions>>();
            //        //logger.LogError(ex, "An error occurred while seeding the database.");
            //        Console.WriteLine("Erro " + ex);
            //    }
            //}


            return services;
        }
    }
}
