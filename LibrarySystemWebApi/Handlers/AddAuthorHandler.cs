using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySystem.CQRS.Commands;
using LibrarySystem.CQRS.Responses.Author;
using LibrarySystemWebApi.Exceptions;
using LibrarySystemWebApi.Models;
using LibrarySystemWebApi.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers
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

            var author = _mapper.Map<Author>(request);

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