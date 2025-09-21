using Microsoft.EntityFrameworkCore;
using OlympicMedalsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OlympicContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("OlympicDb") 
        ?? "Data Source=olympicmedals.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OlympicContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment() || true) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
