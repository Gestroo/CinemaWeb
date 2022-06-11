using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CinemaLibrary.Entity
{
    public class Client : Human //Клиент
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public List<Booking> Bookings { get; set; }

        private static ApplicationContext db = Context.Db;
        public Client()
        {
            Bookings = new List<Booking>();
        }

        public Client(string LastName, string FirstName, string? MiddleName, string PhoneNumber, DateTime BirthDate)
            : base(LastName, FirstName, MiddleName, PhoneNumber)
        {
            this.BirthDate = BirthDate;
            Bookings = new List<Booking>();
        }
        public static Client FindClient(string lastName, string firstName, string middleName, string phoneNumber, DateTime birthDate)
        {
            return db.Client.Where(c => c.LastName == lastName && c.FirstName == firstName && c.MiddleName == middleName && c.PhoneNumber == phoneNumber && c.BirthDate == birthDate).FirstOrDefault();
        }
        public static Client FindClientByTicket(Seance seance, int row, int seat)
        {
            return db.Client.FirstOrDefault(c => c.Bookings.Any(r => r.Ticket == Ticket.FindTicket(seance, row, seat)));

        }
        public static bool Add(Client client)
        {
            try {
                db.Client.Add(client);
                db.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
        public override string GetFullName()
        {
            return "Клиент: " + base.GetFullName();
        }
        public static Client? GetClientAuth(string login, string pass)
        {
            return db.Client.FirstOrDefault(
                    c =>  c.Email == login && c.Password == pass);
        }
    }
}
