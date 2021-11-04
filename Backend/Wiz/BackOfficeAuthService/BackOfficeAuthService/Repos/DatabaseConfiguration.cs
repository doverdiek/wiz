
using AbstractModels;
using DataModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDBCrudLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeAuthService.Repos
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public DatabaseConfiguration()
        {
            ConfigureDatabase();
        }
        public void ConfigureDatabase()
        {
            BsonClassMap.RegisterClassMap<User>(t =>
            {
                t.AutoMap();
            });
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
        }
    }
}
