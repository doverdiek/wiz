using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using ProductService.Configuration;
using ProductService.Repos;
using ProductService.Services;
using Newtonsoft.Json;
using BackOfficeAuth;
using MongoDBCrudLibrary;
using Microsoft.Extensions.FileProviders;
using System.IO;
using SqlDBCrudLibrary;
using AutoMapper;

namespace ProductService
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
            services.SetupBackOfficeAuthentication();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
           
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService.Services.ProductService>();

            var mongo = true;
            //Mongo
            if (mongo) {
                services.AddScoped<IDBService, DBService>(t =>
            {
                var configuration = t.GetRequiredService<IDatabaseConfiguration>();
                var dbservice = new DBService(t.GetRequiredService<IMongoClient>(), "Wiz", configuration);
                return dbservice;
            });

            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            services.AddScoped<IProductRepo, MongoProductRepo>(t =>
            {
                var dbservice = t.GetRequiredService<IDBService>();
                return new MongoProductRepo(dbservice.Database, "Product");
            });
            services.AddScoped<ICategoryRepo, MongoCategoryRepo>(t =>
            {
                var dbservice = t.GetRequiredService<IDBService>();
                return new MongoCategoryRepo(dbservice.Database, "ProductCategory");
            });
            services.AddTransient<IMongoClient, MongoClient>((t) =>
            {
                return new MongoClient(Configuration.GetValue<string>("MongoDB"));
            });
            }
            else
            {
                services.AddDbContext<WizDBContext>();
                services.AddScoped<IProductRepo, SqlProductRepo>(t =>
                {
                    var dbservice = t.GetRequiredService<WizDBContext>();
                    return new SqlProductRepo(dbservice);
                });
                services.AddScoped<ICategoryRepo, SqlCategoryRepo>(t =>
                {
                    var dbservice = t.GetRequiredService<WizDBContext>();
                    return new SqlCategoryRepo(dbservice);
                });
            }
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
               
            }
            else
            {
                app.UsePathBase("/backofficeproductservice");
            }
         
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
