using Microsoft.AspNetCore.Mvc;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Controllers;
[ApiController]
[Route("genres")]
public class GenreController: ControllerBase
{
    private readonly IGenreRepository _genreRepository;

    public GenreController(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    [HttpGet]
    public IActionResult GetGenres()
    {
        return Ok(_genreRepository.GetGenres().Select(g=>new GenreModel(g)));
    }
}