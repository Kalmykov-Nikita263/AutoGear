using AutoGear.Identity.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace AutoGear.Identity;

public static class IdentityExtensions
{
    public static IServiceCollection AddAutogearIdentity<TUser, TRole>(this IServiceCollection services) 
        where TUser : IdentityUser
        where TRole : IdentityRole
    {
        services.AddTransient<PasswordHasher>();

        services.AddScoped<UserManager<TUser>>();
        services.AddScoped<RoleManager<TRole>>();
        services.AddScoped<SignInManager<TUser>>();

        return services;
    }
}
