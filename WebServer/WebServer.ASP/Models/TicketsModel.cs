namespace WebServer.ASP.Models
{
    public class TicketsModel
    {
        public int ID { get; set; }
        public int Seance { get; set; }
        public List<SeatModel> Seat { get; set; }
        public string? DateTime { get; set; }

        public TicketsModel()
        {
        }
    }
}
