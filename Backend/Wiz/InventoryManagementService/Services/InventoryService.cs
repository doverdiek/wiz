using DataModels;
using InventoryManagementService.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace InventoryManagementService.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepo _inventoryRepo;

        public InventoryService(IInventoryRepo inventoryRepo)
        {
            this._inventoryRepo = inventoryRepo ?? throw new ArgumentNullException(nameof(inventoryRepo));
        }

        public void AddInventory(Inventory inventory)
        {  
            _inventoryRepo.UpsertRecord(inventory);
        }

    
        public IEnumerable<Inventory> GetAllProductStock(string UserId)
        {
            return _inventoryRepo.GetAllDocuments(UserId);
        }
    }
}
