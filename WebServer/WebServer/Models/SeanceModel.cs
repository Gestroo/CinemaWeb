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
        public HallModel CinemaHall { get; set; }
        public FilmModel Film { get; set; }
        public string SeanceDate { get; set; }
        public string SeanceTime { get; set; }
        public int Cost { get; set; }

        public SeanceModel(int id,HallModel hall, FilmModel film, string SeanceDate, string SeanceTime, int cost) { 
            this.ID = id;
            this.CinemaHall = hall;
            this.Film = film;
            this.SeanceTime = SeanceTime;
            this.SeanceDate = SeanceDate;
            this.Cost = cost;
        }
    }
}
