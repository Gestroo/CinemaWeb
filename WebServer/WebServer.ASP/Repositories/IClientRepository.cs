using CinemaLibrary.Entity;
using WebServer.ASP.Models;

namespace WebServer.ASP.Repositories;

public interface IClientRepository
{
    Client? GetClientById(int id);
    Client UpdateClient(Client client, ClientModel model);
}