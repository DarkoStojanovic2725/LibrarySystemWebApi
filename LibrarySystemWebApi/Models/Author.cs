using System;
using System.ComponentModel.DataAnnotations;
using LibrarySystemWebApi.Models.Interfaces;

namespace LibrarySystemWebApi.Models
{
    public class Author : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedUtcDateTime { get; set; }
        public DateTime ModifiedUtcDateTime { get; set; }
    }
}