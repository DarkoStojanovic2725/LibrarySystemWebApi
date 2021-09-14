using LibrarySystem.CQRS.Responses.Book;
using MediatR;

namespace LibrarySystem.CQRS.Queries.Book
{
    public class DeleteBookQuery : IRequest<DeleteBookResponse>
    {
        public int Id { get; set; }
    }
}
