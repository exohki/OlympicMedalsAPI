using Microsoft.EntityFrameworkCore;
using OlympicMedalsAPI.Models;

namespace OlympicMedalsAPI.Data
{
    public class OlympicContext : DbContext
    {
        public OlympicContext(DbContextOptions<OlympicContext> options) : base(options) { }
        public DbSet<Country> Countries { get; set; }
    }
}
