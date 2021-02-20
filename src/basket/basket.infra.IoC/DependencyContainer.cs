/*using basket.application.interfaces;
using basket.application.models;
using basket.application.services;
using basket.data.interfaces;
using basket.data.repository;*/
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace basket.infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
  

            //services.AddTransient<IBasketsRepository, BasketsRepository>();
            //services.AddTransient<IBasketsService, BasketsService>();
            //AutoMapper
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(ass => ass.FullName.Contains("basket.")).ToArray();

            services.AddAutoMapper(assemblies);

        }
    }
}
