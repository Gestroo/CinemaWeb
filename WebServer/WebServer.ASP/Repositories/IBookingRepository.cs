using CinemaLibrary.Entity;

namespace WebServer.ASP.Repositories;

public interface IBookingRepository
{
    Booking? GetBookingById(int id);
    IEnumerable<Booking> GetBookings(Client client);
}