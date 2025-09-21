using Microsoft.EntityFrameworkCore;
using OlympicMedalsAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// SQLite database configuration
builder.Services.AddDbContext<OlympicContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("OlympicDb") 
        ?? "Data Source=olympicmedals.db"));

// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure database is created and migrations applied
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OlympicContext>();
    db.Database.Migrate();
}

// Enable Swagger for all environments and make it accessible at root
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OlympicMedalsAPI v1");
    c.RoutePrefix = string.Empty; // Swagger will open at https://<your-app>.azurewebsites.net/
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
