using CinemaLibrary;
using CinemaLibrary.Entity;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Services;

public class GenreService : IGenreRepository
{
    private ApplicationContext _context;

    public GenreService(ApplicationContext context)
    {
        _context = context;
    }
    public IEnumerable<Genre> GetGenres()
    {
        return _context.Genre.OrderBy(g => g.Title);
    }
}