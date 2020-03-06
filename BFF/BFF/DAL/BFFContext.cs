using BFF.Models;
using Microsoft.EntityFrameworkCore;

namespace BFF.DAL
{
    public class BFFContext : DbContext
    {
        public DbSet<Oefening> Oefeningen { get; set; }
        public DbSet<Prestatie> Prestaties { get; set; }
    }
}