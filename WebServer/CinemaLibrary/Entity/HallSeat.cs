using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class HallSeat //Место
    {

        public int ID { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        public List<Seance> BoughtSeances { get; set; }
        public List<Seance> ReservedSeances { get; set; }
        private static ApplicationContext db = Context.Db;

        public int HallRowID { get; set; }
        public HallSeat()
        {
            BoughtSeances = new List<Seance>();
            ReservedSeances = new List<Seance>();
        }
        public static HallSeat GetSeatByID(int id) {
            using var db = new ApplicationContext();
            return db.HallSeat.FirstOrDefault(s => s.ID == id);
        }
    }
}
