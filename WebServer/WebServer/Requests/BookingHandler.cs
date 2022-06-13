using CinemaLibrary.Entity;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Requests
{
    [RequestHandlerPath("/films")]
    public class BookingHandler:RequestHandler
    {
        [Get("get")]
        public void GetFilms()
        {
            if (!Headers.TryGetValue("Access-Token", out var token) && !TokenWorker.CheckToken(token)) {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var client = TokenWorker.GetClientByToken(token);
            if (client is null) {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            List<Booking> rawbookings = Booking.GetBookings(client.ID);
            

            if (!rawbookings.Any())
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            List<BookingModel> bookings = new List<BookingModel>();
            foreach (var b in rawbookings)
            {
           //    BookingModel booking = new BookingModel(b.ID,b.DateTime.ToString(),new TicketModel(b.Ticket.ID,) ,client,b.isBought) { };

             //   bookings.Add(booking);
            }

           // Send(new AnswerModel(true, new { films = films }, null, null));
        }
    }
}
