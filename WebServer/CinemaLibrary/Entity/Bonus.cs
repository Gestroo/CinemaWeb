namespace CinemaLibrary.Entity;

public class Bonus
{
    public int ID { get; set; }
    public string Name { get; set; }
    public float Discount { get;set; }
    private static ApplicationContext db = Context.Db;
}