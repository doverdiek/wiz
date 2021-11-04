using DataModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDBCrudLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementService.Configuration
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public DatabaseConfiguration()
        {
            ConfigureDatabase();
        }
        public void ConfigureDatabase()
        {
            BsonClassMap.RegisterClassMap<Inventory>(t =>
            {
                t.AutoMap();
            });
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        }
    }
}
