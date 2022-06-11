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

        public RowModel(int id,int rowNumber,List<SeatModel> seats) { 
            this.ID = id;
            this.RowNumber = rowNumber;
            this.Seats = seats;
        }
    }
}
