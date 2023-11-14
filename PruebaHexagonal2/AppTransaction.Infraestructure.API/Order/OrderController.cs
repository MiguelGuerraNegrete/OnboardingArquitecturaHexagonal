using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AppTransaction.Infraestructure.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var allOrdes = await _orderService.GetAsync();
            return Ok(allOrdes);
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> GetByID(Guid orderId )
        {
            var service = _orderService.GetByAsync(orderId);
            return Ok(service);
        }

        [HttpPost]
        public async Task< IActionResult> Post([FromBody] Order order)
        {
            await _orderService.SaveAsync(order);
            return Ok("Added order");
        }
    }
}
