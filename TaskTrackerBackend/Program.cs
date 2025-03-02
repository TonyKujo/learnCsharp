using Microsoft.EntityFrameworkCore;
using TaskTrackerBackend.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
