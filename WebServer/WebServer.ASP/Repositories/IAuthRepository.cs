using CinemaLibrary.Entity;
using WebServer.ASP.Models;

namespace WebServer.ASP.Repositories;

public interface IAuthRepository
{
    Client? GetClientAuth(string phone, string pass);
    Client AddNewClient(RegModel regModel);
}