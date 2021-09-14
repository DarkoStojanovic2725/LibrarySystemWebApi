using LibrarySystem.CQRS.Responses.Book;
using LibrarySystem.CQRS.Shared.Enums;
using MediatR;

namespace LibrarySystem.CQRS.Commands.Book
{
    public class UpdateBookCommand : IRequest<UpdateBookResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
    }
}
