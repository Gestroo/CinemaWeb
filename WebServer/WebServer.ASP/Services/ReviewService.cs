using CinemaLibrary;
using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Services;

public class ReviewService : IReviewRepository
{
    private ApplicationContext _context;

    public ReviewService(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<Review> GetReviews(Client client)
    {
        return _context.Review.Where(r => r.Client.ID == client.ID).Include(r=>r.Film).ThenInclude(f=>f.Genre);
    }

    public Review AddReview(ReviewModel model, Client client)
    {
        var film = _context.Film.FirstOrDefault(f => f.ID == model.Film.ID);
        if (film is null) throw new Exception("Film not found");
        _context.Genre.Where(f => f.ID == film.GenreID).Load();
        var review = new Review { Film = film, Client = client, Rating = model.Rating, Comment = model.Comment };
        var newReview = _context.Review.Add(review);
        var count = _context.Review.Where(r => r.Film.ID == film.ID).Count();
        film.Rating = (film.Rating == 0) ?  model.Rating : (film.Rating + (review.Rating / count)) / (count + 1) * count; //Перерасчет рейтинга фильма
        _context.SaveChanges();
        return newReview.Entity;
    }
}