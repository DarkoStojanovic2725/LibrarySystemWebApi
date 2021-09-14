using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySystem.CQRS.Commands.Book;
using LibrarySystem.CQRS.Responses.Book;
using LibrarySystem.CQRS.Shared.Enums;
using LibrarySystemWebApi.Exceptions;
using LibrarySystemWebApi.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers.Book
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, AddBookResponse>
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AddBookHandler(IBookService bookService, IMapper mapper, IAuthorService authorService)
        {
            _bookService = bookService;
            _mapper = mapper;
            _authorService = authorService;
        }

        public async Task<AddBookResponse> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var response = new AddBookResponse();

            if (request != null && string.IsNullOrWhiteSpace(request.Title) /*&& string.IsNullOrWhiteSpace(request.Genre)*/)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Values can't be empty");
            }


            if (request != null)
            {
                var author = await _authorService.GetAuthorById(request.AuthorId);
                
                if (author == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Author doesn't exist");
                }

                //if (!string.IsNullOrWhiteSpace(request.Genre))
                //{
                //    var enumValueValid = Enum.TryParse<Genre>(request.Genre, true, out _);
                //    if (!enumValueValid)
                //    {
                //        throw new RestException(HttpStatusCode.BadRequest, "Enum value doesn't exist");
                //    }
                //}
            }

            var book = _mapper.Map<Models.Book>(request);

            book.CreatedUtcDateTime = DateTime.Now;
            book.ModifiedUtcDateTime = DateTime.Now;

            var addedBook = await _bookService.AddBook(book);

            response.Successful = addedBook > 0;

            return response;
        }
    }
}
