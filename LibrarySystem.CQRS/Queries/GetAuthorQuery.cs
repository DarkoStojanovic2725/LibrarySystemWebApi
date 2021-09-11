using LibrarySystem.CQRS.Responses;
using MediatR;

namespace LibrarySystem.CQRS.Queries
{
    public class GetAuthorQuery : IRequest<GetAuthorResponse>
    {
        public int Id { get; set; }
    }
}
