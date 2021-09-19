using System;
using LibrarySystem.Data.Models.Interfaces;

namespace LibrarySystem.Data.Models
{
    public class Author : IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedUtcDateTime { get; set; }
        public DateTime ModifiedUtcDateTime { get; set; }
    }
}