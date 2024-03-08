using Microsoft.EntityFrameworkCore;
using identity_base_api.Infrastructure.Database;
using identity_base_api.Repositories;
using identity_base_api.Services;
using identity_base_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace identity_base_api.Infrastructure.System.Extensions;

public static class ServiceExtension
{
    public static  SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Spi9wavAp0lyanlbRidred3sPe8hUf?u"));

    public static void AddRepositoriesExtension(this IServiceCollection services, string connection)
    {
        // Database
        services.AddDbContext<Context>(opts => {
            opts.UseMySql(connection, ServerVersion.AutoDetect(connection));
        });

        services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders();

        services.AddSingleton<IAuthorizationHandler, AdminAuthorizationExtension>();

        // Repositories
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
    }
}