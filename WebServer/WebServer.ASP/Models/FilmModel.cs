using CinemaLibrary.Entity;

namespace WebServer.ASP.Models
{
    public class FilmModel
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public int Duration { get; set; }
        public GenreModel Genre { get; set; }
        public int Restriction { get; set; }
        public string Description { get; set; }
        public string? Poster { get; set; }
        public FilmModel(Film f) { 
            this.ID = f.ID;
            this.Name = f.Name;
            this.Duration = f.Duration;
            this.Genre = new GenreModel(f.Genre);
            this.Restriction = f.Restriction;
            this.Description = f.Description;
            this.Poster = f.Poster;
        }
        public FilmModel() { }
    }
}
