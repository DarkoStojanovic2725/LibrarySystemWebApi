using LibrarySystem.CQRS.Responses.Author;
using MediatR;

namespace LibrarySystem.CQRS.Commands.Author
{
    public class UpdateAuthorCommand : IRequest<UpdateAuthorResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
