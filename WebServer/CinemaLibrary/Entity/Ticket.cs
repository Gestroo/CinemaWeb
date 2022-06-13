using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Ticket //Билет
    {
        public int ID { get; set; }
        public Seance Seance { get; set; }
        [Required]
        public HallRow Row { get; set; }
        [Required]
        public HallSeat Seat { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        public DateTime dateTime { get; set; }
        public int SeanceID { get; set; }
        public int RowID { get; set; }
        public int SeatID { get; set; }
        public int PersonalID { get; set; }
        [Required]
        public Personal Personal { get; set; }
        private static ApplicationContext db = Context.Db;


        public static Ticket? FindTicket(Seance seance, int row, int seat)
        {
            using var db = new ApplicationContext();
            return db.Ticket.FirstOrDefault(t => t.Seance == seance && t.Row.RowNumber == row && t.Seat.SeatNumber == seat);
        }
        public static void Add(Ticket ticket)
        {
            db.Ticket.Add(ticket);
            db.SaveChanges();
        }

    }
}
