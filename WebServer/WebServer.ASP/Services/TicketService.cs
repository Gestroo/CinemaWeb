using CinemaLibrary;
using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Services;

public class TicketService : ITicketRepository
{
    private ApplicationContext _context;

    public TicketService(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Booking> BookTicket(TicketsModel model, Client client)
    {
        var seance = _context.Seance.FirstOrDefault(s => s.ID == model.Seance);
        if (seance is null) return Array.Empty<Booking>();
        var seats = model.Seat.Select(s => _context.HallSeat.FirstOrDefault(h => h.ID == s.ID)).ToList();
        if (seats.Any(s => s == null)) return Array.Empty<Booking>();
        try
        {
            return AddBookings(seance, seats, client);
        }
        catch (Exception e)
        {
            // TODO: изменить исключение
            return Array.Empty<Booking>();
        }
    }

    public IEnumerable<Booking> BuyTicket(TicketsModel model, Client client)
    {
        var bookings = BookTicket(model, client).ToList();
        if (!bookings.Any()) return Array.Empty<Booking>();
        foreach (var b in bookings)
        {
            b.isBought = true;
            b.Ticket.Seance.BoughtSeats.Add(b.Ticket.Seat);  
        }

        try
        {
            _context.SaveChanges();
            return bookings;
        }
        catch (Exception e)
        {
            // TODO: изменить исключение
            return Array.Empty<Booking>();
        }
        
    }

    private IEnumerable<Booking> AddBookings(Seance seance,IEnumerable<HallSeat> seats, Client client)
    {
        List<Booking> bookings = new List<Booking>();
        _context.Film.Where(s => s.ID == seance.FilmID).Load();
        _context.CinemaHall.Where(h => h.HallNumber == seance.CinemaHallID).Load();
        _context.Genre.Where(f => f.ID == seance.Film.GenreID).Load();
        foreach (var s in seats)
        {
            int id = ((s.ID - 1) / 10) + 1;
            Ticket ticket = new Ticket()
            {
                Seance = seance,
                Row = _context.HallRow.FirstOrDefault(r => r.RowNumber == id && r.CinemaHallID == seance.CinemaHallID),
                Seat = s,
                TotalPrice = seance.Cost,
                dateTime = DateTime.Now.Kind == DateTimeKind.Utc ? DateTime.Now : DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                Personal = _context.Personal.First(p => p.Role.ID == 2)
            };
            
            Booking booking = new Booking()
            {
                DateTime = DateTime.Now.Kind == DateTimeKind.Utc ? DateTime.Now : DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), 
                Ticket = ticket,
                isBought = false
            };
            seance.ReservedSeats.Add(s);
            _context.Add(booking);

            bookings.Add(booking);
        }
        client.Bookings.AddRange(bookings);
        _context.SaveChanges();
        return bookings;
    }
}