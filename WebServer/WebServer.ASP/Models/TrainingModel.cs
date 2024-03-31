using CinemaLibrary.Entity;

namespace WebServer.ASP.Models;

public class TrainingModel
{
    public int ID { get; set; }
    public bool Flag { get; set; }
    public string? LastTrain { get; set; }
    public ClientModel Client { get; set; }

    public TrainingModel(Training t)
    {
        this.ID = t.ID;
        this.Flag = t.TrainingFlag;
        this.LastTrain = t.lastTrain.ToString();
        this.Client = new ClientModel(t.Client);
    }

    public TrainingModel()
    {
    }
}