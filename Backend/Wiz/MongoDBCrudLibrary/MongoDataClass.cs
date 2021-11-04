using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBCrudLibrary
{
    public class MongoDataClass : IMongoDataClass
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is MongoDataClass)
            {
                var that = obj as MongoDataClass;
                return this.Id == that.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CustomerId);
        }
    }
}
