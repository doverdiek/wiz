using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using WebshopOrderService.Configuration;

namespace WebshopOrderService
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
            services.AddScoped<IMongoDBCollection<Product>, MongoDBCollection<Product>>(t =>
            {
                var dbservice = t.GetRequiredService<IDBService>();
                return new MongoDBCollection<Product>(dbservice.Database, "Product");
            });
            services.AddTransient<IMongoClient, MongoClient>((t) =>
            {
                return new MongoClient(Configuration.GetValue<string>("MongoDB"));
            });
            services.AddScoped<IMongoDBCollection<Inventory>, MongoDBCollection<Inventory>>(t =>
            {
                var dbservice = t.GetRequiredService<IDBService>();
                return new MongoDBCollection<Inventory>(dbservice.Database, "Inventory");
            });
            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            services.AddScoped<IDBService, DBService>(t =>
            {
                var configuration = t.GetRequiredService<IDatabaseConfiguration>();
                var dbservice = new DBService(t.GetRequiredService<IMongoClient>(), "Wiz", configuration);
                return dbservice;
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
