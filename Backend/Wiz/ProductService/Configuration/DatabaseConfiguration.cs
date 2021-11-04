
using DataModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

using MongoDBCrudLibrary;


namespace ProductService.Configuration
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public DatabaseConfiguration()
        {
            ConfigureDatabase();
        }
        public void ConfigureDatabase()
        {
            BsonClassMap.RegisterClassMap<Product>(cm => {
                cm.AutoMap();
            });
            BsonClassMap.RegisterClassMap<Category>(cm => {
                cm.AutoMap();
            });
            BsonClassMap.RegisterClassMap<CategoryProperty>(cm => {
                cm.AutoMap();
            });
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
           
        }
    }
}
