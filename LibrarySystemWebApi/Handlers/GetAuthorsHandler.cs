using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Queries;
using LibrarySystem.CQRS.Responses;
using LibrarySystemWebApi.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers
{
    public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, List<GetAuthorResponse>>
    {
        private readonly IAuthorService _service;

        public GetAuthorsHandler(IAuthorService service)
        {
            _service = service;
        }
        //Dodati automaper
        public Task<List<GetAuthorResponse>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
