using AppTransaction.Aplication.Services;
using AppTransaction.Domain;
using AppTransaction.Infraestruture.Datos.Contexts;
using AppTransaction.Infraestruture.Datos.Contexts.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace AppTransaction.Infraestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        ProductService CreateService()
        {
            TransactionContext db = new TransactionContext();
            ProductRepository repo = new ProductRepository(db);
            ProductService service = new ProductService(repo);
            return service;

        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var service = CreateService();
            return Ok(service.Get());
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetByID(int productId)
        {
            var service = CreateService();
            return Ok(service.GetById(productId));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var service = CreateService();
            service.Post(product);
            return Ok("Added product");
        }

        [HttpPut("{productId}")]
        public ActionResult Put(int productId, [FromBody] Product product)
        {
            var service = CreateService();
            product.ProductId = productId;
            service.Update(product);
            return Ok("Updated");
        }

        [HttpDelete("{productId}")]
        public ActionResult Delete(int productId)
        {
            var service = CreateService();
            service.Delete(productId);
            return Ok("Deleted");
        }
    }
}
