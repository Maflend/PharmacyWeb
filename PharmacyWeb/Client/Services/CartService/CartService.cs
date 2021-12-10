using Blazored.LocalStorage;
using Blazored.Toast.Services;
using PharmacyWeb.Client.Services.ProductService;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IProductService _productService;
        private readonly IToastService _toastService;

        public List<Sale> Sales { get; set; } = new();


        public CartService(ILocalStorageService localStorage, IProductService productService, IToastService toastService)
        {
            _localStorage = localStorage;
            _productService = productService;
            _toastService = toastService;
        }
        public event Action OnChange;

        public async Task AddToCart(Product product)
        {
            var cart = await _localStorage.GetItemAsync<List<Product>>("cart");
            if(cart is null)
            {
                cart = new();
            }
            cart.Add(product);
            await _localStorage.SetItemAsync("cart", cart);

            var productName = _productService.Products.First(p => p.Id == product.Id).Name;
            _toastService.ShowSuccess(productName, "Добавлено в корзину:");

            OnChange.Invoke();
        }

        public async Task GetCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<Product>>("cart");
            if(cart == null)
            {
                return;
            }
            foreach(var product in cart)
            {
                if(Sales.Any(s=>s.Product.Id == product.Id))
                {
                    Sales.First(s => s.Product.Id == product.Id).Quantity  = cart.Where(p=>p.Id == product.Id).Count();
                }
                else
                {
                    Sales.Add(new Sale { Product = product, Quantity = 1 });
                }
            }

           
            


        }
    }
}
