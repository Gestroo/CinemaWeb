using CinemaLibrary.Entity;

namespace WebServer.ASP.Repositories;

public interface IFilmRepository
{
    IEnumerable<Film> GetFilms();
    Film? GetFilmById(int id);
}