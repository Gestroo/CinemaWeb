using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class CinemaHall //Кинозал
    {
        [Key]
        public int HallNumber { get; set; }
        public string HallName { get; set; }
        public List<HallRow> Rows { get; set; }

        private static ApplicationContext db = Context.Db;


        public CinemaHall()
        {

            Rows = new List<HallRow>();
        }

        public static List<CinemaHall> GetHalls()
        {
            ApplicationContext db = Context.Db; 
            try
            {
                return db.CinemaHall.ToList();
            }
            catch
            {
                return null;
            }
            
        }
    }
}
