﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LibrarySystem.CQRS.Queries;
using LibrarySystem.CQRS.Responses;
using LibrarySystemWebApi.Services;
using MediatR;

namespace LibrarySystemWebApi.Handlers
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
            return _mapper.Map<GetAuthorResponse>(author);
        }
    }
}
