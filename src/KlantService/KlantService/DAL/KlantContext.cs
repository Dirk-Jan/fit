using KlantService.Models;
using Microsoft.EntityFrameworkCore;

namespace KlantService.DAL
{
    public class KlantContext : DbContext
    {
        public KlantContext(DbContextOptions<KlantContext> options) : base(options) { }

        public DbSet<Klant> Klanten { get; set; }
    }
}