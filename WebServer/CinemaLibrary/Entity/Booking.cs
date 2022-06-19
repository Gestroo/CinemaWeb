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
            ApplicationContext db = Context.Db;
            try
            {
                return db.Client.Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.Film).ThenInclude(f => f.Genre).Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Row).Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seat).Include(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.CinemaHall).First(c => c.ID == id).Bookings;
            }
            catch {
                return null;
            }
        }
        public static Booking GetBookingByID(int id) {
            ApplicationContext db = Context.Db;
            try
            {
                return db.Booking.Include(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.Film).ThenInclude(f => f.Genre).Include(b => b.Ticket).ThenInclude(t => t.Row).Include(b => b.Ticket).ThenInclude(t => t.Seat).Include(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.CinemaHall).First(b => b.ID == id);
            }
            catch
            {
                return null;
            }
        }
        public bool Add()
        {
            ApplicationContext db = Context.Db;
            try
            {
                db.Add(this);
                return true;
            }
            catch
            {
                return false;
            }
            
            
        }
        public static void Save()
        {
            ApplicationContext db = Context.Db;
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return;
            }
        }

    }

}
