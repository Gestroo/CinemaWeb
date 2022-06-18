using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class SeatModel
    {
        public int ID { get; set; }
        public int SeatNumber { get; set; }
        public string Status { get; set; }
        public SeatModel(HallSeat seat, Seance seance)
        {
            this.ID = seat.ID;
            this.SeatNumber = seat.SeatNumber;
            this.Status = Seance.CheckSeatStatus(seat, seance);
        }
        public SeatModel() { }
    }
   
}
