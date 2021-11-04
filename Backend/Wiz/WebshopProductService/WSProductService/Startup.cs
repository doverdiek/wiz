using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractModels;
using DataModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDBCrudLibrary;
using WSInformationService.Configuration;
using WSInformationService.Repos;
using WSInformationService.Services;

namespace WSProductService
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
            services.AddScoped<IMongoDBCollection<Category>, MongoDBCollection<Category>>(t =>
            {
                var dbservice = t.GetRequiredService<IDBService>();
                return new MongoDBCollection<Category>(dbservice.Database, "ProductCategory");
            });
            services.AddScoped<IMongoDBCollection<Product>, MongoDBCollection<Product>>(t =>
            {
                var dbservice = t.GetRequiredService<IDBService>();
                return new MongoDBCollection<Product>(dbservice.Database, "Product");
            });
            services.AddScoped<IMongoDBCollection<User>, MongoDBCollection<User>>(t =>
            {
                var dbservice = t.GetRequiredService<IDBService>();
                return new MongoDBCollection<User>(dbservice.Database, "Auth");
            });
            services.AddTransient<IMongoClient, MongoClient>((t) =>
            {
                return new MongoClient(Configuration.GetValue<string>("MongoDB"));
            });
            services.AddTransient<IWebshopRepo, WebshopRepo>();
            services.AddTransient<IWebshopService, WebshopService>();
            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            services.AddScoped<IDBService, DBService>(t =>
            {
                var configuration = t.GetRequiredService<IDatabaseConfiguration>();
                var dbservice = new DBService(t.GetRequiredService<IMongoClient>(), "Wiz", configuration);
                return dbservice;
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
            }
            else
            {
                app.UsePathBase("/wsinformationservice");
            }
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
