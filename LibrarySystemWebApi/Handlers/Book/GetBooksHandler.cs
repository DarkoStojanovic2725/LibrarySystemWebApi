using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySystem.CQRS.Queries.Book;
using LibrarySystem.CQRS.Responses.Book;
using LibrarySystem.Service.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers.Book
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, List<GetBookResponse>>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public GetBooksHandler(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public async Task<List<GetBookResponse>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookService.GetAllBooks();

            var response = new List<GetBookResponse>();

            if (books != null)
            {
                response = _mapper.Map<List<GetBookResponse>>(books);
            }

            return response;
        }
    }
}
