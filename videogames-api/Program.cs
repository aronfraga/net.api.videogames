using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using videogames_api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<VideogamesContext>(conection => conection.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var context = scope.ServiceProvider.GetRequiredService<VideogamesContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
