using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySystem.CQRS.Queries.Book;
using LibrarySystem.CQRS.Responses.Book;
using LibrarySystem.Service.Services;
using LibrarySystemWebApi.Exceptions;
using MediatR;

namespace LibrarySystemWebApi.Handlers.Book
{
    public class GetBookHandler : IRequestHandler<GetBookQuery, GetBookResponse>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public GetBookHandler(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public async Task<GetBookResponse> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetBookById(request.Id);

            return book != null
                ? _mapper.Map<GetBookResponse>(book)
                : throw new RestException(HttpStatusCode.NotFound, "Book not found");
        }
    }
}
