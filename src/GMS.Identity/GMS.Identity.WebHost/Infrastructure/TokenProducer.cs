using JWTAuthManager;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GMS.Identity.WebHost.Infrastructure;

public static class TokenProducer
{
    public static string GetJWTToken(IEnumerable<Claim> inedtityClaims, IAuthOptions authOptions)
    {
        var now = DateTime.UtcNow;
        
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
                issuer: authOptions.Issuer,
                audience: authOptions.Audience,
                notBefore: now,
                claims: inedtityClaims,
                expires: now.Add(TimeSpan.FromMinutes(authOptions.LifeTime)),
                signingCredentials: new SigningCredentials(authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }
}
