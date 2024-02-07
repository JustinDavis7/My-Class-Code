using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HW4.Models
{
    public partial class ToDoDbContext : DbContext
    {
        public ToDoDbContext()
        {
        }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompletedTask> CompletedTasks { get; set; } = null!;
        public virtual DbSet<ItemTask> ItemTasks { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<ToDoItem> ToDoItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ToDoConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompletedTask>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CompletedTasks)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("CTask_Fk_Person");
            });

            modelBuilder.Entity<ItemTask>(entity =>
            {
                entity.HasOne(d => d.Completed)
                    .WithMany(p => p.ItemTasks)
                    .HasForeignKey(d => d.CompletedId)
                    .HasConstraintName("ITask_Fk_Completed");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemTasks)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("ITask_Fk_Item");
            });

            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ToDoItems)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("Item_Fk_Person");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
