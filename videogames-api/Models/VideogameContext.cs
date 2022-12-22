using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Reflection.Emit;
using videogames_api.Models;

namespace videogames_api.Models {
    public class VideogamesContext : DbContext {
        public VideogamesContext(DbContextOptions<VideogamesContext> options) : base(options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Videogame>().HasMany(data => data.Genre)
                                            .WithMany(data => data.Videogame)
                                            .UsingEntity<VideogameGenre>(data => data.HasOne(data => data.Genre)
                                            .WithMany()
                                            .HasForeignKey(data => data.IdGenre),
                                             data => data.HasOne(data => data.Videogame)
                                            .WithMany()
                                            .HasForeignKey(data => data.IdVideogame));
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<VideogameGenre> VideogameGenres { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Platform> Platforms { get; set; }

        public virtual DbSet<Videogame> Videogames { get; set; }
    }
}