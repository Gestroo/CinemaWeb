using CinemaLibrary.Entity;
using WebServer.ASP.Models;

namespace WebServer.ASP.Repositories;

public interface IReviewRepository
{
    IEnumerable<Review> GetReviews(Client client);
    Review AddReview(ReviewModel model,Client client);
}