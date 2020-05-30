using Microsoft.EntityFrameworkCore;
using OefeningService.Models;

namespace OefeningService.DAL
{
    public class OefeningContext : DbContext
    {
        public OefeningContext(DbContextOptions<OefeningContext> options) : base(options) { }

        public DbSet<Oefening> Oefeningen { get; set; }
    }
}