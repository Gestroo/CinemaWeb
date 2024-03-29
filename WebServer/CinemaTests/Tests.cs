using CinemaLibrary;
using CinemaLibrary.Entity;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;
using WebServer.ASP.Services;

namespace CinemaTests
{
    public class Tests
    {
        private IReviewRepository _reviewRepository;
        private IClientRepository _clientRepository;
        private IGenreRepository _genreRepository;
        private IFilmRepository _filmRepository;


        [SetUp]
        public void Setup()
        {
            var keepAliveConnection = new SqliteConnection("DataSource=:memory:");
            keepAliveConnection.Open();
            var context = new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>().UseSqlite(keepAliveConnection).Options);
            context.Database.EnsureCreated();
            var film = new Film {
                ID = 1,
                Name = "Test",
                Genre = context.Genre.First(),
                Description="",
                Restriction=16,
                Duration=135,
                DateStart=DateTime.Now,
                DateFinish=DateTime.Now.AddDays(3),
            };
            context.Film.Add(film);
            var film2 = new Film
            {
                ID = 2,
                Name = "Test",
                Genre = context.Genre.First(),
                Description = "",
                Restriction = 16,
                Duration = 135,
                DateStart = DateTime.Now,
                DateFinish = DateTime.Now,
            };
            context.Film.Add(film2);
            var film3 = new Film
            {
                ID = 3,
                Name = "Test",
                Genre = context.Genre.First(),
                Description = "",
                Restriction = 16,
                Duration = 135,
                DateStart = DateTime.Now.AddDays(-15),
                DateFinish = DateTime.Now.AddDays(-3),
            };
            context.Film.Add(film3);
            var client = new Client
            {
                ID = 1,
                LastName = "�������",
                FirstName = "������",
                MiddleName = "��������",
                PhoneNumber = "88005553535",
                Password = "123",
                Email = "biliberda@mail.ru",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
            };
               context.Client.Add(client);
            context.SaveChanges();
            _reviewRepository = new ReviewService(context);
            _clientRepository = new ClientService(context);
            _genreRepository = new GenreService(context);
            _filmRepository = new FilmService(context);

        }

       
        [Test]
        public void AddReview_CorrectData_ReturnsReviewEntity()
        {
            Client client = _clientRepository.GetClientById(1);      
            ReviewModel model = new ReviewModel { Id = 999, Client = new ClientModel(client), Film = new FilmModel(_filmRepository.GetFilmById(1)), Rating = 5, Comment = "������������ ���������� ������" };
            var review = _reviewRepository.AddReview(model,client);

            Assert.NotNull(client);
            Assert.NotNull(review);
            Assert.IsAssignableFrom<Review>(review);
        }
        [Test]
        public void CreateClientModel_Null_ReturnNewModel()
        {
            Assert.Throws<NullReferenceException>(()=>new ClientModel(null));
        }
        [Test]
        public void GetFilms_ThreeFilms_ReturnTwoFilms()
        {
            var films = _filmRepository.GetFilms();
            Assert.That(2, Is.EqualTo(films.Count()));
        }

    }
}