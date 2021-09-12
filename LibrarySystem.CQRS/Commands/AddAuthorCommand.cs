using System;
using System.Collections.Generic;
using System.Text;
using LibrarySystem.CQRS.Responses;
using LibrarySystem.CQRS.Responses.Author;
using MediatR;

namespace LibrarySystem.CQRS.Commands
{
    public class AddAuthorCommand : IRequest<AddAuthorResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
