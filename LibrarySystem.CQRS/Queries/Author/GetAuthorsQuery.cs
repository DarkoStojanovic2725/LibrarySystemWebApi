using System.Collections.Generic;
using LibrarySystem.CQRS.Responses.Author;
using MediatR;

namespace LibrarySystem.CQRS.Queries.Author
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorResponse>>
    {
    }
}
