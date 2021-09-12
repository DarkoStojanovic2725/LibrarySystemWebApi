using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySystem.CQRS.Queries;
using LibrarySystem.CQRS.Responses.Author;
using LibrarySystemWebApi.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers
{
    public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, List<GetAuthorResponse>>
    {
        private readonly IAuthorService _service;
        private readonly IMapper _mapper;

        public GetAuthorsHandler(IAuthorService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<GetAuthorResponse>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _service.GetAllAuthors();

            var response = new List<GetAuthorResponse>();

            if (authors != null)
            {
                response = _mapper.Map<List<GetAuthorResponse>>(authors);
            }

            return response;
        }
    }
}
