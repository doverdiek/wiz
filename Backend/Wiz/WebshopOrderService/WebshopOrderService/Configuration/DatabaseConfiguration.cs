using DataModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDBCrudLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopOrderService.Configuration
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public DatabaseConfiguration()
        {
            ConfigureDatabase();
        }
        public void ConfigureDatabase()
        {
            BsonClassMap.RegisterClassMap<Product>(t =>
            {
                t.AutoMap();
            });
            BsonClassMap.RegisterClassMap<Category>(t =>
            {
                t.AutoMap();
            });
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        }
    }
}
