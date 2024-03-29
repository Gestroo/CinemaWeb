﻿using CinemaLibrary.Entity;
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
    [RequestHandlerPath("/bookings")]
    public class BookingHandler:RequestHandler
    {
        List<BookingModel> filterBookings = new List<BookingModel>();
        [Get("get")]
        public void GetBookings()
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
               BookingModel booking = new BookingModel(b,client) { };

                bookings.Add(booking);
            }
            filterBookings = bookings;
            Send(new AnswerModel(true, new { bookings = bookings }, null, null));
        }
        [Get("filter")]
        public void FilterBookings()
        {
            if (!filterBookings.Any())
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            List<BookingModel> tmp = filterBookings;
            if (Params.TryGetValue("option", out var sort) && sort != "")
            {
                if (Convert.ToInt32(sort) == 1)
                {
                    tmp = tmp.OrderByDescending(b => b.DateTime).ToList();
                }
                if (Convert.ToInt32(sort) == 2)
                {
                    
                }
                if (Convert.ToInt32(sort) == 3)
                {
                   
                }

            }

           

            Send(new AnswerModel(true, new { bookings = tmp }, null, null));
        }
        [Get("id")]
        public void GetBookingByID()
        {
            if (!Params.TryGetValue("id", out var id))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
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
            var b = Booking.GetBookingByID(int.Parse(id));

            if (b == null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            BookingModel booking = new BookingModel(b,client) { };
            Send(new AnswerModel(true, new { booking = booking }, null, null));
        }
    }
}
