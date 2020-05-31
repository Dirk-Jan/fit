using System;
using Microsoft.EntityFrameworkCore;
using PrestatieService.Constants;
using PrestatieService.Models;

namespace PrestatieService.DAL
{
    public class PrestatieContext : DbContext
    {
        public PrestatieContext() {}
        public PrestatieContext(DbContextOptions<PrestatieContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // It is necessary to be defined here to work with EF migrations, even though it is already defined in the Startup.cs
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
            }
        }

        public DbSet<Prestatie> Prestaties { get; set; }
    }
}