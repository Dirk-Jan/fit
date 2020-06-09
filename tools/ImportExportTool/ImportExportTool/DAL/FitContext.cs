using System;
using ImportExportTool.Models;
using Microsoft.EntityFrameworkCore;

namespace ImportExportTool.DAL
{
    public class FitContext : DbContext
    {
        public FitContext() {}
        public FitContext(DbContextOptions<FitContext> options) : base(options) {}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            }
        }

        public DbSet<Oefening> Oefeningen { get; set; }
        public DbSet<Prestatie> Prestaties { get; set; }
    }
}