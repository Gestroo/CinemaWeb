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

namespace WebServer.Requests
{
    [RequestHandlerPath("/seances")]
    public class SeanceHandler : RequestHandler
    {
       // [Get("get")]
        //public void GetSeances()
        //{
        //    List<Film> rawfilms = Seance.GetSeance();
        //    List<FilmModel> films = new List<FilmModel>();

        //    if (!rawfilms.Any())
        //    {
        //        Send(new AnswerModel(false, null, 401, "incorrect request body"));
        //        return;
        //    }
        //    foreach (var f in rawfilms)
        //    {
        //        FilmModel film = new FilmModel(f.ID, f.Name, f.Duration, f.GenreID, f.Restriction, f.Description, f.Poster) { Genre = f.Genre };

        //        films.Add(film);
        //    }

        //    Send(new AnswerModel(true, new { films = films }, null, null));
        //}
        [Post("id")]
        public void GetSeancesByID()
        {
            var id = Bind<int>();
            var rawseance = Seance.GetSeancesByFilm(id);
            List<SeanceModel> seances = new List<SeanceModel>();
            if (rawseance == null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            foreach (var s in rawseance)
            {
                SeanceModel seance = new SeanceModel(s.ID, s.CinemaHall, s.Film, s.SeanceDate, s.BoughtSeats, s.ReservedSeats) { };
                seances.Add(seance);
            }
                
            Send(new AnswerModel(true, new { seances = seances }, null, null));
        }
    }
}
