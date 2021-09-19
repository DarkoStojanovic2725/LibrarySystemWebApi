using System;
using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.CQRS.Commands.Author;
using LibrarySystem.CQRS.Responses.Author;
using LibrarySystem.Service.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers.Author
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
