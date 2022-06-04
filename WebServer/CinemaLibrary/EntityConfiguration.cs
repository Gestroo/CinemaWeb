using CinemaLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace CinemaLibrary
{
    public static class EntityConfiguration
    {
        public static void PersonalConfigure(EntityTypeBuilder<Personal> builder)
        {
            builder.ToTable("personal");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.Login).HasColumnName("login");
            builder.Property(p => p.Password).HasColumnName("password");
            builder.Property(p => p.RoleID).HasColumnName("role_id");
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50).HasColumnName("lastname");
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50).HasColumnName("firstname");
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15).HasColumnName("phonenumber");
            builder.Property(e => e.MiddleName).HasMaxLength(50).HasColumnName("middlename");
            builder.HasIndex(e => e.PhoneNumber);
        }
        public static void BookingConfigure(EntityTypeBuilder<Booking> builder) {
            builder.ToTable("booking");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.DateTime).HasColumnName("datetime");
            builder.Property(p => p.ClientID).HasColumnName("client_id");
        }
        public static void CinemaHallConfigure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.ToTable("cinemahall");
            builder.Property(p => p.HallNumber).HasColumnName("hallnumber");
            builder.Property(p => p.HallName).HasColumnName("hallname");
        }
        public static void FilmConfigure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("film");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.Name).HasColumnName("title");
            builder.Property(p => p.Duration).HasColumnName("duration");
            builder.Property(p => p.Restriction).HasColumnName("restriction");
            builder.Property(p => p.Description).HasColumnName("description");
            builder.Property(p => p.DateStart).HasColumnName("datestart");
            builder.Property(p => p.DateFinish).HasColumnName("datefinish");
            builder.Property(p => p.GenreID).HasColumnName("genre_id");
            builder.Property(p => p.Poster).HasColumnName("poster");

        }
        public static void GenreConfigure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.Title).HasColumnName("title");
            builder.Property(p => p.Description).HasColumnName("description");
        }
        public static void HallRowConfigure(EntityTypeBuilder<HallRow> builder)
        {
            builder.ToTable("hallrow");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.CinemaHallID).HasColumnName("cinemahall_id");
            builder.Property(p => p.RowNumber).HasColumnName("row_number");
        }
        public static void HallSeatConfigure(EntityTypeBuilder<HallSeat> builder)
        {
            builder.ToTable("hallseat");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.HallRowID).HasColumnName("hallrow_id");
            builder.Property(p => p.SeatNumber).HasColumnName("seat_number");
        }
        public static void RoleConfigure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.PersonalRole).HasColumnName("personal_role");
        }
        public static void SeanceConfigure(EntityTypeBuilder<Seance> builder)
        {
            builder.ToTable("seance");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.CinemaHallID).HasColumnName("cinemahall_id");
            builder.Property(p => p.FilmID).HasColumnName("film_id");
            builder.Property(p => p.SeanceDate).HasColumnName("seancedate");
        }
        public static void TicketConfigure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("ticket");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.RowID).HasColumnName("row_id");
            builder.Property(p => p.SeatID).HasColumnName("seat_id");
            builder.Property(p => p.SeanceID).HasColumnName("seance_id");
            builder.Property(p => p.PersonalID).HasColumnName("personal_id");
            builder.Property(p => p.TotalPrice).HasColumnName("total_price");
        }
        public static void ClientConfigure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");
            builder.Property(p => p.BirthDate).HasColumnName("birthdate");
            builder.Property(p => p.ID).HasColumnName("id");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.Password).HasColumnName("password");
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50).HasColumnName("lastname");
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50).HasColumnName("firstname");
            builder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15).HasColumnName("phonenumber");
            builder.Property(e => e.MiddleName).HasMaxLength(50).HasColumnName("middlename");
            builder.HasIndex(e => e.PhoneNumber);
        }


        public static void RoleDataConfigure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                ID = 1,
                PersonalRole = "admin"
            },
                new Role
                {
                    ID = 2,
                    PersonalRole = "cashier"
                }
                );
        }

        public static void PersonalDataConfigure(EntityTypeBuilder<Personal> builder)
        {
            builder.HasData(new Personal
            (
                 "Широков",
               "Дмитрий",
                "Романович",
                "+79513538360"
            )
            {
                ID = 1,
                Login = "admin",
                Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                RoleID = 1
            },
             new Personal
             (
                  "Ромашкова",
                  "Зинаида",
                "Григорьевна",
                 "+79229334455"
                 )
             {
                 ID = 2,
                 Login = "cashier1",
                 Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",

                 RoleID = 2
             }
             ) ;
        }
        public static void GenreDataConfigure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(

                    new Genre
                    {
                        ID = 1,
                        Title = "Боевик"
                    },
                    new Genre
                    {
                        ID = 2,
                        Title = "Ужасы"
                    },
                    new Genre
                    {
                        ID = 3,
                        Title = "Мультфильм"
                    },
                    new Genre
                    {
                        ID = 4,
                        Title = "Комедия"
                    },
                    new Genre
                    {
                        ID = 5,
                        Title = "Фантастика"
                    },
                    new Genre
                    {
                        ID = 6,
                        Title = "Фэнтези"
                    },
                    new Genre
                    {
                        ID = 7,
                        Title = "Драма"
                    },
                    new Genre
                    {
                        ID = 8,
                        Title = "Мелодрама"
                    },
                    new Genre
                    {
                        ID = 9,
                        Title = "Вестерн"
                    },
                    new Genre
                    {
                        ID = 10,
                        Title = "Аниме"
                    },
                    new Genre
                    {
                        ID = 11,
                        Title = "Триллер"
                    }
                );
        }

       
        public static void HallDataConfigure(EntityTypeBuilder<CinemaHall> builder)
        {
            builder.HasData(new CinemaHall
            {
                HallNumber = 1,
                HallName = "Зал 1",
            },
                new CinemaHall
                {
                    HallNumber = 2,
                    HallName = "Зал 2",
                },
                new CinemaHall
                {
                    HallNumber = 3,
                    HallName = "Зал 3",
                },
                new CinemaHall
                {
                    HallNumber = 4,
                    HallName = "Зал 4",
                },
                new CinemaHall
                {
                    HallNumber = 5,
                    HallName = "Зал 5",
                }
                );
        }
        static List<HallRow> rows;
        public static void RowsDataConfigure(EntityTypeBuilder<HallRow> builder)
        {
            rows = new List<HallRow>();//Добавление рядов
            for (int i = 1; i < 7; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i, CinemaHallID = 1 });
            for (int i = 7; i < 13; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i - 6, CinemaHallID = 2 });
            for (int i = 13; i < 19; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i - 12, CinemaHallID = 3 });
            for (int i = 19; i < 25; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i - 18, CinemaHallID = 4 });
            for (int i = 25; i < 31; i++)
                rows.Add(new HallRow { ID = i, RowNumber = i - 24, CinemaHallID = 5 });
            builder.HasData(rows);
        }
        public static void SeatsDataConfigure(EntityTypeBuilder<HallSeat> builder)
        {
            var seats = new List<HallSeat>();
            int count = 1;
            for (int i = 0; i < 6; i++)//заполнение мест для первого зала
                for (int j = 1; j < 11; j++)
                {
                    seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                    count++;
                }
            for (int i = 6; i < 12; i++)//для второго зала
                if (i % 2 == 0)
                    for (int j = 1; j < 9; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
                else
                    for (int j = 1; j < 11; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
            for (int i = 12; i < 18; i++)//для третьего зала
                if (i % 2 == 0)
                    for (int j = 1; j < 10; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
                else
                    for (int j = 1; j < 11; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
            for (int i = 18; i < 24; i++)//для четвертого зала
                if (i % 2 == 0)
                    for (int j = 1; j < 11; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
                else
                    for (int j = 1; j < 10; j++)
                    {
                        seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                        count++;
                    }
            for (int i = 24; i < 30; i++)// для пятого зала
                for (int j = 1; j < 11; j++)
                {
                    seats.Add(new HallSeat { ID = count, SeatNumber = j, HallRowID = rows[i].ID });
                    count++;
                }
            builder.HasData(seats);
        }
    }

}

