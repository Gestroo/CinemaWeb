﻿using Microsoft.EntityFrameworkCore;
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
            using var db = new ApplicationContext();
            { return db.Seance.ToList(); }
        }
        public static Seance GetSeance(DateTime dateTime, CinemaHall cinemaHall)
        {
            using var db = new ApplicationContext();
            return db.Seance.Where(s => s.SeanceDate == dateTime).Where(s => s.CinemaHall == cinemaHall).FirstOrDefault();
        }
        public static void Add(Seance seance)
        {
            db.Seance.Add(seance);
            db.SaveChanges();
        }
        public static List<Seance> GetSeancesByFilm(int id) {
            using var db = new ApplicationContext();
            return db.Seance.Where(s => s.Film.ID == id).Include(s => s.Film).ThenInclude(f=>f.Genre).Include(s=>s.CinemaHall).Include(s=>s.ReservedSeats).Include(s=>s.BoughtSeats).ToList();
        }
        public static Seance GetSeanceByID(int id)
        {
            using var db = new ApplicationContext();
            return db.Seance.Where(s => s.ID == id).Include(s => s.Film).ThenInclude(f => f.Genre).Include(s => s.CinemaHall).ThenInclude(h => h.Rows).ThenInclude(r => r.Seats).Include(s => s.ReservedSeats).Include(s => s.BoughtSeats).FirstOrDefault();
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
            using var db = new ApplicationContext();
            db.SaveChanges();
        }
    }
}
