using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackOfficeAuth;
using DataModels;
using InventoryManagementService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementService.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : BackOfficeController
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService) 
        { 
            this._inventoryService = inventoryService ?? throw new ArgumentNullException(nameof(inventoryService));
        }

        [HttpPost("AddInventory")]
        public string UpsertInventory([FromBody]Inventory inventory)
        {
            inventory.CustomerId = UserId;
            _inventoryService.AddInventory(inventory);
            return "Inventory Added";
        }

        [HttpGet("GetAllProductStock")]
        public List<Inventory> GetAllProductStock()
        {
            return _inventoryService.GetAllProductStock(UserId).ToList();
        }

    }
}
