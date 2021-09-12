using LibrarySystem.CQRS.Responses;
using LibrarySystem.CQRS.Responses.Author;
using MediatR;

namespace LibrarySystem.CQRS.Queries
{
    public class GetAuthorQuery : IRequest<GetAuthorResponse>
    {
        public int Id { get; set; }
    }
}
