using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaLibrary.Entity
{
    public class RefreshToken
    {
        [Key]
        public string Token { get; set; }
        public Client Client { get; set; }
        private static ApplicationContext db = Context.Db;

        internal RefreshToken()
        {
            Token = "";
            Client = new Client();
        }

        private RefreshToken(string token, Client client)
        {
            Token = token;
            Client = client;
        }

        public static bool AddToken(string token, Client client)
        {
            var jwtToken = new RefreshToken(token, client);
            try
            {
                db.RefreshTokens.Add(jwtToken);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static Client? ContainsToken(string token)
        {
            var strtoken = db.RefreshTokens.Include(r => r.Client)
           .FirstOrDefault(a => a.Token == token);
            if (strtoken is null) return null;
            db.RefreshTokens.Remove(strtoken);
            return strtoken.Client;
        }
    }
}
