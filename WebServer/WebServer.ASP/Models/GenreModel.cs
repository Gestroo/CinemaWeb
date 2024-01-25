using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
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
