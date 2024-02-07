using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Final.Models
{
    public partial class WCDbContext : DbContext
    {
        public WCDbContext()
        {
        }

        public WCDbContext(DbContextOptions<WCDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<MatchResult> MatchResults { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=WorldCupConnection")
                              .UseLazyLoadingProxies();
            }
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchResult>(entity =>
            {
                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.MatchResultAwayTeams)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MatchResult_Fk_CountryAway");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchResultHomeTeams)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MatchResult_Fk_CountryHome");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasOne(d => d.ClubTeam)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.ClubTeamId)
                    .HasConstraintName("Player_Fk_ClubTeam");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Player_Fk_Country");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Player_Fk_Position");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
