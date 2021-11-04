using AbstractModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class DataClass : IDataClass
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
            if (obj is DataClass)
            {
                var that = obj as DataClass;
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
