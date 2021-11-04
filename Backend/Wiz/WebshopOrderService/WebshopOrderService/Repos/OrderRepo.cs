using DataModels;
using MongoDBCrudLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopOrderService.Models;

namespace WebshopOrderService.Repos
{
    public class OrderRepo : IOrderRepo
    {
        public OrderRepo(
            IMongoDBCollection<Product> productRepo,
             IMongoDBCollection<Inventory> inventoryRepo
            )
        {

        }
        public void CreateOrder(Cart cart)
        {

        }
    }
}
