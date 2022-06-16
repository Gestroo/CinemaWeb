using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using Trivial.Security;
using CinemaLibrary.Entity;
using WebServer.Models;

namespace WebServer.Requests;

[RequestHandlerPath("/auth")]
public class AuthHandler : RequestHandler
{
    private (string, string) GenerateToken(Client client)
    {
        var model = new JsonWebTokenPayload
        {
            Id = Guid.NewGuid().ToString("n"),
            Issuer = $"{client.PhoneNumber}",
            Expiration = DateTime.Now + new TimeSpan(1, 0, 0)
        };
        var refreshModel = new JsonWebTokenPayload
        {
            Id = Guid.NewGuid().ToString("n"),
            Issuer = $"{client.Email}",
            IssuedAt = DateTime.Now
        };
        var jwt = new JsonWebToken<JsonWebTokenPayload>(model, Program.Sign);
        var refreshjwt = new JsonWebToken<JsonWebTokenPayload>(refreshModel, Program.Sign);
        RefreshToken.AddToken(refreshjwt.ToEncodedString(), client);
        return (jwt.ToEncodedString(), refreshjwt.ToEncodedString());
    }

    private (string, string) RefreshTokenCheck(string token)
    {
        var client = RefreshToken.ContainsToken(token);
        return client is null ? ("", "") : GenerateToken(client);
    }

    [Post("/signin")]
    public void LoginUser()
    {
        var body = Bind<AuthModel>();
        if (body is null || string.IsNullOrEmpty(body.phone) || string.IsNullOrEmpty(body.password))
        {
            Send(new AnswerModel(false, null, 400, "incorrect request"));
            return;
        }

        var client = Client.GetClientAuth(body.phone, body.password);
        if (client is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request body"));
            return;
        }

        var tokens = GenerateToken(client);
        Send(new AnswerModel(true, new { access_token = tokens.Item1, refresh_token = tokens.Item2, user = new ClientModel(client.ID, client.BirthDate.ToShortDateString(), client.LastName, client.FirstName, client.MiddleName, client.PhoneNumber, client.Email) }, null, null));
    }

    [Post("/signup")]
    public void RegisterUser()
    {
        var body = Bind<RegModel>();
        if (RegModel.Check(body))
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        var client = new Client(body.lastname, body.firstname, body.middlename == "" ? null : body.middlename, body.phone, DateOnly.Parse( body.birthdate)) {
            Email = body.email,
            Password = body.password
        };
        if (!Client.Add(client))
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }
        var tokens = GenerateToken(client);
        Send(new AnswerModel(true, new { access_token = tokens.Item1, refresh_token = tokens.Item2, user = new ClientModel(client.ID, client.BirthDate.ToShortDateString(), client.LastName,client.FirstName,client.MiddleName,client.PhoneNumber,client.Email) }, null, null));
    }

    [Get("/reauth")]
    public void ReAuthUser()
    {
        if (!Params.TryGetValue("token", out var token))
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        var tokens = RefreshTokenCheck(token);
        if (string.IsNullOrEmpty(tokens.Item1) || string.IsNullOrEmpty(tokens.Item2))
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }
        Send(new AnswerModel(true, new { access_token = tokens.Item1, refresh_token = tokens.Item2 }, null, null));
    }
}