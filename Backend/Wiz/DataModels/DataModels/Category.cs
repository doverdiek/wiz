using AbstractModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;

namespace DataModels
{
    [BsonIgnoreExtraElements]
    public class Category : DataClass
    {
        [BsonIgnoreIfDefault]
        public string CategoryName { get; set; }
        [BsonIgnoreIfDefault]
        public string CategoryDescription { get; set; }
        [BsonIgnoreIfDefault]
        public List<string> ProductIds { get; set; }
        [BsonIgnoreIfDefault]
        public List<Product> Products { get; set; }
        [BsonIgnoreIfDefault]
        public List<string> SubCategoriesIds { get; set; }
        [BsonIgnoreIfDefault]
        public List<Category> SubCategories { get; set; }
        [BsonIgnoreIfDefault]
        public List<CategoryProperty> Properties { get; set; }
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ParentCategoryId { get; set; }

        public bool MainCategory { get; set; } = false;

    }
}