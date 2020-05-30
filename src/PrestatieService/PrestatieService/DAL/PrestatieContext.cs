using Microsoft.EntityFrameworkCore;
using PrestatieService.Models;

namespace PrestatieService.DAL
{
    public class PrestatieContext : DbContext
    {
        public PrestatieContext(DbContextOptions<PrestatieContext> options) : base(options) { }

        public DbSet<Prestatie> Prestaties { get; set; }
    }
}