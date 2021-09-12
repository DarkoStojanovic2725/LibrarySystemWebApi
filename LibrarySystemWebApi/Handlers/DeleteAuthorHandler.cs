using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Queries;
using LibrarySystem.CQRS.Responses.Author;
using LibrarySystemWebApi.Exceptions;
using LibrarySystemWebApi.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorQuery, DeleteAuthorResponse>
    {
        private readonly IAuthorService _authorService;

        public DeleteAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<DeleteAuthorResponse> Handle(DeleteAuthorQuery request, CancellationToken cancellationToken)
        {
            var response = new DeleteAuthorResponse();

            var authorToDelete = await _authorService.GetAuthorById(request.Id);

            if (authorToDelete == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Author not found");
            }

            var deletedAuthor = await _authorService.DeleteAuthor(authorToDelete);

            response.Successful = deletedAuthor > 0;

            return response;
        }
    }
}
