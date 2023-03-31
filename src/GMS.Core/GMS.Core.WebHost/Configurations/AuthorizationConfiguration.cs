using JWTAuthManager;
using System.Security.Claims;

namespace GMS.Core.WebHost.Configurations
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection AddAuthorizationGMS(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy("GymOwner", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, nameof(Priviliges.GYMOwner)));
                });

                options.AddPolicy("Administrator", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, nameof(Priviliges.GYMOwner))
                                               || x.User.HasClaim(ClaimTypes.Role, nameof(Priviliges.Administrator)));
                });

                options.AddPolicy("Manager", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, nameof(Priviliges.GYMOwner))
                                               || x.User.HasClaim(ClaimTypes.Role, nameof(Priviliges.Administrator))
                                               || x.User.HasClaim(ClaimTypes.Role, nameof(Priviliges.Manager)));
                });

                options.AddPolicy("Trainer", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, nameof(Priviliges.Coach)));
                });

                options.AddPolicy("User", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, nameof(Priviliges.User)));
                });
            });

            return serviceCollection;
        }
    }
}
