using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace CinemaLibrary.Entity
{
    public class Seance //Сеанс
    {
        public int ID { get; set; }
        [Required]
        public CinemaHall CinemaHall { get; set; }
        [Required]
        public Film Film { get; set; }
        [Required]
        public DateTime SeanceDate { get; set; }

        public List<HallSeat> BoughtSeats { get; set; }
        public List<HallSeat> ReservedSeats { get; set; }
        public int CinemaHallID { get; set; }
        public int FilmID { get; set; }

        public string Date { get { return SeanceDate.ToString("d"); } }
        public string Time { get { return SeanceDate.ToString("t"); } }

        public Seance()
        {
            BoughtSeats = new List<HallSeat>();
            ReservedSeats = new List<HallSeat>();
        }

        private static ApplicationContext db = Context.Db;
        public static List<Seance> GetSeances()
        {
            { return db.Seance.ToList(); }
        }
        public static Seance GetSeance(DateTime dateTime, CinemaHall cinemaHall)
        {
            return db.Seance.Where(s => s.SeanceDate == dateTime).Where(s => s.CinemaHall == cinemaHall).FirstOrDefault();
        }
        public static void Add(Seance seance)
        {
            db.Seance.Add(seance);
            db.SaveChanges();
        }
        public static List<Seance> GetSeancesByFilm(int id) {
            using var db = new ApplicationContext();
            return db.Seance.Where(s => s.Film.ID == id).Include(s => s.Film).Include(s=>s.CinemaHall).Include(s=>s.ReservedSeats).Include(s=>s.BoughtSeats).ToList();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
