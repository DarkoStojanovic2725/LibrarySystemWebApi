using LibrarySystem.CQRS.Responses.Author;
using MediatR;

namespace LibrarySystem.CQRS.Commands.Author
{
    public class AddAuthorCommand : IRequest<AddAuthorResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
