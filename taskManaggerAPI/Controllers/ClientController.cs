using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskManaggerAPI.Data.Entities;
using taskManaggerAPI.Data.Models;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;

        public ClientController(IUserService userService, IClientService clientService)
        {
            _userService = userService;
            _clientService = clientService;
        }

        [HttpGet("GetClients")]
        public IActionResult GetClients()
        {
            var clients = _clientService.GetClients();

            try
            {
                return Ok(clients.Where(x => x.State == true));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet("GetClientById{id}")]
        public IActionResult GetClientById(int id)
        {
            var client = _clientService.GetClientById(id);

            if (client == null)
            {
                return NotFound($"El admmin de ID: {id} no fue encontrado");
            }

            return Ok(client);
        }

        [HttpPost("CreateNewClient")]
        public IActionResult CreateClient([FromBody] ClientPostDto dto)
        {
            if (dto.Name == "string" || dto.Email == "string" || dto.UserName == "string" || dto.Password == "string")
            {
                return BadRequest("Client no creado, por favor completar los campos");
            }
            try
            {
                var client = new Client()
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    Password = dto.Password,
                    UserName = dto.UserName,
                    UserType = "Client"
                };
                int id = _userService.CreateUser(client);
                return Ok($"Admin creado exitosamente con id: {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("DeleteClient/{id}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                var existingClient = _clientService.GetClientById(id);
                if (existingClient == null)
                {
                    return NotFound($"No se encontró ningún Client con el ID: {id}");
                }
                _userService.DeleteUser(id);
                return Ok($"Client con ID: {id} eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdateClient{id}")]
        public IActionResult UpdateClient([FromRoute] int id, [FromBody] ClientPutDto client)
        {
            if (client.Name == "string" || client.Email == "string" || client.UserName == "string" || client.Password == "string")
            {
                return BadRequest("Client no actualizado, por favor completar los campos");
            }
            var clientToUpdate = _clientService.GetClientById(id);
            if (clientToUpdate == null)
            {
                return NotFound($"Client con ID {id} no encontrado");
            }
            try
            {
                clientToUpdate.Name = client.Name;
                clientToUpdate.Email = client.Email;
                clientToUpdate.Password = client.Password;
                clientToUpdate.UserName = client.UserName;

                clientToUpdate = _clientService.UpdateClient(clientToUpdate);
                return Ok($"Client actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el Cliente: {ex.Message}");
            }
        }
    }
}
