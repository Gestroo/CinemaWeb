using CinemaLibrary;
using CinemaLibrary.Entity;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Services;

public class AuthService: IAuthRepository
{
    private ApplicationContext _context;

    public AuthService(ApplicationContext context)
    {
        _context = context;
    }

    public Client? GetClientAuth(string phone, string pass)
    {
        return _context.Client.FirstOrDefault(c => c.PhoneNumber == phone && c.Password == pass);
    }

    public Client AddNewClient(RegModel regModel)
    {
        if (_context.Client.Any(c => c.PhoneNumber == regModel.phone)) throw new Exception("Phone is unavailable");
        if (_context.Client.Any(c => c.Email == regModel.email)) throw new Exception("Email is unavailable");
        var client = new Client(regModel.lastname, regModel.firstname, regModel.middlename, regModel.phone,
            DateOnly.FromDateTime(Convert.ToDateTime(regModel.birthdate)), regModel.password, regModel.email);
        var newClient = _context.Client.Add(client);
        _context.SaveChanges();
        return newClient.Entity;
    }
}