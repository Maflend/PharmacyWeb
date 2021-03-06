using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Client.Services.CartService
{
    public interface ICartService
    {
        List<Sale> Sales { get; set; }
        string Message { get; set; }
        event Action OnChange;
        Task AddToCart(Product product);

        Task GetCartItems();
        Task EmptyCart();
        Task CreateOrder();
    }
}
