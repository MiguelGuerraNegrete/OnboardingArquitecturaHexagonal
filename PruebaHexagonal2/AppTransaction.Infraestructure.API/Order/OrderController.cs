using AppTransaction.Aplication.Interfaces;
using AppTransaction.Aplication.Services;
using AppTransaction.Domain;
using AppTransaction.Domain.Interfaces.Repository;
using AppTransaction.Infraestruture.Datos.Contexts;
using AppTransaction.Infraestruture.Datos.Contexts.Repositorys;
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
        
        [HttpGet("{orderId}")]
        public ActionResult<Order> GetByID( )
        {
            var service = _orderService.ExecuteAsync();
            return Ok(service);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            _orderService.ExecuteAsync();
            return Ok("Added order");
        }
    }
}
