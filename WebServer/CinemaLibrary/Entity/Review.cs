using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CinemaLibrary.Entity
{
    public class Review
    {
        public int ID { get; set; }
        public Film Film { get; set; }
        public Client Client { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime dateTime { get; set; }
        
        public static Review? CheckReview(int filmId,string phone) {
            ApplicationContext db = Context.Db;
            try
            {
                return db.Review.Include(r => r.Film).ThenInclude(f => f.Genre).Include(r => r.Client).FirstOrDefault(r => r.Film.ID == filmId && r.Client.PhoneNumber == phone);
            }
            catch 
            {
            return null;
            }
        }
        public static List<Review> GetReviews(int id) {
            ApplicationContext db = Context.Db;
            try
            {
                return db.Review.Include(r => r.Film).ThenInclude(f => f.Genre).Include(r => r.Client).ThenInclude(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.Film).ThenInclude(f => f.Genre).Include(r => r.Client).ThenInclude(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Row).Include(r => r.Client).ThenInclude(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seat).Include(r => r.Client).ThenInclude(c => c.Bookings).ThenInclude(b => b.Ticket).ThenInclude(t => t.Seance).ThenInclude(s => s.CinemaHall).Where(r => r.Client.ID == id).ToList();
            }
            catch { 
            return null;
            }
        }
        public static void Add(Review review)
        {
            ApplicationContext db = Context.Db;
            try
            {
                db.Review.Add(review);
                db.SaveChanges();
            }
            catch {
                return;
            }
        }
        public bool Update()
        {
            ApplicationContext db = Context.Db;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
 
}
