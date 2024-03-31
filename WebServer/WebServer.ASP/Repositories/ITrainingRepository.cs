using CinemaLibrary.Entity;

namespace WebServer.ASP.Repositories;

public interface ITrainingRepository
{
    Training GetTrainingByClientId(Client client);
    Training UpdateTraining(Client client);
}