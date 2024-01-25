using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebServer.ASP;

public class Options
{
    public const string Issuer = "Cinema_Web_Server";
    public const string Audience = "Cinema_Web_App";
    private const string Key = "oVKJYivecvudMHCELtNHDmER7Z3ASeXZ6D14vCnXk8zzcFlqemB5S8NMeNwqThmT";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));

    public static readonly SigningCredentials SigningCredentials =
        new(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);


}