﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySystemWebApi.Models;

namespace LibrarySystemWebApi.Services
{
    public interface IAuthorService
    {
        Task<Author> GetAuthorById(int id);
        Task<bool> UpdateAuthor(Author author);
        Task<List<Author>> GetAllAuthors();
        Task<int> AddAuthor(Author author);
        Task<int> DeleteAuthor(Author author);
    }
}