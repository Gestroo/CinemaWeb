using CinemaLibrary.Entity;

namespace WebServer.ASP.Models
{
    public class GenreModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public GenreModel(Genre g) { 
            this.ID = g.ID;
            this.Title = g.Title;
        }
        public GenreModel() { }
    }
}
