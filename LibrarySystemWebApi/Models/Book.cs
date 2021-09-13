using System;
using System.ComponentModel.DataAnnotations;
using LibrarySystem.CQRS.Shared.Enums;
using LibrarySystemWebApi.Models.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LibrarySystemWebApi.Models
{
    public class Book : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Genre Genre { get; set; }
        public DateTime CreatedUtcDateTime { get; set; }
        public DateTime ModifiedUtcDateTime { get; set; }

        #region Navigation properties

        public Author Author { get; set; }

        #endregion
    }
}
