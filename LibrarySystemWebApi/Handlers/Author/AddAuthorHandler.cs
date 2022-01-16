using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySystem.CQRS.Commands.Author;
using LibrarySystem.CQRS.Responses.Author;
using LibrarySystem.Service.Services;
using LibrarySystemWebApi.Exceptions;
using MediatR;

namespace LibrarySystemWebApi.Handlers.Author
{
    public class AddAuthorHandler : IRequestHandler<AddAuthorCommand, AddAuthorResponse>
    {
        private readonly IAuthorService _service;
        private readonly IMapper _mapper;

        public AddAuthorHandler(IMapper mapper, IAuthorService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<AddAuthorResponse> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var response = new AddAuthorResponse();

            if (request != null && ValidateString(request.FirstName) && ValidateString(request.LastName))
            {
                throw new RestException(HttpStatusCode.BadRequest, "Values can't be empty");
            }

            var author = _mapper.Map<LibrarySystem.Data.Models.Author>(request);

            author.CreatedUtcDateTime = DateTime.Now;
            author.ModifiedUtcDateTime = DateTime.Now;

            var addedAuthor = await _service.AddAuthor(author);

            response.Successful = addedAuthor > 0;

            return response;
        }

        private bool ValidateString(string propertyName)
        {
            return string.IsNullOrWhiteSpace(propertyName);
        }
    }
}