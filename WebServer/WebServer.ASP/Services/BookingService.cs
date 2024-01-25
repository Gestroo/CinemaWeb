using CinemaLibrary;
using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Services;

public class BookingService : IBookingRepository
{
    private ApplicationContext _context;

    public BookingService(ApplicationContext context)
    {
        _context = context;
    }

    public Booking? GetBookingById(int id)
    {
        return _context.Booking.Include(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.Film)
            .ThenInclude(f => f.Genre).Include(b => b.Ticket).ThenInclude(t => t.Row).Include(b => b.Ticket)
            .ThenInclude(t => t.Seat).Include(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.CinemaHall)
            .FirstOrDefault(b => b.ID == id);
    }

    public IEnumerable<Booking> GetBookings(Client client)
    {
        // return _context.Booking;
        return _context.Client.Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seance)
            .ThenInclude(s => s.Film).ThenInclude(f => f.Genre).Include(c => c.Bookings).ThenInclude(b => b.Ticket)
            .ThenInclude(t => t.Row).Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seat)
            .Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seance)
            .ThenInclude(s => s.CinemaHall).First(c => c.ID == client.ID).Bookings;
    }
}