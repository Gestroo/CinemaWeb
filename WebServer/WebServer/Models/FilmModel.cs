using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class FilmModel
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public int Duration { get; set; }
        public GenreModel Genre { get; set; }
        public int Restriction { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public FilmModel(int id, string Name, int duration, GenreModel genre, int restriction,string description,string poster) { 
            this.ID = id;
            this.Name = Name;
            this.Duration = duration;
            this.Genre = genre;
            this.Restriction = restriction; 
            this.Description = description;
            this.Poster = poster;
        }
    }
}
