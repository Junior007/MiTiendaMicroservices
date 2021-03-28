using identity.api.Data;
using identity.api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateAndSeedDatabase(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });



        private static void CreateAndSeedDatabase(IHost host)
        {

            //using (var scope = host.Services.CreateScope())
            {
                var loggerFactory = (ILoggerFactory)host.Services.GetService(typeof(ILoggerFactory));

                try
                {
                    UsersContext userContext = (UsersContext)host.Services.GetService(typeof(UsersContext));
                    IAuthService authService = (IAuthService)host.Services.GetService(typeof(IAuthService));
                    Seed.SeedUsers(userContext, authService);
                }
                catch (Exception exception)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(exception, "An error occurred seeding the DB.");
                }
            }
        }
    }
}
