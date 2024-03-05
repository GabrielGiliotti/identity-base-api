using Microsoft.EntityFrameworkCore;
using identity_base_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace identity_base_api.Infrastructure.Database;

public class Context : IdentityDbContext<User>
{
    public Context(DbContextOptions<Context> opts) : base(opts) {}
}
