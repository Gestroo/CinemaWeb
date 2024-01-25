using Microsoft.AspNetCore.Mvc;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Controllers;
[ApiController]
[Route("seances")]
public class SeanceController: ControllerBase
{
    private readonly ISeanceRepository _seanceRepository;

    public SeanceController(ISeanceRepository seanceRepository)
    {
        _seanceRepository = seanceRepository;
    }

    [HttpGet("film/{id:int}")]
    public IActionResult GetSeancesByFilmID(int id)
    {
        var seances = _seanceRepository.GetSeancesByFilmId(id);
        if (seances is null) return NotFound();
        return Ok(seances.Select(s => new SeanceModel(s)));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetSeanceByID(int id)
    {
        var seance = _seanceRepository.GetSeanceById(id);
        if (seance is null) return NotFound();
        return Ok(new SeanceModel(seance));
    }
}