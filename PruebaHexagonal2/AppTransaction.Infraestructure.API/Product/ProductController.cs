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
    public class ProductController : ControllerBase
    {
        private readonly TransactionContext _dbcontext;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductController(IProductRepository service, IProductService productService, TransactionContext db)
        {
            _productRepository = service;
            _productService = productService;
            _dbcontext = db;
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetByID(Guid productId)
        {
            var service = _productRepository.GetAsync(productId);
            return Ok(service);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            _productRepository.Save(product);
            return Ok("Added product");
        }
    }
}
