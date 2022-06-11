using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using Trivial.Security;
using CinemaLibrary.Entity;
using WebServer.Models;



namespace WebServer.Requests
{
    [RequestHandlerPath("/genres")]
    public class GenreHandler : RequestHandler
    {
        [Get("get")]
        public void GetGenres()
        {
            List<Genre> rawgenres = Genre.GetGenres();
            

            if (!rawgenres.Any())
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            List<GenreModel> genres = new List<GenreModel>();
            foreach (var g in rawgenres)
            {
                GenreModel genre = new GenreModel(g.ID,g.Title);
                genres.Add(genre);
            }

            Send(new AnswerModel(true, new { genres = genres }, null, null));
        }
    }
}
