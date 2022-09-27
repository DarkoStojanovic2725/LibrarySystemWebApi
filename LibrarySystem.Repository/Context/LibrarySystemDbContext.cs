using System;
using LibrarySystem.Data.Enums;
using LibrarySystem.Data.Models;
using LibrarySystem.Repository.DataSeedExtensions;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository.Context
{
    public class LibrarySystemDbContext : DbContext
    {
        public LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(cfg =>
            {
                cfg.HasKey(e => e.Id);

                cfg.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(60);

                cfg.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Book>(cfg =>
            {
                cfg.HasKey(e => e.Id);

                cfg.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                cfg.Property(e => e.AuthorId)
                    .IsRequired();

                cfg.Property(e => e.Genre)
                    .IsRequired();
            });

            modelBuilder.PopulateInitialData();
        }
    }
}
