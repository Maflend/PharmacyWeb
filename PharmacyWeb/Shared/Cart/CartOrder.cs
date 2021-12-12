using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWeb.Shared.Cart
{
    public class CartOrder
    {
        public DateTime DateCreate { get; set; }
        public int UserId { get; set; }
        public List<CartSale> CartSales { get; set; }

    }
    public class CartSale
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
