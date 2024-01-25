using CinemaLibrary.Entity;
using WebServer.ASP.Models;

namespace WebServer.ASP.Repositories;

public interface ITicketRepository
{
    IEnumerable<Booking> BookTicket(TicketsModel model,Client client);
    IEnumerable<Booking> BuyTicket(TicketsModel model,Client client);
}