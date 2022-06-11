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
        [Get("filmId")]
        public void GetSeancesByFilmID()
        {
            if (!Params.TryGetValue("id", out var id)) {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var rawseance = Seance.GetSeancesByFilm(int.Parse(id));
            
            if (rawseance == null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            List<SeanceModel> seances = new List<SeanceModel>();
            foreach (var s in rawseance)
            {
                SeanceModel seance = new SeanceModel(s.ID, new HallModel(s.CinemaHall.HallNumber,s.CinemaHall.HallName,new List<RowModel>()), new FilmModel(s.Film.ID,s.Film.Name,s.Film.Duration,new GenreModel(s.Film.Genre.ID,s.Film.Genre.Title),s.Film.Restriction,s.Film.Description,s.Film.Poster), s.SeanceDate.ToString("d"),s.SeanceDate.ToString("t"),s.Cost) { };
                seances.Add(seance);
            }
                
            Send(new AnswerModel(true, new { seances = seances }, null, null));
        }
        [Get("id")]
        public void GetSeancesByID()
        {
            if (!Params.TryGetValue("id", out var id))
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            var s = Seance.GetSeanceByID(int.Parse(id));

            if (s == null)
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }


            SeanceModel seance = new SeanceModel(s.ID, new HallModel(s.CinemaHall.HallNumber, s.CinemaHall.HallName, new List<RowModel>()), new FilmModel(s.Film.ID, s.Film.Name, s.Film.Duration, new GenreModel(s.Film.Genre.ID, s.Film.Genre.Title), s.Film.Restriction, s.Film.Description, s.Film.Poster), s.SeanceDate.ToString("d"), s.SeanceDate.ToString("t"), s.Cost) { };
            foreach (var r in s.CinemaHall.Rows)
            {
                var kakta = new RowModel(r.ID, r.RowNumber, new List<SeatModel>());
                foreach (var seat in r.Seats.OrderBy(s=>s.SeatNumber))
                {
                    kakta.Seats.Add(new SeatModel(seat, s));

                }
                seance.CinemaHall.Rows.Add(kakta);
            }

            Send(new AnswerModel(true, new { seance = seance }, null, null));
        }
    }
}
