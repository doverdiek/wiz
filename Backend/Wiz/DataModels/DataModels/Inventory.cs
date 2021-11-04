using DataModels;
using MongoDB.Bson.Serialization.Attributes;
namespace DataModels
{
    [BsonIgnoreExtraElements]
    public class Inventory: DataClass
    {
        [BsonIgnoreIfDefault]
        public string ProductId { get; set; }
        [BsonIgnoreIfDefault]
        public int Quantity { get; set; }
        [BsonIgnoreIfDefault]
        public string Description { get; set; }
        [BsonIgnoreIfDefault]
        public string Type { get; set; }
        [BsonIgnoreIfDefault]
        public string CustomerEmail { get; set; }
        [BsonIgnoreIfDefault]
        public string ReturnDate { get; set; }

    }
}

