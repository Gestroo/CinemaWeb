using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    private static JwtSecurityToken GetAccessToken(int id)
    {
        return new JwtSecurityToken(issuer: Options.Issuer, audience: Options.Audience,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)), claims: new[] {new Claim("user", id.ToString())},
            signingCredentials: Options.SigningCredentials);
    }

    [HttpPost("login")]
    public IActionResult Login(AuthModel model)
    {
        var client = _authRepository.GetClientAuth(model.phone, model.password);
        if (client is null) return BadRequest("Incorrect login or password");
        var jwt = GetAccessToken(client.ID);
        return Ok(new {AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),User = new ClientModel(client)});
    }

    [HttpPost("register")]
    public IActionResult Registration(RegModel regModel)
    {
        try
        {
            var client = _authRepository.AddNewClient(regModel);
            var jwt = GetAccessToken(client.ID);
            return Ok(new {AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),User = new ClientModel(client)});
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}