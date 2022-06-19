using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using CinemaLibrary.Entity;
using Trivial.Security;
using WebServer.Models;
using System.Web;

namespace WebServer.Requests
{
    [RequestHandlerPath("/films")]
    public class FilmHandler:RequestHandler
    {
        List<FilmModel> filterFilms = new List<FilmModel>();
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
                FilmModel film = new FilmModel(f) { };
                
                films.Add(film);
            }
            filterFilms = films;
            Send(new AnswerModel(true, new { films = films }, null, null));
        }
        [Get("filter")]
        public void FilterFilms()
        {
            if (!filterFilms.Any())
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            List<FilmModel> tmp = filterFilms;
            if (Params.TryGetValue("option", out var sort) && sort != "")
            {
                if (Convert.ToInt32(sort) == 1)
                {
                }
                if (Convert.ToInt32(sort) == 2)
                {
                    tmp = tmp.OrderBy(f => f.Name).ToList();
                }
                if (Convert.ToInt32(sort) == 3)
                {
                    tmp = tmp.OrderBy(f => f.Duration).ToList();
                }

            }

            if (Params.TryGetValue("genre", out var genre) && genre != "")
            {
                tmp = tmp.Where(r => r.Genre.Title == HttpUtility.UrlDecode(genre)).ToList();
            }

            if (Params.TryGetValue("title", out var search) && search != "")
            {
                tmp = tmp.Where(r => r.Name.ToLower().Contains(HttpUtility.UrlDecode(search).ToLower())).ToList();
            }

            if (Params.TryGetValue("restriction", out var restriction))
            {
                tmp = tmp.Where(r => r.Restriction <= Convert.ToInt32(restriction)).ToList();
            }
            if (Params.TryGetValue("minDuration", out var min) && Params.TryGetValue("maxDuration", out var max)) 
            {
                tmp = tmp.Where(r => r.Duration <= Convert.ToInt32(max)&& r.Duration >= Convert.ToInt32(min)).ToList();
            }

            Send(new AnswerModel(true, new { films = tmp }, null, null));
        }
        [Get("id")]
        public void GetFilmsByID()
        {
            var id = GetParams<int>("id");
            if (id == null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var rawfilm= Film.GetFilmByID(id);
            if (rawfilm == null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            FilmModel film = new FilmModel(rawfilm) {};
            Send(new AnswerModel(true, new { film = film }, null, null));
        }
    }
}
