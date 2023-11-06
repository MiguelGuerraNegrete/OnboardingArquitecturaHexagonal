using AppTransaction.Aplication.Services;
using AppTransaction.Domain;
using AppTransaction.Infraestruture.Datos.Contexts;
using AppTransaction.Infraestruture.Datos.Contexts.Repositorys;
using Microsoft.AspNetCore.Mvc;


namespace AppTransaction.Infraestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        ClientService CreateService()
        {
            TransactionContext db = new TransactionContext();
            ClientRepository repo = new ClientRepository(db);
            ClientService service = new ClientService(repo);
            return service;

        }
        
        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            var service = CreateService();
            return Ok(service.Get());
        }

        [HttpGet("{clientId}")]
        public ActionResult<Client> GetByID(int clientId)
        {
            var service = CreateService();
            return Ok(service.GetById(clientId));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            var service = CreateService();
            service.Post(client);
            return Ok("Added client");
        }

        [HttpPut("{clientId}")]
        public ActionResult Put(int clientId, [FromBody] Client client)
        {
            var service = CreateService();
            client.ClientId = clientId;
            service.Update(client);
            return Ok("Updated");
        }

        [HttpDelete("{clientId}")]
        public ActionResult Delete(int clientId)
        {
            var service = CreateService();
            service.Delete(clientId);
            return Ok("Deleted");
        }
    }
}
