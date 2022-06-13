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

        public SeanceModel(Seance seance) { 
            this.ID = seance.ID;
            this.CinemaHall = new HallModel(seance.CinemaHall,seance);
            this.Film = new FilmModel(seance.Film);
            this.SeanceTime = seance.SeanceDate.ToString("t");
            this.SeanceDate = seance.SeanceDate.ToString("d");
            this.Cost = seance.Cost;
        }
    }
}
