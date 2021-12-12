using Microsoft.EntityFrameworkCore;
using PharmacyWeb.Server.Data;
using PharmacyWeb.Shared.Cart;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrder(CartOrder cartOrder)
        {
            var user = await _context.Users.FindAsync(cartOrder.UserId);
            List<Sale> sales = new();


            foreach(var cartSale in cartOrder.CartSales)
            {
                var product = await _context.Products.FindAsync(cartSale.ProductId);
                var sale = new Sale()
                {
                    Product = product,
                    Quantity = cartSale.Quantity
                };
                await _context.AddAsync(sale);
                sales.Add(sale);
            }

            Order order = new()
            {
                DateSale = cartOrder.DateCreate,
                User = user,
                Sales = sales
            };
           
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();

            var result = await _context.Orders
                .Include(o=>o.User)
                .Include(o => o.Sales)
                .ThenInclude(s => s.Product)
                .FirstAsync(o=>o.User.Id == user.Id && o.DateSale == cartOrder.DateCreate);

            return result;
        }
    }
}
