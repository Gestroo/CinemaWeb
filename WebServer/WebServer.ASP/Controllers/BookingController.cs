using CinemaLibrary.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Controllers;

[ApiController]
[Route("bookings")]
[Authorize]
public class BookingController : ControllerBase
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IClientRepository _clientRepository;

    public BookingController(IBookingRepository bookingRepository, IClientRepository clientRepository)
    {
        _bookingRepository = bookingRepository;
        _clientRepository = clientRepository;
    }

    private Client? GetClientInRequest()
    {
        var id = HttpContext.User.FindFirst("user");
        return id is null ? null : _clientRepository.GetClientById(Convert.ToInt32(id.Value));
    }

    [HttpGet("get")]
    public IActionResult GetBookings()
    {
        var client = GetClientInRequest();
        if (client is null) return BadRequest("token is incorrect");
        return Ok(_bookingRepository.GetBookings(client).Select(b => new BookingModel(b, client)));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetBookingById(int id)
    {
        var client = GetClientInRequest();
        if (client is null) return BadRequest("token is incorrect");
        var booking = _bookingRepository.GetBookingById(id);
        if (booking is null) return NotFound();
        return Ok(new BookingModel(booking,client));
    }

    [HttpGet("filter")]
    public IActionResult FilterBookings([FromQuery]int sort)
    {
        var client = GetClientInRequest();

        var tmp = _bookingRepository.GetBookings(client);
        tmp = sort switch
        {
            1 => tmp.OrderByDescending(b => b.DateTime).ToList(),
            2 => tmp.OrderBy(b => b.Ticket.Seance.Film.Name).ToList(),
            3 => tmp.OrderBy(b => b.Ticket.Seance.Film.Duration).ToList(),
            _ => tmp
        };

        return Ok(tmp.Select(b => new BookingModel(b, client)));
    }
}
