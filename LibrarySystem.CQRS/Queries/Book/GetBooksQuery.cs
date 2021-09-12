using System.Collections.Generic;
using LibrarySystem.CQRS.Responses.Book;
using MediatR;

namespace LibrarySystem.CQRS.Queries.Book
{
    public class GetBooksQuery : IRequest<List<GetBookResponse>>
    {
    }
}
