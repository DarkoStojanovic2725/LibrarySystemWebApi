using System.Collections.Generic;
using LibrarySystem.CQRS.Responses;
using LibrarySystem.CQRS.Responses.Author;
using MediatR;

namespace LibrarySystem.CQRS.Queries
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorResponse>>
    {
    }
}
