using AppTransaction.Aplication.Interfaces;
using AppTransaction.Domain;
using Microsoft.AspNetCore.Mvc;


namespace AppTransaction.Infraestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var allClients = await _clientService.GetAsync();
            return Ok(allClients);
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult> GetByID(Guid clientId)
        {
            var service = await _clientService.GetByIdAsync(clientId);
            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
        {
            await _clientService.Save(client);
            return Ok("Added client");
        }
    }
}
