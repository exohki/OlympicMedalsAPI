using Microsoft.EntityFrameworkCore;
using OlympicMedalsApi.Models;


namespace OlympicMedalsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Medal> Medals { get; set; }
    }
}