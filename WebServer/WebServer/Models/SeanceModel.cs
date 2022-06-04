using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaLibrary.Entity;

namespace WebServer.Models
{
    public class SeanceModel
    {
        public int ID { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public Film Film { get; set; }
        public DateTime SeanceDate { get; set; }

        public List<HallSeat> BoughtSeats { get; set; }
        public List<HallSeat> ReservedSeats { get; set; }

        public SeanceModel(int id,CinemaHall hall, Film film, DateTime SeanceDate, List<HallSeat> boughtseats, List<HallSeat> reservedseats) { 
            this.ID = id;
            this.CinemaHall = hall;
            this.Film = film;
            this.SeanceDate = SeanceDate;
            this.BoughtSeats = boughtseats;
            this.ReservedSeats = reservedseats;
        }
    }
}
