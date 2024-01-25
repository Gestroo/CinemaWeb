using CinemaLibrary.Entity;

namespace WebServer.ASP.Models
{
    public class TicketModel
    {
        public int ID { get; set; }
        public SeanceModel Seance { get; set; }
        public RowModel Row { get; set; }
        public SeatModel Seat { get; set; }
        public string DateTime { get; set; }

        public TicketModel(Ticket t) {
            this.ID = t.ID;
            this.Seance = new SeanceModel(t.Seance);
            this.Row = new RowModel(t.Row,t.Seance);
            this.Seat = new SeatModel(t.Seat, t.Seance);
            this.DateTime = t.dateTime.ToString();

        }
    }
}
