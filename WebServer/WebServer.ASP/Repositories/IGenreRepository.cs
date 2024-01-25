using CinemaLibrary.Entity;

namespace WebServer.ASP.Repositories;

public interface IGenreRepository
{
    IEnumerable<Genre> GetGenres();
}