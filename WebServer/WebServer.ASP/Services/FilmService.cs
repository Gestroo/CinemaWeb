using CinemaLibrary;
using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Services;

public class FilmService : IFilmRepository
{
    private ApplicationContext _context;

    public FilmService(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<Film> GetFilms()
    {
        var films = _context.Film.Where(f => f.DateFinish >= DateTime.Today).Include(f=>f.Genre);
        return films;
    }

    public Film? GetFilmById(int id)
    {
        var film = _context.Film.Include(f=>f.Genre).FirstOrDefault(f => f.ID == id);
        if (film is null) return null;
        return film;
    }
}