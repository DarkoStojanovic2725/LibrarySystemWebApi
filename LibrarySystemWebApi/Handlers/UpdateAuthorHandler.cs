using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Commands;
using LibrarySystem.CQRS.Queries;
using LibrarySystem.CQRS.Responses;
using LibrarySystem.CQRS.Responses.Author;
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

            

            var authorToUpdate = await _authorService.GetAuthorById(request.Id);


            authorToUpdate.FirstName = request.FirstName;
            authorToUpdate.LastName = request.LastName;
            authorToUpdate.ModifiedUtcDateTime = DateTime.Now;

            await _authorService.UpdateAuthor(authorToUpdate);
            return response;
        }
    }
}
