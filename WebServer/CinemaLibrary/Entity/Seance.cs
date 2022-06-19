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
        public int Cost { get; set; }
        public List<HallSeat> BoughtSeats { get; set; }
        public List<HallSeat> ReservedSeats { get; set; }
        public int CinemaHallID { get; set; }
        public int FilmID { get; set; }
        private static List<Seance> seances = new List<Seance>();
        public string Date { get { return SeanceDate.ToString("d"); } }
        public string Time { get { return SeanceDate.ToString("t"); } }

        public Seance()
        {
            BoughtSeats = new List<HallSeat>();
            ReservedSeats = new List<HallSeat>();
        }

        private static ApplicationContext db = Context.Db;
        public static void GetSeances()
        {
            ApplicationContext db = Context.Db; ;
            try
            {
                seances = db.Seance.Include(s => s.Film).ThenInclude(f => f.Genre).Include(s => s.CinemaHall).ThenInclude(h => h.Rows).ThenInclude(r => r.Seats).Include(s => s.ReservedSeats).Include(s => s.BoughtSeats).ToList();
            }
            catch {
                return;
            }
        }
        public static Seance GetSeance(DateTime dateTime, CinemaHall cinemaHall)
        {
            ApplicationContext db = Context.Db;
            return db.Seance.Where(s => s.SeanceDate == dateTime).Where(s => s.CinemaHall == cinemaHall).FirstOrDefault();
        }
        public static void Add(Seance seance)
        {
            ApplicationContext db = Context.Db;
            db.Seance.Add(seance);
            db.SaveChanges();
        }
        public static List<Seance> GetSeancesByFilm(int id) {
            
            return seances.Where(s => s.Film.ID == id).ToList();
        }
        public static Seance GetSeanceByID(int id)
        {
            return seances.Where(s => s.ID == id).First();
          //  ApplicationContext db = Context.Db;
          //  return db.Seance.Where(s => s.ID == id).Include(s => s.Film).ThenInclude(f => f.Genre).Include(s => s.CinemaHall).ThenInclude(h => h.Rows).ThenInclude(r => r.Seats).Include(s => s.ReservedSeats).Include(s => s.BoughtSeats).FirstOrDefault();
        }
        public static string CheckSeatStatus(HallSeat seat,Seance seance) {
            string status="Свободно";
            if (seance.ReservedSeats.Contains(seat))
                status = "Забронировано";
            if (seance.BoughtSeats.Contains(seat))
                status = "Куплено";
            return status;
        }

        public void Save()
        {
            ApplicationContext db = Context.Db;
            db.SaveChanges();
        }
    }
}
