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

        private static ApplicationContext db = Context.Db;
        public static List<string> GetFilmName()
        {
            return db.Film.Select(x => x.Name).ToList();
        }
        public static List<Film> GetFilms() => db.Film.Include(f=>f.Genre).ToList(); //лямбда-выражение заменяет return

        public static void Add(Film film)
        {
            db.Film.Add(film);
            db.SaveChanges();
        }
        public static Film GetFilmByID(int id)
        {
            using var db=new ApplicationContext();
            return db.Film.Where(f => f.ID == id).Include(f=>f.Genre).FirstOrDefault();
        }
    }
}
