using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        event Action ProductsChanged;
        Task GetProducts(int? categoryIndex = null);
    }
}
