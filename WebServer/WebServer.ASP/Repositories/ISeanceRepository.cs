using CinemaLibrary.Entity;

namespace WebServer.ASP.Repositories;

public interface ISeanceRepository
{
    IQueryable<Seance> GetSeancesByFilmId(int id);
    Seance? GetSeanceById(int id);
    
}