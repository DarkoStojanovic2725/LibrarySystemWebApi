using LibrarySystem.CQRS.Responses.Book;
using LibrarySystem.CQRS.Shared.Enums;
using MediatR;

namespace LibrarySystem.CQRS.Commands.Book
{
    public class AddBookCommand : IRequest<AddBookResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
    }
}