using CinemaLibrary;
using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Services;

public class SeanceService: ISeanceRepository
{
    private ApplicationContext _context;

    public SeanceService(ApplicationContext context)
    {
        _context = context;
    }
    public IQueryable<Seance> GetSeancesByFilmId(int id)
    {
        return _context.Seance.Where(s => s.FilmID == id).Include(s=>s.CinemaHall).Include(s=>s.Film).ThenInclude(f=>f.Genre);
    }

    public Seance? GetSeanceById(int id)
    {
        return _context.Seance.Include(s => s.Film).ThenInclude(f => f.Genre).Include(s => s.CinemaHall).ThenInclude(h => h.Rows).ThenInclude(r => r.Seats).Include(s => s.ReservedSeats).Include(s => s.BoughtSeats).FirstOrDefault(s => s.ID == id);
    }
}