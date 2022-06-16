using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Booking
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public Ticket Ticket { get; set; }
        public bool isBought { get; set; }
        public int ClientID { get; set; }
        private static ApplicationContext db = Context.Db;

        public Booking() { }

        public static List<Booking> GetBookings(int id) {
            using var db = new ApplicationContext();
            return db.Client.Include(c=>c.Bookings).ThenInclude(b=>b.Ticket).ThenInclude(t=>t.Seance).ThenInclude(s=>s.Film).ThenInclude(f=>f.Genre).Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t=>t.Row).Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seat).Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.CinemaHall).First(c => c.ID == id).Bookings; 
        }
        public static Booking GetBookingByID(int id) {
            using var db = new ApplicationContext();
            return db.Booking.Include(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.Film).ThenInclude(f => f.Genre).Include(b => b.Ticket).ThenInclude(t => t.Row).Include(b => b.Ticket).ThenInclude(t => t.Seat).Include(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.CinemaHall).First(b=>b.ID == id);
        }
        public static void Add(Booking booking)
        {
            db.Add(booking);
            db.SaveChanges();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }

}
