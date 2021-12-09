using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;
using System.Net.Http.Json;

namespace PharmacyWeb.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public List<Product> Products { get; set; } = new();

        public event Action ProductsChanged;

        public async Task GetProducts(int? categoryIndex = null)
        {
            var result = categoryIndex == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/Category/{categoryIndex}");
            Products = result.Data;
            ProductsChanged.Invoke();
        }
    }
}
