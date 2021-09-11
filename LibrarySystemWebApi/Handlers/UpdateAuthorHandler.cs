using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Commands;
using LibrarySystem.CQRS.Queries;
using LibrarySystem.CQRS.Responses;
using LibrarySystemWebApi.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, UpdateAuthorResponse>
    {
        private readonly IAuthorService _authorService;

        public UpdateAuthorHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<UpdateAuthorResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateAuthorResponse();

            if (request.Id == 0 && request.Id < 0)
            {
                throw new Exception();
            }

            var authorToUpdate = await _authorService.GetAuthorById(request.Id);

            if (authorToUpdate == null)
            {
                throw new Exception();
            }

            authorToUpdate.FirstName = request.FirstName;
            response.Success = await _authorService.UpdateAuthor(authorToUpdate);
            return response;
        }
    }
}
