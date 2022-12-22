using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using videogames_api.Models;

namespace videogames_api.Models {
    public class VideogamesContext : DbContext {
        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Platform> Platforms { get; set; }

        public virtual DbSet<Videogame> Videogames { get; set; }

        public VideogamesContext(DbContextOptions<VideogamesContext> options) : base(options){
        }
    }
}
