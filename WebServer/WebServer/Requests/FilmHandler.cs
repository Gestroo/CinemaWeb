﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using CinemaLibrary.Entity;
using Trivial.Security;
using WebServer.Models;

namespace WebServer.Requests
{
    [RequestHandlerPath("/films")]
    public class FilmHandler:RequestHandler
    {
        [Get("get")]
        public void GetFilms()
        {
            List<Film> rawfilms = Film.GetFilms();
            List<FilmModel> films = new List<FilmModel>();

            if (!rawfilms.Any())
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            foreach (var f in rawfilms)
            {
                FilmModel film = new FilmModel(f.ID,f.Name, f.Duration, f.GenreID, f.Restriction, f.Description, f.Poster) { Genre = f.Genre };
                
                films.Add(film);
            }
            
            Send(new AnswerModel(true, new { films = films }, null, null));
        }
        [Post("id")]
        public void GetFilmsByID()
        {
            var id = Bind<int>();
            var rawfilm= Film.GetFilmByID(id);
            if (rawfilm == null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            FilmModel film = new FilmModel(rawfilm.ID, rawfilm.Name, rawfilm.Duration, rawfilm.GenreID, rawfilm.Restriction, rawfilm.Description, rawfilm.Poster) { Genre = rawfilm.Genre };
            Send(new AnswerModel(true, new { film = film }, null, null));
        }
    }
}