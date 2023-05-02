using GMS.Communication.Core.Abstractons;
using GMS.Communication.Core.Domain;
using GMS.Communication.DataAccess.Context;
using GMS.Communication.DataAccess.Repository;
using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Mapping;
using GMS.Communication.WebHost.Models;
using JWTAuthManager;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GMS.Communication.WebHost
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CommunicationDb>(options =>
            {
                options.UseSqlite(
                    "Data Source=Communication.db",
                    x => x.MigrationsAssembly("GMS.Communication.DataAccess.Sqlite")
                    );
            });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddSingleton<IUserIdProvider, MyUserProvider>();
            services.AddScoped(typeof(IRepository<GmsMessage>), typeof(EfRepository<GmsMessage>));
            services.AddScoped(typeof(IRepository<TrainingNotification>), typeof(EfRepository<TrainingNotification>));
            services.AddSignalR();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddCustomJWTAuthentification();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }



            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>($"/chatHub");
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
