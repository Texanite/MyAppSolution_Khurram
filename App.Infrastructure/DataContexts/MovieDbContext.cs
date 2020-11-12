using App.Infrastructure.DataModels;
using App.Infrastructure.DataModels.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.DataContexts
{
    public class MovieDbContext : DbContext
    {
        private const string connectionString = "myconnectionstring";
        public MovieDbContext() { }

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
             : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
               
            }
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieStats> MovieStats { get; set; }
        public DbSet<MoviesRegion> moviesRegions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new MovieStatsConfiguration());
            modelBuilder.ApplyConfiguration(new MovieStatsConfiguration());
        }
    }
}
