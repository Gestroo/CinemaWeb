using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Film //Фильм
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public int GenreID { get; set;}
        [Required]
        public int Restriction { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateFinish { get; set; }
        public string Poster { get; set; }

        public string ogranPlus { get { return $"{Restriction}+"; } }
         
        public static List<string> GetFilmName()
        {
            ApplicationContext db = Context.Db;
            return db.Film.Select(x => x.Name).ToList();
        }
        public static List<Film> GetFilms() {
            using var db = new ApplicationContext();
          return  db.Film.Include(f => f.Genre).ToList();
        }
        public static void Add(Film film)
        {
            ApplicationContext db = Context.Db;
            db.Film.Add(film);
            db.SaveChanges();
        }
        public static Film GetFilmByID(int id)
        {
            ApplicationContext db = Context.Db;
            return db.Film.Where(f => f.ID == id).Include(f=>f.Genre).FirstOrDefault();
        }
    }
}
