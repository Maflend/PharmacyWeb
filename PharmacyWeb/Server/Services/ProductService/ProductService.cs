using Microsoft.EntityFrameworkCore;
using PharmacyWeb.Server.Data;
using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            var response = new ServiceResponse<List<Product>>
            {
                Data = products
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(int categoryIndex)
        {
            var products = await _context.Products.Where(p => (int)p.Category.Categories == categoryIndex).ToListAsync();
            return new ServiceResponse<List<Product>>() { Data = products };
        }
    }
}
