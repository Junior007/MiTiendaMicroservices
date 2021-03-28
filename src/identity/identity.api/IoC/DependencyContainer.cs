
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using identity.api.Data;
using identity.api.Services;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace identity.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UsersContext>(c =>
                c.UseSqlServer(configuration["ConnectionStrings:IdentityConnection"]), ServiceLifetime.Singleton);//, b => b.MigrationsAssembly("identity.api"), ServiceLifetime.Singleton);
            services.AddTransient<UsersContext, UsersContext>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IAuthService, AuthService>();
            //AutoMapper
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(ass => ass.FullName.Contains("identity.")).ToArray();

            services.AddAutoMapper(assemblies);

        }
    }
}
