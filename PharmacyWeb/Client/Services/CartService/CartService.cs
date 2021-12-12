using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using PharmacyWeb.Client.Services.AuthService;
using PharmacyWeb.Client.Services.ProductService;
using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Cart;
using PharmacyWeb.Shared.Models;
using System.Net.Http.Json;

namespace PharmacyWeb.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IProductService _productService;
        private readonly IToastService _toastService;
        private readonly IAuthService _authService;
        private readonly HttpClient _http;

        public List<Sale> Sales { get; set; } = new();
        public string Message { get; set; } = "";

        public CartService(ILocalStorageService localStorage,
            IProductService productService,
            IToastService toastService,
            IAuthService authService,
            HttpClient http)
        {
            _localStorage = localStorage;
            _productService = productService;
            _toastService = toastService;
            _authService = authService;
            _http = http;
        }
        public event Action OnChange;

        public async Task AddToCart(Product product)
        {
            if(_authService.User != null)
            {
                var cart = await _localStorage.GetItemAsync<List<Product>>("cart");
                if (cart is null)
                {
                    cart = new();
                }
                cart.Add(product);
                await _localStorage.SetItemAsync("cart", cart);

                var productName = _productService.Products.First(p => p.Id == product.Id).Name;
                _toastService.ShowSuccess(productName, "Добавлено в корзину:");

                OnChange.Invoke();
            }
            else
            {
                _toastService.ShowError("Для покупки товара необходимо авторизоваться");
            }
            
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

        public async Task EmptyCart()
        {
            await _localStorage.RemoveItemAsync("cart");
            Sales = new List<Sale>();
            OnChange.Invoke();
        }

        public async Task CreateOrder()
        {
            if(Sales != null && Sales.Count != 0)
            {
                List<CartSale> cartSales = new();

                foreach(var sale in Sales)
                {
                    CartSale cartSale = new()
                    {
                        Quantity = sale.Quantity,
                        ProductId = sale.Product.Id
                    };
                    cartSales.Add(cartSale);
                }

                CartOrder cartOrder = new()
                {
                    UserId = _authService.User.Id,
                    DateCreate = DateTime.Now,
                    CartSales = cartSales
                };


               // await _localStorage.SetItemAsync<CartOrder>("order", cartOrder);
                var response = await _http.PostAsJsonAsync<CartOrder>("api/order", cartOrder);
                var orderResponse = await response.Content.ReadFromJsonAsync<ServiceResponse<Order>>();
                if (orderResponse.Success)
                {
                    Message = "";
                    await EmptyCart();
                }
                Message = orderResponse.Message;
                
            }
            
           
            
        }
    }
}
