using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySystemWebApi.Models;
using LibrarySystemWebApi.Repository;

namespace LibrarySystemWebApi.Services
{
    public class BookService : IBookService
    {
        private readonly ILibraryRepository _repository;

        public BookService(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _repository.GetFirstAsync<Book>(t => t.Id == id, includeExpression: t => t.Author);
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var result = await _repository.UpdateAsync(book);
            return result > 0;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _repository.GetListAsync<Book>(includeExpression: t => t.Author);
        }

        public async Task<int> AddBook(Book book)
        {
            return await _repository.AddAsync(book);
        }

        public async Task<int> DeleteBook(Book book)
        {
            return await _repository.DeleteAsync(book);
        }
    }
}
