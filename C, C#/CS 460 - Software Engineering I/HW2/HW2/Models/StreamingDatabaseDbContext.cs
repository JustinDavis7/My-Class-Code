using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HW2.Models
{
    public partial class StreamingDatabaseDbContext : DbContext
    {
        public StreamingDatabaseDbContext()
        {
        }

        public StreamingDatabaseDbContext(DbContextOptions<StreamingDatabaseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgeCertification> AgeCertifications { get; set; } = null!;
        public virtual DbSet<Credit> Credits { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<GenreAssignment> GenreAssignments { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<ProductionCountry> ProductionCountries { get; set; } = null!;
        public virtual DbSet<ProductionCountryAssignment> ProductionCountryAssignments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Show> Shows { get; set; } = null!;
        public virtual DbSet<ShowType> ShowTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=StreamingDatabaseConnection");
            }
            optionsBuilder.UseLazyLoadingProxies();    
            // now works for LINQPad
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credit>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Credits)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Credit_Fk_Person");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Credits)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Credit_Fk_Role");

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.Credits)
                    .HasForeignKey(d => d.ShowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Credit_Fk_Show");
            });

            modelBuilder.Entity<GenreAssignment>(entity =>
            {
                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GenreAssignments)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GenreAssignment_Fk_Genre");

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.GenreAssignments)
                    .HasForeignKey(d => d.ShowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GenreAssignment_Fk_Show");
            });

            modelBuilder.Entity<ProductionCountryAssignment>(entity =>
            {
                entity.HasOne(d => d.ProductionCountry)
                    .WithMany(p => p.ProductionCountryAssignments)
                    .HasForeignKey(d => d.ProductionCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProdCountryAssign_Fk_ProductionCountry");

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.ProductionCountryAssignments)
                    .HasForeignKey(d => d.ShowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProdCountryAssign_Fk_Show");
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.HasOne(d => d.AgeCertification)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.AgeCertificationId)
                    .HasConstraintName("Show_Fk_AgeCertification");

                entity.HasOne(d => d.ShowType)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.ShowTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Show_Fk_ShowType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
