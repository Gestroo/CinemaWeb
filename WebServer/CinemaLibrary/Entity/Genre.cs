using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Genre //Жанр
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        private static ApplicationContext db = Context.Db;
        public static List<string> GetGenresTitle()
        {
            ApplicationContext db = Context.Db;
            return db.Genre.Select(g => g.Title).ToList();
        }
        public static List<Genre> GetGenres() {
            using var db = new ApplicationContext();
            try
            {
                return db.Genre.OrderBy(g => g.Title).ToList();
            }
            catch { 
            return null;
            }
        }
        public static Genre GetGenreByTitle(string title)
        {
            ApplicationContext db = Context.Db;
            try
            {
                return db.Genre.Where(g => g.Title == title).FirstOrDefault();
            }
            catch {
                return null;
            }
        }
        public static Genre GetGenreById(int id)
        {
            ApplicationContext db = Context.Db;
            var genre =  db.Genre.FirstOrDefault(g => g.ID == id);
            return genre;
        }
    }
}

