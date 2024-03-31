using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;

namespace CinemaLibrary
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base(GetDb())
        {
           // Database.Migrate();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
          //  Database.Migrate();
          //  Context.AddDb(this);
        }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<CinemaHall> CinemaHall { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<HallRow> HallRow { get; set; }
        public DbSet<HallSeat> HallSeat { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Seance> Seance { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Training> Training { get; set; }

        readonly static StreamWriter stream = new StreamWriter("log.txt", true);
        public static DbContextOptions<ApplicationContext> GetDb()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>().UseNpgsql("Host=localhost;Port=5432;Database=cinema;Username=Gestroo;Password=123");
           // var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>().UseNpgsql("Host=45.10.244.15;Port=55532;Database=work100027;Username=work100027;Password=jGG*CL|1k9Xk04qjR%du");
            optionsBuilder.LogTo(stream.WriteLine);
            return optionsBuilder.Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Human>();
            modelBuilder.Entity<Seance>().Ignore(s => s.Date).Ignore(s=>s.Time);
            modelBuilder.Entity<Seance>().HasMany(s => s.BoughtSeats).WithMany(bs => bs.BoughtSeances).UsingEntity(j => j.ToTable("SeanceBoughtSeats"));
            modelBuilder.Entity<Seance>().HasMany(s => s.ReservedSeats).WithMany(rs => rs.ReservedSeances).UsingEntity(j => j.ToTable("SeanceReservedSeats"));
            modelBuilder.Entity<Booking>(EntityConfiguration.BookingConfigure);
            modelBuilder.Entity<CinemaHall>(EntityConfiguration.CinemaHallConfigure);
            modelBuilder.Entity<Film>(EntityConfiguration.FilmConfigure);
            modelBuilder.Entity<Genre>(EntityConfiguration.GenreConfigure);
            modelBuilder.Entity<Role>(EntityConfiguration.RoleConfigure);
            modelBuilder.Entity<HallRow>(EntityConfiguration.HallRowConfigure);
            modelBuilder.Entity<HallSeat>(EntityConfiguration.HallSeatConfigure);
            modelBuilder.Entity<Personal>(EntityConfiguration.PersonalConfigure);
            modelBuilder.Entity<Seance>(EntityConfiguration.SeanceConfigure);
            modelBuilder.Entity<Ticket>(EntityConfiguration.TicketConfigure);
            modelBuilder.Entity<Role>(EntityConfiguration.RoleDataConfigure);
            modelBuilder.Entity<Personal>(EntityConfiguration.PersonalDataConfigure);
            modelBuilder.Entity<Client>(EntityConfiguration.ClientConfigure);
            modelBuilder.Entity<Genre>(EntityConfiguration.GenreDataConfigure);
            modelBuilder.Entity<CinemaHall>(EntityConfiguration.HallDataConfigure);
            modelBuilder.Entity<HallRow>(EntityConfiguration.RowsDataConfigure);
            modelBuilder.Entity<HallSeat>(EntityConfiguration.SeatsDataConfigure);
            modelBuilder.Entity<Training>(EntityConfiguration.TrainingConfigure);
        }
    }
}
