using System;
using Microsoft.EntityFrameworkCore;
using OefeningService.Constants;
using OefeningService.Models;

namespace OefeningService.DAL
{
    public class OefeningContext : DbContext
    {
        public OefeningContext() {}
        public OefeningContext(DbContextOptions<OefeningContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // It is necessary to be defined here to work with EF migrations, even though it is already defined in the Startup.cs
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
            }
        }
        
        public DbSet<Oefening> Oefeningen { get; set; }
    }
}