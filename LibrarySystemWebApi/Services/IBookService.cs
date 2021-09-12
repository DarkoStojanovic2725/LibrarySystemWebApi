using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySystemWebApi.Models;

namespace LibrarySystemWebApi.Services
{
    public interface IBookService
    {
        Task<Book> GetBookById(int id);
        Task<bool> UpdateBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<int> AddBook(Book book);
        Task<int> DeleteBook(Book book);
    }
}
