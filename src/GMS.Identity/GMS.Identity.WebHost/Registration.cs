using AutoMapper;
using FluentValidation;
using GMS.Identity.Client.Models;
using GMS.Identity.Client.Validators;
using GMS.Identity.Core.Abstractions.Repositories;
using GMS.Identity.DataAccess.Context;
using GMS.Identity.DataAccess.Repositories;
using GMS.Identity.WebHost.Configuration;
using GMS.Identity.WebHost.Infrastructure;
using JWTAuthManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GMS.Identity.WebHost;

public static class Registration
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(SwaggerOptions.SwaggerGenOptions(new SwaggerGenOptions(), configuration));

        services.AddDbContext<IdentityContext>(options => { options.UseLazyLoadingProxies().EnableSensitiveDataLogging().UseSqlite("Data Source = Application.db"); });
        // services.AddDbContext<IdentityContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("ModuleDatabase"), x => x.MigrationsHistoryTable("__MigrationHistory", "identity")));
        //var mapperConfig = new MapperConfiguration(mc =>
        //{
        //    mc.AddProfile(new MappingProfile());
        //});
        //IMapper mapper = mapperConfig.CreateMapper();
        //services.AddSingleton(mapper);
        services.ConfigureMapper();

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICoachRepository, CoachRepository>();
        //services.AddScoped<IValidator<UserCreateApiModel>, UserCreateValidator>();
        services.AddValidatorsFromAssemblyContaining<UserCreateValidator>();

        //Добавляем авторизацию
        services.AddCustomJWTAuthentification();
        //IAuthOptions authOptions = new AuthOptions(configuration);
        //services.AddSingleton(authOptions);
        //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //            .AddJwtBearer(Infrastructure.JwtBearerOptions.GetJwtBearerOptions(new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions(), configuration, authOptions));


        //При старте приложения запускаем миграции
        using var serviceProvider = services.BuildServiceProvider();
        using var context = serviceProvider.GetRequiredService<IdentityContext>();
        context.Database.Migrate();
    }
}
