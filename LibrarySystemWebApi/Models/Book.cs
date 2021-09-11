using System;
using LibrarySystemWebApi.Enums;
using LibrarySystemWebApi.Models.Interfaces;

namespace LibrarySystemWebApi.Models
{
    public class Book : IEntity<int>
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public DateTime CreatedUtcDateTime { get; set; }
        public DateTime ModifiedUtcDateTime { get; set; }

        #region Navigation properties

        public Author Author { get; set; }

        #endregion
    }
}
