using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyWeb.Server.Services.OrderService;
using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Cart;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<ServiceResponse<Order>> CreateOrder(CartOrder cartOrder)
        {
            if (cartOrder != null)
            {
                var result = await _orderService.AddOrder(cartOrder);
                return new ServiceResponse<Order>()
                {
                    Data = null,
                    Success = true,
                    Message = ""
                };
            }
            return new ServiceResponse<Order>()
            {
                Data = null,
                Message = "Не удалось сделать заказ",
                Success = false
            };


         
        }
    }
}