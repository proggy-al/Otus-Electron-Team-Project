using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GMS.Identity.WebHost.Infrastructure;

public class JwtBearerOptions
{
    public static Action<Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions> GetJwtBearerOptions(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions jwtBearerOptions, IConfiguration configuration, IAuthOptions authOptions)
    {
        return
            jwtBearerOptions =>
            {
                jwtBearerOptions.RequireHttpsMetadata = bool.Parse(configuration.GetSection("Authorization:JwtBearerOptions:RequireHttpsMetadata").Value);
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    // укзывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = bool.Parse(configuration.GetSection("Authorization:JwtBearerOptions:TokenValidationParameters:ValidateIssuer").Value),
                    // строка, представляющая издателя
                    ValidIssuer = authOptions.Issuer,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = bool.Parse(configuration.GetSection("Authorization:JwtBearerOptions:TokenValidationParameters:ValidateAudience").Value),
                    // установка потребителя токена
                    ValidAudience = authOptions.Audience,
                    // будет ли валидироваться время существования
                    ValidateLifetime = bool.Parse(configuration.GetSection("Authorization:JwtBearerOptions:TokenValidationParameters:ValidateLifetime").Value),
                    // установка ключа безопасности
                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = bool.Parse(configuration.GetSection("Authorization:JwtBearerOptions:TokenValidationParameters:ValidateIssuerSigningKey").Value),
                };
            };            
    }

}


