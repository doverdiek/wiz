using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BackOfficeAuthService.Services;
using BackOfficeAuthService.Repos;
using MongoDB.Driver;
using MongoDBCrudLibrary;
using AutoMapper;
using BackOfficeAuth;

namespace BackOfficeAuthService
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
            services.AddAutoMapper(typeof(Startup));
            services.SetupBackOfficeAuthentication();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            services.AddScoped<IAuthRepo, AuthRepo>(t =>
            {
                var dbservice = t.GetRequiredService<IDBService>();
                var mapper = t.GetRequiredService<IMapper>();
                return new AuthRepo(dbservice.Database, "Auth", mapper);
            });
            services.AddScoped<IDBService, DBService>(t =>
            {
                var configuration = t.GetRequiredService<IDatabaseConfiguration>();
                var dbservice = new DBService(t.GetRequiredService<IMongoClient>(), "Wiz", configuration);
                return dbservice;
            });
            services.AddTransient<IMongoClient, MongoClient>((t) =>
            {
                return new MongoClient(Configuration.GetValue<string>("MongoDB"));
            });

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
                app.UsePathBase("/backofficeauthservice");
            }
            app.UseDeveloperExceptionPage();
            app.UseCors();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
