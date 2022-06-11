using System;
using System.Collections.Generic;

namespace CinemaLibrary.Entity
{
    public class Booking
    {
        public int ID { get; set; }
        public Client Client { get; set; }
        public DateTime DateTime { get; set; }
        public Ticket Ticket { get; set; }
        public bool isBought { get; set; }
        public int ClientID { get; set; }
        private static ApplicationContext db = Context.Db;

        public Booking() { }

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
