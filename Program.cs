using identity_base_api.Infrastructure.System.Extensions;
using identity_base_api.Infrastructure.System.Middlewares;
using identity_base_api.Infrastructure.System.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = builder.Configuration.GetSection("Settings").Get<Settings>()!;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddRepositoriesExtension(settings.ConnectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
