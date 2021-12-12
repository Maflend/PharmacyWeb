using PharmacyWeb.Shared.Cart;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<Order> AddOrder(CartOrder order);
        
    }
}
