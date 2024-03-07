using Microsoft.EntityFrameworkCore;
using identity_base_api.Infrastructure.Database;
using identity_base_api.Repositories;
using identity_base_api.Services;
using identity_base_api.Models;
using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Infrastructure.System.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositoriesExtension(this IServiceCollection services, string connection)
    {
        // Database
        services.AddDbContext<Context>(opts => {
            opts.UseMySql(connection, ServerVersion.AutoDetect(connection));
        });

        services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();
                
        // Repositories
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
    }
}