using identity_base_api.Infrastructure.System.Extensions;
using identity_base_api.Infrastructure.System.Middlewares;
using identity_base_api.Infrastructure.System.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = builder.Configuration.GetSection("Settings").Get<Settings>()!;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddRepositoriesExtension(settings.ConnectionString);

builder.Services
    .AddAuthentication(opts => {
        opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opts => {
        opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters 
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = ServiceExtension.key,
            ValidateAudience = false,
            ValidateIssuer = false,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization(opts => {
    opts.AddPolicy("MinAge", policy =>
        policy.Requirements.Add(new AgeRequirement(18)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
