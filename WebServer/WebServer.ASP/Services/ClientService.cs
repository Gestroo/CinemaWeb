using CinemaLibrary;
using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Services;

public class ClientService : IClientRepository
{
    private ApplicationContext _context;

    public ClientService(ApplicationContext context)
    {
        _context = context;
    }

    public Client? GetClientById(int id)
    {
        return _context.Client.FirstOrDefault(c => c.ID == id);
    }

    public Client UpdateClient(Client client, ClientModel model)
    {
        var newClientEntry = _context.Entry(client);
        var newClient = newClientEntry.Entity;
        if (!string.IsNullOrWhiteSpace(model.lastname) && newClient.LastName != model.lastname)
            newClient.LastName = model.lastname;
        if (!string.IsNullOrWhiteSpace(model.firstname) && newClient.FirstName != model.firstname)
            newClient.FirstName = model.firstname;
        if (!string.IsNullOrWhiteSpace(model.middlename) && newClient.MiddleName != model.middlename)
            newClient.MiddleName = model.middlename;
        if (!string.IsNullOrWhiteSpace(model.birthdate) &&
            newClient.BirthDate != DateOnly.FromDateTime(Convert.ToDateTime(model.birthdate)))
            newClient.BirthDate = DateOnly.FromDateTime(Convert.ToDateTime(model.birthdate));
        if (!string.IsNullOrWhiteSpace(model.email) && newClient.Email != model.email &&
            !_context.Client.Any(c => c.Email == model.email))
            newClient.Email = model.email;
        if (!string.IsNullOrWhiteSpace(model.phone) && newClient.PhoneNumber != model.phone &&
            !_context.Client.Any(c => c.PhoneNumber == model.phone))
            newClient.PhoneNumber = model.phone;
        newClientEntry.State = EntityState.Modified;
        _context.SaveChanges();
        return newClient;
    }
}