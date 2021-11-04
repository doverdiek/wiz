using AbstractModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModels
{
    [BsonIgnoreExtraElements]
    public class Product :  DataClass
    {
        [BsonIgnoreIfDefault]
        public int Sku { get; set; }
        [BsonIgnoreIfDefault]
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public decimal Price { get; set; }
        [BsonIgnoreIfDefault]
        public decimal DiscountPrice { get; set; }
        [BsonIgnoreIfDefault]
        public decimal WholeSalePrice { get; set; }
        [BsonIgnoreIfDefault]
        public string[] Images { get; set; }
        [BsonIgnoreIfDefault]
        public string Description { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Category { get; set; }
        [BsonIgnoreIfDefault]
        public int Quantity { get; set; }
        [BsonIgnoreIfDefault]
        public int CartQuantity { get; set; }
        public List<CategoryProperty> Properties { get; set; }
    }
}
