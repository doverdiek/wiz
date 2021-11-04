using WebshopOrderService.Models;

namespace WebshopOrderService.Repos
{
    public interface IOrderRepo
    {
        void CreateOrder(Cart cart);
    }
}