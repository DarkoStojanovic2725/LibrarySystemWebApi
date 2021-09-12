using LibrarySystem.CQRS.Responses.Author;
using MediatR;

namespace LibrarySystem.CQRS.Queries
{
    public class DeleteAuthorQuery : IRequest<DeleteAuthorResponse>
    {
        public int Id { get; set; }
    }
}
