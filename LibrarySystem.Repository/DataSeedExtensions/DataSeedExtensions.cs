using System;
using LibrarySystem.Data.Enums;
using LibrarySystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository.DataSeedExtensions
{
    public static class DataSeedExtensions
    {
        public static void PopulateInitialData(this ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "William",
                    LastName = "Shakespeare",
                    CreatedUtcDateTime = DateTime.Now,
                    ModifiedUtcDateTime = DateTime.Now
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Franz",
                    LastName = "Kafka",
                    CreatedUtcDateTime = DateTime.Now,
                    ModifiedUtcDateTime = DateTime.Now
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Mark",
                    LastName = "Twain",
                    CreatedUtcDateTime = DateTime.Now,
                    ModifiedUtcDateTime = DateTime.Now
                }
            );

            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    CreatedUtcDateTime = DateTime.Now,
                    ModifiedUtcDateTime = DateTime.Now,
                    Title = "Romeo and Juliet",
                    Description = "Romeo and Juliet is a tragedy about two young Italian star-crossed lovers whose deaths...",
                    Genre = Genre.Tragedy,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    CreatedUtcDateTime = DateTime.Now,
                    ModifiedUtcDateTime = DateTime.Now,
                    Title = "The Trial",
                    Description = "The Trial (German: Der Process) is a novel written by Franz Kafka between 1914 and 1915...",
                    Genre = Genre.ScienceFiction,
                    AuthorId = 2
                },
                new Book
                {
                    Id = 3,
                    CreatedUtcDateTime = DateTime.Now,
                    ModifiedUtcDateTime = DateTime.Now,
                    Title = "The Adventures of Tom Sawyer",
                    Description = "The Adventures of Tom Sawyer is an 1876 novel by Mark Twain about a boy growing up along the Mississippi River.",
                    Genre = Genre.Satire,
                    AuthorId = 3
                }
            );
        }
    }
}
