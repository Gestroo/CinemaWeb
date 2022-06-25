using CinemaLibrary.Entity;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Requests
{
    [RequestHandlerPath("/tickets")]
    public class TicketHandler : RequestHandler
    {
        [Post("book")]
        [ResponseTimeout(10000)]
        public void BookTickets()
        {
            if (!Headers.TryGetValue("Access-Token", out var token) && !TokenWorker.CheckToken(token))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var client = TokenWorker.GetClientByToken(token);
            if (client is null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var body = Bind<TicketsModel>();
            if (body is null ||  body.Seat is null || body.Seance ==0)

            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }
            Seance seance = Seance.GetSeanceByID(body.Seance);
            List<HallSeat> seats = new List<HallSeat>();
            foreach (var s in body.Seat)
            {
                seats.Add(HallSeat.GetSeatByID(s.ID));
            }
            AddBookings(seance,seats,client);

           Send(new AnswerModel(true, null, null, null));
        }
        [Post("buy")]
        [ResponseTimeout(10000)]
        public void BuyTickets()
        {
            if (!Headers.TryGetValue("Access-Token", out var token) && !TokenWorker.CheckToken(token))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var client = TokenWorker.GetClientByToken(token);
            if (client is null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var body = Bind<TicketsModel>();
            if (body is null || body.Seat is null || body.Seance ==0)
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }


            Seance seance = Seance.GetSeanceByID(body.Seance);
            List<HallSeat> seats = new List<HallSeat>();
            foreach (var s in body.Seat)
            {
                seats.Add(HallSeat.GetSeatByID(s.ID));
            }
            var bookings = AddBookings(seance,seats,client);
            foreach (var b in bookings) {
                b.isBought = true;
                CommitMessage(b.Ticket, client);
            }
            foreach (var s in seats)
            {
                seance.BoughtSeats.Add(s);       
            }
            Booking.Save();
            
            Send(new AnswerModel(true, null, null, null));
        }


        public List<Booking> AddBookings(Seance seance,List<HallSeat> seats, Client client)
        {;
            List<Booking> bookings = new List<Booking>();
            foreach (var s in seats)
            {
                Ticket ticket = new Ticket()
                {
                    Seance = seance,
                    Row = HallRow.FindRowBySeatID(s.ID, seance.CinemaHall.HallNumber),
                    Seat = s,
                    TotalPrice = seance.Cost,
                    dateTime = DateParser.SetKindUtc(DateTime.Now),
                    Personal = Personal.GetCashier()
                };
                ticket.Add();
                Booking booking = new Booking()
                {
                    DateTime = DateParser.SetKindUtc(DateTime.Now),
                    Ticket = ticket,
                    isBought = false
                };
                seance.ReservedSeats.Add(s);
                booking.Add();

                bookings.Add(booking);
            }
            client.Bookings.AddRange(bookings);
            Booking.Save();
            return bookings;
        }

        public static void CommitMessage(Ticket ticket,Client client)
        {
            var from = new MailAddress("cinema-vyatsu@mail.ru", "Кинотеатр Премьер");
            var to = new MailAddress(client.Email, "Пользователь");

            var msg2 = new MailMessage(from, to);
            msg2.Subject = "Билет в кинотеатр Премьер";
            msg2.Body = FillTable(ticket,client);
            msg2.IsBodyHtml = true;
            using (var smtp = new SmtpClient("smtp.mail.ru", 587))
            {
                smtp.Credentials = new NetworkCredential("cinema-vyatsu@mail.ru", "zRqvkv9A579XiSNgNsKF");
                smtp.EnableSsl = true;
                smtp.Send(msg2);
            }
        }
        public static string FillTable(Ticket ticket,Client client) {
            var s = new StringBuilder("<h2 style = \"text-align:center;\"> Уважаемый(-ая) " + client.FirstName + " " + client.MiddleName + "! Благодарим вас за то,что выбрали наш кинотеатр.</h2>" + Environment.NewLine);
            s.Append("<div style = \"border:3px solid black;width:25%;margin:auto\">" + Environment.NewLine);
            s.Append("<h3 style = \"text-align:center; \">"+ticket.Seance.Film.Name+","+ticket.Seance.Date+","+ ticket.Seance.Time +","+ticket.Seance.Film.Restriction+"+" +"</h3> " + Environment.NewLine);
            s.Append("<h2 style = \"text-align:center;\" >" + ticket.Seance.CinemaHall.HallName + "</h2>");
            s.Append("<h2 style = \"text-align:center; \">" + "Ряд " + ticket.Row.RowNumber + "</ h2 >");
            s.Append("<h2 style = \"text-align:center; \">" + "Место " + ticket.Seat.SeatNumber + "</ h2 >");
            s.Append("<h2 style = \"text-align:center; \">" + client.LastName+" "+client.FirstName+" "+client.MiddleName + "</ h2 >");
            return s.ToString();
        }
    }
    
}
