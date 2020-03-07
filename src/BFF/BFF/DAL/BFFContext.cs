using System;
using BFF.Constants;
using BFF.Models;
using Microsoft.EntityFrameworkCore;

namespace BFF.DAL
{
    public class BFFContext : DbContext
    {
        public BFFContext() {}
        public BFFContext(DbContextOptions<BFFContext> options) : base(options) {}

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // base.OnConfiguring(optionsBuilder);
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         // It is necessary to be defined here to work with EF migrations, even though it is already defined in the Startup.cs
        //         optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable(EnvNames.DbConnectionString));
        //     }
        // }

        public DbSet<Oefening> Oefeningen { get; set; }
        public DbSet<Prestatie> Prestaties { get; set; }
    }
}