using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthManager;

public static class CustomJWTtokenExtension
{
    public static void AddCustomJWTAuthentification(this IServiceCollection services)
    {
        var builder = WebApplication.CreateBuilder();
        builder.Configuration.AddJsonFile(Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),"identitysettings.json"));

        IAuthOptions authOptions = new AuthOptions(builder.Configuration);
        services.AddSingleton(authOptions);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(JwtBearerOptions.GetJwtBearerOptions(new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions(), builder.Configuration, authOptions));
    }
}
