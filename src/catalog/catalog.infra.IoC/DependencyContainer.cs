using catalog.application.interfaces;
using catalog.application.models;
using catalog.application.services;
using catalog.data.interfaces;
using catalog.data.repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace catalog.infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
  

            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IProductsService, ProductsService>();
            //AutoMapper
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(ass => ass.FullName.Contains("catalog.")).ToArray();

            services.AddAutoMapper(assemblies);

        }
    }
}
