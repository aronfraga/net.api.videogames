using Microsoft.EntityFrameworkCore;
using videogames_api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<VideogamesContext>(conection => conection.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
