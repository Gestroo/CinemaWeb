using System;

namespace CinemaLibrary.Entity;

public class Training
{
    public int ID { get; set; }
    public Client Client { get; set; }
    public bool TrainingFlag { get; set; }
    public DateTime? lastTrain { get; set; }
    public int ClientID { get; set; }
    private static ApplicationContext db = Context.Db;
}