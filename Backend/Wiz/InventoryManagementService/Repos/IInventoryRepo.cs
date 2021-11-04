using MongoDBCrudLibrary;
using DataModels;

namespace InventoryManagementService.Repos
{
    public interface IInventoryRepo : IMongoDBCollection<Inventory>
    {
        void AddProductQuantity(string productId, int quantity);

    }
}