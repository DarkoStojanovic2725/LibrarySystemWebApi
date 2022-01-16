using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySystem.CQRS.Queries.Author;
using LibrarySystem.CQRS.Responses.Author;
using LibrarySystem.Service.Services;
using LibrarySystemWebApi.Exceptions;
using MediatR;

namespace LibrarySystemWebApi.Handlers.Author
{
    public class GetAuthorHandler : IRequestHandler<GetAuthorQuery, GetAuthorResponse>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public GetAuthorHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<GetAuthorResponse> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorService.GetAuthorById(request.Id);

            return author != null
                ? _mapper.Map<GetAuthorResponse>(author)
                : throw new RestException(HttpStatusCode.NotFound, "Author not found");
        }
    }
}
