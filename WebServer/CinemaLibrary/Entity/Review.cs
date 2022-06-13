using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary.Entity
{
    public class Review
    {
        public int ID { get; set; }
        public Film Film { get; set; }
        public Client Client { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
