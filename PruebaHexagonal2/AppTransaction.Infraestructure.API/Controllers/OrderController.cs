using AppTransaction.Aplication.Services;
using AppTransaction.Domain;
using AppTransaction.Infraestruture.Datos.Contexts;
using AppTransaction.Infraestruture.Datos.Contexts.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace AppTransaction.Infraestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService CreateService()
        {
            TransactionContext db = new TransactionContext();
            OrderRepository repoOrder = new OrderRepository(db);
            ClientRepository repoClient = new ClientRepository(db);
            ProductRepository repoProduct = new ProductRepository(db);
            OrderService service = new OrderService(repoOrder);
            return service;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            var service = CreateService();
            return Ok(service.Get());
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> Get1(long orderId)
        {
            var service = CreateService();
            return Ok(service.GetById(orderId));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            var service = CreateService();
            service.Post(order);
            return Ok("Added order");
        }

        [HttpDelete("{orderId}")]
        public ActionResult Delete(long orderId)
        {
            var service = CreateService();
            service.Cancel(orderId);
            return Ok("Deleted");
        }
    }
}
