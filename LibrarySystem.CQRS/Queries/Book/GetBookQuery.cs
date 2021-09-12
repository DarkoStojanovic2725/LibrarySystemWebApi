using LibrarySystem.CQRS.Responses.Book;
using MediatR;

namespace LibrarySystem.CQRS.Queries.Book
{
    public class GetBookQuery : IRequest<GetBookResponse>
    {
        public int Id { get; set; }
    }
}
