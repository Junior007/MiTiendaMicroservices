using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.ApiCollection;
using web.ApiCollection.Interfaces;
using web.Settings;
using IdentityModel;
namespace web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiSettings>(Configuration.GetSection(nameof(ApiSettings)));
            services.AddSingleton<IApiSettings>(sp => sp.GetRequiredService<IOptions<ApiSettings>>().Value);


            // add for httpClient factory
            services.AddHttpClient();

            // add api dependecy
            services.AddTransient<ICatalogApi, CatalogApi>();
            services.AddTransient<IBasketApi, BasketApi>();
            services.AddTransient<IOrderApi, OrderApi>();

            services.AddRazorPages();
            //OpenId
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
             {
                 //options.Authority = "https://identityapi";
                 options.Authority = "http://localhost:8060";

                 options.ClientId = "storeClient1";
                 options.ClientSecret = "una palabra secreta";
                 options.ResponseType = "code id_token";

                 //options.Scope.Add("openid");
                 //options.Scope.Add("profile");
                 options.Scope.Add("address");
                 options.Scope.Add("email");
                 options.Scope.Add("roles");

                 options.ClaimActions.DeleteClaim("sid");
                 options.ClaimActions.DeleteClaim("idp");
                 options.ClaimActions.DeleteClaim("s_hash");
                 options.ClaimActions.DeleteClaim("auth_time");
                 options.ClaimActions.MapUniqueJsonKey("role", "role");
                 //TODO
                 options.Scope.Add("catalogapi");

                 options.SaveTokens = true;
                 options.GetClaimsFromUserInfoEndpoint = true;

                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     NameClaimType = JwtClaimTypes.GivenName,
                     RoleClaimType = JwtClaimTypes.Role
                 };
                 options.RequireHttpsMetadata = false;
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
