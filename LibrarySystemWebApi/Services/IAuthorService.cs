using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystemWebApi.Models;

namespace LibrarySystemWebApi.Services
{
    public interface IAuthorService
    {
        Task<Author> GetAuthorById(int id);
        Task<bool> UpdateAuthor(Author author);
    }
}
