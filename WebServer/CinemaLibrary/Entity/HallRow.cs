﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class HallRow //Ряд
    {
        public int ID { get; set; }
        [Required]
        public int RowNumber { get; set; }
        [Required]
        public List<HallSeat> Seats { get; set; }

        public int CinemaHallID { get; set; }

        public HallRow() { Seats = new List<HallSeat>(); }
        private static ApplicationContext db = Context.Db;
        public static HallRow GetHallRowByNumber(int rowNumber)
        {
            ApplicationContext db = Context.Db;
            return db.HallRow.FirstOrDefault(h => h.RowNumber == rowNumber);
        }
        public static HallSeat FindSeat(int row, int number)
        {
            ApplicationContext db = Context.Db;
            return db.HallRow.FirstOrDefault(r => r.RowNumber == row && r.Seats.Any(s=>s.SeatNumber == number)).Seats[number-1];
        }
        public static HallRow FindRowBySeatID(int seatId,int hallId) {
            ApplicationContext db = Context.Db;
            int id = ((seatId - 1) / 10) + 1;
            try
            {
                return db.HallRow.FirstOrDefault(r => r.RowNumber == id && r.CinemaHallID == hallId);
            }
            catch {
                return null; ;
            }
        }
    }
}
