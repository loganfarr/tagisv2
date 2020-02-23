using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using tagisApi.Authentication;
using tagisApi.Authentication.Interfaces;
using tagisApi.Controllers;
using tagisApi.Controllers.Interfaces;
using tagisApi.Models;

namespace tagisApi
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
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                    options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                })
                .AddApiKeySupport(options => { });

            services.Configure<TokenManager>(Configuration.GetSection("Authorization:Tokens"));
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IProductsControllerInterface, ProductsController>();
            services.AddScoped<IOrdersControllerInterface, OrdersController>();
            services.AddScoped<IStoreControllerInterface, StoreController>();
            services.AddScoped<IUserControllerInterface, UserController>();
            services.AddScoped<IUserRolesController, UserRolesController>();

            services.AddSingleton<IGetAllApiKeysQuery, InMemoryGetAllApiKeysQuery>();

            services.AddDbContext<TagisDbContext>(options => options.UseMySQL(Configuration["ConnectionStrings:Local"]));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader());
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}