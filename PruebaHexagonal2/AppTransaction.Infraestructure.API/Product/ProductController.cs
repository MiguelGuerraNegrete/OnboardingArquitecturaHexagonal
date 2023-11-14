using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AppTransaction.Infraestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;         
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var allClients = await _productService.GetAsync();
            return Ok(allClients);
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetByID(Guid productId)
        {
            var service = _productService.GetByIdAsync(productId);
            return Ok(service);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            _productService.SaveAsync(product);
            return Ok("Added product");
        }
    }
}
