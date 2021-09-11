using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Queries;
using LibrarySystem.CQRS.Responses;
using LibrarySystemWebApi.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers
{
    public class GetAuthorHandler : IRequestHandler<GetAuthorQuery, GetAuthorResponse>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<GetAuthorResponse> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = new GetAuthorResponse();
            var authorResponse = await _authorService.GetAuthorById(request.Id);
            author.Id = authorResponse.Id;
            author.FirstName = authorResponse.FirstName;
            //null check
            return author;
        }
    }
}
