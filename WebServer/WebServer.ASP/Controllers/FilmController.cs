using CinemaLibrary.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Controllers;
[ApiController]
[Route("films")]
public class FilmController : ControllerBase
{
    private readonly IFilmRepository _filmRepository;

    public FilmController(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    [HttpGet]
    public IActionResult GetFilms()
    {
        return Ok(_filmRepository.GetFilms().Select(g=>new FilmModel(g)));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetFilmById(int id)
    {
        var film = _filmRepository.GetFilmById(id);
        if (film is null) return NotFound();
        return Ok(film);
    }
    [HttpGet("filter")]
    public IActionResult FilterFilms([FromQuery] string? title, [FromQuery] int sort, [FromQuery] string? genre, [FromQuery]int restriction, [FromQuery] int minDuration, [FromQuery] int maxDuration)
        //TODO: Принимать все остальное
    {
        var tmp = _filmRepository.GetFilms();
        tmp = sort switch
        {
            1 => tmp.OrderByDescending(f=>f.Rating).ToList(),
            2 => tmp.OrderBy(f => f.Name).ToList(),
            3 => tmp.OrderBy(f => f.Duration).ToList(),
            _ => tmp
        };
        if (title is not null) tmp = tmp.Where(f => f.Name.ToLower().Contains(title)).ToList();
        if (genre is not null) tmp = tmp.Where(f => f.Genre.Title.Equals(genre)).ToList();
        if (restriction <19) tmp = tmp.Where(f => f.Restriction.Equals(restriction)).ToList();
        tmp = tmp.Where(f => f.Duration > minDuration && f.Duration < maxDuration).ToList();

        return Ok(tmp.Select(f => new FilmModel(f)));
    }
}