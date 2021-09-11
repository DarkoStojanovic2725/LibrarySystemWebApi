using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystemWebApi.Models;
using LibrarySystemWebApi.Repository;

namespace LibrarySystemWebApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ILibraryRepository _repository;

        public AuthorService(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _repository.GetFirstAsync<Author>(t => t.Id == id);
        }

        public async Task<bool> UpdateAuthor(Author author)
        {
            var result = await _repository.UpdateAsync(author);
            return result > 0;
        }
    }
}
