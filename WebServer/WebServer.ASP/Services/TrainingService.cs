using CinemaLibrary;
using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Services;

public class TrainingService : ITrainingRepository
{
    private ApplicationContext _context;

    public TrainingService(ApplicationContext context)
    {
        _context = context;
    }

    public Training GetTrainingByClientId(Client client)
    {
        return _context.Training.FirstOrDefault(t => t.ClientID == client.ID)!;
    }

    public Training UpdateTraining(Client client)
    {
        var train = GetTrainingByClientId(client);
        var newTrainEntry = _context.Entry(train);
        var newTrain = newTrainEntry.Entity;
        newTrain.TrainingFlag = true;
        newTrain.lastTrain = DateTime.Now;
        newTrainEntry.State = EntityState.Modified;
        _context.SaveChanges();
        return newTrain;
    }
}