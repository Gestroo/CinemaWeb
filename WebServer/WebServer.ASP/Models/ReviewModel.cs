using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class ReviewModel
    {
        public int ID { get; set; }
        public FilmModel Film { get; set; }
        public ClientModel Client { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public ReviewModel(Review r){
            this.ID = r.ID;
            this.Film = new FilmModel(r.Film);
            this.Client = new ClientModel(r.Client);
            this.Rating = r.Rating;
            this.Comment = r.Comment;
        }
        public ReviewModel() { }
    }
}
