namespace InventoryManagementService
{
    using InventoryManagementService.Configuration;
    using InventoryManagementService.Repos;
    using InventoryManagementService.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MongoDB.Driver;
    using BackOfficeAuth;
    using MongoDBCrudLibrary;

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

            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();

            services.AddTransient<IInventoryService, InventoryService>();
            
            services.AddScoped<IDBService, DBService>(t =>
            {
                var configuration = t.GetRequiredService<IDatabaseConfiguration>();

                var dbservice = new DBService(t.GetRequiredService<IMongoClient>(), "Wiz", configuration);

                return dbservice;
            });

            services.AddScoped<IInventoryRepo, InventoryRepo>(t =>
            {
                var dbservice = t.GetRequiredService<IDBService>();
                return new InventoryRepo(dbservice.Database, "Inventory");
            });
           
            services.AddTransient<IMongoClient, MongoClient>((t) =>
            {
                return new MongoClient(Configuration.GetValue<string>("MongoDB"));
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
                app.UsePathBase("/inventorymanagementservice");
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
