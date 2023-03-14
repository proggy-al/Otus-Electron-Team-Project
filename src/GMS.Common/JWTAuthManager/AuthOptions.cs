using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthManager;

public class AuthOptions:IAuthOptions
{
    public string Issuer { get; set; } = "MyAuthServer"; // издатель токена
    public string Audience { get; set; } = "MyAuthClient"; // потребитель токена
    
    public string Key { get; set; } = "mysupersecret_secretkey!123";   // ключ для шифрации
    public int LifeTime { get; set; } = 525600; // время жизни токена - 1 год в минутах
    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }

    public AuthOptions(IConfiguration configuration)
    {
        Issuer = configuration.GetSection("Authorization:AditionalOptions:ISSUER").Value;
        Audience = configuration.GetSection("Authorization:AditionalOptions:AUDIENCE").Value;
        Key= configuration.GetSection("Authorization:AditionalOptions:KEY").Value;
        LifeTime = int.Parse(configuration.GetSection("Authorization:AditionalOptions:LIFETIME").Value);
    }

}

