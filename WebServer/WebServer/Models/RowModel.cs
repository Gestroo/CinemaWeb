using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class RowModel
    {
        public int ID { get; set; }
        public int RowNumber { get; set; }
        public List<SeatModel> Seats { get; set; }

        public RowModel(HallRow row,Seance seance) {
            this.ID = row.ID;
            this.RowNumber = row.RowNumber;
             List<SeatModel>  seats = new List<SeatModel>();
            foreach (var s in row.Seats.OrderBy(s=>s.SeatNumber))
                seats.Add(new SeatModel(s,seance));
            this.Seats = seats;
        }
    }
}
