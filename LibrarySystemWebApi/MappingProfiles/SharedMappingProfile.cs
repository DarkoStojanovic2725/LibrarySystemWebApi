using AutoMapper;
using LibrarySystem.CQRS.Commands.Author;
using LibrarySystem.CQRS.Commands.Book;
using LibrarySystem.CQRS.Responses.Author;
using LibrarySystem.CQRS.Responses.Book;
using LibrarySystemWebApi.Models;

namespace LibrarySystemWebApi.MappingProfiles
{
    public class SharedMappingProfile : Profile
    {
        public SharedMappingProfile()
        { 
            CreateMap<Author, GetAuthorResponse>();
            CreateMap<UpdateAuthorCommand, Author>();
            CreateMap<AddAuthorCommand, Author>();
            CreateMap<Book, GetBookResponse>().ForMember(t => t.Author, 
                opt => 
                    opt.MapFrom(c => $"{c.Author.FirstName} {c.Author.LastName}"));
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<AddBookCommand, Book>();
        }
    }
}
