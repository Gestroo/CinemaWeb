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
    [RequestHandlerPath("/reviews")]
    public class ReviewHandler : RequestHandler
    {
        [Post("add")]
        public void AddReview()
        {
            var body = Bind<ReviewModel>();
            if (body is null || body.Client is null || body.Film is null || body.Rating == 0|| string.IsNullOrEmpty(body.Comment))
      
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }
            Review review;
            if (Review.CheckReview(body.Film.ID, body.Client.phone) is null)
            {
                var film = Film.GetFilmByID(body.Film.ID);
                var client = Client.FindClientByPhoneNumber(body.Client.phone);
                 review = new Review()
                {
                     Film = film,
                    Client = client,
                    Rating = body.Rating,
                    Comment = body.Comment,
                };
                Review.Add(review);
            }
            else {
                review = Review.CheckReview(body.Film.ID, body.Client.phone);
                review.Rating = body.Rating;
                review.Comment = body.Comment;
                review.Update();
            }
                

            Send(new AnswerModel(true, null, null, null));
        }

        [Get("get")]
        public void GetReviews()
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
            List<Review> rawreviews = Review.GetReviews(client.ID);


            if (!rawreviews.Any())
            {
                Send(new AnswerModel(false, null, 401, "incorrect request body"));
                return;
            }
            List<ReviewModel> reviews = new List<ReviewModel>();
            foreach (var r in rawreviews)
            {
                ReviewModel review = new ReviewModel(r) { };

                reviews.Add(review);
            }

            Send(new AnswerModel(true, new { reviews = reviews }, null, null));
        }
    }
}
