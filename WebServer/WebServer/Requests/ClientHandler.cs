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
    [RequestHandlerPath("/clients")]
    public class ClientHandler : RequestHandler
    {
        [Post("edit")]
        public void EditClient ()
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
            var body = Bind<ClientModel>();
            if (body is null || string.IsNullOrEmpty(body.phone) || string.IsNullOrEmpty(body.firstname) || string.IsNullOrEmpty(body.lastname) || string.IsNullOrEmpty(body.birthdate) ||
                   string.IsNullOrEmpty(body.phone) || string.IsNullOrEmpty(body.email))
            {
                Send(new AnswerModel(false, null, 400, "incorrect request"));
                return;
            }
            bool IsUpdated = false;
            if (client.FirstName != body.firstname) { client.FirstName = body.firstname; IsUpdated = true; }
            if (client.LastName != body.lastname) { client.LastName = body.lastname; IsUpdated = true; }
            if (client.MiddleName != body.middlename) { client.MiddleName = body.middlename; IsUpdated = true; }
            if (client.Email != body.email) { client.Email = body.email; IsUpdated = true; }
            if (client.PhoneNumber != body.phone) { client.PhoneNumber = body.phone; IsUpdated = true; }
            if (client.BirthDate != DateOnly.Parse(body.birthdate)) { client.BirthDate = DateOnly.Parse(body.birthdate); IsUpdated = true; }

            if (IsUpdated)
                client.Update();

            ClientModel clientModel = new ClientModel(Client.FindClientByPhoneNumber(client.PhoneNumber));


                Send(new AnswerModel(true, new { client = clientModel }, null, null));
        }
    }
}
