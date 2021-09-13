using LibrarySystem.CQRS.Responses.Book;
using MediatR;

namespace LibrarySystem.CQRS.Commands.Book
{
    public class AddBookCommand : IRequest<AddBookResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
    }
}