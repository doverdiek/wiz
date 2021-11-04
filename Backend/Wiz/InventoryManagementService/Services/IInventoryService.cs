using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementService.Services
{
    public interface IInventoryService
    {
        void AddInventory(Inventory inventory);

        IEnumerable<Inventory> GetAllProductStock(string UserId);
    }
}
