using JWTAuthManager.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JWTAuthManager;

public static class CustomJWTtokenExtension
{
    public static IServiceCollection AddCustomJWTAuthentification(this IServiceCollection services)
    {
        var configOptions = new ConfigurationBuilder().AddJsonFile("identitysettings.json").Build();
        var authOptions = configOptions.GetSection(AuthOptions.Position).Get<AuthOptions>();
        var jwtOptions = configOptions.GetSection(JwtBearerTokenOptions.Position).Get<JwtBearerTokenOptions>();

        services.AddSingleton(authOptions);
        services.AddAuthentication(authOpt =>
        {
            authOpt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authOpt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
                .AddJwtBearer(jwtOpt =>
                {
                    jwtOpt.RequireHttpsMetadata = jwtOptions.RequireHttpsMetadata;
                    jwtOpt.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = jwtOptions.ValidateIssuer,
                        // будет ли валидироваться потребитель токена
                        ValidateAudience = jwtOptions.ValidateAudience,
                        // будет ли валидироваться время существования
                        ValidateLifetime = jwtOptions.ValidateLifetime,
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = jwtOptions.ValidateIssuerSigningKey,
                        // строка, представляющая издателя
                        ValidIssuer = authOptions.Issuer,
                        ValidAudience = authOptions.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Key))
                    };
                });

        return services;
    }
}
