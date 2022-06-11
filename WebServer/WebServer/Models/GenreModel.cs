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

        public GenreModel(int id,string title) { 
            this.ID = id;
            this.Title = title;
        }

    }
}
