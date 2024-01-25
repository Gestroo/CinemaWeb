using CinemaLibrary.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Controllers;
[ApiController]
[Route("clients")]
[Authorize]
public class ClientController: ControllerBase
{
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    private Client? GetClientInRequest()
    {
        var id = HttpContext.User.FindFirst("user");
        return id is null ? null : _clientRepository.GetClientById(Convert.ToInt32(id.Value));
    }

    [HttpPost("update")]
    public IActionResult UpdateClient(ClientModel clientModel)
    {
        var client = GetClientInRequest();
        if (client is null) return BadRequest("token is incorrect");
        return Ok(new ClientModel(_clientRepository.UpdateClient(client, clientModel)));
    }
}