using LibrarySystem.CQRS.Responses.Author;
using MediatR;

namespace LibrarySystem.CQRS.Queries.Author
{
    public class GetAuthorQuery : IRequest<GetAuthorResponse>
    {
        public int Id { get; set; }
    }
}
