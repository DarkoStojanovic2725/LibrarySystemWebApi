using System;

namespace LibrarySystem.CQRS.Responses.Book
{
    public class GetBookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Genre { get; set; }
        public string Author { get; set; }
        public DateTime ModifiedUtcDateTime { get; set; }
    }
}