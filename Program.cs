using Microsoft.EntityFrameworkCore;
using OlympicMedalsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "olympicmedals.db");

builder.Services.AddDbContext<OlympicContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OlympicContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OlympicMedalsAPI v1");
    c.RoutePrefix = string.Empty; 
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
