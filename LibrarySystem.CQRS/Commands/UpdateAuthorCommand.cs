using System;
using System.Collections.Generic;
using System.Text;
using LibrarySystem.CQRS.Responses;
using MediatR;

namespace LibrarySystem.CQRS.Commands
{
    public class UpdateAuthorCommand : IRequest<UpdateAuthorResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
}
