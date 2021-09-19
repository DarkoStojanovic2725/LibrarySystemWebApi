using System.Net;
using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Queries.Book;
using LibrarySystem.CQRS.Responses.Book;
using LibrarySystem.Service.Services;
using LibrarySystemWebApi.Exceptions;
using MediatR;

namespace LibrarySystemWebApi.Handlers.Book
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookQuery, DeleteBookResponse>
    {
        private readonly IBookService _bookService;

        public DeleteBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<DeleteBookResponse> Handle(DeleteBookQuery request, CancellationToken cancellationToken)
        {
            var response = new DeleteBookResponse();

            var bookToDelete = await _bookService.GetBookById(request.Id);

            if (bookToDelete == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Author not found");
            }

            var deletedBook = await _bookService.DeleteBook(bookToDelete);

            response.Successful = deletedBook > 0;

            return response;
        }
    }
}
