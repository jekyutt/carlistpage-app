using Loppprojekt.Infra.Cars.CarsDb;
using Loppprojekt.Infra.Motorbikes.BikeDb;
using Loppprojekt.Infra.Sales.StatementsDb;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Loppprojekt.Soft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbCars = services.GetRequiredService<CarsDbContext>();
                CarsDbInitializer.Initialize(dbCars);
                var dbBikes = services.GetRequiredService<BikeDbContext>();
                BikeDbInitializer.Initialize(dbBikes);
                var dbStatements = services.GetRequiredService<StatementsDbContext>();
                StatementsDbInitializer.Initialize(dbStatements);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
