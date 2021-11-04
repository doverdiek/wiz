
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDBCrudLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBCrudLibrary
{
    public class DBService : IDBService
    {
        public DBService(IMongoClient client, string DBName, IDatabaseConfiguration configuration)
        {
            Database = client.GetDatabase(DBName);
        }

        public IMongoClient DBClient { get; }
        public IMongoDatabase Database { get;  }
    }
}
