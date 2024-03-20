using CinemaLibrary.Entity;

namespace WebServer.ASP.Repositories;

public interface IFilmRepository
{
    IQueryable<Film> GetFilms();
    Film? GetFilmById(int id);
}