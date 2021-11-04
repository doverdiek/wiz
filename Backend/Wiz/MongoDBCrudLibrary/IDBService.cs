using MongoDB.Driver;

namespace MongoDBCrudLibrary
{
    public interface IDBService
    {
        IMongoClient DBClient { get; }
        IMongoDatabase Database { get;  }
    }
}