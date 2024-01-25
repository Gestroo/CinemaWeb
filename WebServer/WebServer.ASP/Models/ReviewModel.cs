using CinemaLibrary.Entity;

namespace WebServer.ASP.Models
{
    public class ReviewModel
    {
        public int? Id { get; set; }
        public FilmModel Film { get; set; }
        public ClientModel Client { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public ReviewModel(Review r){
            this.Id = r.ID;
            this.Film = new FilmModel(r.Film);
            this.Client = new ClientModel(r.Client);
            this.Rating = r.Rating;
            this.Comment = r.Comment;
        }
        public ReviewModel() { }
    }
}
