using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Commands.Book;
using LibrarySystem.CQRS.Responses.Book;
using LibrarySystem.CQRS.Shared.Enums;
using LibrarySystemWebApi.Exceptions;
using LibrarySystemWebApi.Services;
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

            if (string.IsNullOrWhiteSpace(request.Title) && string.IsNullOrWhiteSpace(request.Genre))
            {
                throw new RestException(HttpStatusCode.BadRequest, "Values can't be empty");
            }

            if (!string.IsNullOrWhiteSpace(request.Genre))
            {
                var enumValueValid = Enum.TryParse<Genre>(request.Genre, true, out var parsedGenre);

                if (!enumValueValid)
                {
                    throw new RestException(HttpStatusCode.BadRequest, "Enum value doesn't exist");
                }

                bookToUpdate.Genre = parsedGenre;
            }

            bookToUpdate.Title = request.Title;
            bookToUpdate.Description = request.Description;

            bookToUpdate.AuthorId = request.AuthorId;

            bookToUpdate.ModifiedUtcDateTime = DateTime.Now;

            await _bookService.UpdateBook(bookToUpdate);
            return response;
        }
    }
}
