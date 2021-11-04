using AbstractModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDBCrudLibrary
{


    public class MongoDBCollection<T> : IMongoDBCollection<T> where T : IDataClass
    {
        public MongoDBCollection(IMongoDatabase database, string collectionName)
        {
            Collection = database.GetCollection<T>(collectionName);
        }


        public IMongoCollection<T> Collection { get; set; }

        public IQueryable<T> QueryAble => Collection.AsQueryable();

        public virtual void DeleteRecord(T document)
        {
            DeleteRecord(document.Id);
        }

        public virtual void DeleteRecord(string documentId)
        {
            Collection.DeleteOne(Builders<T>.Filter.Eq("Id", documentId));
        }

        public virtual IEnumerable<T> GetAllDocuments(string UserId)
        {
            try { 
            var query = Collection.AsQueryable();
            var data = query.Where(a => a.CustomerId.Equals(UserId));
            return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T GetSpecificRecord(string documentId)
        {
            return Collection.Find(Builders<T>.Filter.Eq("Id", documentId)).FirstOrDefault();
        }

        public virtual T UpsertRecord(T document) 
        {
            if (document.Id == default)
            {
                Collection.InsertOne(document);
                return document;
            }
            var filter = Builders<T>.Filter.Eq(x => x.Id, document.Id);
            UpdateDefinition<T> updateDefination = null;
            foreach (var change in document.ToBsonDocument())
            {
                if (updateDefination == null)
                {
                    var builder = Builders<T>.Update;
                    updateDefination = builder.Set(change.Name, change.Value);
                }
                else
                {
                    updateDefination = updateDefination.Set(change.Name, change.Value);
                }
            }
            var update = Collection.UpdateOne(filter, updateDefination);
            return GetSpecificRecord(document.Id);
        }
    }
}
