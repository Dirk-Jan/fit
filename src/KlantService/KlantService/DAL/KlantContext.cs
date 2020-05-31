using System;
using KlantService.Constants;
using KlantService.Models;
using Microsoft.EntityFrameworkCore;

namespace KlantService.DAL
{
    public class KlantContext : DbContext
    {
        public KlantContext() {}
        public KlantContext(DbContextOptions<KlantContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // It is necessary to be defined here to work with EF migrations, even though it is already defined in the Startup.cs
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
            }
        }
        
        public DbSet<Klant> Klanten { get; set; }
    }
}