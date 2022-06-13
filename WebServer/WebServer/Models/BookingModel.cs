using CinemaLibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class BookingModel
    {
        public int ID { get; set; }
        public string DateTime { get; set; }
        public TicketModel Ticket { get; set; }
        public ClientModel Client { get; set; }
        public bool IsBought { get; set; }

        public BookingModel(Booking b,Client client) {
            this.ID = b.ID;
            this.DateTime = b.DateTime.ToString();
            this.Ticket = new TicketModel(b.Ticket);
            this.Client = new ClientModel(client);
            this.IsBought = b.isBought;
        }
        
    }
}
