using System.Net;
using System.Net.Mail;
using System.Text;
using CinemaLibrary.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Controllers;
[ApiController]
[Route("tickets")]
[Authorize]
public class TicketController: ControllerBase
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IClientRepository _clientRepository;

    public TicketController(ITicketRepository ticketRepository, IClientRepository clientRepository)
    {
        _ticketRepository = ticketRepository;
        _clientRepository = clientRepository;
    }
    private Client? GetClientInRequest()
    {
        var id = HttpContext.User.FindFirst("user");
        return id is null ? null : _clientRepository.GetClientById(Convert.ToInt32(id.Value));
    }
    [HttpPost("book")]
    public IActionResult BookTicket(TicketsModel model)
    {
        var client = GetClientInRequest();
        if (client is null) return BadRequest("token is incorrect");
        try
        {
            var bookings = _ticketRepository.BookTicket(model, client);
            if (!bookings.Any()) return BadRequest();
             return Ok(bookings.Select(b => new BookingModel(b, client)));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpPost("buy")]
    public IActionResult BuyTicket(TicketsModel model)
    {
        var client = GetClientInRequest();
        if (client is null) return BadRequest("token is incorrect");
        try
        {
            var bookings = _ticketRepository.BuyTicket(model, client).ToList();
            if (!bookings.Any()) return BadRequest();
            foreach (var b in bookings)
            {
                CommitMessage(b.Ticket,client);
            }
            return Ok(bookings.Select(b=>new BookingModel(b,client)));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
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
            smtp.Credentials = new NetworkCredential("cinema-vyatsu@mail.ru", "YMUtzMmhWV0WnPUYUeZZ");
            smtp.EnableSsl = true;
            smtp.Send(msg2);
        }
    }
    public static string FillTable(Ticket ticket,Client client) {
        var s = new StringBuilder("<h2 style = \"text-align:center;\"> Уважаемый(-ая) " + client.FirstName + " " + client.MiddleName + "! Благодарим вас за то,что выбрали наш кинотеатр.</h2>" + Environment.NewLine);
        s.Append("<div style = \"border:3px solid black;width:25%;margin:auto\">" + Environment.NewLine);
        s.Append("<h3 style = \"text-align:center; \">"+ticket.Seance.Film.Name+","+ticket.Seance.Date+","+ ticket.Seance.Time +","+ticket.Seance.Film.Restriction+"+" +"</h3> " + Environment.NewLine);
        s.Append("<h2 style = \"text-align:center;\" >" + ticket.Seance.CinemaHall.HallName + "</h2>");
        s.Append("<h2 style = \"text-align:center; \">" + "Ряд " + ticket.Row.RowNumber + "</h2>");
        s.Append("<h2 style = \"text-align:center; \">" + "Место " + ticket.Seat.SeatNumber + "</h2>");
        s.Append("<h2 style = \"text-align:center; \">" + client.LastName+" "+client.FirstName+" "+client.MiddleName + "</h2>");
        return s.ToString();
    }
}