using basket.application.interfaces;
using basket.application.services;
using basket.data.repositories;
using basket.domain.interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace basket.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
  

            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IBasketsService, BasketsService>();
            //AutoMapper
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(ass => ass.FullName.Contains("basket.")).ToArray();

            services.AddAutoMapper(assemblies);

        }
    }
}
