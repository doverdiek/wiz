using DataModels;
using MongoDB.Driver;
using MongoDBCrudLibrary;
using System;
using System.Collections.Generic;

namespace InventoryManagementService.Repos
{
    public class InventoryRepo : MongoDBCollection<Inventory>, IInventoryRepo
    {
        public InventoryRepo(IMongoDatabase database, string collectionName) : base(database, collectionName) { }

        public void AddProductQuantity(string productId, int quantity)
        {
            var inventory = GetSpecificRecord(productId);
            if(inventory == null) 
            {
                inventory.Quantity = quantity;
            }
            UpsertRecord(inventory);
        }

    
    }
}
