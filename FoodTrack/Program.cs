using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FoodTrack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            //seed database (also auto-update pending migrations if there is any)
            //SeedAppDb(host);

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseWebRoot("Content")
                .UseStartup<Startup>();

        private static void SeedAppDb(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var foodTrackDbContext = services.GetRequiredService<FoodTrackDbContext>();
                FoodTrackDbSeeder.Seed(foodTrackDbContext).Wait();
            }
        }
    }
}
