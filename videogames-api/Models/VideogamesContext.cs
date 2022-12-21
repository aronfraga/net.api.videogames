using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace videogames_api.Models;

public partial class VideogamesContext : DbContext
{
    public VideogamesContext()
    {
    }

    public VideogamesContext(DbContextOptions<VideogamesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Videogame> Videogames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.IdGenre).HasName("PK__genre__C58C06763C8C8440");

            entity.ToTable("genre");

            entity.Property(e => e.IdGenre).HasColumnName("idGenre");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.IdPlatforms).HasName("PK__platform__EC1EDCC7D77C0753");

            entity.ToTable("platforms");

            entity.Property(e => e.IdPlatforms).HasColumnName("idPlatforms");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Videogame>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__videogam__3213E83F5FCB9D3A");

            entity.ToTable("videogame");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Genre).HasColumnName("genre");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Platforms).HasColumnName("platforms");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReleaseDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("release_date");

            entity.HasOne(d => d.GenreNavigation).WithMany(p => p.Videogames)
                .HasForeignKey(d => d.Genre)
                .HasConstraintName("FK_IDGENRE");

            entity.HasOne(d => d.PlatformsNavigation).WithMany(p => p.Videogames)
                .HasForeignKey(d => d.Platforms)
                .HasConstraintName("FK_IDPLATFORMS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
