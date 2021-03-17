using catalog.application.interfaces;
using catalog.application.services;
using catalog.data.repository;
using catalog.domain.interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;
using catalog.data.interfaces;
using Microsoft.Extensions.Options;
using catalog.data.context;
using catalog.data.models;

namespace catalog.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {

            //TODO
            //Para inyectar las propiedades de la conexión en el contexto
            /*services.Configure<CatalogDatabaseSettings>(configuration.GetSection(nameof(CatalogDatabaseSettings)));
            services.AddSingleton<ICatalogDatabaseSettings>(
                sp => sp.GetRequiredService<IOptions<CatalogDatabaseSettings>>().Value);
            services.AddTransient<ICatalogContext, CatalogContext>();*/

            //
            services.AddTransient<ICatalogContext, CatalogContext>();
            //
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IProductsService, ProductsService>();
            //AutoMapper
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(ass => ass.FullName.Contains("catalog.")).ToArray();

            services.AddAutoMapper(assemblies);

        }
    }
}
