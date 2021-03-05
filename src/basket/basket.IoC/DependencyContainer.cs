using basket.application.interfaces;
using basket.application.services;
using basket.data.context;
using basket.data.interfaces;
using basket.data.repositories;
using basket.domain.interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;
using RabbitMQ.Client;
using StackExchange.Redis;
using infra.eventbus.bus;
using infra.eventbus.interfaces;


namespace basket.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {

            //REDIS
            services.AddSingleton<ConnectionMultiplexer>(
                sp => {
                    var redisConfiguration = ConfigurationOptions.Parse(configuration["ConnectionStrings:Redis"], true);
                    return ConnectionMultiplexer.Connect(redisConfiguration);

                });
            //MicrorabitMQ
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBus:HostName"],
                    DispatchConsumersAsync = true

                };

                if (!string.IsNullOrEmpty(configuration["EventBus:UserName"]))
                {
                    factory.UserName = configuration["EventBus:UserName"];
                }

                if (!string.IsNullOrEmpty(configuration["EventBus:Password"]))
                {
                    factory.Password = configuration["EventBus:Password"];
                }

                return new RabbitMQConnection(factory);
            });
            services.AddSingleton<IEventBus, RabbitMQBus>();


            services.AddTransient<IBasketContext, BasketContext>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IBasketService, BasketService>();
            //AutoMapper
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(ass => ass.FullName.Contains("basket.")).ToArray();

            services.AddAutoMapper(assemblies);

        }
    }
}
