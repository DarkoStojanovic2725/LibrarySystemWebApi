using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Commands.Book;
using LibrarySystem.CQRS.Responses.Book;
using LibrarySystem.Service.Services;
using LibrarySystemWebApi.Exceptions;
using MediatR;

namespace LibrarySystemWebApi.Handlers.Book
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, UpdateBookResponse>
    {
        private readonly IBookService _bookService;

        public UpdateBookHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<UpdateBookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateBookResponse();
            
            var bookToUpdate = await _bookService.GetBookById(request.Id);

            if (bookToUpdate == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Book not found");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                throw new RestException(HttpStatusCode.BadRequest, "Value can't be empty");
            }

            bookToUpdate.Title = request.Title;
            bookToUpdate.Description = request.Description;
            bookToUpdate.Genre = request.Genre;
            bookToUpdate.AuthorId = request.AuthorId;

            bookToUpdate.Author = null;

            bookToUpdate.ModifiedUtcDateTime = DateTime.Now;

            await _bookService.UpdateBook(bookToUpdate);
            return response;
        }
    }
}
