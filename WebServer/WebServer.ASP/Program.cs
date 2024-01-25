using CinemaLibrary;
using CinemaLibrary.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebServer.ASP;
using WebServer.ASP.Repositories;
using WebServer.ASP.Services;
using WebServer.ASP.Controllers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddCors(o=>o.AddDefaultPolicy(b=>b.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000").AllowCredentials()));

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(o => o.UseNpgsql(connection));

builder.Services.AddSignalR();

builder.Services.AddTransient<ISeanceRepository, SeanceService>();
builder.Services.AddTransient<IGenreRepository, GenreService>();
builder.Services.AddTransient<IAuthRepository, AuthService>();
builder.Services.AddTransient<IClientRepository, ClientService>();
builder.Services.AddTransient<IBookingRepository, BookingService>();
builder.Services.AddTransient<IFilmRepository, FilmService>();
builder.Services.AddTransient<IReviewRepository, ReviewService>();
builder.Services.AddTransient<ITicketRepository, TicketService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = Options.Issuer,
        ValidateAudience = true,
        ValidAudience = Options.Audience,
        ValidateLifetime = true,
        IssuerSigningKey = Options.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseWebSockets();
app.UseRouting();
app.UseAuthentication().UseAuthorization();
app.UseEndpoints(e=>e.MapControllers());

app.Run();