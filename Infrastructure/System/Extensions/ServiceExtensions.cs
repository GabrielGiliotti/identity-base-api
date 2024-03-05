using Microsoft.EntityFrameworkCore;
using identity_base_api.Infrastructure.Database;
using identity_base_api.Models;
using identity_base_api.Repositories;
using identity_base_api.Services;

namespace identity_base_api.Infrastructure.System.Extensions;

public static class ServiceExtensions
{
    public static void AddRepositoriesExtension(this IServiceCollection services, string connection)
    {
        // Database
        services.AddDbContext<Context>(opts => 
            opts.UseMySql(connection, ServerVersion.AutoDetect(connection)));
        
        services.AddScoped<IUnitOfwork, UnitOfwork>();
        
        // Repositories
        services.AddScoped<IRepository<User>, Repository<User>>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Services
        services.AddScoped<IUserService, UserService>();
    }
}