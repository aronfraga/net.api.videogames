using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Reflection.Emit;
using videogames_api.Models;

namespace videogames_api.Models {
    public class VideogamesContext : DbContext {

        public VideogamesContext(DbContextOptions<VideogamesContext> options) : base(options){
        }

        public DbSet<Videogame> Videogames { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Videogame>()
                        .HasMany<Genre>(data => data.Genres)
                        .WithMany(data => data.Videogames);
            modelBuilder.Entity<Videogame>()
                        .HasMany<Platform>(data => data.Platforms)
                        .WithMany(data => data.Videogames);
            base.OnModelCreating(modelBuilder);
        }
    }
}


