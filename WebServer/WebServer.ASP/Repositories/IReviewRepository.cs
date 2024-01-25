using CinemaLibrary.Entity;
using WebServer.ASP.Models;

namespace WebServer.ASP.Repositories;

public interface IReviewRepository
{
    IQueryable<Review> GetReviews(Client client);
    Review AddReview(ReviewModel model,Client client);
}