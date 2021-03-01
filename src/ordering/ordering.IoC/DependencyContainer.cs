﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ordering.application.services;
using ordering.application.interfaces;  
using ordering.data.repositories;
using ordering.domain.interfaces;
using System;
using System.Linq;
using System.Reflection;
using ordering.data.context;
using Microsoft.EntityFrameworkCore;
using infra.eventbus.interfaces;
using RabbitMQ.Client;
using infra.eventbus.bus;

namespace ordering.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //OrderContext (data base)
            services.AddDbContext<OrderContext>(c =>
                c.UseSqlServer(configuration["ConnectionStrings:OrderConnection"]), ServiceLifetime.Singleton);
            //
            //MicrorabitMQ
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBus:HostName"]
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
            services.AddTransient<IEventBus, RabbitMQBus>();


            services.AddTransient<OrderContext, OrderContext>();
            //
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrdersService, OrdersService>();
            //AutoMapper
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(ass => ass.FullName.Contains("ordering.")).ToArray();

            services.AddAutoMapper(assemblies);

        }
    }
}