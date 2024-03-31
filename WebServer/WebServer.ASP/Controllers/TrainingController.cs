using CinemaLibrary.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Controllers;

[ApiController]
[Route("training")]
[Authorize]
public class TrainingController : ControllerBase
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IClientRepository _clientRepository;

    public TrainingController(ITrainingRepository trainingRepository, IClientRepository clientRepository)
    {
        _trainingRepository = trainingRepository;
        _clientRepository = clientRepository;
    }

    private Client? GetClientInRequest()
    {
        var id = HttpContext.User.FindFirst("user");
        return id is null ? null : _clientRepository.GetClientById(Convert.ToInt32(id.Value));
    }
    
    [HttpGet]
    public IActionResult GetTraining()
    {
        var client = GetClientInRequest();
        if (client is null) return BadRequest("token is incorrect");
        try
        {
            var train = _trainingRepository.GetTrainingByClientId(client);
            return Ok (new TrainingModel(train));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult UpdateTraining()
    {
        var client = GetClientInRequest();
        if (client is null) return BadRequest("token is incorrect");
        var train = _trainingRepository.UpdateTraining(client);
        return Ok(new TrainingModel(train));
    }
}