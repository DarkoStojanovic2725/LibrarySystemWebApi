using System;
using LibrarySystem.Data.Enums;
using LibrarySystem.Data.Models;
using LibrarySystem.Repository.Repository;

namespace LibrarySystemWebApi.DataSeed
{
    public class DataSeeder : IDataSeeder
    {
        private readonly ILibraryRepository _repository;

        public DataSeeder(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public void SeedData()
        {
            var author1 = new Author
            {
                FirstName = "William",
                LastName = "Shakespeare",
                CreatedUtcDateTime = DateTime.Now,
                ModifiedUtcDateTime = DateTime.Now
            };

            var author2 = new Author
            {
                FirstName = "Franz",
                LastName = "Kafka",
                CreatedUtcDateTime = DateTime.Now,
                ModifiedUtcDateTime = DateTime.Now
            };

            var author3 = new Author
            {
                FirstName = "Mark",
                LastName = "Twain",
                CreatedUtcDateTime = DateTime.Now,
                ModifiedUtcDateTime = DateTime.Now
            };

            _repository.Add(author1);
            _repository.Add(author2);
            _repository.Add(author3);

            var book1 = new Book
            {
                AuthorId = author1.Id,
                CreatedUtcDateTime = DateTime.Now,
                ModifiedUtcDateTime = DateTime.Now,
                Title = "Hamlet",
                Description = "Hamlet is a tragedy written by William Shakespeare sometime between 1599 and 1601",
                Genre = Genre.Tragedy
            };

            var book2 = new Book
            {
                AuthorId = author1.Id,
                CreatedUtcDateTime = DateTime.Now,
                ModifiedUtcDateTime = DateTime.Now,
                Title = "Romeo and Juliet",
                Description = "Romeo and Juliet is a tragedy about two young Italian star-crossed lovers whose deaths...",
                Genre = Genre.Tragedy
            }; 
            
            var book3 = new Book
            {
                AuthorId = author2.Id,
                CreatedUtcDateTime = DateTime.Now,
                ModifiedUtcDateTime = DateTime.Now,
                Title = "The Trial",
                Description = "The Trial (German: Der Process) is a novel written by Franz Kafka between 1914 and 1915...",
                Genre = Genre.ScienceFiction
            };

            var book4 = new Book
            {
                AuthorId = author3.Id,
                CreatedUtcDateTime = DateTime.Now,
                ModifiedUtcDateTime = DateTime.Now,
                Title = "The Adventures of Tom Sawyer",
                Description = "The Adventures of Tom Sawyer is an 1876 novel by Mark Twain about a boy growing up along the Mississippi River.",
                Genre = Genre.Satire
            };

            var book5 = new Book
            {
                AuthorId = author2.Id,
                CreatedUtcDateTime = DateTime.Now,
                ModifiedUtcDateTime = DateTime.Now,
                Title = "The Metamorphosis",
                Description = "One of Kafka's best-known works, Metamorphosis tells the story of salesman Gregor Samsa, who wakes one morning...",
                Genre = Genre.ScienceFiction
            };

            _repository.Add(book1);
            _repository.Add(book2);
            _repository.Add(book3);
            _repository.Add(book4);
            _repository.Add(book5);
        }
    }
}
