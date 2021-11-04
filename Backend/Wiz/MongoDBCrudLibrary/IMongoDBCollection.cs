using AbstractDataModels.Repo;
using AbstractModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDBCrudLibrary
{
    public interface IMongoDBCollection<T> : ICrudRepo<T> where T : IDataClass
    {
        public IMongoCollection<T> Collection { get; set; }

    }
}
